using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReceptionServiceCore.DB;
using ReceptionServiceCore.Models;
using ReceptionServiceCore.Models.JsonData;
using CryptoPro.Security.Cryptography.X509Certificates;
using CryptoPro.Security.Cryptography.Pkcs;
using System.Security.Cryptography.Pkcs;
using System.IO;

namespace ReceptionServiceCore.Extensions
{
    public class Network
    {
        [JsonIgnore]
        protected ManagerReceptionService Manager { get; private set; }
        [JsonIgnore]
        protected StartupModel Startup { get; private set; }
        internal Network(StartupModel startup)
        {
            Startup = startup;
            Manager = new ManagerReceptionService(Startup);
        }

        internal (T?, string) SendRequesAsync<T>(Point point, dynamic Header, string? Payload = null, string? Session = null, bool isJWT = false, bool isCls = false, string Method = "POST")
        {
            T? ResponseData = default(T);
            string Error = "";
            try
            {
                HttpWebRequest request = WebRequest.Create(GetURL(point)) as HttpWebRequest;
                request.ContentType = "application/json";
                request.Method = Method;
                if (Session != null) request.Headers.Add("Session-Key", Session);
                if (Method.ToUpper() != "GET")
                    if (!isJWT) 
                    {
                        if (!isCls) using (StreamWriter writer = new StreamWriter(request.GetRequestStream())) writer.Write(Payload);
                        else using (StreamWriter writer = new StreamWriter(request.GetRequestStream())) writer.Write(JsonConvert.SerializeObject(Header));
                    } 
                    else using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                    {
                        string data = "{\"Token\": \"" + CreateJWT(Header, Payload) + "\"}";
                        writer.Write(data);
                    }

                using (HttpWebResponse response = (request.GetResponse()) as HttpWebResponse)
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string data = reader.ReadToEnd();
                    if (data == null || data == "") throw new Exception("NotFountData: Нет данных отправленного токена, повторите отправить данные позже!");

                    if (!isCls) ResponseData = JsonConvert.DeserializeObject<T>(data);
                    else ResponseData = data.DecodeXml<T>();
                }
            }
            catch (WebException ex)
            {
                try
                {
                    using (var stream = ex.Response?.GetResponseStream())
                    using (var reader = new StreamReader(stream)) 
#if DEBUG
                    Console.WriteLine("Message: " + ex.Message + "\n" + "StackTrace: " + ex.StackTrace + "\n" + "Sender: " + JsonConvert.SerializeObject(new ErrorData() { Point = GetURL(point), Method = Method, Source = Startup.AppSetting.Source, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session }) + "\n" + "MessageResult: " + reader.ReadToEnd());
                    Error = "Message: " + ex.Message + "\n" + "StackTrace: " + ex.StackTrace + "\n" + "Sender: " + JsonConvert.SerializeObject(new ErrorData() { Point = GetURL(point), Method = Method, Source = Startup.AppSetting.Source, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session });
#else
                    Manager.SaveErrorRequest(Message: ex.Message, StackTrace: ex.StackTrace, Sender: (new ErrorData() { Point = GetURL(point), Method = Method, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session }).EncodeJSON(Startup), MessageResult: reader.ReadToEnd());
                    Error = "Message: " + ex.Message + "\n" + "StackTrace: " + ex.StackTrace + "\n" + "Sender: " + JsonConvert.SerializeObject(new ErrorData() { Point = GetURL(point), Method = Method, Source = Startup.AppSetting.Source, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session });
#endif
                }
                catch (Exception ex1)
                {
#if DEBUG
                    Console.WriteLine("Message: " + ex1.Message + "\n" + "StackTrace: " + ex1.StackTrace + "\n" + "Sender: " + JsonConvert.SerializeObject(new ErrorData() { Point = GetURL(point), Method = Method, Source = Startup.AppSetting.Source, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session }));
                    Error = "Message: " + ex1.Message + "\n" + "StackTrace: " + ex1.StackTrace + "\n" + "Sender: " + JsonConvert.SerializeObject(new ErrorData() { Point = GetURL(point), Method = Method, Source = Startup.AppSetting.Source, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session });
#else
                    Manager.SaveErrorRequest(Message: ex1.Message, StackTrace: ex1.StackTrace, Sender: (new ErrorData() { Point = GetURL(point), Method = Method, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session }).EncodeJSON(Startup), MessageResult: null);
                    Error = "Message: " + ex1.Message + "\n" + "StackTrace: " + ex1.StackTrace + "\n" + "Sender: " + JsonConvert.SerializeObject(new ErrorData() { Point = GetURL(point), Method = Method, Source = Startup.AppSetting.Source, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session });
#endif
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                    Console.WriteLine("Message: " + ex.Message + "\n" + "StackTrace: " + ex.StackTrace + "\n" + "Sender: " + JsonConvert.SerializeObject(new ErrorData() { Point = GetURL(point), Method = Method, Source = Startup.AppSetting.Source, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session }));
                    Error = "Message: " + ex.Message + "\n" + "StackTrace: " + ex.StackTrace + "\n" + "Sender: " + JsonConvert.SerializeObject(new ErrorData() { Point = GetURL(point), Method = Method, Source = Startup.AppSetting.Source, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session });
#else
                    Manager.SaveErrorRequest(Message: ex.Message, StackTrace: ex.StackTrace, Sender: (new ErrorData() { Point = GetURL(point), Method = Method, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session }).EncodeJSON(Startup), MessageResult: null);
                    Error = "Message: " + ex.Message + "\n" + "StackTrace: " + ex.StackTrace + "\n" + "Sender: " + JsonConvert.SerializeObject(new ErrorData() { Point = GetURL(point), Method = Method, Source = Startup.AppSetting.Source, Header = Header != null ? JsonConvert.SerializeObject(Header) : null, Payload = Payload, SessionKey = Session });
#endif
            }
            return (ResponseData, Error);
        }

