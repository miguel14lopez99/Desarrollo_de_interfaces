using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.SomeResources
{
    class Dates
    {
        public static int toCientificDate(DateTime date)
        {        
            String sDate = date.ToString("yyyyMMdd");
            int cientificDate = Convert.ToInt32(sDate);

            return cientificDate;
        }

        public static DateTime toDateTime(int cientificDate)
        {
            
            int year = cientificDate / 10000;
            int month_day = cientificDate % 10000;
            int month = month_day / 100;
            int day = month_day % 100;

            DateTime date = new DateTime(year, month, day);

            return date;
        }

    }
}
