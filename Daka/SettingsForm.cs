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
        public SettingsForm(string filepath, int viewDays)
        {
            InitializeComponent();
            FilePathLabel.Text = filepath;
            numericUpDown1.Value = viewDays;
        }

        private void chooseFilePath_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog1 = new FolderBrowserDialog();
            //folderBrowserDialog1.ShowDialog();
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

        public delegate void changeSettingsDelegate(int viewdays);
        public event changeSettingsDelegate changeSettingsDelegateEvent;
        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Enabled)
            {
                if (MessageBox.Show("确认修改？", "修改", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    changeSettingsDelegateEvent( (int)numericUpDown1.Value );
                    Close();
                }
            }
        }
    }
}
