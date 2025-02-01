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

        public static string ConvertToStringYMD(this DateTime Date)
        {
            return Date.ToString("yyyy-MM-dd");
        }

        public static string ConvertTostringYMDHMS(this DateTime Date)
        {
            return Date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ConvertToStringYMDTHMSZ(this DateTime Date)
        {
            return Date.ToString("yyyy-MM-dd'T'HH:mm:ss+03:00");
        }

        public static string ConvertToStringYMD(this string Date)
        {
            return DateTime.Parse(Date).ToString("yyyy-MM-dd");
        }

        public static string ConvertTostringYMDHMS(this string Date)
        {
            return DateTime.Parse(Date).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ConvertToStringYMDTHMSZ(this string Date)
        {
            return DateTime.Parse(Date).ToString("yyyy-MM-dd'T'HH:mm:ss+03:00");
        }

    }
}