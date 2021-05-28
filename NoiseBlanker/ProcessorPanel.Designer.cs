namespace SDRSharp.Plugin.NoiseBlanker
{
    partial class ProcessorPanel
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
            this.enableCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.thresholdLabel = new Telerik.WinControls.UI.RadLabel();
            this.thresholdTrackBar = new Telerik.WinControls.UI.RadTrackBar();
            this.pulseWidthLabel = new Telerik.WinControls.UI.RadLabel();
            this.pulseWidthTrackBar = new Telerik.WinControls.UI.RadTrackBar();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel1 = new Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel();
            this.lookupWindowTrackBar = new Telerik.WinControls.UI.RadTrackBar();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.lookupWindpwLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.enableCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pulseWidthLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pulseWidthTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupWindowTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupWindpwLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableCheckBox.Location = new System.Drawing.Point(3, 3);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(60, 18);
            this.enableCheckBox.TabIndex = 0;
            this.enableCheckBox.Text = "Enabled";
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.thresholdLabel.Location = new System.Drawing.Point(218, 3);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(29, 18);
            this.thresholdLabel.TabIndex = 6;
            this.thresholdLabel.Text = "3 dB";
            // 
            // thresholdTrackBar
            // 
            this.thresholdTrackBar.AllowKeyNavigation = true;
            this.thresholdTrackBar.AllowShowFocusCues = true;
            this.thresholdTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.thresholdTrackBar, 2);
            this.thresholdTrackBar.LargeTickFrequency = 10;
            this.thresholdTrackBar.Location = new System.Drawing.Point(3, 27);
            this.thresholdTrackBar.Maximum = 30F;
            this.thresholdTrackBar.Name = "thresholdTrackBar";
            this.thresholdTrackBar.Size = new System.Drawing.Size(244, 34);
            this.thresholdTrackBar.SmallTickFrequency = 2;
            this.thresholdTrackBar.SnapMode = Telerik.WinControls.UI.TrackBarSnapModes.None;
            this.thresholdTrackBar.TabIndex = 1;
            this.thresholdTrackBar.Value = 10F;
            // 
            // pulseWidthLabel
            // 
            this.pulseWidthLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pulseWidthLabel.Location = new System.Drawing.Point(214, 67);
            this.pulseWidthLabel.Name = "pulseWidthLabel";
            this.pulseWidthLabel.Size = new System.Drawing.Size(33, 18);
            this.pulseWidthLabel.TabIndex = 8;
            this.pulseWidthLabel.Text = "25 µs";
            // 
            // pulseWidthTrackBar
            // 
            this.pulseWidthTrackBar.AllowKeyNavigation = true;
            this.pulseWidthTrackBar.AllowShowFocusCues = true;
            this.pulseWidthTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.pulseWidthTrackBar, 2);
            this.pulseWidthTrackBar.LargeTickFrequency = 10;
            this.pulseWidthTrackBar.Location = new System.Drawing.Point(3, 91);
            this.pulseWidthTrackBar.Maximum = 101F;
            this.pulseWidthTrackBar.Minimum = 1F;
            this.pulseWidthTrackBar.Name = "pulseWidthTrackBar";
            this.pulseWidthTrackBar.Size = new System.Drawing.Size(244, 34);
            this.pulseWidthTrackBar.SmallTickFrequency = 5;
            this.pulseWidthTrackBar.SnapMode = Telerik.WinControls.UI.TrackBarSnapModes.None;
            this.pulseWidthTrackBar.TabIndex = 2;
            this.pulseWidthTrackBar.Value = 10F;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Pulse Width";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lookupWindowTrackBar, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.enableCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pulseWidthTrackBar, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.thresholdTrackBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.thresholdLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pulseWidthLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lookupWindpwLabel, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 200);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // lookupWindowTrackBar
            // 
            this.lookupWindowTrackBar.AllowKeyNavigation = true;
            this.lookupWindowTrackBar.AllowShowFocusCues = true;
            this.lookupWindowTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.lookupWindowTrackBar, 2);
            this.lookupWindowTrackBar.LargeTickFrequency = 10;
            this.lookupWindowTrackBar.Location = new System.Drawing.Point(3, 155);
            this.lookupWindowTrackBar.Maximum = 101F;
            this.lookupWindowTrackBar.Minimum = 1F;
            this.lookupWindowTrackBar.Name = "lookupWindowTrackBar";
            this.lookupWindowTrackBar.Size = new System.Drawing.Size(244, 34);
            this.lookupWindowTrackBar.SmallTickFrequency = 5;
            this.lookupWindowTrackBar.SnapMode = Telerik.WinControls.UI.TrackBarSnapModes.None;
            this.lookupWindowTrackBar.TabIndex = 11;
            this.lookupWindowTrackBar.Value = 26F;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Location = new System.Drawing.Point(3, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Lookup Window";
            // 
            // lookupWindpwLabel
            // 
            this.lookupWindpwLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lookupWindpwLabel.Location = new System.Drawing.Point(217, 131);
            this.lookupWindpwLabel.Name = "lookupWindpwLabel";
            this.lookupWindpwLabel.Size = new System.Drawing.Size(30, 18);
            this.lookupWindpwLabel.TabIndex = 8;
            this.lookupWindpwLabel.Text = "2 ms";
            // 
            // ProcessorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProcessorPanel";
            this.Size = new System.Drawing.Size(250, 200);
            ((System.ComponentModel.ISupportInitialize)(this.enableCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pulseWidthLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pulseWidthTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupWindowTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupWindpwLabel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCheckBox enableCheckBox;
        private Telerik.WinControls.UI.RadLabel thresholdLabel;
        private Telerik.WinControls.UI.RadTrackBar thresholdTrackBar;
        private Telerik.WinControls.UI.RadLabel pulseWidthLabel;
        private Telerik.WinControls.UI.RadTrackBar pulseWidthTrackBar;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadTrackBar lookupWindowTrackBar;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadLabel lookupWindpwLabel;
    }
}
