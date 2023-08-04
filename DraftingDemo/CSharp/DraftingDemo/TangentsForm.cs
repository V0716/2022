using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class TangentsForm : Form
    {

        public TangentsForm()
        {
            InitializeComponent();
            lineRadioButton.Checked = true;
        }
        
        private void selectButton_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CircleTangents = circlesRadioButton.Checked;
            LineTangents = lineRadioButton.Checked;
            radiusLabel.Enabled = circlesRadioButton.Checked;
            radiusTextBox.Enabled=circlesRadioButton.Checked;
            optionsGruopBox.Enabled=circlesRadioButton.Checked;

        }

        private void circlesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CircleTangents = circlesRadioButton.Checked;
            LineTangents = lineRadioButton.Checked;
            radiusLabel.Enabled = circlesRadioButton.Checked;
            radiusTextBox.Enabled=circlesRadioButton.Checked;
            optionsGruopBox.Enabled=circlesRadioButton.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double val;
            if (Double.TryParse(radiusTextBox.Text, out val))
            {
                TangentRadius = val;
            }

        }
                
        public double TangentRadius = 10;

        public bool LineTangents { get; set; }

        public bool CircleTangents { get; set; }

        public bool TrimTangents { get; set; }

        public bool FlipTangents { get; set; }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            TrimTangents = trimCheckBox.Checked;
        }

        private void flipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FlipTangents = flipCheckBox.Checked;
        }

        
    }
}
