using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Extensions
{
    public class CryptographyExtension
    {
        public string EncodeWithKey(string? data, string? key)
        {
            if (key == null) throw new ArgumentNullException();
            StringBuilder sb = new StringBuilder();
            data = EncodeToBase64(data ?? "");
            key = EncodeToBase64(key ?? "");
            for(int i = 0; i < data.Length; i++)
            {
                sb.Append((char)(data[i] ^ key[(i % key.Length)]));
            }
            return EncodeToBase64(sb.ToString());
        }
        public string DecodeWithKey(string data, string key)
        {
            StringBuilder sb = new StringBuilder();
            data = DecodeToBase64(data);
            key = EncodeToBase64(key);

            for(int i = 0; i < data.Length; i++)
            {
                sb.Append((char)(data[i] ^ key[(i % key.Length)]));
            }
            return DecodeToBase64(sb.ToString());
        }
        public string EncodeToBase64(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(ReverseString(str)));
        }
        public string DecodeToBase64(string str)
        {
            return ReverseString(Encoding.UTF8.GetString(Convert.FromBase64String(str)));
        }
        protected string ReverseString(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }
    }
}