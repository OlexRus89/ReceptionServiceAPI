using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Extensions
{
    public class StringExtension
    {
        public string GetType<T>() 
        {
            return typeof(T).Name.Replace("[]", "");
        }

        public string GetMethodType<T>() 
        {
            return GetNamespace<T>().Split('.').Last();
        }

        public string GetNamespace<T>() 
        {
            return (typeof(T).Namespace ?? "").Replace("[]", "");
        }
    }

    public static class StringExtensions
    {
        public static bool IsValidURI(this string source)
        {
            Uri uriResult;
            bool isTrue = false;
            if (source.StartsWith("http://") || source.StartsWith("https://") || source.StartsWith("www."))
            {
                if (Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp) isTrue = true;
                if (Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttps) isTrue = true;
            }
            
            return isTrue;
        }

        public static (bool ResultBool, int ResultInt) IsValidInt(this string source)
        {
            int n;
            if (int.TryParse(source, out n)) return (true, n);
            else return (false, 0);
        }

        public static bool IsValidFile(this string sourse)
        {
            DirectoryInfo directory = new DirectoryInfo(sourse);
            return directory.Exists;  
        }

        public static (bool ResultBool, float ResultFloat) IsValidFloat(this string source)
        {
            float n;
            if (float.TryParse(source, out n)) return (true, n);
            else return (false, 0);
        }

        public static (bool ResultBool, double ResultDouble) IsValidDouble(this string source)
        {
            double n;
            if (double.TryParse(source, out n)) return (true, n);
            else return (false, 0);
        }

        public static (bool ResultBool, decimal ResultDecimal) IsValidDecimal(this string source)
        {
            decimal n;
            if (decimal.TryParse(source, out n)) return (true, n);
            else return (false, 0);
        }
    }
}