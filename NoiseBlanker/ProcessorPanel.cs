using System;
using System.Windows.Forms;

namespace SDRSharp.Plugin.NoiseBlanker
{
    public partial class ProcessorPanel : UserControl
    {
        private NoiseBlankerProcessor _processor;

        public ProcessorPanel(NoiseBlankerProcessor processor)
        {
            _processor = processor;

            InitializeComponent();

            enableCheckBox.Checked = _processor.Enabled;
            thresholdTrackBar.Value = (float)_processor.NoiseThreshold * 2;
            pulseWidthTrackBar.Value = (float)_processor.PulseWidth;
            lookupWindowTrackBar.Value = (float)_processor.LookupWindow;

            enableCheckBox.CheckStateChanged += new EventHandler(this.enableCheckBox_CheckedChanged);
            thresholdTrackBar.ValueChanged += new EventHandler(this.thresholdTrackBar_Scroll);
            pulseWidthTrackBar.ValueChanged += new EventHandler(this.pulseWidthTrackBar_Scroll);
            lookupWindowTrackBar.ValueChanged += new EventHandler(this.lookupWindowTrackBar_Scroll);

            enableCheckBox_CheckedChanged(null, null);
            thresholdTrackBar_Scroll(null, null);
            pulseWidthTrackBar_Scroll(null, null);
            lookupWindowTrackBar_Scroll(null, null);
        }

        private void enableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _processor.Enabled = enableCheckBox.Checked;
        }

        private void thresholdTrackBar_Scroll(object sender, EventArgs e)
        {
            _processor.NoiseThreshold = thresholdTrackBar.Value * 0.5;
            thresholdLabel.Text = _processor.NoiseThreshold.ToString("0.0") + " dB";
        }

        private void pulseWidthTrackBar_Scroll(object sender, EventArgs e)
        {
            _processor.PulseWidth = pulseWidthTrackBar.Value;
            pulseWidthLabel.Text = _processor.PulseWidth.ToString("0.00") + " µs";
        }

        private void lookupWindowTrackBar_Scroll(object sender, EventArgs e)
        {
            _processor.LookupWindow = lookupWindowTrackBar.Value;
            lookupWindpwLabel.Text = _processor.LookupWindow.ToString("0.00") + " ms";
        }
    }
}
