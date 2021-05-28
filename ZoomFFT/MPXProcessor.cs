using SDRSharp.Common;
using SDRSharp.PanView;
using SDRSharp.Radio;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace SDRSharp.Plugin.ZoomFFT
{
    public unsafe class MPXProcessor : IRealProcessor
    {
        private const float RBW = 15;
        private const int FFTTimerInterval = 50;
        private const int MaxMPXBandwidth = 100000;

        private UnsafeBuffer _inputBuffer;
        private UnsafeBuffer _fftBuffer;
        private UnsafeBuffer _fftWindow;
        private UnsafeBuffer _fftSpectrum;
        private UnsafeBuffer _scaledFFTSpectrum;
        private float _fftCompensation;
        private double _sampleRate;
        private bool _enabled;

        private Thread _fftThread;
        private bool _terminated = true;
        private System.Windows.Forms.Timer _fftTimer;
        private SpectrumAnalyzer _spectrumAnalyzer;

        private readonly FloatFifoStream _floatStream = new FloatFifoStream(BlockMode.BlockingRead);
        private readonly SharpEvent _fftEvent = new SharpEvent(false);
        private readonly ISharpControl _control;

        public MPXProcessor(ISharpControl control)
        {
            _control = control;
            _control.PropertyChanged += NotifyPropertyChangedHandler;

            #region FFT Timer

            _fftTimer = new System.Windows.Forms.Timer();
            _fftTimer.Tick += fftTimer_Tick;
            _fftTimer.Interval = FFTTimerInterval;

            #endregion

            #region Display component

            _spectrumAnalyzer = new SpectrumAnalyzer();
            _spectrumAnalyzer.Dock = DockStyle.Fill;
            _spectrumAnalyzer.Margin = new Padding(0, 0, 0, 0);
            _spectrumAnalyzer.DisplayRange = 100;
            _spectrumAnalyzer.EnableFilter = false;
            _spectrumAnalyzer.EnableHotTracking = false;
            _spectrumAnalyzer.EnableFrequencyMarker = false;
            _spectrumAnalyzer.StepSize = 19000;
            _spectrumAnalyzer.UseStepSizeForDisplay = true;
            _spectrumAnalyzer.UseSmoothing = true;
            _spectrumAnalyzer.SpectrumWidth = MaxMPXBandwidth;
            _spectrumAnalyzer.Frequency = _spectrumAnalyzer.SpectrumWidth / 2;
            _spectrumAnalyzer.CenterFrequency = _spectrumAnalyzer.SpectrumWidth / 2;
            _spectrumAnalyzer.Attack = 0.9f;
            _spectrumAnalyzer.Decay = 0.6f;
            _spectrumAnalyzer.Text = "FM MPX Spectrum";
            _spectrumAnalyzer.FrequencyChanged += spectrumAnalyzer_FrequencyChanged;
            _spectrumAnalyzer.CenterFrequencyChanged += spectrumAnalyzer_CenterFrequencyChanged;
            _spectrumAnalyzer.Visible = false;
            _spectrumAnalyzer.VisibleChanged += spectrumAnalyzer_VisibleChanged;

            #endregion

            _control.RegisterStreamHook(this, ProcessorType.FMMPX);
            _control.RegisterFrontControl(_spectrumAnalyzer, (PluginPosition)Utils.GetIntSetting("zoomPosition", (int)PluginPosition.Bottom));
        }

        private void spectrumAnalyzer_VisibleChanged(object sender, EventArgs e)
        {
            if (_spectrumAnalyzer.Visible)
            {
                if (_control.IsPlaying)
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
            bins <<= 1;

            var restart = false;
            if (!_terminated)
            {
                Stop();
                restart = true;
            }

            lock (this)
            {
                InitFFTBuffers(bins);
                BuildFFTWindow(bins);
            }

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
            get { return _enabled; }
            set
            {
                _enabled = value;
                ConfigureSpectrumAnalyzer();
            }
        }

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

        private void NotifyPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "StartRadio":
                    if (Enabled)
                    {
                        Start();
                    }
                    break;

                case "StopRadio":
                    Stop();
                    break;

                case "DetectorType":
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
                _fftThread.Name = "Zoom FFT MPX";
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

            if (_fftThread != null && _fftThread.ThreadState != ThreadState.Unstarted)
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

        #region FFT

        private void ProcessFFT(object parameter)
        {
            while (_control.IsPlaying && !_terminated)
            {
                #region Configure

                UnsafeBuffer inputBuffer;
                UnsafeBuffer fftBuffer;
                UnsafeBuffer fftWindow;
                UnsafeBuffer fftSpectrum;
                UnsafeBuffer scaledFFTSpectrum;

                lock (this)
                {
                    inputBuffer = _inputBuffer;
                    fftBuffer = _fftBuffer;
                    fftWindow = _fftWindow;
                    fftSpectrum = _fftSpectrum;
                    scaledFFTSpectrum = _scaledFFTSpectrum;
                }

                if (inputBuffer == null)
                {
                    continue;
                }

                var inputPtr = (float*)inputBuffer;
                var fftPtr = (Complex*)fftBuffer;
                var fftWindowPtr = (float*)fftWindow;
                var fftSpectrumPtr = (float*)fftSpectrum;
                var scaledFFTSpectrumPtr = (byte*)scaledFFTSpectrum;

                var fftBins = fftBuffer.Length;
                var fftRate = fftBins / (_fftTimer.Interval * 0.001);
                var fftOverlapRatio = _sampleRate / fftRate;
                var samplesToConsume = (int)(fftBins * fftOverlapRatio);
                var fftSamplesPerFrame = Math.Min(samplesToConsume, fftBins);
                var excessSamples = samplesToConsume - fftSamplesPerFrame;

                #endregion

                #region Shift data for overlapped mode)

                if (fftSamplesPerFrame < fftBins)
                {
                    Utils.Memcpy(inputPtr, inputPtr + fftSamplesPerFrame, (fftBins - fftSamplesPerFrame) * sizeof(float));
                }

                #endregion

                #region Read IQ data

                var targetLength = fftSamplesPerFrame;

                var total = 0;
                while (_control.IsPlaying && total < targetLength && !_terminated)
                {
                    var len = targetLength - total;
                    total += _floatStream.Read(inputPtr, fftBins - targetLength + total, len);
                }

                if (_terminated)
                    break;

                _floatStream.Advance(excessSamples);

                #endregion

                #region Calculate FFT

                for (var i = 0; i < fftBins / 2; i++)
                {
                    fftPtr[i] = inputPtr[i];
                }

                for (var i = fftBins / 2; i < fftBins; i++)
                {
                    fftPtr[i] = 0;
                }
                Fourier.ApplyFFTWindow(fftPtr, fftWindowPtr, fftBins / 2);
                Fourier.ForwardTransform(fftPtr, fftBins, true);
                Fourier.SpectrumPower(fftPtr + fftBins / 2, fftSpectrumPtr, fftBins / 2, _fftCompensation + 103);

                #endregion

                if (fftSamplesPerFrame < fftBins)
                {
                    var readDelta = fftBins - fftSamplesPerFrame;
                    while (!_terminated && _floatStream.Length > _inputBufferLength * 2 && _floatStream.Length >= readDelta)
                    {
                        _floatStream.Read(inputPtr + fftSamplesPerFrame, readDelta);
                    }
                }
                else
                {
                    while (!_terminated && _floatStream.Length > _inputBufferLength * 2 && _floatStream.Length >= fftBins)
                    {
                        _floatStream.Read(inputPtr, fftBins);
                    }
                }

                if (!_terminated)
                {
                    _fftEvent.WaitOne();
                }
            }
            _floatStream.Flush();
        }

        private void BuildFFTWindow(int fftBins)
        {
            var window = FilterBuilder.MakeWindow(WindowType.Blackman, fftBins / 2);
            fixed (float* windowPtr = window)
            {
                Utils.Memcpy(_fftWindow, windowPtr, fftBins / 2 * sizeof(float));
            }
            _fftCompensation = FilterBuilder.GetDBFSCompensation(window);
        }

        private void fftTimer_Tick(object sender, EventArgs e)
        {
            if (_control.IsPlaying && _spectrumAnalyzer.Visible && _control.DetectorType == DetectorType.WFM)
            {
                var spectrum = _fftSpectrum;
                var ratio = _spectrumAnalyzer.SpectrumWidth / _sampleRate;
                var bins = Math.Min(spectrum.Length / 2, (int)(spectrum.Length * ratio));
                _spectrumAnalyzer.Render((float*)spectrum, bins);
                GC.KeepAlive(spectrum);
                _fftEvent.Set();
            }
        }

        private void InitFFTBuffers(int fftBins)
        {
            _inputBuffer = UnsafeBuffer.Create(fftBins, sizeof(float));
            _fftBuffer = UnsafeBuffer.Create(fftBins, sizeof(Complex));
            _fftWindow = UnsafeBuffer.Create(fftBins, sizeof(float));
            _fftSpectrum = UnsafeBuffer.Create(fftBins, sizeof(float));
            _scaledFFTSpectrum = UnsafeBuffer.Create(fftBins, sizeof(byte));
        }

        #endregion

        #region Display

        private void ConfigureSpectrumAnalyzer()
        {
            _spectrumAnalyzer.SpectrumWidth = Math.Min(MaxMPXBandwidth, (int)(_sampleRate * 0.5));
            _spectrumAnalyzer.Frequency = _spectrumAnalyzer.SpectrumWidth / 2;
            _spectrumAnalyzer.CenterFrequency = _spectrumAnalyzer.SpectrumWidth / 2;
            _spectrumAnalyzer.Visible = _enabled && _control.DetectorType == DetectorType.WFM;
            _spectrumAnalyzer.Attack = _control.SAttack;
            _spectrumAnalyzer.Decay = _control.SDecay;
            _spectrumAnalyzer.Contrast = _control.FFTContrast;
            _spectrumAnalyzer.VerticalLinesGradient = _control.Gradient;
            _spectrumAnalyzer.SpectrumStyle = _control.FFTSpectrumStyle;
        }

        #endregion
    }
}
