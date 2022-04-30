using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace Daka
{
    public partial class main : Form
    {
        
        public ItemList itemList;

        private const string ItemListFileName = "ItemList.json";
        //private const string ItemListPath = "./";

        //private const string version = "0.0";

        /// <summary>
        /// 主窗口生成
        /// </summary>
        public main()
        {
            InitializeComponent();
            showDateTime();


            if (File.Exists(ItemListFileName))
            {
                /*Binary IO 只能读取固定结构的数据，弃用
                using (var stream = File.Open(ItemListFileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                    }
                }
                */
                ///使用Json序列化
                ///
                string jsonString = File.ReadAllText(ItemListFileName);
                JsonIO input = new JsonIO(jsonString);
                itemList = new ItemList(input);
                Console.WriteLine("readok!");

            }
            else
            {
                itemList = new ItemList();
            }

            Show_checklist(DateTime.Now);
            Show_Listview();
        }


       /// <summary>
        /// timer 控制时钟刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            showDateTime();
        }

        /// <summary>
        /// 左侧上方时间信息生成
        /// </summary>
        public void showDateTime()
        {
            DateTime currentDateTime = DateTime.Now;
            Date.Text = currentDateTime.ToLongDateString().ToString();
            Time.Text = currentDateTime.ToLongTimeString().ToString();
            Weekday.Text = currentDateTime.DayOfWeek.ToString();
            Date.Update();
            Time.Update();
            Weekday.Update();
        }


        /// <summary>
        /// 左侧日期选择框数据改变：改变后查看所选日期的任务完成情况
        /// 日期不为当天时，无法保存checklist状态。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date != DateTime.Today)
            {
                confirm.Enabled = false;
            }
            else
            {
                confirm.Enabled = true;
                Show_checklist(dateTimePicker1.Value);
            }
        }


        /// <summary>
        /// 左侧下方check李斯特生成，显示dt当天的打卡情况
        /// </summary>
        /// <param name="dt"></param>
        public void Show_checklist(DateTime dt)
        {
            checkedListBox1.Items.Clear();
            ITEM[] items = itemList.GetItems();
            int itemNum = items.Count();
            foreach(ITEM item in items)
            {
                checkedListBox1.Items.Add(item.Id);
            }
            checkedListBox1.Update();
            checkedListBox1.Show();
        }


        /// <summary>
        /// 左侧下方“记录”按钮按下后的操作：
        /// 1、保存打卡记录（待实现）;
        /// 2、保存ItemList信息 ;
        /// 3、重绘所有list ;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirm_Click(object sender, EventArgs e)
        {
            foreach(Object itemChecked in checkedListBox1.CheckedItems)
            {
                Console.WriteLine("check:" + itemChecked.ToString());
                itemList.Daka(itemChecked.ToString());
            }

            saveItemList();
            drawLists();
        }


        /////////////////////////////////////////
        ///分割线
        /////////////////////////////////////////
        ///
        
        /// <summary>
        /// 新建打卡按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加新打卡_Click(object sender, EventArgs e)
        {
            NewDaka form2 = new NewDaka();
            form2.mydelegateEvent += NewItemFromForm2;
            form2.ShowDialog(this);
        }


        /// <summary>
        /// 右侧打卡表格生成（待改动）
        /// </summary>
        public void Show_Listview()
        {
            
            listView1.Items.Clear();
            listView1.Columns.Clear();
            ITEM[] items = itemList.GetItems();
            listView1.BeginUpdate();
            listView1.View = View.Details;
            //ColumnHeader columnHeader = new ColumnHeader();
            //columnHeader.Text = "打卡事项";
            //columnHeader.Width = 120;
            //columnHeader.TextAlign = HorizontalAlignment.Right;
            listView1.Columns.Add("打卡事项", 60, HorizontalAlignment.Right);
            for (int i = 0; i <= 2; i++)
            {
                listView1.Columns.Add(DateTime.Now.AddDays(-i).ToShortDateString().Substring(5), 38, HorizontalAlignment.Center);
            }

            //string[] subItem = { "1", "2", "3" };
            foreach (ITEM item in items)
            {
                ListViewItem listViewItem = new ListViewItem();///
                listViewItem.Text = item.Id;
                listViewItem.SubItems.Add(item.IsDakaDay(DateTime.Today) ? "yes" :" ");
                listViewItem.SubItems.Add(item.IsDakaDay(DateTime.Today.AddDays(-1)) ? "yes" : " ");
                listView1.Items.Add(listViewItem);
            }
            listView1.EndUpdate();
            //listView1.Update();
            listView1.Show();

        }

         
        /// <summary>
        /// 绘制checklist与打卡记录Listview；
        /// checklist为当天
        /// </summary>
        public void drawLists()
        {
            Show_checklist(DateTime.Today);
            Show_Listview();
        }

        //////////////////////////////////////////
        ///
        //////////////////////////////////////////

        /// <summary>
        /// 保存ItemList类为JsonIO并存入ItemListFileName指向的文件（json）。
        /// （ItemListFileName后续可设为自填选项）
        /// </summary>
        private void saveItemList()
        {
            JsonIO save = new JsonIO(itemList);
            string jsonString = JsonSerializer.Serialize<JsonIO>(save);
            Console.WriteLine(jsonString);
            if (!File.Exists(ItemListFileName))
            {
                File.Create(ItemListFileName).Close();
            }
            File.WriteAllText(ItemListFileName, jsonString);
        }


        /// <summary>
        /// 来自新建项目的item，添加到项目列表中（委托）
        /// </summary>
        /// <param name="item"></param>
        private void NewItemFromForm2(string id, int duration, DateTime startdate)
        {
            itemList.NewItem(id, startdate, duration);
            saveItemList();
            drawLists();
        }


        /// <summary>
        /// 修改(委托)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id_new"></param>
        /// <param name="duration"></param>
        private void ChangeItemInfo(string id, ITEM itemInfo, bool needDelete)
        {
            if (needDelete)
            {
                itemList.DeleteItem(id);
            }
            else
            {
                itemList.changeItem(id, itemInfo);
            }
            saveItemList();
            drawLists();
        }


        private void ListView双击项目菜单(object sender, EventArgs e)
        {
            string itemName = listView1.SelectedItems[0].Text;
            Console.WriteLine(itemName);
            ChangeDaka form2 = new ChangeDaka(ref itemList, itemName);
            form2.changeItemDelegateEvent += ChangeItemInfo;
            form2.ShowDialog(this);
            
        }






        /*private void ListView右键新建项(Object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                
            }
        }*/

        /// <summary>
        /// 设置窗口-------------------待写
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 设置_Click(object sender, EventArgs e)
        {

        }
    }
}