        private string GetURL(Point point)
        {
            string url = Startup.AppSetting.URLs.Where(a => a.UrlName == Startup.AppSetting.StartupURL).First().Url;
            switch (point)
            {
                case Point.SessionNew: return url + "/api/session/new";
                case Point.ClsGet: return url + "/api/cls/get";
                case Point.TokenNew: return url + "/api/token/new";
                case Point.DelayGet: return url + "/api/token/delay/get";
                case Point.OwnGet: return url + "/api/token/own/get";
                case Point.DespatchGet: return url + "/api/token/despatch/get";
                case Point.FileGet: return url + "/api/file/get";
                case Point.Check: return url + "/api/token/certificate/check";
                default: return "";
            }
        }

        private string CreateJWT(dynamic Header, string Payload)
        {
            string result = "";
            string header = "";
            Payload = Convert.ToBase64String(Encoding.UTF8.GetBytes(Payload ?? ""));
            string seriz = JsonConvert.SerializeObject(Header);
            byte[] bytes = Encoding.UTF8.GetBytes(seriz);
            header = Convert.ToBase64String(bytes);
            string Signature = GetSignature(header + "." + Payload);
            result = header + "." + Payload + "." + Signature;
            return result;
        }

        private byte[] SignMsg(Byte[] msg, CpX509Certificate2? signerCert)
        {
            ContentInfo contentInfo = new ContentInfo(msg);
            CpSignedCms signedCms = new CpSignedCms(contentInfo, true);
            CpCmsSigner cmsSigner = new CpCmsSigner(signerCert);
            signedCms.ComputeSignature(cmsSigner);
            return signedCms.Encode();
        }

        private CpX509Certificate2? GetSignerCert(string signerName)
        {
            CpX509Store storeMy =  new CpX509Store(StoreName.My, StoreLocation.CurrentUser);
            storeMy.Open(OpenFlags.ReadOnly);
            CpX509Certificate2Collection certColl = storeMy.Certificates.Find(X509FindType.FindBySubjectName, signerName, false);
            if (certColl.Count == 0) return null;

            storeMy.Close();
            return certColl[0];
        }

        private string GetSignature(string data)
        {
            return Convert.ToBase64String(SignMsg(Encoding.UTF8.GetBytes(data), GetSignerCert(Startup.AppSetting.CerificateName)));
        }
    }

    internal enum Point
    {
        /// <summary>
        /// Получение новой сессии
        /// </summary>
        SessionNew,
        /// <summary>
        /// Получение справочной информации
        /// </summary>
        ClsGet,
        /// <summary>
        /// Добавление токена для внесения, обновления, удаления и прочтения данных
        /// </summary>
        TokenNew,
        /// <summary>
        /// Получение оценки времени работы API сервиса приема
        /// </summary>
        DelayGet,
        /// <summary>
        /// Получения списка документов, который находится в очереди и вытаскивания из очереди внутри ОО
        /// </summary>
        OwnGet,
        /// <summary>
        /// Получения списка документов, который находится в очереди и вытаскивания из очереди из вне ОО
        /// </summary>
        DespatchGet,
        /// <summary>
        /// Получения файла по идентификатору Fui
        /// </summary>
        FileGet,
        /// <summary>
        /// Проверка сертификата
        /// </summary>
        Check
    }
}