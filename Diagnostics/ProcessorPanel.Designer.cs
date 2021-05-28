namespace SDRSharp.Plugin.Diagnostics
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            this.tableLayoutPanel1 = new Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.enableCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.sourceComboBox = new Telerik.WinControls.UI.RadDropDownList();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.averageTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.referenceTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.acquireButton = new Telerik.WinControls.UI.RadButton();
            this.integrationNumericUpDown = new Telerik.WinControls.UI.RadSpinEditor();
            this.rebuildButton = new Telerik.WinControls.UI.RadButton();
            this.resetButton = new Telerik.WinControls.UI.RadButton();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.averageTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.referenceTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acquireButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integrationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rebuildButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetButton)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.enableCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sourceComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.averageTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.referenceTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.acquireButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.integrationNumericUpDown, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.rebuildButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.resetButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 170);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Reference";
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableCheckBox.Location = new System.Drawing.Point(3, 5);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(65, 17);
            this.enableCheckBox.TabIndex = 0;
            this.enableCheckBox.Text = "Enabled";
            this.enableCheckBox.CheckStateChanged += new System.EventHandler(this.enableCheckBox_CheckedChanged);
            // 
            // sourceComboBox
            // 
            this.sourceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.sourceComboBox, 2);
            this.sourceComboBox.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "Filtered IF";
            radListDataItem2.Text = "Full IQ";
            radListDataItem3.Text = "Demodulator";
            this.sourceComboBox.Items.Add(radListDataItem1);
            this.sourceComboBox.Items.Add(radListDataItem2);
            this.sourceComboBox.Items.Add(radListDataItem3);
            this.sourceComboBox.Location = new System.Drawing.Point(96, 31);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(151, 20);
            this.sourceComboBox.TabIndex = 7;
            this.sourceComboBox.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.sourceComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Source";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Integration (sec)";
            // 
            // averageTextBox
            // 
            this.averageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.averageTextBox, 2);
            this.averageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.averageTextBox.Location = new System.Drawing.Point(96, 114);
            this.averageTextBox.Name = "averageTextBox";
            this.averageTextBox.ReadOnly = true;
            this.averageTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.averageTextBox.Size = new System.Drawing.Size(151, 30);
            this.averageTextBox.TabIndex = 14;
            this.averageTextBox.Text = "0.00 dB";
            this.averageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Power:";
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.referenceTextBox.Location = new System.Drawing.Point(96, 58);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.ReadOnly = true;
            this.referenceTextBox.Size = new System.Drawing.Size(72, 20);
            this.referenceTextBox.TabIndex = 11;
            this.referenceTextBox.Text = "0.00 dB";
            this.referenceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // acquireButton
            // 
            this.acquireButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.acquireButton.Location = new System.Drawing.Point(174, 57);
            this.acquireButton.Name = "acquireButton";
            this.acquireButton.Size = new System.Drawing.Size(73, 22);
            this.acquireButton.TabIndex = 10;
            this.acquireButton.Text = "Acquire";
            this.acquireButton.Click += new System.EventHandler(this.acquireButton_Click);
            // 
            // integrationNumericUpDown
            // 
            this.integrationNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.integrationNumericUpDown.Location = new System.Drawing.Point(96, 86);
            this.integrationNumericUpDown.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.integrationNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.integrationNumericUpDown.Name = "integrationNumericUpDown";
            this.integrationNumericUpDown.NullableValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.integrationNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.integrationNumericUpDown.TabIndex = 13;
            this.integrationNumericUpDown.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.integrationNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.integrationNumericUpDown.ValueChanged += new System.EventHandler(this.integrationNumericUpDown_ValueChanged);
            // 
            // rebuildButton
            // 
            this.rebuildButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rebuildButton.Location = new System.Drawing.Point(174, 85);
            this.rebuildButton.Name = "rebuildButton";
            this.rebuildButton.Size = new System.Drawing.Size(73, 23);
            this.rebuildButton.TabIndex = 17;
            this.rebuildButton.Text = "Rebuild";
            this.rebuildButton.Click += new System.EventHandler(this.rebuildButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.resetButton, 2);
            this.resetButton.Location = new System.Drawing.Point(96, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(151, 22);
            this.resetButton.TabIndex = 16;
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 500;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // ProcessorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProcessorPanel";
            this.Size = new System.Drawing.Size(250, 170);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.averageTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.referenceTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acquireButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integrationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rebuildButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.DoubleBufferedTableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadCheckBox enableCheckBox;
        private Telerik.WinControls.UI.RadDropDownList sourceComboBox;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadButton acquireButton;
        private Telerik.WinControls.UI.RadTextBox referenceTextBox;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadSpinEditor integrationNumericUpDown;
        private Telerik.WinControls.UI.RadTextBox averageTextBox;
        private System.Windows.Forms.Timer refreshTimer;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadButton resetButton;
        private Telerik.WinControls.UI.RadButton rebuildButton;
    }
}
