using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Extensions
{
    public static class DateExtenstion
    {
        public static DateTime ConvertToDate(this string Date)
        {
            string D = Date.Split('_')[0];
            string H = Date.Split('_')[1];
            return DateTime.ParseExact(D + " " + H.Split('-')[0] + ":" + H.Split('-')[1] + ":00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static bool DateValid(this DateTime Date)
        {
            return Date > DateTime.Now;
        }
    }
}