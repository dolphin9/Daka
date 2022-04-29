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
        private DateTime currentDateTime;
        public ItemList itemList;

        private const string ItemListFileName = "ItemList.json";


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

        public void Show_checklist(DateTime dt)
        {
            checkedListBox1.Items.Clear();
            Item[] items = itemList.GetItems();
            int itemNum = items.Count();
            foreach(Item item in items)
            {
                checkedListBox1.Items.Add(item.Id());
            }
            checkedListBox1.Update();
            checkedListBox1.Show();
        }

        public void Show_Listview()
        {
            
            listView1.Items.Clear();
            Item[] items = itemList.GetItems();
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
            foreach (Item item in items)
            {
                ListViewItem listViewItem = new ListViewItem();///
                listViewItem.Text = item.Id();
                listViewItem.SubItems.Add(item.IsDakaDay(DateTime.Today) ? "yes" :" ");
                listViewItem.SubItems.Add(item.IsDakaDay(DateTime.Today.AddDays(-1)) ? "yes" : " ");
                listView1.Items.Add(listViewItem);
            }
            listView1.EndUpdate();
            //listView1.Update();
            listView1.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            showDateTime();
        }

        public void showDateTime()
        {
            currentDateTime = DateTime.Now;
            Date.Text = currentDateTime.ToLongDateString().ToString();
            Time.Text = currentDateTime.ToLongTimeString().ToString();
            Weekday.Text = currentDateTime.DayOfWeek.ToString();
            Date.Update();
            Time.Update();
            Weekday.Update();
        }



        private void NewItemFromForm2(Item item)
        {
            Console.WriteLine(item.Id() + ":" + item.ToString());
            itemList.AddItem(item);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date != currentDateTime.Date)
            {
                confirm.Enabled = false;
            }
            else
            {
                confirm.Enabled = true;
                Show_checklist(dateTimePicker1.Value);
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            saveItemList();
        }

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

        private void 新建打卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDaka form2 = new NewDaka();
            form2.mydelegateEvent += NewItemFromForm2;
            form2.ShowDialog(this);
        }
    }
}
