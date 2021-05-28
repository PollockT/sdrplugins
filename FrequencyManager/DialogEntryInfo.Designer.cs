namespace SDRSharp.Plugin.FrequencyManager
{
    partial class DialogEntryInfo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.lblMode = new Telerik.WinControls.UI.RadLabel();
            this.comboGroupName = new Telerik.WinControls.UI.RadDropDownList();
            this.textBoxName = new Telerik.WinControls.UI.RadTextBox();
            this.frequencyNumericUpDown = new Telerik.WinControls.UI.RadSpinEditor();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.shiftNumericUpDown = new Telerik.WinControls.UI.RadSpinEditor();
            this.label6 = new Telerik.WinControls.UI.RadLabel();
            this.nudFilterBandwidth = new Telerik.WinControls.UI.RadSpinEditor();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.favouriteCb = new Telerik.WinControls.UI.RadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFilterBandwidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.favouriteCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select an existing group or enter a new group name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Group:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Frequency:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 187);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mode:";
            // 
            // lblMode
            // 
            this.lblMode.Location = new System.Drawing.Point(89, 187);
            this.lblMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(2, 2);
            this.lblMode.TabIndex = 5;
            // 
            // comboGroupName
            // 
            this.comboGroupName.Location = new System.Drawing.Point(85, 34);
            this.comboGroupName.Margin = new System.Windows.Forms.Padding(2);
            this.comboGroupName.Name = "comboGroupName";
            this.comboGroupName.Size = new System.Drawing.Size(178, 20);
            this.comboGroupName.TabIndex = 0;
            this.comboGroupName.TextChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(85, 64);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(178, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // frequencyNumericUpDown
            // 
            this.frequencyNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.frequencyNumericUpDown.Location = new System.Drawing.Point(85, 96);
            this.frequencyNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.frequencyNumericUpDown.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.frequencyNumericUpDown.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.frequencyNumericUpDown.Name = "frequencyNumericUpDown";
            this.frequencyNumericUpDown.Size = new System.Drawing.Size(124, 20);
            this.frequencyNumericUpDown.TabIndex = 2;
            this.frequencyNumericUpDown.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.frequencyNumericUpDown.ThousandsSeparator = true;
            this.frequencyNumericUpDown.ValueChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(125, 245);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(67, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "O&K";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(196, 245);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            // 
            // shiftNumericUpDown
            // 
            this.shiftNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.shiftNumericUpDown.Location = new System.Drawing.Point(85, 126);
            this.shiftNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.shiftNumericUpDown.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.shiftNumericUpDown.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.shiftNumericUpDown.Name = "shiftNumericUpDown";
            this.shiftNumericUpDown.Size = new System.Drawing.Size(124, 20);
            this.shiftNumericUpDown.TabIndex = 3;
            this.shiftNumericUpDown.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.shiftNumericUpDown.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 129);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Shift:";
            // 
            // nudFilterBandwidth
            // 
            this.nudFilterBandwidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFilterBandwidth.Location = new System.Drawing.Point(85, 156);
            this.nudFilterBandwidth.Margin = new System.Windows.Forms.Padding(2);
            this.nudFilterBandwidth.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudFilterBandwidth.Name = "nudFilterBandwidth";
            this.nudFilterBandwidth.Size = new System.Drawing.Size(124, 20);
            this.nudFilterBandwidth.TabIndex = 4;
            this.nudFilterBandwidth.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFilterBandwidth.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 160);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Filter BW:";
            // 
            // favouriteCb
            // 
            this.favouriteCb.Location = new System.Drawing.Point(85, 207);
            this.favouriteCb.Name = "favouriteCb";
            this.favouriteCb.Size = new System.Drawing.Size(66, 18);
            this.favouriteCb.TabIndex = 16;
            this.favouriteCb.Text = "Favourite";
            // 
            // DialogEntryInfo
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(276, 279);
            this.Controls.Add(this.favouriteCb);
            this.Controls.Add(this.nudFilterBandwidth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.shiftNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.frequencyNumericUpDown);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.comboGroupName);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogEntryInfo";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Entry Information";
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFilterBandwidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.favouriteCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadLabel label5;
        private Telerik.WinControls.UI.RadLabel lblMode;
        private Telerik.WinControls.UI.RadDropDownList comboGroupName;
        private Telerik.WinControls.UI.RadTextBox textBoxName;
        private Telerik.WinControls.UI.RadSpinEditor frequencyNumericUpDown;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadSpinEditor shiftNumericUpDown;
        private Telerik.WinControls.UI.RadLabel label6;
        private Telerik.WinControls.UI.RadSpinEditor nudFilterBandwidth;
        private Telerik.WinControls.UI.RadLabel label7;
        private Telerik.WinControls.UI.RadCheckBox favouriteCb;
    }
}