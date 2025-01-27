using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReceptionServiceAPI.Models.JsonData;
using ReceptionServiceCore.DB;
using ReceptionServiceCore.Extensions;
using ReceptionServiceCore.Models;
using ReceptionServiceCore.Models.JsonData;
using ReceptionServiceCore.Models.ReceptionService;
using ReceptionServiceCore.Models.ReceptionService.Cls;
using ReceptionServiceCore.Models.ReceptionService.Own;

namespace ReceptionServiceCore.Controller
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
                Manager = new ManagerReceptionService(Startup);
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
            (SessionData? Item1, string? Item2) data = Network.SendRequesAsync<SessionData>(Point.SessionNew, new HeaderData() { Action = "Add", Entity = "ApplicationList", Ogrn = Ogrn ?? Startup.AppSetting.Ogrn, Kpp = Kpp ?? Startup.AppSetting.Kpp.First().KppOrganization }, "<PackageData></PackageData>", isJWT: true);
            Console.WriteLine("завершение операции с ответом ... " + "\n" + (data.Item1 != null ? (data.Item1.SessionKey) : "Ошибка записана в логе!\n"));
            return (data.Item1, data.Item2);
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
        public (T[]? Data, string? Error) API_GetCls<T>(string? Ogrn = null, string? Kpp = null)
        {
            StringExtension str = new StringExtension();
            Console.Write($"Выполняется запрос: получение списка {str.GetType<T>()} ... ");
            StringExtension strE = new StringExtension();
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            var data = Network.SendRequesAsync<T[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<T>() }, isCls: true);
            Console.Write("завершение операции с ответом ... " + (data.Item1 != null ? ("... Количество Cls: " + data.Item1.Count()) : "Ошибка записана в логе!\n"));
            return (data.Item1, data.Item2);
            
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
            Console.Write("завершение операции с ответом ... " + (data.Item1 != null ? (data.Item1.Status == "Токен в порядке").ToString().ToUpper() + "\n" : "Ошибка записана в логе!\n"));
            return ((data.Item1 != null ? (data.Item1.Status == "Токен в порядке") : false), data.Item2);
        }

        /// <summary>
        /// Работоспособность потока данных
        /// </summary>
        public (DelayData? Data, string? Error) API_GetDelay()
        {
            Console.Write("Выполняется запрос: пропускная способность ... ");
            var data = Network.SendRequesAsync<DelayData>(Point.DelayGet, null, Method: "Get");
            Console.WriteLine("завершение операции с ответом ... " + "\n" + (data.Item1 != null ? (data.Item1.Comment + ".\nКоличество секунд задержки: " + data.Item1.DelayHumanReadable + "\n") : "Ошибка записана в логе!\n"));
            return (data.Item1, data.Item2);
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
            Console.Write("завершение операции с ответом ... " + (data.Item1 != null ? data.Item1.IdJwt.ToString().ToUpper() + "\n" : "Ошибка записана в логе!\n"));
            return (data.Item1, data.Item2);
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
            Console.Write("завершение операции с ответом ... " + (data.Item1 != null ? "Имеется токен" + "\n" : "Ошибка записана в логе!\n"));
            if (data.Item1 == null) return (null, data.Item2);
            return (Encoding.UTF8.GetString(Convert.FromBase64String(data.Item1.Token.Split('.')[1])), data.Item2);
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
            Console.Write("завершение операции с ответом ... " + (data.Item1 != null ? "Имеется токен" + "\n" : "Ошибка записана в логе!\n"));
            if (data.Item1 == null) return (null, null, data.Item2);
            return (JsonConvert.DeserializeObject<HeaderJwtData>(Encoding.UTF8.GetString(Convert.FromBase64String(data.Item1.Token.Split('.')[0]))), Encoding.UTF8.GetString(Convert.FromBase64String(data.Item1.Token.Split('.')[1])), data.Item2);
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
            Console.Write("завершение операции с ответом ... " + (data.Item1 != null ? "Имеются списки ожидаемых обработок токенов" + "\n" : "Ошибка записана в логе!\n"));
            return (data.Item1, data.Item2);
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
            Console.Write("завершение операции с ответом ... " + (data.Item1 != null ? "Имеются файлы\n" : "Ошибка записана в логе!\n"));
            return (data.Item1, data.Item2);
        }

        #endregion
        
        // #region Автоматизация

        // /// <summary>
        // /// Отправка токенов в ССПВО (Автоматизированная версия)
        // /// </summary>
        // /// <returns></returns>
        // public async Task Auto_SendTokens()
        // {
        //     IEnumerable<GetTokenModel> tokens = await Manager.GetTokensOwn();
        //     foreach (var item in tokens)
        //     {
        //         var data = API_NewToken<TokenData?>(item.Action, item.Entity, item.Ogrn, item.Kpp, Xml: item.Payload);
        //         if (data.Data != null)
        //         {
        //             await Manager.UpdateToken(item.IdObject, (int)data.Data.IdJwt, (int)data.Data.DelaySeconds);
        //         }
        //         await Task.Delay(2000);
        //     }
        //     if (tokens.Count() == 0) Console.WriteLine("Очередь на отправку пуста!"); Console.WriteLine();
        // }

        // /// <summary>
        // /// Принятия результатов токенов из ССПВО (Автоматизированная версия)
        // /// </summary>
        // /// <returns></returns>
        // public async Task Auto_GetTokens()
        // {
        //     IEnumerable<GetTokenModel> tokens = await Manager.GetTokensOwn(true);
        //     foreach (var item in tokens)
        //     {
        //         if (item.IdJWT != null)
        //         {
        //             bool isStop = false;
        //             string data = API_GetOwn((int)item.IdJWT, item.Ogrn, item.Kpp).XmlData;
        //             if (data != null)
        //             {
        //                 if (data.DecodeXml<DefaultResponse>(true).ErrorList != null && !isStop)
        //                 {
        //                     await Manager.CreateToken(6, item.IdObject, Result: data);
        //                     isStop = true;
        //                 }
        //                 if (item.Action.Contains("Get") && !isStop)
        //                 {
        //                     await Manager.CreateToken(5, item.IdObject, Result: data);
        //                     isStop = true;
        //                 }
        //                 if (!item.Action.Contains("Get") && !isStop)
        //                 {
        //                     await Manager.CreateToken(4, item.IdObject, Result: data);
        //                     isStop = true;
        //                 }
        //             }
        //         }

        //         await Task.Delay(2000);
        //     }
        //     if (tokens.Count() == 0) Console.WriteLine("Очередь на принятия данных пуста!"); Console.WriteLine();
        // }

        // /// <summary>
        // /// Получения Id токенов из внешнего источника (Despatch) в ССПВО (Автоматизированная версия)
        // /// </summary>
        // /// <returns></returns>
        // public async Task Auto_GetIdsJwtDespatch()
        // {
        //     Console.WriteLine("Запущен процесс получения списков идентификаторов токенов");
        //     var data = API_GetJwtList(true);
        //     {
        //         if (data.JwtList == null) Console.WriteLine("Отсутствуют данные!");
        //         if (data.JwtList != null && data.JwtList.Length == 0) Console.WriteLine("В очереди отсутвствуют данные!");
        //         if (data.JwtList != null && data.JwtList.Length > 0)
        //         {
        //             foreach (var item in data.JwtList.List)
        //             {
        //                 Console.WriteLine("Запись в БД уникальный идентификатор токена: {0}", item);
        //                 await Manager.UpdateToken(item);
        //                 await Task.Delay(1000);
        //             }
        //         }
        //     }
        // }

        // /// <summary>
        // /// Получения всех токенов из внешних источников (Despatch) в ССПВО (Автоматизированная версия)
        // /// </summary>
        // /// <returns></returns>
        // public async Task Auto_GetTokensDespatch()
        // {
        //     Console.WriteLine("Запущен процесс получения токенов по идентификаторам IdJwt");
        //     var tokens = await Manager.GetTokensDespatch();
        //     foreach(var item in tokens)
        //     {
        //         var data = API_GetDespatch(item.IdJwt);
        //         if (data.XmlData != null)
        //         {
        //             await Manager.CreateToken(item.IdJwt, data.XmlData, data.Header.Entity, data.Header.CreatedAt);
        //         }
        //         await Task.Delay(2000);
        //     }
        //     if (tokens.Count() == 0) Console.WriteLine("Очередь на принятия данных от источников пуста!"); Console.WriteLine();
        // }

        // /// <summary>
        // /// Получение и обработка файлов из ССПВО (Автоматизированная версия)
        // /// </summary>
        // /// <returns></returns>
        // public async Task Auto_GetFiles()
        // {
        //     Console.WriteLine("Запущен процесс получения информации файлов");
        //     var files = await Command_GetFiles();
        //     foreach(var item in files)
        //     {
        //         var isLoadFile = await Command_SaveFile(new FileData() { Fui = item.Fui }, item.NameDirectory, item.NameFile);
        //         if (isLoadFile.IsLoad && !isLoadFile.Error)
        //         {
        //             item.Status = 5;
        //             await Command_SaveFile(item);
        //         }

        //         if (!isLoadFile.IsLoad && isLoadFile.Error)
        //         {
        //             item.Status = 6;
        //             await Command_SaveFile(item);
        //         }
        //         await Task.Delay(2000);
        //     }
        //     if (files.Count() == 0) Console.WriteLine("Очередь на обработку фйлов пуста!"); Console.WriteLine();
        // }

        // #endregion
    }
}