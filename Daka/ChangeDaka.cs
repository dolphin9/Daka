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
    public partial class ChangeDaka : Form
    {
        string itemId;
        ITEM itemInfo;

        public ChangeDaka(ref ItemList itemList, string ItemId)
        {
            InitializeComponent();
            itemId = ItemId;
            itemInfo = itemList.getItemInfo(ItemId);


            itemName.Text = itemInfo.Id;
            
            totalDays.Text = " / " + (itemInfo.Duration + 1).ToString();

            DateTime dt = itemInfo.StopDate();
            dateTimePicker1.Value = dt;
            Console.WriteLine(dateTimePicker1.Value.ToString() + " = " + dt.ToString());
              
            remainDays.Text = remaindays().ToString() ;

            itemName.Enabled = false;
            remainDays.Enabled = false;
            dateTimePicker1.Enabled = false;
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            itemName.Enabled = true;
            remainDays.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        public delegate void changeItemDelegate(string id, ITEM itemInfo, bool DeleteOrNot);
        public event changeItemDelegate changeItemDelegateEvent;
        private void ConfirmButton_Click(object sender, EventArgs e)
        {

            if (isNotNull(itemName.Text))
            {
                itemInfo.Id = itemName.Text;
                if (MessageBox.Show("确认修改？", "修改", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    changeItemDelegateEvent(itemId, itemInfo, false);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("打卡项目的名字不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void DeletButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除？", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                changeItemDelegateEvent(itemId, itemInfo, true);
                Close();
            }
        }

   
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int rd;
            if (isNotNull(remainDays.Text))
            {
                try
                {
                     rd = Convert.ToInt32(remainDays.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("请输入一个正整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    remainDays.Text = "";
                    return;
                }

                if (rd >= 0 && rd < 365000)
                {
                    if(rd == 0)
                    {
                        if(MessageBox.Show("确定结束这项打卡吗?", "结束打卡", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        {
                            remainDays.Text = remaindays().ToString();
                            return;
                        }
                    }
                    DateTime stopDate = DateTime.Today.AddDays(rd);
                    itemInfo.Duration = (stopDate - itemInfo.StartDate).Days;
                    dateTimePicker1.Value = stopDate;
                    totalDays.Text = " / " + (itemInfo.Duration +1).ToString();
                }
                else if (rd > 0)
                {
                    MessageBox.Show("真的吗?", "???", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                    remainDays.Text = "";
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(remaindays() != itemInfo.Duration)
            {
                totalDays.Text = " / " + ((dateTimePicker1.Value - itemInfo.StartDate).Days + 1).ToString();          
                remainDays.Text = remaindays().ToString();
            }

            
        }
        private bool isNotNull(string s)
        {
            return s != null && s.Length > 0;
        }

        private int remaindays(){
            return (dateTimePicker1.Value.Date - DateTime.Today).Days;
        }

    }
}
