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
    public partial class NewDaka : Form
    {
        public int duration;
        public TimeSpan dt;
        public ITEM item;


        public NewDaka()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (isNotNull(textBox2.Text))
            {
                try
                {
                    duration = Convert.ToInt32(textBox2.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("请输入一个正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox2.Text = "";
                }

                if(duration > 0 && duration < 365000)
                {
                    dateTimePicker1.Value = DateTime.Now.Date.AddDays(duration);
                }
                else if(duration != 0)
                {
                    MessageBox.Show("真的吗?", "???", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                    textBox2.Text = "";
                }

                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dt = dateTimePicker1.Value - DateTime.Today;
            duration = dt.Days;
        }


        /// <summary>
        /// 使用委托在窗口间传递Item值
        /// 将item传回主界面并存入Itemlist;
        /// </summary>
        /// <param name="item"></param>
        public delegate void addItemDelegate(string id, int duration, DateTime startDate);
        public event addItemDelegate mydelegateEvent;

        private void button1_Click(object sender, EventArgs e)
        {
            if (isNotNull(itemName.Text))
            {
                mydelegateEvent(itemName.Text, duration, DateTime.Today);
                Close();
            }
            else
            {
                MessageBox.Show("请输入打卡项目的名字","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private bool isNotNull(string s)
        {
            return s != null && s.Length > 0;
        }
    }
}
