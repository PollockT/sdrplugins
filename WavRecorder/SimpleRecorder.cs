using SDRSharp.Radio;
using System;
using System.Threading;

namespace SDRSharp.Plugin.WavRecorder
{
    public enum RecordingMode
    {
        Baseband,
        Audio,
        RAW
    }

    public unsafe class SimpleRecorder : IDisposable
    {
        private const int DefaultAudioGain = 30;

        private static readonly int _bufferCount = Utils.GetIntSetting("RecordingBufferCount", 8);
        private readonly float _audioGain = (float)Math.Pow(DefaultAudioGain / 10.0, 10);

        private readonly SharpEvent _bufferEvent = new SharpEvent(false);

        private readonly UnsafeBuffer[] _circularBuffers = new UnsafeBuffer[_bufferCount];

        private int _circularBufferTail;
        private int _circularBufferHead;
        private int _circularBufferLength;
        private volatile int _circularBufferUsedCount;

        private long _skippedBuffersCount;
        private bool _diskWriterRunning;
        private bool _unityGain;
        private ushort _channels = 2;
        private string _fileName;
        private double _sampleRate;
        private double _frequencyOffset;

        private WavSampleFormat _wavSampleFormat;
        private SimpleWavWriter _wavWriter;
        private Thread _diskWriter;
        private FrequencyTranslator _iqTranslator;
        private readonly RecordingMode _recordingMode;
        private readonly RecordingBaseBandProcessor _basebandProcessor;
        private readonly RecordingAudioProcessor _audioProcessor;

        public bool IsRecording
        {
            get { return _diskWriterRunning; }
        }

        public bool IsStreamFull
        {
            get { return _wavWriter == null ? false : _wavWriter.IsStreamFull; }
        }

        public long BytesWritten
        {
            get { return _wavWriter == null ? 0L : _wavWriter.Length; }
        }

        public long SkippedBuffers
        {
            get { return _wavWriter == null ? 0L : _skippedBuffersCount; }
        }

        public RecordingMode Mode
        {
            get { return _recordingMode; }
        }

        public WavSampleFormat Format
        {
            get { return _wavSampleFormat; }
            set
            {
                if (_diskWriterRunning)
                {
                    throw new ArgumentException("Format cannot be set while recording");
                }
                _wavSampleFormat = value;
            }
        }

        public double SampleRate
        {
            get { return _sampleRate; }
            set
            {
                if (_diskWriterRunning)
                {
                    throw new ArgumentException("SampleRate cannot be set while recording");
                }

                _sampleRate = value;
            }
        }

        public int FrequencyOffset
        {
            get { return (int)_frequencyOffset; }
            set
            {
                if (_diskWriterRunning)
                {
                    throw new ArgumentException("SampleRate cannot be set while recording");
                }

                _frequencyOffset = value;
            }
        }

