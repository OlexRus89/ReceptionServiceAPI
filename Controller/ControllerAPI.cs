using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CryptoCore.Models.JsonData;
using CryptoCore.DB;
using CryptoCore.Extensions;
using CryptoCore.Models;
using CryptoCore.Models.ReceptionService;
using CryptoCore.Models.ReceptionService.Cls;
using CryptoCore.Models.ReceptionService.Own;

namespace CryptoCore.Controller
{
    public class ControllerAPI
    {
        public StartupModel? Startup;
        protected Network? Network;
        protected ManagerReceptionService? Manager;
        protected SessionData? Session;

        public ControllerAPI() 
        {
            Startup = new StartupModel().Startup();
            if (Startup != null) 
            {
                Network = new Network(Startup);
                Manager = new ManagerReceptionService(Startup, Startup.AppSetting.StartupSQLForAPI);
                Session = new SessionData();
            }
            else new ControllerAPI();
        }

        /// <summary>
        /// Деинициализация
        /// </summary>
        public void Deinit() 
        {
            Startup = null;
            Network = null;
            Manager = null;
            Session = null;
        }

        /// <summary>
        /// Добавления сессии
        /// </summary>
        /// <param name="Ogrn">Огрн организации</param>
        /// <param name="Kpp">Кпп организации</param>
        private void SetSessionKey(string? Ogrn = null, string? Kpp = null)
        {
            Session = Session.SetSession(Startup);
        }

        #region API_ССПВО можно наследовать с другими проектами (не рекомендуется)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Ogrn"></param>
        /// <param name="Kpp"></param>
        /// <returns></returns>
        public (SessionData? Data, string? Error) API_SessionNew(string? Ogrn = null, string? Kpp = null)
        {
            Console.Write("Выполняется запрос: получение сессии ... ");
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            var data = Network.SendRequesAsync<SessionData>(Point.SessionNew, new HeaderSessionData() { Ogrn = Ogrn ?? Startup.AppSetting.Ogrn, Kpp = Kpp ?? Startup.AppSetting.Kpp.First().KppOrganization }, isJWT: true);
            Console.WriteLine("завершение операции с ответом ... " + "\n" + (data.Data != null ? (data.Data.SessionKey) : "Ошибка записана в логе!\n"));
            return (data.Data, data.Error);
        }

        /// <summary>
        /// Получение списков Cls из Сервиса приема "Поступление в ВУЗ онлайн". 
        /// ВНИМАНИЕ. В значение T указывать только его модель без применения IEnumerable, List, Array или []
        /// </summary>
        /// <param name="Data">Результат списков Cls</param>
        /// <param name="Ogrn">Огрн организации (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп организации (может пустым, берется из конфигуратора приложения первым)</param>
        /// <typeparam name="T">Значение модели Cls. Не принимать дополнительные значения массив (например, IEnumerable, List, Array или [])</typeparam>
        /// <returns>Возвращаем два значения: Data - данные Cls, Error - ошибка</returns>
        public (T[]? Data, string? DataToString, string? Error) API_GetCls<T>(bool isToString = false, string? Ogrn = null, string? Kpp = null)
        {
            StringExtension str = new StringExtension();
            Console.Write($"Выполняется запрос: получение списка {str.GetType<T>()} ... ");
            StringExtension strE = new StringExtension();
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            SetSessionKey(Ogrn, Kpp);
            var data = Network.SendRequesAsync<T[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<T>() }, isCls: true, isToString: isToString);
            if (!isToString) Console.Write("завершение операции с ответом ... " + (data.Data != null ? ("... Количество Cls: " + data.Data.Count()) : "Ошибка записана в логе!\n"));
            else Console.Write("завершение операции с ответом ... " + ((data.DataToString == null || data.DataToString == "") ? "Ошибка записана в логе!\n" : "... Данные имеются: "));
            return (data.Data, data.DataToString, data.Error);
            
        }

