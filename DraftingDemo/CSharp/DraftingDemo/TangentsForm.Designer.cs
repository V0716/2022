namespace WindowsApplication1
{
    partial class TangentsForm
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
            this.lineRadioButton = new System.Windows.Forms.RadioButton();
            this.circlesRadioButton = new System.Windows.Forms.RadioButton();
            this.flipCheckBox = new System.Windows.Forms.CheckBox();
            this.trimCheckBox = new System.Windows.Forms.CheckBox();
            this.radiusTextBox = new System.Windows.Forms.TextBox();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.selectButton = new System.Windows.Forms.Button();
            this.curveTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.optionsGruopBox = new System.Windows.Forms.GroupBox();
            this.curveTypeGroupBox.SuspendLayout();
            this.optionsGruopBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lineRadioButton
            // 
            this.lineRadioButton.AutoSize = true;
            this.lineRadioButton.Location = new System.Drawing.Point(9, 22);
            this.lineRadioButton.Name = "lineRadioButton";
            this.lineRadioButton.Size = new System.Drawing.Size(50, 17);
            this.lineRadioButton.TabIndex = 0;
            this.lineRadioButton.TabStop = true;
            this.lineRadioButton.Text = "Lines";
            this.lineRadioButton.UseVisualStyleBackColor = true;
            this.lineRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // circlesRadioButton
            // 
            this.circlesRadioButton.AutoSize = true;
            this.circlesRadioButton.Location = new System.Drawing.Point(9, 44);
            this.circlesRadioButton.Name = "circlesRadioButton";
            this.circlesRadioButton.Size = new System.Drawing.Size(56, 17);
            this.circlesRadioButton.TabIndex = 1;
            this.circlesRadioButton.TabStop = true;
            this.circlesRadioButton.Text = "Circles";
            this.circlesRadioButton.UseVisualStyleBackColor = true;
            this.circlesRadioButton.CheckedChanged += new System.EventHandler(this.circlesRadioButton_CheckedChanged);
            // 
            // flipCheckBox
            // 
            this.flipCheckBox.AutoSize = true;
            this.flipCheckBox.Location = new System.Drawing.Point(12, 44);
            this.flipCheckBox.Name = "flipCheckBox";
            this.flipCheckBox.Size = new System.Drawing.Size(42, 17);
            this.flipCheckBox.TabIndex = 2;
            this.flipCheckBox.Text = "Flip";
            this.flipCheckBox.UseVisualStyleBackColor = true;
            this.flipCheckBox.CheckedChanged += new System.EventHandler(this.flipCheckBox_CheckedChanged);
            // 
            // trimCheckBox
            // 
            this.trimCheckBox.AutoSize = true;
            this.trimCheckBox.Location = new System.Drawing.Point(12, 23);
            this.trimCheckBox.Name = "trimCheckBox";
            this.trimCheckBox.Size = new System.Drawing.Size(46, 17);
            this.trimCheckBox.TabIndex = 3;
            this.trimCheckBox.Text = "Trim";
            this.trimCheckBox.UseVisualStyleBackColor = true;
            this.trimCheckBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // tangentRadiusTextBox
            // 
            this.radiusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.radiusTextBox.Location = new System.Drawing.Point(138, 95);
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.Size = new System.Drawing.Size(76, 20);
            this.radiusTextBox.TabIndex = 4;
            this.radiusTextBox.Text = "10.0";
            this.radiusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.radiusTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radiusLabel
            // 
            this.radiusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(24, 98);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(106, 13);
            this.radiusLabel.TabIndex = 5;
            this.radiusLabel.Text = "Tangent circle radius";
            // 
            // selectButton
            // 
            this.selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.selectButton.Location = new System.Drawing.Point(148, 124);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(66, 23);
            this.selectButton.TabIndex = 6;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // curveTypeGroupBox
            // 
            this.curveTypeGroupBox.Controls.Add(this.lineRadioButton);
            this.curveTypeGroupBox.Controls.Add(this.circlesRadioButton);
            this.curveTypeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.curveTypeGroupBox.Name = "curveTypeGroupBox";
            this.curveTypeGroupBox.Size = new System.Drawing.Size(114, 71);
            this.curveTypeGroupBox.TabIndex = 7;
            this.curveTypeGroupBox.TabStop = false;
            this.curveTypeGroupBox.Text = "Output curve type";
            // 
            // optionsGruopBox
            // 
            this.optionsGruopBox.Controls.Add(this.trimCheckBox);
            this.optionsGruopBox.Controls.Add(this.flipCheckBox);
            this.optionsGruopBox.Location = new System.Drawing.Point(138, 12);
            this.optionsGruopBox.Name = "optionsGroupBox";
            this.optionsGruopBox.Size = new System.Drawing.Size(76, 71);
            this.optionsGruopBox.TabIndex = 8;
            this.optionsGruopBox.TabStop = false;
            this.optionsGruopBox.Text = "Options";
            // 
            // TangentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 162);
            this.Controls.Add(this.optionsGruopBox);
            this.Controls.Add(this.curveTypeGroupBox);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.radiusLabel);
            this.Controls.Add(this.radiusTextBox);
            this.Name = "TangentsForm";
            this.Text = "Tan. curves";
            this.curveTypeGroupBox.ResumeLayout(false);
            this.curveTypeGroupBox.PerformLayout();
            this.optionsGruopBox.ResumeLayout(false);
            this.optionsGruopBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton lineRadioButton;
        private System.Windows.Forms.RadioButton circlesRadioButton;
        private System.Windows.Forms.CheckBox flipCheckBox;
        private System.Windows.Forms.CheckBox trimCheckBox;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.GroupBox curveTypeGroupBox;
        private System.Windows.Forms.GroupBox optionsGruopBox;
    }
}