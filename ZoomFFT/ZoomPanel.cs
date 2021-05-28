using System;
using System.Windows.Forms;

namespace SDRSharp.Plugin.ZoomFFT
{
    public partial class ZoomPanel : UserControl
    {
        private IFProcessor _ifProcessor;
        private MPXProcessor _mpxProcessor;
        private AFProcessor _afProcessor;

        public bool IsActive => enableIFCheckBox.Checked || enableMPXCheckBox.Checked || enableAudioCheckBox.Checked;

        public ZoomPanel(IFProcessor ifProcessor, MPXProcessor mpxProcessor, AFProcessor afProcessor)
        {
            InitializeComponent();
            _ifProcessor = ifProcessor;
            _mpxProcessor = mpxProcessor;
            _afProcessor = afProcessor;
            enableFilterCheckBox.Checked = _ifProcessor.EnableFilter && _ifProcessor.Enabled;
            enableFilterCheckBox.Enabled = _ifProcessor.Enabled;
            enableIFCheckBox.Checked = _ifProcessor.Enabled;
            enableMPXCheckBox.Checked = _mpxProcessor.Enabled;
            enableAudioCheckBox.Checked = _afProcessor.Enabled;
        }

        private void enableFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _ifProcessor.EnableFilter = enableFilterCheckBox.Enabled && enableFilterCheckBox.Checked;
        }

        private void enableIFCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _ifProcessor.Enabled = enableIFCheckBox.Checked;
            enableFilterCheckBox.Enabled = enableIFCheckBox.Checked;
            if (!enableIFCheckBox.Checked)
            {
                _ifProcessor.EnableFilter = false;
            }
            else
            {
                enableFilterCheckBox_CheckedChanged(null, null);
            }
        }

        private void enableMPXCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _mpxProcessor.Enabled = enableMPXCheckBox.Checked;
        }

        private void enableAudioCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _afProcessor.Enabled = enableAudioCheckBox.Checked;
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            enableIFCheckBox.Checked = _ifProcessor.DisplayIsVisible;
            enableMPXCheckBox.Checked = _mpxProcessor.DisplayIsVisible;
            enableAudioCheckBox.Checked = _afProcessor.DisplayIsVisible;
        }
    }
}
