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
            duration = 0;
            item.StartDate = DateTime.Today;
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
                    item.Duration = duration;
                    dateTimePicker1.Value = item.StopDate();
                }
                else if(duration > 0)
                {
                    MessageBox.Show("真的吗?", "???", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("截止日期不能早于明天哦", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox2.Text = "";
                }

                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                return;
            }

            if(dateTimePicker1.Value != item.StopDate())
            {
                item.Duration = item.DaysFromStartDate(dateTimePicker1.Value);
                textBox2.Text = item.Duration.ToString();
            }
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
