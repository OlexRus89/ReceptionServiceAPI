using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CryptoCore.Extensions;

namespace CryptoCore.Models.JsonData
{
    public class SessionData
    {
        [JsonProperty("Session-Key")]
        public string? SessionKey { get; set; }
        public string? Deprecated { get; set; }
        [JsonIgnore]
        public DateTime Expired { get; set; }
        protected SessionData? WriteSession(CryptographyExtension crypro, FileInfo FileAppData, StartupModel startup, string? Ogrn = null, string? Kpp = null)
        {
            Network Network = new Network(startup);
            SessionData Session = Network.SendRequesAsync<SessionData>(Point.SessionNew, new HeaderData() { Action = "Add", Entity = "ApplicationList", Ogrn = Ogrn ?? startup.AppSetting.Ogrn, Kpp = Kpp ?? startup.AppSetting.Kpp.First().KppOrganization }, "<PackageData></PackageData>", isJWT: true).Data ?? new();
            Console.WriteLine("завершение операции c ответом ... " + ((Session != null && Session.SessionKey != null) ? ("сессионный ключ записан " + "до " + Session.SessionKey.Split('+')[2] + "\n") : "Ошибка записана в логе!\n"));
            if (Session != null && Session.SessionKey != null)
            {
                Session.Expired = Session.SessionKey.Split('+')[2].ConvertToDate();
                using (StreamWriter writer = new StreamWriter(FileAppData.ToString(), false))
                {
                    SessionData encodeJson = new SessionData() { SessionKey = crypro.EncodeWithKey(Session.SessionKey, startup.AppSetting.Key) };
                    writer.WriteLine(JsonConvert.SerializeObject(encodeJson));
                    writer.Close();
                    return Session;
                }
            }
            return Session;
        }

        protected SessionData ReadSession(CryptographyExtension crypro, FileInfo FileAppData, StartupModel startup)
        {
            SessionData session = new SessionData();
            using (StreamReader stringReader = new StreamReader(FileAppData.ToString()))
            {
                if (SessionKey == null)
                {
                    session = JsonConvert.DeserializeObject<SessionData>(stringReader.ReadToEnd());
                    session.SessionKey = crypro.DecodeWithKey(session.SessionKey, startup.AppSetting.Key);
                    stringReader.Close();

                    if (session.SessionKey.Split('+')[2].ConvertToDate().DateValid())
                    {
                        session.Expired = session.SessionKey.Split('+')[2].ConvertToDate();
                        Console.WriteLine("завершение операции с ответом ... " + "сессионный ключ записан " + "до " + session.SessionKey.Split('+')[2] + "\n");
                        return session;
                    }
                    else
                    {
                        stringReader.Close();
                        return WriteSession(crypro, FileAppData, startup);
                    }
                }
                else
                {
                    if (SessionKey.Split('+')[2].ConvertToDate().DateValid())
                    {
                        session = new SessionData();
                        session.SessionKey = SessionKey;
                        session.Expired = SessionKey.Split('+')[2].ConvertToDate();
                        Console.WriteLine("завершение операции с ответом ... " + "сессионный ключ записан " + "до " + SessionKey.Split('+')[2] + "\n");
                        stringReader.Close();
                        return session;
                    }
                    else
                    {
                        stringReader.Close();
                        return WriteSession(crypro, FileAppData, startup);
                    }
                }
            }
        }
        internal SessionData SetSession(StartupModel startup)
        {
            var os = Environment.OSVersion;
            Console.Write("Выполняется запрос: добавления сессионного ключа ... ");
            CryptographyExtension crypro = new CryptographyExtension();
            var a = Enum.GetValues(typeof(Environment.SpecialFolder))
                .Cast<Environment.SpecialFolder>()
                .Select(specialFolder => new
                {
                    Name = specialFolder.ToString(),
                    Path = Environment.GetFolderPath(specialFolder)
                })
                .OrderBy(item => item.Path.ToLower());
            FileInfo FileAppData = new FileInfo(a.First(a => a.Name == "LocalApplicationData").Path + (os.Platform == PlatformID.Win32NT ? "\\SSCoreApp\\Session.setting" : "/SSCoreApp/Session.setting"));
            DirectoryInfo FileTempAppData = new DirectoryInfo(a.First(a => a.Name == "LocalApplicationData").Path + (os.Platform == PlatformID.Win32NT ? "\\SSCoreApp" : "/SSCoreApp"));
            if(!FileTempAppData.Exists) FileTempAppData.Create();
            if (!FileAppData.Exists) return WriteSession(crypro, FileAppData, startup);
            else return ReadSession(crypro, FileAppData, startup);
        }
    }
}