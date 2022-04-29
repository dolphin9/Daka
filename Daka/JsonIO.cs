using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

/// <summary>
/// 由于提供给System.Text.Json转换的数据必须为Public，
/// 在不影响封装的情况下，必须新建一个类用来存储和交互。
/// </summary>
namespace Daka
{

    public struct ITEM
    {
        [JsonInclude]
        public string Id;
        [JsonInclude]
        public int Duration;
        [JsonInclude]
        public DateTime StartDate;
        [JsonInclude]
        public DateTime[] DakaDate;
        public bool IsDakaDay(DateTime dt) /// 可优化
        {
            foreach (DateTime d in DakaDate)
            {
                if (d.Date.Equals(dt.Date))
                    return true;
            }
            return false;
        }

    }
    public class JsonIO
    {
        [JsonInclude]
        public int ITEM_AMOUNT;
        [JsonInclude]
        public ITEM[] Items;

        
        /// <summary>
        /// (输出)ItemList to JsonIO
        /// </summary>
        /// <param name="itemLsit"></param>
        public JsonIO(ItemList itemLsit)
        {
            ITEM_AMOUNT = itemLsit.ItemAmount();
            Items = itemLsit.GetItems();
        }


        /// <summary>
        /// （输入）JsonString to  JsonIO 
        /// </summary>
        /// <param name="jsonString"></param>
        public JsonIO(string jsonString)
        {
            JsonIO tmp =JsonSerializer.Deserialize<JsonIO>(jsonString);
            this.Items = tmp.Items;
            this.ITEM_AMOUNT = tmp.ITEM_AMOUNT;
        }


        /// <summary>
        /// Deserialize必须定义无参构造
        /// </summary>
        public JsonIO(){ }

    }

    

}
