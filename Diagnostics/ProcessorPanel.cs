using SDRSharp.Common;
using SDRSharp.Radio;
using System;
using System.Windows.Forms;

namespace SDRSharp.Plugin.Diagnostics
{
    public partial class ProcessorPanel : UserControl
    {
        private float _reference;
        private ISharpControl _control;
        private AmplitudeProcessor _processor;

        public ProcessorPanel(AmplitudeProcessor processor, ISharpControl control)
        {
            _processor = processor;
            _control = control;
            InitializeComponent();

            sourceComboBox.SelectedIndex = 0;
            integrationNumericUpDown_ValueChanged(null, null);
        }

        private void enableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _processor.Enabled = enableCheckBox.Checked;
            refreshTimer.Enabled = enableCheckBox.Checked;
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (_processor.Enabled && !averageTextBox.Focused)
            {
                if (_processor.Average < -500)
                {
                    averageTextBox.Text = "-";
                }
                else
                {
                    averageTextBox.Text = (_processor.Average - _reference).ToString("#0.00") + " dB";
                }
            }
        }

        private void acquireButton_Click(object sender, EventArgs e)
        {
            _reference = _processor.Average;
            referenceTextBox.Text = _processor.Average.ToString("#0.00") + " dB";
        }

        private void sourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _control.UnregisterStreamHook(_processor);
            switch (sourceComboBox.SelectedIndex)
            {
                case 0:
                    _control.RegisterStreamHook(_processor, ProcessorType.DecimatedAndFilteredIQ);
                    break;

                case 1:
                    _control.RegisterStreamHook(_processor, ProcessorType.RawIQ);
                    break;

                case 2:
                    _control.RegisterStreamHook(_processor, ProcessorType.DemodulatorOutput);
                    break;
            }
            resetButton_Click(null, null);
        }

        private void integrationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _processor.Integration = (double)integrationNumericUpDown.Value;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _reference = 0;
            referenceTextBox.Text = "0.00 dB";
            _processor.Rebuild();
        }

        private void rebuildButton_Click(object sender, EventArgs e)
        {
            _processor.Rebuild();
        }
    }
}
