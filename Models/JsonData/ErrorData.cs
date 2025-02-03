using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CryptoCore.Extensions;

namespace CryptoCore.Models.JsonData
{
    public class ErrorData
    {
        public string? Point { get; set; }
        public string ContentType = "application/json";
        public string? Method { get; set; }
        public string? Source { get; set; }
        public string? Header { get; set; }
        public string? Payload { get; set; }
        public string? SessionKey { get; set; }

        public string EncodeJSON(StartupModel startup) 
        {
            CryptographyExtension crypto = new CryptographyExtension();
            Source = startup.AppSetting.Source;
            Header = Header != null ? crypto.EncodeWithKey(Header, startup.AppSetting.Key) : null;
            Payload = Payload != null ? crypto.EncodeWithKey(Payload, startup.AppSetting.Key) : null;
            SessionKey = SessionKey != null ? crypto.EncodeWithKey(SessionKey, startup.AppSetting.Key) : null;

            return JsonConvert.SerializeObject(new { Point, ContentType, Method, Source, Header, Payload, SessionKey });
        }

        public string DecodeJSON(string data, StartupModel startup)
        {
            CryptographyExtension crypto = new CryptographyExtension();
            var result = JsonConvert.DeserializeObject<ErrorData>(data);

            result.Source = startup.AppSetting.Source;
            result.Header = result.Header != null ? crypto.DecodeWithKey(result.Header, startup.AppSetting.Key) : null;
            result.Payload = result.Payload != null ? crypto.DecodeWithKey(result.Payload, startup.AppSetting.Key) : null;
            result.SessionKey = result.SessionKey != null ? crypto.DecodeWithKey(result.SessionKey, startup.AppSetting.Key) : null;

            return JsonConvert.SerializeObject(result);
        }
    }
}