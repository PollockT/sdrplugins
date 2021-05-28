namespace SDRSharp.Plugin.SNRLogger
{
    partial class PluginPanel
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
            this.intervalLabel = new Telerik.WinControls.UI.RadLabel();
            this.intervalTrackBar = new Telerik.WinControls.UI.RadTrackBar();
            this.tableLayoutPanel1 = new Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel();
            this.snrTimer = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.enableCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalTrackBar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableCheckBox.Location = new System.Drawing.Point(3, 3);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(65, 17);
            this.enableCheckBox.TabIndex = 0;
            this.enableCheckBox.Text = "Enabled";
            this.enableCheckBox.CheckStateChanged += new System.EventHandler(this.enableCheckBox_CheckedChanged);
            // 
            // intervalLabel
            // 
            this.intervalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.intervalLabel.Location = new System.Drawing.Point(207, 3);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(40, 18);
            this.intervalLabel.TabIndex = 6;
            this.intervalLabel.Text = "0.1 sec";
            // 
            // intervalTrackBar
            // 
            this.intervalTrackBar.AllowKeyNavigation = true;
            this.intervalTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.intervalTrackBar, 2);
            this.intervalTrackBar.LargeTickFrequency = 100;
            this.intervalTrackBar.Location = new System.Drawing.Point(3, 27);
            this.intervalTrackBar.Maximum = 601F;
            this.intervalTrackBar.Minimum = 1F;
            this.intervalTrackBar.Name = "intervalTrackBar";
            this.intervalTrackBar.Size = new System.Drawing.Size(244, 34);
            this.intervalTrackBar.SmallTickFrequency = 50;
            this.intervalTrackBar.TabIndex = 1;
            this.intervalTrackBar.Value = 1F;
            this.intervalTrackBar.ValueChanged += new System.EventHandler(this.intervalTrackBar_Scroll);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.enableCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.intervalTrackBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.intervalLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 80);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // snrTimer
            // 
            this.snrTimer.Tick += new System.EventHandler(this.snrTimer_Tick);
            // 
            // PluginPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PluginPanel";
            this.Size = new System.Drawing.Size(250, 80);
            ((System.ComponentModel.ISupportInitialize)(this.enableCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalTrackBar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCheckBox enableCheckBox;
        private Telerik.WinControls.UI.RadLabel intervalLabel;
        private Telerik.WinControls.UI.RadTrackBar intervalTrackBar;
        private Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer snrTimer;
    }
}
