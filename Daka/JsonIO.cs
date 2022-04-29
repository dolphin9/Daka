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

        /// <summary>
        /// 转换item
        /// </summary>
        /// <param name="item"></param>
        public ITEM(Item item)
        {
            this.Id = item.Id();
            this.Duration = item.Duration();
            this.StartDate = item.StartDate();
            this.DakaDate = item.getDakaDate();
        }
    }
    public class JsonIO
    {
        [JsonInclude]
        public int ITEM_AMOUNT;
        [JsonInclude]
        public ITEM[] Items;

        private Item[] items;
        
        /// <summary>
        /// ItemList to JsonIO
        /// </summary>
        /// <param name="itemLsit"></param>
        public JsonIO(ItemList itemLsit)
        {
            ITEM_AMOUNT = itemLsit.ItemAmount();
            Items = new ITEM[ITEM_AMOUNT];
            items = itemLsit.GetItems();
            for(int i = 0; i < ITEM_AMOUNT; i++)
            {
                Items[i] = new ITEM(items[i]);
            }

        }
        /// <summary>
        /// JsonString to  JsonIO 
        /// </summary>
        /// <param name="jsonString"></param>
        public JsonIO(string jsonString)
        {
            JsonIO tmp =JsonSerializer.Deserialize<JsonIO>(jsonString);
            this.Items = tmp.Items;
            this.ITEM_AMOUNT = tmp.ITEM_AMOUNT;
        }
        
        public JsonIO(){ }

    }

    

}
