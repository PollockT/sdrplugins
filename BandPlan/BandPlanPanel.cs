using SDRSharp.Common;
using SDRSharp.PanView;
using SDRSharp.Radio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SDRSharp.Plugin.BandPlan
{
    [DesignTimeVisible(true)]
    [Category("SDRSharp")]
    [Description("RF Band Plan Panel")]
    public partial class BandPlanPanel : UserControl
    {
        private const long MinFMBCFrequency = 65000000;
        private const long MaxFMBCFrequency = 108000000;

        private readonly List<RangeEntry> _allBands = new List<RangeEntry>();
        private readonly List<RangeEntry> _visibleBands = new List<RangeEntry>();
        private readonly ISharpControl _control;

        public bool IsActive => showBookmarksCheckBox.Checked || updateSettingsCheckBox.Checked;

        public void SaveEntries()
        {
            var settingsPersister = new SettingsPersister();
            settingsPersister.PersistStoredFrequencies(_allBands);
        }

        private RangeEntry _currentRange;

        public BandPlanPanel(ISharpControl control)
        {
            InitializeComponent();

            _control = control;

            _control.SpectrumAnalyzerCustomPaint += controlInterface_CustomPaintHandler;
            _control.SpectrumAnalyzerBackgroundCustomPaint += controlInterface_BackgroundCustomPaintHandler;
            _control.PropertyChanged += controlInterface_PropertyChanged;

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                var settingsPersister = new SettingsPersister();
                _allBands = settingsPersister.ReadStoredFrequencies();
            }

            showBookmarksCheckBox.Checked = Utils.GetBooleanSetting("plugin.bandPlan.enabled", true);
            updateSettingsCheckBox.Checked = Utils.GetBooleanSetting("plugin.bandPlan.autoUpdateSettings", true);
            positionComboBox.SelectedIndex = Utils.GetIntSetting("plugin.bandPlan.position", 1);
        }

        private void UpdateVisibleFrequencies()
        {
            var minFrequency = _control.CenterFrequency - _control.RFDisplayBandwidth / 2;
            var maxFrequency = _control.CenterFrequency + _control.RFDisplayBandwidth / 2;

            _visibleBands.Clear();

            foreach (var entry in _allBands)
            {
                if ((minFrequency >= entry.MinFrequency && minFrequency <= entry.MaxFrequency) ||
                    (maxFrequency >= entry.MinFrequency && maxFrequency <= entry.MaxFrequency) ||
                    (entry.MinFrequency >= minFrequency && entry.MinFrequency <= maxFrequency) ||
                    (entry.MaxFrequency >= minFrequency && entry.MaxFrequency <= maxFrequency))
                {
                    _visibleBands.Add(entry);
                }
            }
        }

        private RangeEntry FindRange(long frequency, List<RangeEntry> list)
        {
            foreach (var band in list)
            {
                if (_control.Frequency >= band.MinFrequency && _control.Frequency <= band.MaxFrequency)
                {
                    var result = FindRange(frequency, band.SubRanges);

                    if (result == null)
                    {
                        return band;
                    }

                    return result;
                }
            }

            return null;
        }

        private void UpdateSettings()
        {
            var range = FindRange(_control.Frequency, _visibleBands);

            if (_currentRange != range)
            {
                _currentRange = null;
                if (range != null)
                {
                    _control.DetectorType = range.DetectorType;
                    _control.StepSize = range.StepSize;
                }
                _currentRange = range;
            }
        }

        private void controlInterface_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (showBookmarksCheckBox.Checked)
            {
                switch (e.PropertyName)
                {
                    case "StartRadio":
                    case "CenterFrequency":
                        UpdateVisibleFrequencies();
                        break;

                    case "Frequency":
                        if (updateSettingsCheckBox.Checked)
                        {
                            UpdateSettings();
                        }
                        break;

                    case "StepSize":
                        if (_currentRange != null && updateSettingsCheckBox.Checked)
                        {
                            _currentRange.StepSize = _control.StepSize;
                        }
                        break;

                    case "DetectorType":
                        if (_currentRange != null && updateSettingsCheckBox.Checked)
                        {
                            _currentRange.DetectorType = _control.DetectorType;
                        }
                        break;
                }
            }
        }

        private void showBookmarksCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showBookmarksCheckBox.Checked)
            {
                UpdateVisibleFrequencies();
            }
            _control.Perform();
            Utils.SaveSetting("plugin.bandPlan.enabled", showBookmarksCheckBox.Checked);
        }

        private void positionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _control.Perform();
            Utils.SaveSetting("plugin.bandPlan.position", positionComboBox.SelectedIndex);
        }

        private void updateSettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (updateSettingsCheckBox.Checked)
            {
                UpdateSettings();
                _control.Perform();
            }

            Utils.SaveSetting("plugin.bandPlan.autoUpdateSettings", updateSettingsCheckBox.Checked);
        }

        private void PaintBand(RangeEntry band, SpectrumAnalyzer spectrum, Graphics g)
        {
            var rect = new Rectangle();
            rect.X = Math.Max(Waterfall.AxisMargin, (int)Math.Round(spectrum.FrequencyToPoint(band.MinFrequency))) + 1;
            rect.Width = Math.Min(spectrum.Width - Waterfall.AxisMargin, (int)Math.Round(spectrum.FrequencyToPoint(band.MaxFrequency))) - rect.X;

            var transparentColor = band.Color;
            var descriptionColor = Color.White;

            switch (positionComboBox.SelectedIndex)
            {
                case 0:
                    if (BandOverlapsWithBroadcastFM(band))
                    {
                        rect.Y = Waterfall.AxisMargin;
                    }
                    else
                    {
                        rect.Y = 0;
                        if (band.Parent == null)
                        {
                            transparentColor = Color.FromArgb(255, transparentColor);
                        }
                    }
                    rect.Height = Waterfall.AxisMargin;
                    break;

                case 1:
                    rect.Y = spectrum.Height - 2 * Waterfall.AxisMargin;
                    rect.Height = Waterfall.AxisMargin;
                    break;

                case 2:
                    rect.Y = Waterfall.AxisMargin;
                    rect.Height = spectrum.Height - 2 * Waterfall.AxisMargin;
                    transparentColor = Color.FromArgb(60, transparentColor);
                    descriptionColor = Color.FromArgb(100, descriptionColor);
                    break;
            }

            using (var format = new StringFormat(StringFormatFlags.NoWrap))
            using (var font = new Font("Lucida Console", 9.0f))
            using (var descriptionBrush = new SolidBrush(descriptionColor))
            using (var transparentBrush = new SolidBrush(transparentColor))
            {
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                format.Trimming = StringTrimming.EllipsisCharacter;

                g.FillRectangle(transparentBrush, rect);

                foreach (var subRange in band.SubRanges)
                {
                    PaintBand(subRange, spectrum, g);
                }

                if (band.Parent == null && !string.IsNullOrEmpty(band.Description) && rect.Width >= 20)
                {
                    g.DrawString(band.Description, font, descriptionBrush, rect, format);
                }
            }
        }

        private bool BandOverlapsWithBroadcastFM(RangeEntry band)
        {
            if (band.MinFrequency >= MinFMBCFrequency && band.MinFrequency <= MaxFMBCFrequency)
            {
                return true;
            }

            if (band.MaxFrequency >= MinFMBCFrequency && band.MaxFrequency <= MaxFMBCFrequency)
            {
                return true;
            }

            return false;
        }

        private void controlInterface_CustomPaintHandler(object sender, CustomPaintEventArgs e)
        {
            if (!showBookmarksCheckBox.Checked)
            {
                return;
            }

            if (positionComboBox.SelectedIndex > 1)
            {
                return;
            }

            foreach (var band in _visibleBands)
            {
                PaintBand(band, (SpectrumAnalyzer)sender, e.Graphics);
            }
        }

        private void controlInterface_BackgroundCustomPaintHandler(object sender, CustomPaintEventArgs e)
        {
            if (!showBookmarksCheckBox.Checked)
            {
                return;
            }

            if (positionComboBox.SelectedIndex != 2)
            {
                return;
            }

            foreach (var band in _visibleBands)
            {
                PaintBand(band, (SpectrumAnalyzer)sender, e.Graphics);
            }
        }
    }
}
