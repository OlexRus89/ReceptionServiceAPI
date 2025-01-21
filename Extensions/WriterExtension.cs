using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Extensions
{
    public class WriterExtension
    {
        internal string path = "";

        public WriterExtension()
        {
            var a = Enum.GetValues(typeof(Environment.SpecialFolder))
                .Cast<Environment.SpecialFolder>()
                .Select(specialFolder => new
                {
                    Name = specialFolder.ToString(),
                    Path = Environment.GetFolderPath(specialFolder)
                })
                .OrderBy(item => item.Path.ToLower());
            FileInfo FileAppData = new FileInfo(a.First(a => a.Name == "LocalApplicationData").Path + "\\SSCoreApp\\XmlSuperSerice.txt");
            path = FileAppData.ToString();
        }

        internal void WriteTxt(string Xml, string? path = null)
        {
            var a = Enum.GetValues(typeof(Environment.SpecialFolder))
                .Cast<Environment.SpecialFolder>()
                .Select(specialFolder => new
                {
                    Name = specialFolder.ToString(),
                    Path = Environment.GetFolderPath(specialFolder)
                })
                .OrderBy(item => item.Path.ToLower());
            FileInfo FileAppData = new FileInfo(a.First(a => a.Name == "LocalApplicationData").Path + "\\SSCoreApp\\XmlSuperSerice.txt");
            DirectoryInfo FileTempAppData = new DirectoryInfo(a.First(a => a.Name == "LocalApplicationData").Path + "\\SSCoreApp");
            using (StreamWriter writer = new StreamWriter(path != null ? path : FileAppData.ToString(), false))
            {
                writer.WriteLine(Xml);
                writer.Close();
            }
        }

        public void DeleteTxt(string? path = null)
        {
            var a = Enum.GetValues(typeof(Environment.SpecialFolder))
                .Cast<Environment.SpecialFolder>()
                .Select(specialFolder => new
                {
                    Name = specialFolder.ToString(),
                    Path = Environment.GetFolderPath(specialFolder)
                })
                .OrderBy(item => item.Path.ToLower());
            FileInfo FileAppData = new FileInfo(a.First(a => a.Name == "LocalApplicationData").Path + "\\SSCoreApp\\XmlSuperSerice.txt");
            DirectoryInfo FileTempAppData = new DirectoryInfo(a.First(a => a.Name == "LocalApplicationData").Path + "\\SSCoreApp");
            FileInfo fileInfo = new FileInfo(path != null ? path : FileAppData.ToString());
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
    }
}