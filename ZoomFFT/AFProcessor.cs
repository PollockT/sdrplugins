using SDRSharp.Common;
using SDRSharp.PanView;
using SDRSharp.Radio;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace SDRSharp.Plugin.ZoomFFT
{
    public unsafe class AFProcessor : IRealProcessor
    {
        private const float RBW = 15;
        private const int FFTTimerInterval = 50;
        private const double BandwidthRatio = 1.1;

        private const int DefaultFilterOrder = 510;

        private int _fftBins;
        private UnsafeBuffer _inputBuffer;
        private float* _inputPtr;
        private UnsafeBuffer _fftBuffer;
        private Complex* _fftPtr;
        private UnsafeBuffer _fftWindow;
        private float* _fftWindowPtr;
        private UnsafeBuffer _fftSpectrum;
        private float* _fftSpectrumPtr;
        private UnsafeBuffer _scaledFFTSpectrum;
        private byte* _scaledFFTSpectrumPtr;
        private float _fftCompensation;
        private double _sampleRate;

        private Thread _fftThread;
        private bool _enabled = false;
        private bool _terminated = true;
        private System.Windows.Forms.Timer _fftTimer;
        private SpectrumAnalyzer _spectrumAnalyzer;

        private readonly FloatFifoStream _floatStream = new FloatFifoStream(BlockMode.BlockingRead);
        private readonly SharpEvent _fftEvent = new SharpEvent(false);
        private readonly ISharpControl _control;

        public AFProcessor(ISharpControl control)
        {
            _control = control;
            _control.PropertyChanged += NotifyPropertyChangedHandler;

            #region FFT Timer

            _fftTimer = new System.Windows.Forms.Timer();
            _fftTimer.Tick += fftTimer_Tick;
            _fftTimer.Interval = FFTTimerInterval;

            #endregion

            #region FFT Buffers / Window

            InitFFTBuffers();
            BuildFFTWindow();

            #endregion

            #region Display component

            _spectrumAnalyzer = new SpectrumAnalyzer();
            _spectrumAnalyzer.Dock = DockStyle.Fill;
            _spectrumAnalyzer.Margin = new Padding(0, 0, 0, 0);
            _spectrumAnalyzer.DisplayRange = 100;
            _spectrumAnalyzer.EnableFilter = false;
            _spectrumAnalyzer.EnableHotTracking = false;
            _spectrumAnalyzer.EnableFrequencyMarker = false;
            _spectrumAnalyzer.StepSize = 5000;
            _spectrumAnalyzer.UseSmoothing = true;
            _spectrumAnalyzer.SpectrumWidth = StreamControl.MinAudioSampleRate / 2;
            _spectrumAnalyzer.Frequency = _spectrumAnalyzer.SpectrumWidth / 2;
            _spectrumAnalyzer.CenterFrequency = _spectrumAnalyzer.SpectrumWidth / 2;
            _spectrumAnalyzer.Attack = 0.9f;
            _spectrumAnalyzer.Decay = 0.6f;
            _spectrumAnalyzer.Text = "Audio Spectrum";
            _spectrumAnalyzer.Visible = false;
            _spectrumAnalyzer.FrequencyChanged += spectrumAnalyzer_FrequencyChanged;
            _spectrumAnalyzer.CenterFrequencyChanged += spectrumAnalyzer_CenterFrequencyChanged;
            _spectrumAnalyzer.VisibleChanged += spectrumAnalyzer_VisibleChanged;

            #endregion

            _control.RegisterStreamHook(this, ProcessorType.FilteredAudioOutput);
            _control.RegisterFrontControl(_spectrumAnalyzer, (PluginPosition)Utils.GetIntSetting("zoomPosition", (int)PluginPosition.Bottom));
        }

        private void spectrumAnalyzer_VisibleChanged(object sender, EventArgs e)
        {
            if (_spectrumAnalyzer.Visible)
            {
                if (_enabled && _control.IsPlaying)
                {
                    Start();
                }
            }
            else
            {
                Stop();
            }
            _spectrumAnalyzer.ResetSpectrum();
        }

        public bool DisplayIsVisible => _spectrumAnalyzer.Visible;

        private void spectrumAnalyzer_FrequencyChanged(object sender, FrequencyEventArgs e)
        {
            e.Cancel = true;
        }

        private void spectrumAnalyzer_CenterFrequencyChanged(object sender, FrequencyEventArgs e)
        {
            e.Cancel = true;
        }

        public double SampleRate
        {
            get { return _sampleRate; }
            set
            {
                if (_sampleRate != value)
                {
                    _sampleRate = value;
                    UpdateFFTBins();
                    if (_spectrumAnalyzer.InvokeRequired)
                    {
                        _spectrumAnalyzer.BeginInvoke(new Action(() => ConfigureSpectrumAnalyzer()));
                    }
                    else
                    {
                        ConfigureSpectrumAnalyzer();
                    }
                }
            }
        }

        private void UpdateFFTBins()
        {
            if (_sampleRate == 0)
            {
                return;
            }

            var bins = 1;

            while (bins <= (1 << 16) && _sampleRate / bins > RBW)
            {
                bins <<= 1;
            }

            _fftBins = bins << 1;

            var restart = false;
            if (!_terminated)
            {
                Stop();
                restart = true;
            }

            InitFFTBuffers();
            BuildFFTWindow();

            if (restart)
            {
                Start();
            }
        }

        public UserControl Control
        {
            get { return _spectrumAnalyzer; }
        }

        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
                _spectrumAnalyzer.Visible = _enabled;
            }
        }

        private void UpdateBandwidth()
        {
            switch (_control.DetectorType)
            {
                case DetectorType.WFM:
                    _spectrumAnalyzer.SpectrumWidth = (int)Math.Min(_control.AudioSampleRate * 0.5, Vfo.MaxBCAudioFrequency * BandwidthRatio);
                    break;

                case DetectorType.NFM:
                    _spectrumAnalyzer.SpectrumWidth = (int)Math.Min(_control.AudioSampleRate * 0.5, Vfo.MaxNFMAudioFrequency * BandwidthRatio);
                    break;

                case DetectorType.AM:
                case DetectorType.DSB:
                case DetectorType.RAW:
                    _spectrumAnalyzer.SpectrumWidth = (int)(Math.Min(_control.AudioSampleRate, _control.FilterBandwidth * BandwidthRatio) * 0.5);
                    break;

                case DetectorType.LSB:
                case DetectorType.USB:
                    _spectrumAnalyzer.SpectrumWidth = (int)Math.Min(_control.AudioSampleRate * 0.5, _control.FilterBandwidth * BandwidthRatio);
                    break;

                case DetectorType.CW:
                    _spectrumAnalyzer.SpectrumWidth = (int)Math.Min(_control.AudioSampleRate * 0.5, _control.CWShift * 2);
                    break;
            }
            _spectrumAnalyzer.Frequency = _spectrumAnalyzer.SpectrumWidth / 2;
            _spectrumAnalyzer.CenterFrequency = _spectrumAnalyzer.SpectrumWidth / 2;
        }

        private void NotifyPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "StartRadio":
                    UpdateBandwidth();
                    if (_enabled)
                    {
                        Start();
                    }
                    break;

                case "StopRadio":
                    Stop();
                    break;

                case "SAttack":
                case "SDecay":
                    ConfigureSpectrumAnalyzer();
                    break;

                case "FFTContrast":
                    _spectrumAnalyzer.Contrast = _control.FFTContrast;
                    break;

                case "Gradient":
                    _spectrumAnalyzer.VerticalLinesGradient = _control.Gradient;
                    break;

                case "FFTSpectrumStyle":
                    _spectrumAnalyzer.SpectrumStyle = _control.FFTSpectrumStyle;
                    break;

                case "CWShift":
                case "DetectorType":
                case "FilterBandwidth":
                    UpdateBandwidth();
                    break;
            }
        }

        #region FFT Thread

        private void Start()
        {
            _terminated = false;

            if (_fftThread == null)
            {
                _fftEvent.Reset();
                _floatStream.Open();
                _fftThread = new Thread(ProcessFFT);
                _fftThread.Name = "Zoom FFT AF";
                _fftThread.Start();
            }

            if (_spectrumAnalyzer.InvokeRequired)
            {
                _spectrumAnalyzer.BeginInvoke(new Action(() => { _fftTimer.Enabled = true; }));
            }
            else
            {
                _fftTimer.Enabled = true;
            }
        }

        public void Stop()
        {
            _terminated = true;

            if (_fftThread != null)
            {
                _fftEvent.Set();
                _floatStream.Close();
                _fftThread.Join();
                _fftThread = null;
            }

            if (_spectrumAnalyzer.InvokeRequired)
            {
                _spectrumAnalyzer.BeginInvoke(new Action(() => { _fftTimer.Enabled = false; }));
            }
            else
            {
                _fftTimer.Enabled = false;
            }
        }

        #endregion

        private int _inputBufferLength;

        public void Process(float* buffer, int length)
        {
            if (!_spectrumAnalyzer.Visible || _terminated)
            {
                return;
            }

            _inputBufferLength = length;
            _floatStream.Write(buffer, length);
        }

        #region FFT

        private void ProcessFFT(object parameter)
        {
            while (_control.IsPlaying && !_terminated)
            {
                #region Configure

                var fftRate = _fftBins / (2 * _fftTimer.Interval * 0.001);
                var fftOverlapRatio = _sampleRate / fftRate;
                var samplesToConsume = (int)(_fftBins * fftOverlapRatio);
                var fftSamplesPerFrame = Math.Min(samplesToConsume, _fftBins);
                var excessSamples = samplesToConsume - fftSamplesPerFrame;

                #endregion

                #region Shift data for overlapped mode

                if (fftSamplesPerFrame < _fftBins)
                {
                    Utils.Memcpy(_inputPtr, _inputPtr + fftSamplesPerFrame, (_fftBins - fftSamplesPerFrame) * sizeof(float));
                }

                #endregion

                #region Read IQ data

                var targetLength = fftSamplesPerFrame;

                var total = 0;
                while (_control.IsPlaying && total < targetLength && !_terminated)
                {
                    var len = targetLength - total;
                    total += _floatStream.Read(_inputPtr, _fftBins - targetLength + total, len);
                }

                if (_terminated)
                    break;

                _floatStream.Advance(excessSamples);

                #endregion

                #region Calculate FFT

                for (var i = 0; i < _fftBins / 2; i++)
                {
                    _fftPtr[i] = _inputPtr[i << 1] + _inputPtr[(i << 1) + 1];
                }

                for (var i = _fftBins / 2; i < _fftBins; i++)
                {
                    _fftPtr[i] = 0;
                }
                Fourier.ApplyFFTWindow(_fftPtr, _fftWindowPtr, _fftBins / 2);
                Fourier.ForwardTransform(_fftPtr, _fftBins, true);
                Fourier.SpectrumPower(_fftPtr + _fftBins / 2, _fftSpectrumPtr, _fftBins / 2, _fftCompensation);

                #endregion

                if (fftSamplesPerFrame < _fftBins)
                {
                    var readDelta = _fftBins - fftSamplesPerFrame;
                    while (!_terminated && _floatStream.Length > _inputBufferLength * 2 && _floatStream.Length >= readDelta)
                    {
                        _floatStream.Read(_inputPtr + fftSamplesPerFrame, readDelta);
                    }
                }
                else
                {
                    while (!_terminated && _floatStream.Length > _inputBufferLength * 2 && _floatStream.Length >= _fftBins)
                    {
                        _floatStream.Read(_inputPtr, _fftBins);
                    }
                }

                if (!_terminated)
                {
                    _fftEvent.WaitOne();
                }
            }
            _floatStream.Flush();
        }

        private void BuildFFTWindow()
        {
            var window = FilterBuilder.MakeWindow(WindowType.Youssef, _fftBins / 2);
            fixed (float* windowPtr = window)
            {
                Utils.Memcpy(_fftWindow, windowPtr, _fftBins / 2 * sizeof(float));
            }
            _fftCompensation = FilterBuilder.GetDBFSCompensation(window) + 100;
        }

        private void fftTimer_Tick(object sender, EventArgs e)
        {
            if (_control.IsPlaying && !_terminated && _spectrumAnalyzer.Visible)
            {
                var ratio = _spectrumAnalyzer.SpectrumWidth * 2 / _sampleRate;
                var bins = Math.Min(_fftBins, (int)(_fftBins * ratio)) / 2;
                _spectrumAnalyzer.Render(_fftSpectrumPtr, bins);
                _fftEvent.Set();
            }
        }

        private void InitFFTBuffers()
        {
            _inputBuffer = UnsafeBuffer.Create(_fftBins, sizeof(float));
            _fftBuffer = UnsafeBuffer.Create(_fftBins, sizeof(Complex));
            _fftWindow = UnsafeBuffer.Create(_fftBins, sizeof(float));
            _fftSpectrum = UnsafeBuffer.Create(_fftBins, sizeof(float));
            _scaledFFTSpectrum = UnsafeBuffer.Create(_fftBins, sizeof(byte));

            _inputPtr = (float*)_inputBuffer;
            _fftPtr = (Complex*)_fftBuffer;
            _fftWindowPtr = (float*)_fftWindow;
            _fftSpectrumPtr = (float*)_fftSpectrum;
            _scaledFFTSpectrumPtr = (byte*)_scaledFFTSpectrum;
        }

        #endregion

        #region Display

        private void ConfigureSpectrumAnalyzer()
        {
            _spectrumAnalyzer.Contrast = _control.FFTContrast;
            _spectrumAnalyzer.Attack = _control.SAttack;
            _spectrumAnalyzer.Decay = _control.SDecay;
            _spectrumAnalyzer.VerticalLinesGradient = _control.Gradient;
            _spectrumAnalyzer.SpectrumStyle = _control.FFTSpectrumStyle;
        }

        #endregion
    }
}
