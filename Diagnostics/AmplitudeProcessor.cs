using SDRSharp.Radio;
using System;

namespace SDRSharp.Plugin.Diagnostics
{
    public unsafe class AmplitudeProcessor : IIQProcessor, IRealProcessor
    {
        private const float BuildIntegration = 2.0f;
        private const float BuildDuration = 10.0f;

        private double _sampleRate;
        private double _integration;
        private bool _enabled;
        private bool _rebuildNeeded;
        private float _avg;
        private int _buildSamples;

        public double SampleRate
        {
            get { return _sampleRate; }
            set
            {
                _sampleRate = value;
                _rebuildNeeded = true;
            }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
            }
        }

        public double Integration
        {
            get { return _integration; }
            set { _integration = value; }
        }
        public float Average
        {
            get { return (float)(10 * Math.Log10(1e-60 + _avg)); }
        }

        public void Rebuild()
        {
            _rebuildNeeded = true;
        }

        public void Process(float* buffer, int length)
        {
            if (_rebuildNeeded)
            {
                _avg = 0;
                _buildSamples = (int)(_sampleRate * BuildDuration);
                _rebuildNeeded = false;
            }

            double integ;

            if (_buildSamples > 0)
            {
                integ = BuildIntegration;
                _buildSamples -= length;
            }
            else
            {
                integ = _integration;
            }

            var alpha = (float)(1.0 - Math.Exp(-1.0 / (_sampleRate * integ)));

            for (var i = 0; i < length; i++)
            {
                var mag = buffer[i] * buffer[i];

                _avg += alpha * (mag - _avg);
            }
        }

        public void Process(Complex* buffer, int length)
        {
            if (_rebuildNeeded)
            {
                _avg = 0;
                _buildSamples = (int)(_sampleRate * BuildDuration);
                _rebuildNeeded = false;
            }

            double integ;

            if (_buildSamples > 0)
            {
                integ = BuildIntegration;
                _buildSamples -= length;
            }
            else
            {
                integ = _integration;
            }

            var alpha = (float)(1.0 - Math.Exp(-1.0 / (_sampleRate * integ)));

            for (var i = 0; i < length; i++)
            {
                var mag = buffer[i].ModulusSquared();

                _avg += alpha * (mag - _avg);
            }
        }
    }
}