        /// <summary>
        /// Проверка сертификата
        /// </summary>
        /// <param name="Ogrn">Огрн организации (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп организации (может пустым, берется из конфигуратора приложения первым)</param>
        /// <returns>Возвращает целостность сертификата. True - сертификат действующий, False - проблема с сертификатом</returns>
        public (bool? IsToken, string? Error) API_CheckCertificate(string? Ogrn = null, string? Kpp = null)
        {
            Console.Write("Выполняется запрос: проверка сертификата ... ");
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            var data = Network.SendRequesAsync<StatusData>(Point.Check, new HeaderData() { Action = "Add", Entity = "ApplicationList", Ogrn = Ogrn, Kpp = Kpp }, "<PackageData></PackageData>", isJWT: true);
            Console.Write("завершение операции с ответом ... " + (data.Data != null ? (data.Data.Status == "Токен в порядке").ToString().ToUpper() + "\n" : "Ошибка записана в логе!\n"));
            return ((data.Data != null ? (data.Data.Status == "Токен в порядке") : false), data.Error);
        }

        /// <summary>
        /// Работоспособность потока данных
        /// </summary>
        public (DelayData? Data, string? Error) API_GetDelay()
        {
            Console.Write("Выполняется запрос: пропускная способность ... ");
            var data = Network.SendRequesAsync<DelayData>(Point.DelayGet, null, Method: "Get");
            Console.WriteLine("завершение операции с ответом ... " + "\n" + (data.Data != null ? (data.Data.Comment + ".\nКоличество секунд задержки: " + data.Data.DelayHumanReadable + "\n") : "Ошибка записана в логе!\n"));
            return (data.Data, data.Error);
        }

        /// <summary>
        /// Создание токена для отправки в Сервис приема
        /// </summary>
        /// <typeparam name="T">Модель данных</typeparam>
        /// <param name="Action">Вид активности</param>
        /// <param name="Entity">Тип сущности</param>
        /// <param name="Ogrn">Огрн (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Tdata">Данные из модели данных (могут быть пустыми)</param>
        /// <param name="Xml">XML документ (могут быть пустыми)</param>
        /// <returns></returns>
        public (TokenData? Data, string? Error) API_NewToken<T>(string Action, string? Entity, string? Ogrn = null, string? Kpp = null, T? Tdata = default(T), string? Xml = null) 
        {
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            SetSessionKey(Ogrn, Kpp);
            Console.Write("Выполняется запрос: добавление токена ... ");
            if (Tdata == null && Xml == null)
            {
                Debug.Write("завершение операции с ответом ... ОШИБКА! ВНЕСИТЕ ДАННЫЕ ЗНАЧЕНИИ XML ИЛИ СУЩЕСТВУЮЩИХ МОДЕЛИ ДАННЫХ!");
                return (null, "ОШИБКА! ВНЕСИТЕ ДАННЫЕ ЗНАЧЕНИИ XML ИЛИ СУЩЕСТВУЮЩИХ МОДЕЛИ ДАННЫХ!");
            }
            var data = Network.SendRequesAsync<TokenData>(Point.TokenNew, new HeaderData() { Action = Action, Entity = Entity == null ? new StringExtension().GetType<T>() : Entity, Ogrn = Ogrn, Kpp = Kpp }, Xml == null ? Tdata.EncodeXml<T>().SetPD() : Xml, Session.SessionKey, true);
            Console.Write("завершение операции с ответом ... " + (data.Data != null ? data.Data.IdJwt.ToString().ToUpper() + "\n" : "Ошибка записана в логе!\n"));
            return (data.Data, data.Error);
        }

        /// <summary>
        /// Результат выполнения отправки токена
        /// </summary>
        /// <param name="IdJwt">Уникальный идентификатор токена</param>
        /// <param name="Ogrn">Огрн (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп (может пустым, берется из конфигуратора приложения первым)</param>
        /// <returns>Строчный результат</returns>
        public (string? XmlData, string? Error) API_GetOwn(int IdJwt, string? Ogrn = null, string? Kpp = null)
        {
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            SetSessionKey(Ogrn, Kpp);
            Console.Write("Выполняется запрос: получения токена ... ");
            var data = Network.SendRequesAsync<TokenData>(Point.OwnGet, null, "{ \"IdJwt\" : "  + IdJwt + " }", Session.SessionKey);
            Console.Write("завершение операции с ответом ... " + (data.Data != null ? "Имеется токен" + "\n" : "Ошибка записана в логе!\n"));
            if (data.Data == null) return (null, data.Error);
            return (Encoding.UTF8.GetString(Convert.FromBase64String(data.Data.Token.Split('.')[1])), data.Error);
        }

