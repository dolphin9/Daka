using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Daka
{
 
    /// <summary>
    /// ItemList为一张打卡项目的表\/
    /// 实现对于Item的增\/删查改
    /// 实现生成特定日期的打卡列表
    /// 需要改成单例模式
    /// </summary>
    public class ItemList
    {
        /// <summary>
        /// items为所有项目集合，索引为项目名称
        /// </summary>
        private Dictionary<string,Item> items;
        /// <summary>
        /// itemAmount记录项目总数
        /// </summary>
        private int itemAmount;

        /// <summary>
        /// 建立空项目列表
        /// </summary>
        public ItemList()
        {
            items = new Dictionary<string, Item>();
            itemAmount = 0;
        }
        
        /// <summary>
        /// 从JsonIO类型提取输入信息建立表单
        /// </summary>
        /// <param name="input"></param>
        public ItemList(JsonIO input)
        {
            items = new Dictionary<string, Item>();
            itemAmount = input.ITEM_AMOUNT;
            for(int i = 0; i < itemAmount; i++)
            {
                items.Add(input.Items[i].Id, new Item(input.Items[i]));
                Console.WriteLine(items[input.Items[i].Id].Id());
            }
        }

        /// <summary>
        /// 得到Item数量
        /// </summary>
        /// <returns></returns>
        public int ItemAmount() { return itemAmount; }

        /// <summary>
        /// 将 items 存为 JsonOI.ITEM 类型
        /// </summary>
        /// <returns></returns>
        public ITEM[] GetItems()
        {
            ITEM[] ret = new ITEM[itemAmount];
            int i = 0;
            foreach (KeyValuePair<string, Item> item in items)
            {
                ret[i].Id = item.Value.Id();
                ret[i].Duration = item.Value.Duration();
                ret[i].StartDate = item.Value.StartDate();
                ret[i].DakaDate = item.Value.getDakaDate();
                i++;
            }
            return ret;
        }

        /// <summary>
        /// 增加一个Item
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="startdate">开始日期</param>
        /// <param name="duration">持续时间</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddItem(string name,DateTime startdate, int duration)
        {
            if (name == null || name == "")
            {
                throw new ArgumentNullException("name");
            }
            if (items.ContainsKey(name))
            {
                throw new InvalidOperationException("name");
            }
            else
            {
                items.Add(name, new Item(name, duration, startdate));
                itemAmount++;
            }
            
        }

        /// <summary>
        /// 删除一个Item
        /// </summary>
        /// <param name="name"></param>
        public void DeletItem(string name)
        {
            try
            {
                items.Remove(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
