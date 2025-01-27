using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Extensions
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

    internal static class StringExtensions
    {
        internal static bool IsValidURI(this string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }

        internal static (bool ResultBool, int ResultInt) IsValidInt(this string source)
        {
            int n;
            if (int.TryParse(source, out n))
            {
                return (true, n);
            }
            else return (false, 0);
        }

        internal static bool IsValidFile(this string sourse)
        {
            DirectoryInfo directory = new DirectoryInfo(sourse);
            return directory.Exists;  
        }
    }
}