        public ushort Channels
        {
            get { return _channels; }
            set
            {
                if (_diskWriterRunning)
                {
                    throw new ArgumentException("SampleRate cannot be set while recording");
                }

                _channels = value;
            }
        }

        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (_diskWriterRunning)
                {
                    throw new ArgumentException("FileName cannot be set while recording");
                }
                _fileName = value;
            }
        }

        public bool UnityGain
        {
            get { return _unityGain; }
            set { _unityGain = value; }
        }

        #region Initialization and Termination

        public SimpleRecorder(RecordingBaseBandProcessor iqProcessor)
        {
            _basebandProcessor = iqProcessor;
            _recordingMode = RecordingMode.Baseband;
        }

        public SimpleRecorder(RecordingAudioProcessor audioProcessor)
        {
            _audioProcessor = audioProcessor;
            _recordingMode = RecordingMode.Audio;
        }

        ~SimpleRecorder()
        {
            Dispose();
        }

        public void Dispose()
        {
            FreeBuffers();
        }

        #endregion

        #region IQ Event Handler

        public void BaseBandDataIn(Complex* buffer, int length)
        {
            #region Buffers

            if (_circularBufferLength != length)
            {
                FreeBuffers();
                CreateBuffers(length);

                _circularBufferTail = 0;
                _circularBufferHead = 0;
            }

            #endregion

            if (_circularBufferUsedCount == _bufferCount)
            {
                _skippedBuffersCount++;
                return;
            }

            var dest = (Complex*)_circularBuffers[_circularBufferHead];

            Utils.Memcpy(dest, buffer, length * sizeof(Complex));

            if (_channels == 2)
            {
                if (_iqTranslator == null || _iqTranslator.SampleRate != _sampleRate || _iqTranslator.Frequency != _frequencyOffset)
                {
                    _iqTranslator = new FrequencyTranslator(_sampleRate);
                    _iqTranslator.Frequency = _frequencyOffset;
                }
                _iqTranslator.Process(dest, length);
            }

            _circularBufferHead++;
            _circularBufferHead &= (_bufferCount - 1);
            _circularBufferUsedCount++;
            _bufferEvent.Set();
        }

        #endregion

        #region Audio Event / Scaling

        public void AudioSamplesIn(float* audio, int length)
        {
            #region Buffers

            var sampleCount = length / 2;
            if (_circularBufferLength != sampleCount)
            {
                FreeBuffers();
                CreateBuffers(sampleCount);

                _circularBufferTail = 0;
                _circularBufferHead = 0;
            }

            #endregion

            if (_circularBufferUsedCount == _bufferCount)
            {
                _skippedBuffersCount++;
                return;
            }

            Utils.Memcpy(_circularBuffers[_circularBufferHead], audio, length * sizeof(float));
            _circularBufferHead++;
            _circularBufferHead &= (_bufferCount - 1);
            _circularBufferUsedCount++;
            _bufferEvent.Set();
        }

        public void ScaleAudio(float* audio, int length)
        {
            if (_unityGain)
            {
                return;
            }

            for (var i = 0; i < length; i++)
            {
                audio[i] *= _audioGain;
            }
        }

        #endregion

        #region Worker Thread

        private void DiskWriterThread()
        {
            if (_recordingMode == RecordingMode.Baseband)
            {
                _basebandProcessor.BaseBandDataReady += BaseBandDataIn;
                _basebandProcessor.Enabled = true;
            }
            else
            {
                _audioProcessor.AudioReady += AudioSamplesIn;
                _audioProcessor.Enabled = true;
            }

            while (_diskWriterRunning && !_wavWriter.IsStreamFull)
            {
                if (_circularBufferTail == _circularBufferHead)
                {
                    _bufferEvent.WaitOne();
                }

                if (_diskWriterRunning && _circularBufferTail != _circularBufferHead)
                {
                    if (_recordingMode == RecordingMode.Audio)
                    {
                        ScaleAudio((float*)_circularBuffers[_circularBufferTail], _circularBuffers[_circularBufferTail].Length * 2);
                    }

                    _wavWriter.Write((float*)_circularBuffers[_circularBufferTail], _circularBuffers[_circularBufferTail].Length);

                    _circularBufferUsedCount--;
                    _circularBufferTail++;
                    _circularBufferTail &= (_bufferCount - 1);
                }
            }

            while (_circularBufferTail != _circularBufferHead)
            {
                if (_circularBuffers[_circularBufferTail] != null)
                {
                    if (_recordingMode == RecordingMode.Audio)
                    {
                        ScaleAudio((float*)_circularBuffers[_circularBufferTail], _circularBuffers[_circularBufferTail].Length * 2);
                    }

                    _wavWriter.Write((float*)_circularBuffers[_circularBufferTail], _circularBuffers[_circularBufferTail].Length);
                }
                _circularBufferTail++;
                _circularBufferTail &= (_bufferCount - 1);
            }

            if (_recordingMode == RecordingMode.Baseband)
            {
                _basebandProcessor.Enabled = false;
                _basebandProcessor.BaseBandDataReady -= BaseBandDataIn;
            }
            else
            {
                _audioProcessor.Enabled = false;
                _audioProcessor.AudioReady -= AudioSamplesIn;
            }

            _diskWriterRunning = false;
        }

        private void Flush()
        {
            if (_wavWriter != null)
            {
                _wavWriter.Close();
            }
        }

        private void CreateBuffers(int size)
        {
            for (var i = 0; i < _bufferCount; i++)
            {
                _circularBuffers[i] = UnsafeBuffer.Create(size, sizeof(Complex));
            }

            _circularBufferLength = size;
        }

        private void FreeBuffers()
        {
            _circularBufferLength = 0;
            var circularBuffers = _circularBuffers;
            if (circularBuffers != null)
            {
                for (var i = 0; i < _bufferCount; i++)
                {
                    if (circularBuffers[i] != null)
                    {
                        circularBuffers[i].Dispose();
                        circularBuffers[i] = null;
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        public void StartRecording()
        {
            if (_diskWriter == null)
            {
                _circularBufferHead = 0;
                _circularBufferTail = 0;

                _skippedBuffersCount = 0;

                _bufferEvent.Reset();

                _wavWriter = new SimpleWavWriter(_fileName, _wavSampleFormat, _channels, (uint)_sampleRate);
                _wavWriter.Open();

                _diskWriter = new Thread(DiskWriterThread);

                _diskWriterRunning = true;
                _diskWriter.Start();
            }
        }

        public void StopRecording()
        {
            _diskWriterRunning = false;

            if (_diskWriter != null)
            {
                _bufferEvent.Set();
                _diskWriter.Join();
            }

            Flush();
            FreeBuffers();

            _diskWriter = null;
            _wavWriter = null;
        }

        #endregion
    }
}
