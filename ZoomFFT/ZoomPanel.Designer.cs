namespace SDRSharp.Plugin.ZoomFFT
{
    partial class ZoomPanel
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
            this.enableFilterCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.mainTableLayoutPanel = new Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel();
            this.enableAudioCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.enableMPXCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.enableIFCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.enableFilterCheckBox)).BeginInit();
            this.mainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enableAudioCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableMPXCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableIFCheckBox)).BeginInit();
            this.SuspendLayout();
            // 
            // enableFilterCheckBox
            // 
            this.enableFilterCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableFilterCheckBox.Location = new System.Drawing.Point(128, 3);
            this.enableFilterCheckBox.Name = "enableFilterCheckBox";
            this.enableFilterCheckBox.Size = new System.Drawing.Size(81, 18);
            this.enableFilterCheckBox.TabIndex = 0;
            this.enableFilterCheckBox.Text = "Enable Filter";
            this.enableFilterCheckBox.CheckStateChanged += new System.EventHandler(this.enableFilterCheckBox_CheckedChanged);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.Controls.Add(this.enableAudioCheckBox, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.enableMPXCheckBox, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.enableIFCheckBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.enableFilterCheckBox, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 4;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(250, 90);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // enableAudioCheckBox
            // 
            this.enableAudioCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableAudioCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableAudioCheckBox.Location = new System.Drawing.Point(3, 51);
            this.enableAudioCheckBox.Name = "enableAudioCheckBox";
            this.enableAudioCheckBox.Size = new System.Drawing.Size(86, 18);
            this.enableAudioCheckBox.TabIndex = 2;
            this.enableAudioCheckBox.Text = "Enable Audio";
            this.enableAudioCheckBox.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.enableAudioCheckBox.CheckStateChanged += new System.EventHandler(this.enableAudioCheckBox_CheckedChanged);
            // 
            // enableMPXCheckBox
            // 
            this.enableMPXCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableMPXCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableMPXCheckBox.Location = new System.Drawing.Point(3, 27);
            this.enableMPXCheckBox.Name = "enableMPXCheckBox";
            this.enableMPXCheckBox.Size = new System.Drawing.Size(80, 18);
            this.enableMPXCheckBox.TabIndex = 1;
            this.enableMPXCheckBox.Text = "Enable MPX";
            this.enableMPXCheckBox.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.enableMPXCheckBox.CheckStateChanged += new System.EventHandler(this.enableMPXCheckBox_CheckedChanged);
            // 
            // enableIFCheckBox
            // 
            this.enableIFCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableIFCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableIFCheckBox.Location = new System.Drawing.Point(3, 3);
            this.enableIFCheckBox.Name = "enableIFCheckBox";
            this.enableIFCheckBox.Size = new System.Drawing.Size(65, 18);
            this.enableIFCheckBox.TabIndex = 3;
            this.enableIFCheckBox.Text = "Enable IF";
            this.enableIFCheckBox.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.enableIFCheckBox.CheckStateChanged += new System.EventHandler(this.enableIFCheckBox_CheckedChanged);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // ZoomPanel
            // 
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "ZoomPanel";
            this.Size = new System.Drawing.Size(250, 90);
            ((System.ComponentModel.ISupportInitialize)(this.enableFilterCheckBox)).EndInit();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enableAudioCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableMPXCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableIFCheckBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadCheckBox enableFilterCheckBox;
        private Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel mainTableLayoutPanel;
        private Telerik.WinControls.UI.RadCheckBox enableIFCheckBox;
        private Telerik.WinControls.UI.RadCheckBox enableAudioCheckBox;
        private Telerik.WinControls.UI.RadCheckBox enableMPXCheckBox;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
