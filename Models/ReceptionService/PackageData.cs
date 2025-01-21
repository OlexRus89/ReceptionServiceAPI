using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ReceptionServiceCore.Extensions;

namespace ReceptionServiceCore.Models.ReceptionService
{
    public static class PackageData
    {
        public static string ConvertToPD<T>(this string Xml)
        {
            return Xml.Replace("PackageData", "ArrayOf" + new StringExtension().GetType<T>());
        }

        public static string ConvertToValue<T>(this string Xml) 
        {
            Debug.WriteLine(typeof(T).ToString().Split('.').Last().Replace("[]", "").Replace("[", "").Replace("]", ""));
            return Xml.Replace("<" + typeof(T).ToString().Split('.').Last().Replace("[]", "").Replace("[", "").Replace("]", "") + ">", "<ValueData>").Replace("</" + typeof(T).ToString().Split('.').Last().Replace("[]", "").Replace("[", "").Replace("]", "") + ">", "</ValueData>");
        }

        public static string SetPD(this string Xml) 
        {
            return "<PackageData> " + Xml.Replace("\r\n", String.Empty).Trim(' ') + " </PackageData>";
        }
    }

    [XmlRoot("PackageData")]
    public class RootData<T>
    {
        public T ValueData { get; set; }
    }
}