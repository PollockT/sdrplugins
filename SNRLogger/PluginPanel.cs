﻿using SDRSharp.Common;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace SDRSharp.Plugin.SNRLogger
{
    public partial class PluginPanel : UserControl
    {
        private ISharpControl _control;
        private string _filename;

        public PluginPanel(ISharpControl control)
        {
            _control = control;

            InitializeComponent();
            intervalTrackBar_Scroll(null, null);
        }

        public bool IsActive => snrTimer.Enabled;

        private void intervalTrackBar_Scroll(object sender, System.EventArgs e)
        {
            snrTimer.Interval = (int)intervalTrackBar.Value * 100;
            intervalLabel.Text = (intervalTrackBar.Value * 0.1).ToString("0.00") + " sec";
        }

        private string MakeFileName()
        {
            var tunedfrequency = Math.Max(_control.Frequency, 0);
            var time = DateTime.Now;
            var dateString = time.ToString("yyyyMMdd");
            var timeString = time.ToString("HHmmssZ");

            var filename = Path.GetDirectoryName(Application.ExecutablePath);
            filename = Path.Combine("" + filename, string.Format("SDRSharp_{0}_{1}_SNR.csv", dateString, timeString));

            return filename;
        }

        private void enableCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (enableCheckBox.Checked)
            {
                _filename = MakeFileName();
                using (var writer = File.CreateText(_filename))
                {
                    writer.WriteLine("Timestamp,Frequency,SNR");
                }
            }
            snrTimer.Enabled = enableCheckBox.Checked;
        }

        private void snrTimer_Tick(object sender, System.EventArgs e)
        {
            if (!_control.IsPlaying || string.IsNullOrEmpty(_filename))
            {
                return;
            }

            var line = string.Format("{0},{1},{2}", DateTime.Now.ToString(), _control.Frequency, Math.Round(_control.VisualSNR, 2).ToString(CultureInfo.InvariantCulture));

            using (var writer = File.AppendText(_filename))
            {
                writer.WriteLine(line);
            }
        }
    }
}
