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
        public Item item;


        public NewDaka()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox2.Text != "")
            {
                try
                {
                    duration = Convert.ToInt32(textBox2.Text);
                }
                catch (FormatException ex)
                {
                    Error form3 = new Error("请输入一个整数");
                    form3.ShowDialog();
                }
                dateTimePicker1.Value = DateTime.Now.Date.AddDays(duration);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dt = dateTimePicker1.Value - DateTime.Now;
            duration = dt.Days;
        }


        /// <summary>
        /// 使用委托在窗口间传递Item值
        /// 将item传回主界面并存入Itemlist;
        /// </summary>
        /// <param name="item"></param>
        public delegate void mydelegate(Item item);
        public event mydelegate mydelegateEvent;

        private void button1_Click(object sender, EventArgs e)
        {
            item = new Item(textBox1.Text, duration, DateTime.Now);
            mydelegateEvent(this.item);
            Close();
        }
    }
}
