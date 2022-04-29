using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Daka
{
    /// <summary>
    /// 记录打卡项目的具体信息
    /// </summary>
    public class Item
    {
        private string id;
        private int duration;
        private DateTime startDate, stopDate;
        private List<DateTime> dakaDate;
        private int dakaDays;

        public Item()
        {
            id = "";
            duration = 0;
            startDate = DateTime.Now;
            stopDate = DateTime.Now;
            dakaDays = 0;
        }

        public Item(string id, int Duration, DateTime StartDate)
        {
            this.id = id;
            this.duration = Duration;
            this.startDate = StartDate;
            stopDate = startDate.AddDays(Duration);
            dakaDate = new List<DateTime>();
            dakaDays = 0;
        }

        public Item (ITEM item)
        {
            this.id = item.Id;
            this.duration = item.Duration;
            this.startDate = item.StartDate;
            this.stopDate = item.StartDate.AddDays(duration);
            this.dakaDays = item.DakaDate.Count();
            dakaDate = new List<DateTime>();
            for(int i = 0; i < dakaDays; i++)
            {
                dakaDate.Add(item.DakaDate[i]);
            }
        }

        public void Daka()
        {
            if (dakaDate.Last().Date != DateTime.Now)
            {
                dakaDate.Add(DateTime.Now);
                dakaDays++;
            }
        }

        public string Id() { return id; }
        public int Duration() { return duration; }
        public DateTime StartDate() { return startDate; }
        public DateTime StopDate() { return stopDate; }
        public bool IsDakaDay(DateTime dt) /// 可优化
        {
            foreach (DateTime d in dakaDate)
            {
                if (d.Date.Equals(dt.Date))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 得到打卡日期列表
        /// </summary>
        /// <returns></returns>
        public DateTime[] getDakaDate()
        {
            DateTime[] dakaDate = new DateTime[dakaDays];
            int i = 0;
            foreach (DateTime d in dakaDate)
            {
                dakaDate[i++] = d;
            }
            return dakaDate;
        }

    }
}
