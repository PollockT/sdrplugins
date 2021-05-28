using SDRSharp.Common;
using SDRSharp.PanView;
using SDRSharp.Radio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SDRSharp.Plugin.FrequencyManager
{
    public delegate void RadioInfo(object sender, MemoryInfoEventArgs e);

    [DesignTimeVisible(true)]
    [Category("SDRSharp")]
    [Description("RF Memory Management Panel")]
    public partial class FrequencyManagerPanel : UserControl
    {
        private static readonly Color _bookMarkColor = Color.FromArgb(80, Color.Blue);
        private readonly SortableBindingList<MemoryEntry> _displayedEntries = new SortableBindingList<MemoryEntry>();
        private readonly List<MemoryEntry> _entries;
        private readonly List<VisibleEntry> _visibleEntries = new List<VisibleEntry>();
        private readonly SettingsPersister _settingsPersister;
        private readonly List<string> _groups = new List<string>();
        private const string AllGroups = "[All Groups]";
        private const string FavouriteGroup = "[Favourites]";

        private ISharpControl _controlInterface;


        public bool IsActive => showBookmarksCheckBox.Checked;

        private class VisibleEntry
        {
            public long MinFreq { get; set; }

            public long MaxFreq { get; set; }

            public string Description { get; set; }
        }

        public FrequencyManagerPanel(ISharpControl control)
        {
            Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            InitializeComponent();

            _controlInterface = control;

            _controlInterface.WaterfallCustomPaint += controlInterface_WaterfallCustomPaint;
            _controlInterface.SpectrumAnalyzerCustomPaint += controlInterface_SpectrumAnalyzerCustomPaint;
            _controlInterface.SpectrumAnalyzerBackgroundCustomPaint += controlInterface_SpectrumAnalyzerBackgroundCustomPaint;
            _controlInterface.PropertyChanged += controlInterface_PropertyChanged;

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                _settingsPersister = new SettingsPersister();
                _entries = _settingsPersister.ReadStoredFrequencies();
                _groups = GetGroupsFromEntries();
                ProcessGroups(null);
            }

            memoryEntryBindingSource.DataSource = _displayedEntries;

            frequenciesRadListView.Columns["Name"].Width = 120;
            frequenciesRadListView.Columns["Frequency"].Width = 80;

            showBookmarksCheckBox.Checked = Utils.GetBooleanSetting("showBookmarks");
        }

        private void UpdateVisibleFrequencies()
        {
            var minFrequency = _controlInterface.CenterFrequency - _controlInterface.RFDisplayBandwidth / 2;
            var maxFrequency = _controlInterface.CenterFrequency + _controlInterface.RFDisplayBandwidth / 2;

            _visibleEntries.Clear();

            for (var i = 0; i < _displayedEntries.Count; i++)
            {
                var entry = _displayedEntries[i];

                var high = entry.Frequency;
                var low = entry.Frequency;

                switch (entry.DetectorType)
                {
                    case DetectorType.AM:
                    case DetectorType.NFM:
                    case DetectorType.WFM:
                    case DetectorType.DSB:
                    case DetectorType.CW:
                    case DetectorType.RAW:
                        high += entry.FilterBandwidth / 2;
                        low -= entry.FilterBandwidth / 2;
                        break;

                    case DetectorType.USB:
                        high += entry.FilterBandwidth;
                        break;

                    case DetectorType.LSB:
                        low -= entry.FilterBandwidth;
                        break;
                }

                if ((low <= maxFrequency && low >= minFrequency) || (high >= minFrequency && high <= maxFrequency))
                {
                    var ve = new VisibleEntry
                    {
                        Description = entry.Name,
                        MinFreq = low,
                        MaxFreq = high
                    };
                    _visibleEntries.Add(ve);
                }
            }
        }

        private void controlInterface_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == "CenterFrequency" || e.PropertyName == "StartRadio") && showBookmarksCheckBox.Checked)
            {
                UpdateVisibleFrequencies();
            }
        }

        private void showBookmarksCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showBookmarksCheckBox.Checked)
            {
                UpdateVisibleFrequencies();
            }
            _controlInterface.Perform();
            Utils.SaveSetting("showBookmarks", showBookmarksCheckBox.Checked);
        }


        private void controlInterface_SpectrumAnalyzerBackgroundCustomPaint(object sender, CustomPaintEventArgs e)
        {
            if (!showBookmarksCheckBox.Checked)
            {
                return;
            }

            var spectrum = (SpectrumAnalyzer)sender;

            using (var markerBrush = new SolidBrush(_bookMarkColor))
            {
                var rect = new Rectangle();
                foreach (var entry in _visibleEntries)
                {
                    var x1 = (int)Math.Max(Waterfall.AxisMargin, spectrum.FrequencyToPoint(entry.MinFreq));
                    var x2 = (int)Math.Min(spectrum.Width - Waterfall.AxisMargin, spectrum.FrequencyToPoint(entry.MaxFreq));

                    rect.X = x1;
                    rect.Y = Waterfall.AxisMargin;
                    rect.Width = (x2 - x1) | 1;
                    rect.Height = spectrum.Height - 2 * Waterfall.AxisMargin;
                    e.Graphics.FillRectangle(markerBrush, rect);
                }
            }
        }

        private void controlInterface_WaterfallCustomPaint(object sender, CustomPaintEventArgs e)
        {
            var waterfall = (Waterfall)sender;
            foreach (var entry in _visibleEntries)
            {
                var x1 = (int)Math.Max(Waterfall.AxisMargin, waterfall.FrequencyToPoint(entry.MinFreq));
                var x2 = (int)Math.Min(waterfall.Width - Waterfall.AxisMargin, waterfall.FrequencyToPoint(entry.MaxFreq));

                if (e.CursorPosition.X >= x1 && e.CursorPosition.X <= x2)
                {
                    e.CustomTitle = entry.Description;
                }
            }
        }

        private void controlInterface_SpectrumAnalyzerCustomPaint(object sender, CustomPaintEventArgs e)
        {
            var spectrum = (SpectrumAnalyzer)sender;

            foreach (var entry in _visibleEntries)
            {
                var x1 = (int)Math.Max(Waterfall.AxisMargin, spectrum.FrequencyToPoint(entry.MinFreq));
                var x2 = (int)Math.Min(spectrum.Width - Waterfall.AxisMargin, spectrum.FrequencyToPoint(entry.MaxFreq));

                if (e.CursorPosition.X >= x1 && e.CursorPosition.X <= x2)
                {
                    e.CustomTitle = entry.Description;
                }
            }
        }

        public String SelectedGroup
        {
            get { return (string)comboGroups.SelectedItem.Text; }
            set
            {
                if (value != null && comboGroups.Items.IndexOf(value) != -1)
                {
                    comboGroups.SelectedIndex = comboGroups.Items.IndexOf(value);
                }
            }
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            Bookmark();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (frequenciesRadListView.SelectedIndex >= 0)
                DoEdit((MemoryEntry)frequenciesRadListView.SelectedItem.DataBoundItem, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var entry = (MemoryEntry)memoryEntryBindingSource.Current;
            if (entry != null && RadMessageBox.Show("Are you sure that you want to delete '"
              + entry.Name + "'?", "Delete Entry", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                _entries.Remove(entry);
                _settingsPersister.PersistStoredFrequencies(_entries);
                _displayedEntries.Remove(entry);
                UpdateVisibleFrequencies();
            }
        }

        private void DoEdit(MemoryEntry memoryEntry, bool isNew)
        {
            var dialog = new DialogEntryInfo(memoryEntry, _groups);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (isNew)
                {
                    _entries.Add(memoryEntry);
                    _entries.Sort((e1, e2) => e1.Frequency.CompareTo(e2.Frequency));
                }
                _settingsPersister.PersistStoredFrequencies(_entries);
                if (!_groups.Contains(memoryEntry.GroupName))
                {
                    _groups.Add(memoryEntry.GroupName);
                    ProcessGroups(memoryEntry.GroupName);
                }
                else
                {
                    if ((string)comboGroups.SelectedItem.Text == AllGroups || (string)comboGroups.SelectedItem.Text == memoryEntry.GroupName ||
                        ((string)comboGroups.SelectedItem.Text == FavouriteGroup && memoryEntry.IsFavourite))
                    {
                        if (isNew)
                            _displayedEntries.Add(memoryEntry);
                    }
                    else
                    {
                        var index = _groups.IndexOf(memoryEntry.GroupName);
                        comboGroups.SelectedIndex = index;
                    }
                }
                UpdateVisibleFrequencies();
            }
        }

        private List<String> GetGroupsFromEntries()
        {
            var groups = new List<string>();
            foreach (MemoryEntry entry in _entries)
            {
                if (!groups.Contains(entry.GroupName))
                    groups.Add(entry.GroupName);
            }
            return groups;
        }

        private void FrequenciesRadListView_ColumnCreating(object sender, ListViewColumnCreatingEventArgs e)
        {
            if (e.Column.FieldName != "Name" && e.Column.FieldName != "Frequency")
            {
                e.Column.Visible = false;
            }
            else if (e.Column.FieldName == "Name")
            {
                e.Column.HeaderText = "Description";
            }
        }

        private void FrequenciesRadListView_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        {
            var cell = e.CellElement as DetailListViewDataCellElement;
            if (cell != null)
            {
                if (cell.Data.FieldName == "Frequency")
                {
                    cell.TextAlignment = ContentAlignment.MiddleRight;
                    cell.Text = GetFrequencyDisplay((long)cell.Row["Frequency"]);
                }
            }
        }

        private void FrequenciesRadListView_DoubleClick(object sender, EventArgs e)
        {
            Navigate();
        }

        private void ProcessGroups(String selectedGroupName)
        {
            _groups.Sort();
            comboGroups.Items.Clear();
            comboGroups.Items.Add(AllGroups);
            comboGroups.Items.Add(FavouriteGroup);
            comboGroups.Items.AddRange(_groups.ToArray());
            if (selectedGroupName != null)
            {
                var index = _groups.IndexOf(selectedGroupName);
                comboGroups.SelectedIndex = index;
            }
            else
                comboGroups.SelectedIndex = 0;
        }

        private void comboGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            memoryEntryBindingSource.Clear();
            _displayedEntries.Clear();
            if (comboGroups.SelectedIndex != -1)
            {
                var selectedGroup = comboGroups.SelectedItem.Text;

                foreach (MemoryEntry entry in _entries)
                {
                    if (selectedGroup == AllGroups || entry.GroupName == selectedGroup || (selectedGroup == FavouriteGroup && entry.IsFavourite))
                    {

                        _displayedEntries.Add(entry);
                    }
                }
            }
            UpdateVisibleFrequencies();
        }

        private void frequencyDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            deleteRadButton.Enabled = frequenciesRadListView.SelectedIndex >= 0;
            editRadButton.Enabled = deleteRadButton.Enabled;
        }

        public void Bookmark()
        {
            var memoryEntry = new MemoryEntry();

            memoryEntry.DetectorType = _controlInterface.DetectorType;
            memoryEntry.Frequency = _controlInterface.Frequency;
            memoryEntry.FilterBandwidth = _controlInterface.FilterBandwidth;
            memoryEntry.Shift = _controlInterface.FrequencyShiftEnabled ? _controlInterface.FrequencyShift : 0;

            memoryEntry.GroupName = "Misc";
            if (_controlInterface.DetectorType == DetectorType.WFM)
            {
                var stationName = _controlInterface.RdsProgramService.Trim();
                memoryEntry.Name = string.Empty;
                if (!string.IsNullOrEmpty(stationName))
                {
                    memoryEntry.Name = stationName;
                }
                else
                {
                    memoryEntry.Name = GetFrequencyDisplay(_controlInterface.Frequency) + " " + memoryEntry.DetectorType;
                }
            }
            else
            {
                memoryEntry.Name = GetFrequencyDisplay(_controlInterface.Frequency) + " " + memoryEntry.DetectorType;
            }
            memoryEntry.IsFavourite = true;
            DoEdit(memoryEntry, true);
        }

        public void Navigate()
        {
            if (frequenciesRadListView.SelectedIndex != -1)
            {
                try
                {
                    var memoryEntry = (MemoryEntry)frequenciesRadListView.SelectedItem.DataBoundItem;

                    _controlInterface.FrequencyShiftEnabled = memoryEntry.Shift != 0;
                    if (_controlInterface.FrequencyShiftEnabled)
                    {
                        _controlInterface.FrequencyShift = memoryEntry.Shift;
                    }
                    _controlInterface.DetectorType = memoryEntry.DetectorType;
                    _controlInterface.FilterBandwidth = (int)memoryEntry.FilterBandwidth;
                    _controlInterface.SetFrequency(memoryEntry.Frequency, true);
                }
                catch (Exception e)
                {
                    RadMessageBox.Show(this, e.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        public static string GetFrequencyDisplay(long frequency)
        {
            string result;
            var absFrequency = Math.Abs(frequency);
            if (absFrequency == 0)
            {
                result = "DC";
            }
            else if (absFrequency > 1500000000)
            {
                result = string.Format("{0:#,0.000 000} GHz", frequency / 1000000000.0);
            }
            else if (absFrequency > 30000000)
            {
                result = string.Format("{0:0,0.000#} MHz", frequency / 1000000.0);
            }
            else if (absFrequency > 1000)
            {
                result = string.Format("{0:#,#.###} kHz", frequency / 1000.0);
            }
            else
            {
                result = frequency.ToString();
            }
            return result;
        }

        private void frequencyDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate();
                e.Handled = true;
            }
        }
    }
}
