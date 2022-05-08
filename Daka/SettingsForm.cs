using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daka
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            FilePathLabel.Text =Settings2.Default.FilePath;
            numericUpDown1.Value = Settings2.Default.viewDays;
        }

        private void chooseFilePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = FilePathLabel.Text;
            folderBrowserDialog1.ShowDialog();
            FilePathLabel.Text = folderBrowserDialog1.SelectedPath;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value > 31) { numericUpDown1.Value = 31;}
            else if(numericUpDown1.Value < 5 ) { numericUpDown1.Value = 5;}
        }

        private void ChangeViewDays_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                if (MessageBox.Show("确认修改？", "修改", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Settings2.Default.viewDays = (int)numericUpDown1.Value;
                    Settings2.Default.FilePath = FilePathLabel.Text;
                    Settings2.Default.Save();
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            FilePathLabel.Text = Settings2.Default.FilePath;
            numericUpDown1.Value = Settings2.Default.viewDays;
        }

        private bool hasChanged()
        {
            bool flag = false;

            flag |= FilePathLabel.Text != Settings2.Default.FilePath;
            flag |= numericUpDown1.Value != Settings2.Default.viewDays;

            return flag;
        }
    }
}
