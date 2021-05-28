using SDRSharp.Radio;

namespace SDRSharp.Plugin.WavRecorder
{
    public unsafe class RecordingBaseBandProcessor : IIQProcessor, IRealProcessor
    {
        public delegate void BasebandDataReadyDelegate(Complex* buffer, int length);
        public event BasebandDataReadyDelegate BaseBandDataReady;

        private volatile bool _enabled;
        private double _sampleRate;

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public double SampleRate
        {
            set { _sampleRate = value; }
            get { return _sampleRate; }
        }

        public void Process(Complex* buffer, int length)
        {
            var handler = BaseBandDataReady;
            if (handler != null)
            {
                handler(buffer, length);
            }
        }

        public void Process(float* buffer, int length)
        {
            var handler = BaseBandDataReady;
            if (handler != null)
            {
                handler((Complex*)buffer, length / 2);
            }
        }
    }
}
