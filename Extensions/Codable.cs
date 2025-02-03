using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using CryptoCore.Models.ReceptionService;
using System.IO;
using CryptoCore.Extensions;

namespace CryptoCore.Extensions
{
    public static class Codable
    {
        /// <summary>
        /// Декодирование данных
        /// </summary>
        /// <param name="Xml">Xml документ</param>
        /// <param name="IsEnablePD">Делать ли конвертацию из модулей, по умолчанию нет</param>
        /// <typeparam name="T">Любые данные</typeparam>
        /// <returns>Возвращает данные по модулю</returns>
        public static T? DecodeXml<T>(this string Xml, bool IsEnablePD = false)
        {
            if (Xml == null) return default;
            T? data = default(T);
            if (IsEnablePD) new WriterExtension().WriteTxt(Xml.ConvertToValue<T>());
            else new WriterExtension().WriteTxt(Xml.ConvertToPD<T>());
            try
            {
                using (StreamReader stringReader = new StreamReader(new WriterExtension().path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    data = (T?)serializer.Deserialize(stringReader);
                    stringReader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            new WriterExtension().DeleteTxt();
            return data;
        }

        public static string? EncodeXml<T>(this T obj)
        {
            if (obj == null) return null;
            XmlSerializerNamespaces names = new XmlSerializerNamespaces();
            names.Add(string.Empty, string.Empty);
            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true,
                Encoding = Encoding.UTF8,
                NewLineOnAttributes = false,

            };

            try
            {
                MemoryStream ms = new MemoryStream();
                XmlWriter writer = XmlWriter.Create(ms, settings);
                XmlSerializer cs = new XmlSerializer(typeof(T));
                cs.Serialize(writer, obj, names);
                ms.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(ms);

                var str = sr.ReadToEnd().Split('\n');
                var result = "";
                for (int i = 0; i < str.Count(); i++)
                {
                    if (!str[i].Contains("p3:nil=\"true\" xmlns:p3=\"http://www.w3.org/2001/XMLSchema-instance\""))
                    {
                        result += str[i] + "\n";
                    }
                }
                new WriterExtension().DeleteTxt();
                return result.TrimEnd().SetPD();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}