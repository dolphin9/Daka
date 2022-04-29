using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daka
{
    /// <summary>
    /// 
    /// </summary>
    internal class DailyLogs
    {
        private DateTime date;
        private List<log> dakaList;

        public DailyLogs()
        {
            date = DateTime.Now;
        }
        public DailyLogs(DateTime dt)
        {
            date = dt;
        }


    }

    public class log
    {
        string name;
        bool isDone;
    }
}
