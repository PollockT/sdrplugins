namespace SDRSharp.Plugin.WavRecorder
{
    partial class RecordingPanel
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            this.recBtn = new Telerik.WinControls.UI.RadButton();
            this.recDisplayTimer = new System.Windows.Forms.Timer(this.components);
            this.durationLbl = new Telerik.WinControls.UI.RadLabel();
            this.sampleFormatCombo = new Telerik.WinControls.UI.RadDropDownList();
            this.sampleFormatLbl = new Telerik.WinControls.UI.RadLabel();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.sizeLbl = new Telerik.WinControls.UI.RadLabel();
            this.groupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.tableLayoutPanel2 = new Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel();
            this.basebandCb = new Telerik.WinControls.UI.RadCheckBox();
            this.audioCb = new Telerik.WinControls.UI.RadCheckBox();
            this.groupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.tableLayoutPanel3 = new Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.skippedBufferCountLbl = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel1 = new Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.recBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleFormatCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleFormatLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basebandCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skippedBufferCountLbl)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // recBtn
            // 
            this.recBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.recBtn.Enabled = false;
            this.recBtn.Location = new System.Drawing.Point(128, 203);
            this.recBtn.Name = "recBtn";
            this.recBtn.Size = new System.Drawing.Size(119, 23);
            this.recBtn.TabIndex = 0;
            this.recBtn.Text = "Record";
            this.recBtn.Click += new System.EventHandler(this.recBtn_Click);
            // 
            // recDisplayTimer
            // 
            this.recDisplayTimer.Interval = 1000;
            this.recDisplayTimer.Tick += new System.EventHandler(this.recDisplayTimer_Tick);
            // 
            // durationLbl
            // 
            this.durationLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.durationLbl.Location = new System.Drawing.Point(97, 27);
            this.durationLbl.Name = "durationLbl";
            this.durationLbl.Size = new System.Drawing.Size(48, 18);
            this.durationLbl.TabIndex = 3;
            this.durationLbl.Text = "00:00:00";
            // 
            // sampleFormatCombo
            // 
            this.sampleFormatCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sampleFormatCombo.DropDownMinSize = new System.Drawing.Size(120, 0);
            this.sampleFormatCombo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "8 Bit PCM";
            radListDataItem2.Text = "16 Bit PCM";
            radListDataItem3.Text = "32 Bit IEEE Float";
            this.sampleFormatCombo.Items.Add(radListDataItem1);
            this.sampleFormatCombo.Items.Add(radListDataItem2);
            this.sampleFormatCombo.Items.Add(radListDataItem3);
            this.sampleFormatCombo.Location = new System.Drawing.Point(91, 8);
            this.sampleFormatCombo.Name = "sampleFormatCombo";
            this.sampleFormatCombo.Size = new System.Drawing.Size(146, 20);
            this.sampleFormatCombo.TabIndex = 4;
            this.sampleFormatCombo.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.sampleFormatCombo_SelectedIndexChanged);
            // 
            // sampleFormatLbl
            // 
            this.sampleFormatLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sampleFormatLbl.Location = new System.Drawing.Point(3, 9);
            this.sampleFormatLbl.Name = "sampleFormatLbl";
            this.sampleFormatLbl.Size = new System.Drawing.Size(82, 18);
            this.sampleFormatLbl.TabIndex = 5;
            this.sampleFormatLbl.Text = "Sample Format";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Duration";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "File Size";
            // 
            // sizeLbl
            // 
            this.sizeLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sizeLbl.Location = new System.Drawing.Point(97, 3);
            this.sizeLbl.Name = "sizeLbl";
            this.sizeLbl.Size = new System.Drawing.Size(32, 18);
            this.sizeLbl.TabIndex = 6;
            this.sizeLbl.Text = "0 MB";
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.HeaderText = "Mode";
            this.groupBox2.Location = new System.Drawing.Point(3, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 94);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.sampleFormatLbl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.sampleFormatCombo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.basebandCb, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.audioCb, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 74);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // basebandCb
            // 
            this.basebandCb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.basebandCb.Location = new System.Drawing.Point(91, 46);
            this.basebandCb.Name = "basebandCb";
            this.basebandCb.Size = new System.Drawing.Size(69, 18);
            this.basebandCb.TabIndex = 6;
            this.basebandCb.Text = "Baseband";
            // 
            // audioCb
            // 
            this.audioCb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.audioCb.Location = new System.Drawing.Point(3, 46);
            this.audioCb.Name = "audioCb";
            this.audioCb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.audioCb.Size = new System.Drawing.Size(50, 18);
            this.audioCb.TabIndex = 7;
            this.audioCb.Text = "Audio";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.HeaderText = "Status";
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 94);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.sizeLbl, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.skippedBufferCountLbl, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.durationLbl, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(240, 74);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dropped Buffers";
            // 
            // skippedBufferCountLbl
            // 
            this.skippedBufferCountLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.skippedBufferCountLbl.Location = new System.Drawing.Point(97, 52);
            this.skippedBufferCountLbl.Name = "skippedBufferCountLbl";
            this.skippedBufferCountLbl.Size = new System.Drawing.Size(12, 18);
            this.skippedBufferCountLbl.TabIndex = 8;
            this.skippedBufferCountLbl.Text = "0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.recBtn, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 240);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // RecordingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RecordingPanel";
            this.Size = new System.Drawing.Size(250, 240);
            ((System.ComponentModel.ISupportInitialize)(this.recBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleFormatCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleFormatLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basebandCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skippedBufferCountLbl)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton recBtn;
        private System.Windows.Forms.Timer recDisplayTimer;
        private Telerik.WinControls.UI.RadLabel durationLbl;
        private Telerik.WinControls.UI.RadDropDownList sampleFormatCombo;
        private Telerik.WinControls.UI.RadLabel sampleFormatLbl;
        private Telerik.WinControls.UI.RadLabel sizeLbl;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadGroupBox groupBox1;
        private Telerik.WinControls.UI.RadGroupBox groupBox2;
        private Telerik.WinControls.UI.RadCheckBox audioCb;
        private Telerik.WinControls.UI.RadCheckBox basebandCb;
        private Telerik.WinControls.UI.RadLabel skippedBufferCountLbl;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel tableLayoutPanel3;
    }
}
