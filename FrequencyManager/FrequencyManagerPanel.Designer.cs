namespace SDRSharp.Plugin.FrequencyManager
{
    partial class FrequencyManagerPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrequencyManagerPanel));
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            this.label17 = new Telerik.WinControls.UI.RadLabel();
            this.comboGroups = new Telerik.WinControls.UI.RadDropDownList();
            this.mainImageList = new System.Windows.Forms.ImageList();
            this.tableLayoutPanel = new Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel();
            this.showBookmarksCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.newRadButton = new Telerik.WinControls.UI.RadButton();
            this.editRadButton = new Telerik.WinControls.UI.RadButton();
            this.deleteRadButton = new Telerik.WinControls.UI.RadButton();
            this.frequenciesRadListView = new Telerik.WinControls.UI.RadListView();
            this.memoryEntryBindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboGroups)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showBookmarksCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newRadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteRadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequenciesRadListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoryEntryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.Location = new System.Drawing.Point(2, 35);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 18);
            this.label17.TabIndex = 5;
            this.label17.Text = "Group:";
            // 
            // comboGroups
            // 
            this.comboGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tableLayoutPanel.SetColumnSpan(this.comboGroups, 2);
            this.comboGroups.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.comboGroups.Location = new System.Drawing.Point(85, 34);
            this.comboGroups.Margin = new System.Windows.Forms.Padding(2);
            this.comboGroups.Name = "comboGroups";
            this.comboGroups.Size = new System.Drawing.Size(163, 20);
            this.comboGroups.TabIndex = 4;
            this.comboGroups.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.comboGroups_SelectedIndexChanged);
            // 
            // mainImageList
            // 
            this.mainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainImageList.ImageStream")));
            this.mainImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.mainImageList.Images.SetKeyName(0, "NewDocumentHS.BMP");
            this.mainImageList.Images.SetKeyName(1, "DeleteHS.bmp");
            this.mainImageList.Images.SetKeyName(2, "EditInformationHS.BMP");
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Controls.Add(this.comboGroups, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.showBookmarksCheckBox, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label17, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.newRadButton, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.editRadButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.deleteRadButton, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.frequenciesRadListView, 0, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(250, 360);
            this.tableLayoutPanel.TabIndex = 8;
            // 
            // showBookmarksCheckBox
            // 
            this.showBookmarksCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel.SetColumnSpan(this.showBookmarksCheckBox, 3);
            this.showBookmarksCheckBox.Location = new System.Drawing.Point(3, 59);
            this.showBookmarksCheckBox.Name = "showBookmarksCheckBox";
            this.showBookmarksCheckBox.Size = new System.Drawing.Size(113, 18);
            this.showBookmarksCheckBox.TabIndex = 7;
            this.showBookmarksCheckBox.Text = "Show on spectrum";
            this.showBookmarksCheckBox.CheckStateChanged += new System.EventHandler(this.showBookmarksCheckBox_CheckedChanged);
            // 
            // newRadButton
            // 
            this.newRadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.newRadButton.Location = new System.Drawing.Point(3, 3);
            this.newRadButton.Name = "newRadButton";
            this.newRadButton.Size = new System.Drawing.Size(77, 26);
            this.newRadButton.TabIndex = 8;
            this.newRadButton.Text = "New";
            this.newRadButton.Click += new System.EventHandler(this.btnNewEntry_Click);
            // 
            // editRadButton
            // 
            this.editRadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editRadButton.Location = new System.Drawing.Point(86, 3);
            this.editRadButton.Name = "editRadButton";
            this.editRadButton.Size = new System.Drawing.Size(77, 26);
            this.editRadButton.TabIndex = 8;
            this.editRadButton.Text = "Edit";
            this.editRadButton.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // deleteRadButton
            // 
            this.deleteRadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteRadButton.Location = new System.Drawing.Point(169, 3);
            this.deleteRadButton.Name = "deleteRadButton";
            this.deleteRadButton.Size = new System.Drawing.Size(78, 26);
            this.deleteRadButton.TabIndex = 8;
            this.deleteRadButton.Text = "Delete";
            this.deleteRadButton.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frequenciesRadListView
            // 
            this.frequenciesRadListView.AllowEdit = false;
            this.frequenciesRadListView.AutoScroll = true;
            this.tableLayoutPanel.SetColumnSpan(this.frequenciesRadListView, 3);
            this.frequenciesRadListView.DataSource = this.memoryEntryBindingSource;
            this.frequenciesRadListView.DisplayMember = "Name";
            this.frequenciesRadListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frequenciesRadListView.EnableColumnSort = true;
            this.frequenciesRadListView.EnableFiltering = true;
            this.frequenciesRadListView.EnableSorting = true;
            this.frequenciesRadListView.ItemSpacing = -1;
            this.frequenciesRadListView.Location = new System.Drawing.Point(3, 83);
            this.frequenciesRadListView.Name = "frequenciesRadListView";
            this.frequenciesRadListView.Size = new System.Drawing.Size(244, 274);
            sortDescriptor1.PropertyName = "Frequency";
            sortDescriptor2.PropertyName = "Name";
            this.frequenciesRadListView.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1,
            sortDescriptor2});
            this.frequenciesRadListView.TabIndex = 9;
            this.frequenciesRadListView.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.frequenciesRadListView.SelectedItemChanged += new System.EventHandler(this.frequencyDataGridView_SelectionChanged);
            this.frequenciesRadListView.CellFormatting += new Telerik.WinControls.UI.ListViewCellFormattingEventHandler(this.FrequenciesRadListView_CellFormatting);
            this.frequenciesRadListView.ColumnCreating += new Telerik.WinControls.UI.ListViewColumnCreatingEventHandler(this.FrequenciesRadListView_ColumnCreating);
            this.frequenciesRadListView.DoubleClick += new System.EventHandler(this.FrequenciesRadListView_DoubleClick);
            this.frequenciesRadListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frequencyDataGridView_KeyDown);
            // 
            // memoryEntryBindingSource
            // 
            this.memoryEntryBindingSource.DataSource = typeof(SDRSharp.Plugin.FrequencyManager.MemoryEntry);
            // 
            // FrequencyManagerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FrequencyManagerPanel";
            this.Size = new System.Drawing.Size(250, 360);
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboGroups)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showBookmarksCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newRadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteRadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequenciesRadListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoryEntryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel label17;
        private Telerik.WinControls.UI.RadDropDownList comboGroups;
        private System.Windows.Forms.ImageList mainImageList;
        private System.Windows.Forms.BindingSource memoryEntryBindingSource;
        private Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel tableLayoutPanel;
        private Telerik.WinControls.UI.RadCheckBox showBookmarksCheckBox;
        private Telerik.WinControls.UI.RadButton newRadButton;
        private Telerik.WinControls.UI.RadButton editRadButton;
        private Telerik.WinControls.UI.RadButton deleteRadButton;
        private Telerik.WinControls.UI.RadListView frequenciesRadListView;
    }
}
