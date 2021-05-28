namespace SDRSharp.Plugin.BandPlan
{
    partial class BandPlanPanel
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            this.tableLayoutPanel = new Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel();
            this.showBookmarksCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.positionComboBox = new Telerik.WinControls.UI.RadDropDownList();
            this.updateSettingsCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showBookmarksCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateSettingsCheckBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.82353F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.17647F));
            this.tableLayoutPanel.Controls.Add(this.showBookmarksCheckBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.positionComboBox, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.updateSettingsCheckBox, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(250, 90);
            this.tableLayoutPanel.TabIndex = 8;
            // 
            // showBookmarksCheckBox
            // 
            this.showBookmarksCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel.SetColumnSpan(this.showBookmarksCheckBox, 2);
            this.showBookmarksCheckBox.Location = new System.Drawing.Point(3, 3);
            this.showBookmarksCheckBox.Name = "showBookmarksCheckBox";
            this.showBookmarksCheckBox.Size = new System.Drawing.Size(113, 18);
            this.showBookmarksCheckBox.TabIndex = 7;
            this.showBookmarksCheckBox.Text = "Show on spectrum";
            this.showBookmarksCheckBox.CheckStateChanged += new System.EventHandler(this.showBookmarksCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Position";
            // 
            // positionComboBox
            // 
            this.positionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.positionComboBox.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "Top";
            radListDataItem2.Text = "Bottom";
            radListDataItem3.Text = "Full";
            this.positionComboBox.Items.Add(radListDataItem1);
            this.positionComboBox.Items.Add(radListDataItem2);
            this.positionComboBox.Items.Add(radListDataItem3);
            this.positionComboBox.Location = new System.Drawing.Point(87, 51);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(160, 20);
            this.positionComboBox.TabIndex = 9;
            this.positionComboBox.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.positionComboBox_SelectedIndexChanged);
            // 
            // updateSettingsCheckBox
            // 
            this.updateSettingsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel.SetColumnSpan(this.updateSettingsCheckBox, 2);
            this.updateSettingsCheckBox.Location = new System.Drawing.Point(3, 27);
            this.updateSettingsCheckBox.Name = "updateSettingsCheckBox";
            this.updateSettingsCheckBox.Size = new System.Drawing.Size(154, 18);
            this.updateSettingsCheckBox.TabIndex = 7;
            this.updateSettingsCheckBox.Text = "Auto update radio settings";
            this.updateSettingsCheckBox.CheckStateChanged += new System.EventHandler(this.updateSettingsCheckBox_CheckedChanged);
            // 
            // BandPlanPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "BandPlanPanel";
            this.Size = new System.Drawing.Size(250, 90);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showBookmarksCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateSettingsCheckBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel tableLayoutPanel;
        private Telerik.WinControls.UI.RadCheckBox showBookmarksCheckBox;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadDropDownList positionComboBox;
        private Telerik.WinControls.UI.RadCheckBox updateSettingsCheckBox;
    }
}
