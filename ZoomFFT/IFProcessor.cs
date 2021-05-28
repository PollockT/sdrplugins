using SDRSharp.Common;
using SDRSharp.PanView;
using SDRSharp.Radio;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace SDRSharp.Plugin.ZoomFFT
{
    public unsafe class IFProcessor : IIQProcessor
    {
        private const float MinRBW = 15;
        private const int FFTTimerInterval = 50;
        private const double BandwidthRatio = 1.1;

        private const int DefaultFilterOrder = 1021;

        private UnsafeBuffer _iqBuffer;
        private UnsafeBuffer _fftBuffer;
        private UnsafeBuffer _fftWindow;
        private UnsafeBuffer _fftSpectrum;
        private float _fftCompensation;
        private double _sampleRate;
        private bool _updateFilter;
        private int _filterbandwidth;
        private int _filterOffset;
        private bool _enabled;
        private bool _enableFilter;
        private bool _renderingComplete;

        private Thread _fftThread;
        private bool _terminated = true;
        private SpectrumAnalyzer _spectrumAnalyzer;

        private readonly float _fftOffset = (float)Utils.GetDoubleSetting("fftOffset", -40.0);
        private readonly ComplexFifoStream _iqStream = new ComplexFifoStream(BlockMode.BlockingRead);
        private readonly ISharpControl _control;

        private ComplexFilter _complexFilter;
        private ComplexDecimator _decimator;
        private UnsafeBuffer _readBuffer;
        private int _maxSamplesToBuffer;

        private static readonly bool _displayBeforeFilter = Utils.GetBooleanSetting("displayBeforeFilter", false);

        public IFProcessor(ISharpControl control)
        {
            _control = control;
            _control.PropertyChanged += NotifyPropertyChangedHandler;

            #region Display component

            _spectrumAnalyzer = new SpectrumAnalyzer();
            _spectrumAnalyzer.Dock = DockStyle.Fill;
            _spectrumAnalyzer.Margin = new Padding(0, 0, 0, 0);
            _spectrumAnalyzer.DisplayRange = 130;
            _spectrumAnalyzer.EnableFilter = false;
            _spectrumAnalyzer.EnableHotTracking = true;
            _spectrumAnalyzer.EnableFilterHotTracking = false;
            _spectrumAnalyzer.UseSimpleHotTracking = true;
            _spectrumAnalyzer.EnableSideFilterResize = true;
            _spectrumAnalyzer.EnableFilterMove = false;
            _spectrumAnalyzer.BandType = BandType.Center;
            _spectrumAnalyzer.StepSize = 1000;
            _spectrumAnalyzer.UseSmoothing = true;
            _spectrumAnalyzer.Attack = 0.9f;
            _spectrumAnalyzer.Decay = 0.8f;
            _spectrumAnalyzer.Text = "IF Spectrum";
            _spectrumAnalyzer.EnableFrequencyMarker = true;
            _spectrumAnalyzer.CenterFrequency = 0;
            _spectrumAnalyzer.Frequency = 0;
            _spectrumAnalyzer.Visible = false;
            _spectrumAnalyzer.FrequencyChanged += spectrumAnalyzer_FrequencyChanged;
            _spectrumAnalyzer.CenterFrequencyChanged += spectrumAnalyzer_CenterFrequencyChanged;
            _spectrumAnalyzer.BandwidthChanged += spectrumAnalyzer_BandwidthChanged;
            _spectrumAnalyzer.VisibleChanged += spectrumAnalyzer_VisibleChanged;

            #endregion

            _control.RegisterStreamHook(this, ProcessorType.DecimatedAndFilteredIQ);
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

        private void spectrumAnalyzer_BandwidthChanged(object sender, BandwidthEventArgs e)
        {
            if (e.Bandwidth > _control.FilterBandwidth)
            {
                e.Cancel = true;
                return;
            }
            _filterbandwidth = e.Bandwidth;
            _filterOffset = e.Offset;
            _updateFilter = true;
        }

        private void spectrumAnalyzer_FrequencyChanged(object sender, FrequencyEventArgs e)
        {
            e.Cancel = true;
        }

        private void spectrumAnalyzer_CenterFrequencyChanged(object sender, FrequencyEventArgs e)
        {
            e.Cancel = true;
            //_control.Frequency += e.Frequency;
        }

        public UserControl Control
        {
            get { return _spectrumAnalyzer; }
        }

        public double SampleRate
        {
            get { return _sampleRate; }
            set
            {
                if (_sampleRate != value)
                {
                    _sampleRate = value;
                    _updateFilter = true;
                    if (_spectrumAnalyzer.InvokeRequired)
                    {
                        _spectrumAnalyzer.BeginInvoke(new Action(() => ConfigureSpectrumAnalyzer(true)));
                    }
                    else
                    {
                        ConfigureSpectrumAnalyzer(true);
                    }
                }
            }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                _spectrumAnalyzer.Visible = value;
                if (_enabled && _control.IsPlaying)
                {
                    Start();
                }
            }
        }

        public bool EnableFilter
        {
            get { return _enableFilter; }
            set
            {
                _enableFilter = value;
                _spectrumAnalyzer.EnableFilter = value;
            }
        }

        public void Process(Complex* buffer, int length)
        {
            if (!_spectrumAnalyzer.Visible || _terminated)
            {
                return;
            }

            _maxSamplesToBuffer = (int)Math.Max(length, Math.Ceiling(_sampleRate * FFTTimerInterval * 0.001));

            if (_displayBeforeFilter)
            {
                _iqStream.Write(buffer, length);
            }

            if (_enableFilter)
            {
                if (_complexFilter == null)
                {
                    var kernel = FilterBuilder.MakeComplexKernel(_sampleRate, DefaultFilterOrder, _filterbandwidth, _filterOffset, WindowType.BlackmanHarris4);
                    _complexFilter = new ComplexFilter(kernel);
                }
                else if (_updateFilter)
                {
                    var kernel = FilterBuilder.MakeComplexKernel(_sampleRate, DefaultFilterOrder, _filterbandwidth, _filterOffset, WindowType.BlackmanHarris4);
                    _complexFilter.SetKernel(kernel);
                    _updateFilter = false;
                }

                _complexFilter.Process(buffer, length);
            }

            if (!_displayBeforeFilter)
            {
                _iqStream.Write(buffer, length);
            }
        }

        private void NotifyPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "StartRadio":
                    if (_enabled)
                    {
                        Start();
                    }
                    break;

                case "StopRadio":
                    Stop();
                    break;

                case "StepSize":
                case "FFTRange":
                case "FFTOffset":
                case "SAttack":
                case "SDecay":
                case "Frequency":
                    ConfigureSpectrumAnalyzer(false);
                    break;

                case "FilterBandwidth":
                case "DetectorType":
                    ConfigureSpectrumAnalyzer(true);
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
            _renderingComplete = true;
            _terminated = false;

            if (_fftThread == null)
            {
                _iqStream.Open();
                _fftThread = new Thread(ProcessFFT);
                _fftThread.Name = "Zoom FFT IF";
                _fftThread.Start();
            }
        }

        public void Stop()
        {
            _terminated = true;

            if (_fftThread != null)
            {
                _iqStream.Close();
                _fftThread.Join();
                _fftThread = null;
            }
        }

        #endregion

        #region FFT

        private void ProcessFFT(object parameter)
        {
            while (_control.IsPlaying && !_terminated)
            {
                if (_spectrumAnalyzer.SpectrumWidth == 0)
                    continue;


                #region Configure

                var decimation = 1;
                var targetWidth = _spectrumAnalyzer.SpectrumWidth * 2 / GetBandwidthFactor();
                while (_sampleRate > decimation * targetWidth)
                {
                    decimation *= 2;
                }

                var bins = 1;
                var width = Math.Max(300, _spectrumAnalyzer.Width);
                while (bins < width || _sampleRate / (decimation * bins) > MinRBW)
                {
                    bins *= 2;
                }

                InitFFTBuffers(bins);

                var minSamplesToConsume = (int)Math.Ceiling(_sampleRate * FFTTimerInterval * 0.001);
                if (_iqStream.Length > _maxSamplesToBuffer)
                {
                    minSamplesToConsume += _iqStream.Length - _maxSamplesToBuffer;
                }

                var samplesToConsume = minSamplesToConsume / decimation * decimation;
                while (samplesToConsume < minSamplesToConsume)
                {
                    samplesToConsume += decimation;
                }

                #endregion

                #region Read IQ data

                if (_readBuffer == null || _readBuffer.Length < samplesToConsume)
                {
                    _readBuffer = UnsafeBuffer.Create(samplesToConsume, sizeof(Complex));
                }

                Thread.Sleep(FFTTimerInterval);
                var total = 0;
                while (_control.IsPlaying && total < samplesToConsume && !_terminated)
                {
                    total += _iqStream.Read((Complex*)_readBuffer, total, samplesToConsume - total);
                }

                if (_spectrumAnalyzer.Width < Waterfall.AxisMargin * 2)
                    continue;

                int len;
                if (decimation > 1)
                {
                    if (_decimator == null || _decimator.DecimationRatio != decimation)
                    {
                        _decimator = new ComplexDecimator(decimation);
                    }
                    len = _decimator.Process((Complex*)_readBuffer, samplesToConsume);
                }
                else
                {
                    _decimator = null;
                    len = Math.Min(samplesToConsume, bins);
                }

                if (len < bins)
                {
                    Utils.Memmove(_iqBuffer, (Complex*)_iqBuffer + len, (bins - len) * sizeof(Complex));
                    Utils.Memcpy((Complex*)_iqBuffer + bins - len, _readBuffer, len * sizeof(Complex));
                }
                else
                {
                    Utils.Memcpy(_iqBuffer, (Complex*)_readBuffer + len - bins, bins * sizeof(Complex));
                }

                if (_terminated)
                    break;

                #endregion

                #region Calculate FFT

                Utils.Memcpy(_fftBuffer, _iqBuffer, bins * sizeof(Complex));
                Fourier.ApplyFFTWindow((Complex*)_fftBuffer, (float*)_fftWindow, bins);
                Fourier.ForwardTransform((Complex*)_fftBuffer, bins);
                Fourier.SpectrumPower((Complex*)_fftBuffer, (float*)_fftSpectrum, bins, _fftCompensation);

                #endregion

                if (_renderingComplete)
                {
                    _renderingComplete = false;
                    _spectrumAnalyzer.BeginInvoke(new Action<UnsafeBuffer, double>(RenderBuffer), _fftSpectrum, _sampleRate / decimation);
                }
            }
            _readBuffer = null;
            _decimator = null;
            _iqStream.Flush();
        }

        private void RenderBuffer(UnsafeBuffer buffer, double bandwidth)
        {
            if (_control.IsPlaying && !_terminated && _spectrumAnalyzer.Visible)
            {
                int bins;
                float* ptr;
                switch (_control.DetectorType)
                {
                    case DetectorType.LSB:
                    case DetectorType.USB:
                        bins = (int)Math.Min(buffer.Length / 2, (double)buffer.Length * _spectrumAnalyzer.SpectrumWidth / bandwidth);
                        ptr = (float*)buffer + buffer.Length / 2 - bins * (_spectrumAnalyzer.SpectrumWidth / 2 - _spectrumAnalyzer.CenterFrequency) / _spectrumAnalyzer.SpectrumWidth;
                        break;

                    default:
                        bins = (int)Math.Min(buffer.Length, (double)buffer.Length * _spectrumAnalyzer.SpectrumWidth / bandwidth);
                        ptr = (float*)buffer + (buffer.Length - bins) / 2;
                        break;
                }
                _spectrumAnalyzer.Render(ptr, bins);
                _renderingComplete = true;
            }
        }

        private void InitFFTBuffers(int bins)
        {
            if (_iqBuffer == null || _iqBuffer.Length != bins)
            {
                _iqBuffer = UnsafeBuffer.Create(bins, sizeof(Complex));
                _fftBuffer = UnsafeBuffer.Create(bins, sizeof(Complex));
                _fftWindow = UnsafeBuffer.Create(bins, sizeof(float));
                _fftSpectrum = UnsafeBuffer.Create(bins, sizeof(float));

                var window = FilterBuilder.MakeWindow(WindowType.BlackmanHarris4, bins);
                fixed (float* windowPtr = window)
                {
                    Utils.Memcpy(_fftWindow, windowPtr, bins * sizeof(float));
                }

                _fftCompensation = FilterBuilder.GetDBFSCompensation(window);
            }
        }

        #endregion

        #region Display

        private double GetBandwidthFactor()
        {
            switch (_control.DetectorType)
            {
                case DetectorType.USB:
                case DetectorType.LSB:
                    return 0.5;
                default:
                    return 1.0;
            }
        }

        private double GetFilterOffset()
        {
            switch (_control.DetectorType)
            {
                case DetectorType.USB:
                    return 0.5;

                case DetectorType.LSB:
                    return -0.5;

                default:
                    return 0;
            }
        }

        private void ConfigureSpectrumAnalyzer(bool overrideFilter)
        {
            _spectrumAnalyzer.SpectrumWidth = (int)Math.Max(_control.FilterBandwidth, Math.Min(_sampleRate * GetBandwidthFactor(), _control.FilterBandwidth * BandwidthRatio));
            if (overrideFilter)
            {
                _spectrumAnalyzer.FilterBandwidth = _control.FilterBandwidth;
                _spectrumAnalyzer.FilterOffset = (int)(GetFilterOffset() * _control.FilterBandwidth);
                _filterOffset = _spectrumAnalyzer.FilterOffset;
                _filterbandwidth = _spectrumAnalyzer.FilterBandwidth;
                _updateFilter = true;
            }

            _spectrumAnalyzer.CenterFrequency = (long)(GetFilterOffset() * _control.FilterBandwidth);

            _spectrumAnalyzer.StepSize = _control.StepSize;
            _spectrumAnalyzer.Attack = _control.SAttack;
            _spectrumAnalyzer.Decay = _control.SDecay;
            _spectrumAnalyzer.Contrast = _control.FFTContrast;
            _spectrumAnalyzer.VerticalLinesGradient = _control.Gradient;
            _spectrumAnalyzer.SpectrumStyle = _control.FFTSpectrumStyle;
            _spectrumAnalyzer.DisplayOffset = (int)_control.FFTOffset;
            if (_sampleRate > 0)
            {
                var bw = _control.Source is IFFTSource ? (_control.Source as IFFTSource).DisplayBandwidth : _control.RFBandwidth;
                _spectrumAnalyzer.DisplayRange = (int)Math.Ceiling((_control.FFTRange + 6.02 * Math.Log(bw / _sampleRate) / Math.Log(4)) * 0.1 + 1) * 10;
            }
        }

        #endregion
    }
}