        /// <summary>
        /// Результат выполнения получения токена из других источников
        /// </summary>
        /// <param name="Header">Шапка токена</param>
        /// <param name="XmlData">Данные токена</param>
        /// <param name="IdJwt">Уникальный идентификатор токена<</param>
        /// <param name="Ogrn">Огрн (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп (может пустым, берется из конфигуратора приложения первым)</param>
        /// <returns>Возврщения шапки, данные токена, в случае каких проблем выводит ошибку</returns>
        public (HeaderJwtData? Header, string? XmlData, string? Error) API_GetDespatch(int IdJwt, string? Ogrn = null, string? Kpp = null)
        {
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            SetSessionKey(Ogrn, Kpp);
            Console.Write("Выполняется запрос: получения токена ... ");
            var data = Network.SendRequesAsync<TokenData>(Point.DespatchGet, null, "{ \"IdJwt\" : "  + IdJwt + " }", Session.SessionKey);
            Console.Write("завершение операции с ответом ... " + (data.Data != null ? "Имеется токен" + "\n" : "Ошибка записана в логе!\n"));
            if (data.Data == null) return (null, null, data.Error);
            return (JsonConvert.DeserializeObject<HeaderJwtData>(Encoding.UTF8.GetString(Convert.FromBase64String(data.Data.Token.Split('.')[0]))), Encoding.UTF8.GetString(Convert.FromBase64String(data.Data.Token.Split('.')[1])), data.Error);
        }

        /// <summary>
        /// Результат списков необработканных Jwt токенов
        /// </summary>
        /// <param name="IsDespatch">Выводить список из внешнего источника (Despatch - True) или из внутренней организации (Own - False)</param>
        /// <param name="Ogrn">Огрн (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп (может пустым, берется из конфигуратора приложения первым)</param>
        /// <returns>Список необработанных токенов</returns>
        public (IdJwtList? JwtList, string? Error) API_GetJwtList(bool IsDespatch, string? Ogrn = null, string? Kpp = null)
        {
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            SetSessionKey(Ogrn, Kpp);
            Console.Write("Выполняется запрос: получение списков Jwt токенов ... ");
            var data = Network.SendRequesAsync<IdJwtList>(!IsDespatch ? Point.OwnGet : Point.DespatchGet, null, "{ \"IdJwt\" : "  + 0 + " }", Session.SessionKey);
            Console.Write("завершение операции с ответом ... " + (data.Data != null ? "Имеются списки ожидаемых обработок токенов" + "\n" : "Ошибка записана в логе!\n"));
            return (data.Data, data.Error);
        }

        /// <summary>
        /// В результате выполнения запросов /api/token/own/get и /api/token/despatch/get может быть получен XML-документ, содержащий 
        /// идентификаторы файлов (Fui). Чтобы получить сами файлы, надо выполнить данный запрос.
        /// Идентификатор Fui действует ограниченное время: 5 суток. Время окончания действия ключа в явном виде записано в самом идентификаторе 
        /// файла. После истечения времени действия идентификатора файла, его надо получать повторно. Для этого необходимо заново выполнить запросы
        /// /api/token/new и /api/token/own/get.
        /// </summary>
        /// <param name="File">Зашифрованный файл</param>
        /// <param name="Fui">Идентификатор Fui</param>
        /// <param name="Ogrn">Огрн организации</param>
        /// <param name="Kpp">Кпп организации</param>
        /// <returns>Возвращение файлов и ошибки, если произойдут</returns>
        public (FileResultData? File, string? Error) API_GetFile(FileData Fui, string Ogrn = null, string? Kpp = null)
        {
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            SetSessionKey(Ogrn, Kpp);
            Console.Write("Выполняется запрос: получение файла от ССПВО ...");
            var data = Network.SendRequesAsync<FileResultData>(Point.FileGet, null, "{ \"Fui\" : " + Fui.Fui + " }", Session.SessionKey);
            Console.Write("завершение операции с ответом ... " + (data.Data != null ? "Имеются файлы\n" : "Ошибка записана в логе!\n"));
            return (data.Data, data.Error);
        }

        #endregion
    }
}