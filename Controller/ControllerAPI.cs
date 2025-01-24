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

        #region API_ССПВО

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
            Console.Write("Выполняется запрос: получение списка Cls ... ");
            StringExtension strE = new StringExtension();
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            var data = Network.SendRequesAsync<T[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<T>() }, isCls: true);
            Console.WriteLine("завершение операции с ответом ... " + "\n" + (data.Item1 != null ? (".Количество Cls: " + data.Item1.Count()) : "Ошибка записана в логе!\n"));
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

        #endregion

        #region Взаимодействие с другими методами 

        /// <summary>
        /// Внесение справочников
        /// </summary>
        /// <param name="Ogrn">Огрн организации (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп организации (может пустым, берется из конфигуратора приложения первым)</param>
        public void Command_InsertCls(string? Ogrn = null, string? Kpp = null)
        {
            StringExtension strE = new StringExtension();
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            Manager.InsertCls(strE.GetType<AchievementCategoryCls>(), API_GetCls<AchievementCategoryCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<AdmissionEventCls>(), API_GetCls<AdmissionEventCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<BenefitCls>(), API_GetCls<BenefitCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<CampaignStatusCls>(), API_GetCls<CampaignStatusCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<CompetitiveGroupStatusCls>(), API_GetCls<CompetitiveGroupStatusCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<DictionaryTypeCls>(), API_GetCls<DictionaryTypeCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<DirectionCls>(), API_GetCls<DirectionCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<DocumentCategoryCls>(), API_GetCls<DocumentCategoryCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<DocumentCheckStatusCls>(), API_GetCls<DocumentCheckStatusCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<DocumentTypeCls>(), API_GetCls<DocumentTypeCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<EducationFormCls>(), API_GetCls<EducationFormCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<EducationLevelCls>(), API_GetCls<EducationLevelCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<EntranceTestLanguageCls>(), API_GetCls<EntranceTestLanguageCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<EntranceTestTypeCls>(), API_GetCls<EntranceTestTypeCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<FreeEducationReasonCls>(), API_GetCls<FreeEducationReasonCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<GenderCls>(), API_GetCls<GenderCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<NoticesTypeCls>(), API_GetCls<NoticesTypeCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<OksmCls>(), API_GetCls<OksmCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<OlympicCls>(), API_GetCls<OlympicCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<OlympicDiplomaTypeCls>(), API_GetCls<OlympicDiplomaTypeCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<OlympicLevelCls>(), API_GetCls<OlympicLevelCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<OlympicProfileCls>(), API_GetCls<OlympicProfileCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<OlympicProfileSubjectCls>(), API_GetCls<OlympicProfileSubjectCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<OlympicRelationProfileCls>(), API_GetCls<OlympicRelationProfileCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<PackagesStatusCls>(), API_GetCls<PackagesStatusCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<PaidContractStatusCls>(), API_GetCls<PaidContractStatusCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<PlaceTypeCls>(), API_GetCls<PlaceTypeCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<ReasonsRejectionCls>(), API_GetCls<ReasonsRejectionCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<RegionCls>(), API_GetCls<RegionCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<SpecialConditionsCls>(), API_GetCls<SpecialConditionsCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<StagesAdmissionCls>(), API_GetCls<StagesAdmissionCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<SubjectCls>(), API_GetCls<SubjectCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<TargetAgreeStatusCls>(), API_GetCls<TargetAgreeStatusCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<TargetContractStatusCls>(), API_GetCls<TargetContractStatusCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<TargetContractTypeCls>(), API_GetCls<TargetContractTypeCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<TargetDocumentTypeCls>(), API_GetCls<TargetDocumentTypeCls>().Data ?? []);
            Manager.InsertCls(strE.GetType<TransferMethodOriginalDocumentCls>(), API_GetCls<TransferMethodOriginalDocumentCls>().Data ?? []);
        }

        /// <summary>
        /// Получение все доступные реквизиты (Fields), превращая их в модели кода
        /// </summary>
        /// <param name="Ogrn">Огрн (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп (может пустым, берется из конфигуратора приложения первым)</param>
        public void Command_GetFields(string? Ogrn = null, string? Kpp = null)
        {
            StringExtension strE = new StringExtension();
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            Console.WriteLine("Выполняется запрос: получение справочника \"Документы\"... ");
            var data = Network.SendRequesAsync<DocumentTypeCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<DocumentTypeCls>() }, isCls: true).Item1 ?? [];
            List<FieldsData> fieldsDatas = new List<FieldsData>();
            foreach(var arr in data)
            {
                if (arr.FieldsDescription != null)
                {
                    foreach(var field in (JsonConvert.DeserializeObject<FieldsJSON>(arr.FieldsDescription) ?? new FieldsJSON()).Fields ?? [])
                    {
                        fieldsDatas.Add(field);
                    }
                } 
            }

            Console.WriteLine();
            Console.WriteLine("Доступные типы данных (Int, String, DateTime)...");
            Console.WriteLine();
            foreach(var a in fieldsDatas.Select(a => a.Type).Distinct())
            {
                foreach(var b in fieldsDatas.Select(a => new { a.Type, a.XmlName, a.Description, a.Values }).Distinct())
                {
                    if (b.Type == a)
                    {
                        Console.Write($"""
                        /// <summary>
                        /// {b.Description}
                        /// <summary>
                        public {(a == "integer" ? "int?" : a == "character" ? "string?" : a == "date" ? "DateTime?" : a == "boolean" ? "bool?" : a == "array" ? $"{b.XmlName}List[]?" : "")} {b.XmlName}
                        """);
                        Console.Write(" { get; set; }");
                        Console.WriteLine();
                        Console.WriteLine();

                        if (b.Type == "array")
                        {
                            Console.WriteLine($"public class {b.XmlName}List ");
                            Console.WriteLine("{");
                            foreach(var v in b.Values.Select(a => a.Type).Distinct())
                            {
                                foreach(var v1 in b.Values.Select(a => new { a.Type, a.XmlName, a.Description, a.Values }).Distinct())
                                {
                                    if (v1.Type == v)
                                    {
                                        Console.Write($"""
                                            /// <summary>
                                            /// {v1.Description}
                                            /// <summary>
                                            public {(v == "integer" ? "int?" : v == "character" ? "string?" : v == "date" ? "DateTime?" : v == "boolean" ? "bool?" : "")} {v1.XmlName}
                                        """);
                                        Console.Write(" { get; set; }");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                    }
                                }
                            }
                            Console.WriteLine("}");
                            Console.WriteLine();
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Скопируйте все данные в проект файла библиотеки CryptoCore - Fields!");
            Console.WriteLine("Обращаем ваше внимание!");
            Console.WriteLine("Если имеются классы, переместите их поверх Fields!");
            Console.WriteLine();
        }

        /// <summary>
        /// Проверка работоспособности БД
        /// </summary>
        /// <returns></returns>
        public async Task<int> Command_WorkingDB()
        {
            return await Manager.Test();
        }

        /// <summary>
        /// Получение уникального идентификатора объекта их токенов ССПВО
        /// </summary>
        /// <returns></returns>
        public async Task<int> Command_CreateIdObject()
        {
            return await Manager.CreateIdObject();
        }

        /// <summary>
        /// Получения токенов по соответсвующим статусам
        /// Если хотим получить все токены для отправки, указываем значение IsGetToken = false
        /// Если хотим обработать все отправленные токены,указываем значение IsGetToken = true
        /// </summary>
        /// <param name="IsGetToken">Получение токенов по соответствующим статусам</param>
        /// <returns></returns>
        public async Task<IEnumerable<GetTokenModel?>> Command_GetTokensOwn(bool IsGetToken)
        {
            return await Manager.GetTokensOwn(IsGetToken);
        }

        /// <summary>
        /// Получения токенов по соответсвующим статусам
        /// Если хотим получить все данные токенов от IdJWT, указываем значение IsGetToken = true
        /// Если хотим обработать все токены и распределить все данные по БД, указываем значение IsGetToken = false
        /// </summary>
        /// <param name="IsGetToken">Получение токенов по соответствующим статусам</param>
        /// <returns></returns>
        public async Task<IEnumerable<GetTokenDespatchModel>?> Command_GetTokensDespatch(bool IsGetToken)
        {
            return await Manager.GetTokensDespatch(IsGetToken);
        }

        #endregion
        
        #region Автоматизация

        /// <summary>
        /// Отправка токенов в ССПВО (Автоматизированная версия)
        /// </summary>
        /// <returns></returns>
        public async Task Auto_SendTokens()
        {
            IEnumerable<GetTokenModel> tokens = await Manager.GetTokensOwn();
            foreach (var item in tokens)
            {
                var data = API_NewToken<TokenData?>(item.Action, item.Entity, item.Ogrn, item.Kpp, Xml: item.Payload);
                if (data.Data != null)
                {
                    await Manager.UpdateToken(item.IdObject, (int)data.Data.IdJwt, (int)data.Data.DelaySeconds);
                }
                await Task.Delay(2000);
            }
            if (tokens.Count() == 0) Console.WriteLine("Очередь на отправку пуста!"); Console.WriteLine();
        }

        /// <summary>
        /// Принятия результатов токенов из ССПВО (Автоматизированная версия)
        /// </summary>
        /// <returns></returns>
        public async Task Auto_GetTokens()
        {
            IEnumerable<GetTokenModel> tokens = await Manager.GetTokensOwn(true);
            foreach (var item in tokens)
            {
                if (item.IdJWT != null)
                {
                    bool isStop = false;
                    string data = API_GetOwn((int)item.IdJWT, item.Ogrn, item.Kpp).XmlData;
                    if (data != null)
                    {
                        if (data.DecodeXml<DefaultResponse>(true).ErrorList != null && !isStop)
                        {
                            await Manager.CreateToken(6, item.IdObject, Result: data);
                            isStop = true;
                        }
                        if (item.Action.Contains("Get") && !isStop)
                        {
                            await Manager.CreateToken(5, item.IdObject, Result: data);
                            isStop = true;
                        }
                        if (!item.Action.Contains("Get") && !isStop)
                        {
                            await Manager.CreateToken(4, item.IdObject, Result: data);
                            isStop = true;
                        }
                    }
                }

                await Task.Delay(2000);
            }
            if (tokens.Count() == 0) Console.WriteLine("Очередь на принятия данных пуста!"); Console.WriteLine();
        }

        /// <summary>
        /// Получения Id токенов из внешнего источника (Despatch) в ССПВО (Автоматизированная версия)
        /// </summary>
        /// <returns></returns>
        public async Task Auto_GetIdsJwtDespatch()
        {
            Console.WriteLine("Запущен процесс получения списков идентификаторов токенов");
            var data = API_GetJwtList(true);
            {
                if (data.JwtList == null) Console.WriteLine("Отсутствуют данные!");
                if (data.JwtList != null && data.JwtList.Length == 0) Console.WriteLine("В очереди отсутвствуют данные!");
                if (data.JwtList != null && data.JwtList.Length > 0)
                {
                    foreach (var item in data.JwtList.List)
                    {
                        Console.WriteLine("Запись в БД уникальный идентификатор токена: {0}", item);
                        await Manager.UpdateToken(item);
                        await Task.Delay(1000);
                    }
                }
            }
        }

        /// <summary>
        /// Получения всех токенов из внешних источников (Despatch) в ССПВО (Автоматизированная версия)
        /// </summary>
        /// <returns></returns>
        public async Task Auto_GetTokensDespatch()
        {
            Console.WriteLine("Запущен процесс получения токенов по идентификаторам IdJwt");
            var tokens = await Manager.GetTokensDespatch();
            foreach(var item in tokens)
            {
                var data = API_GetDespatch(item.IdJwt);
                if (data.XmlData != null)
                {
                    await Manager.CreateToken(item.IdJwt, data.XmlData, data.Header.Entity, data.Header.CreatedAt);
                }
                await Task.Delay(2000);
            }
            if (tokens.Count() == 0) Console.WriteLine("Очередь на принятия данных от источников пуста!"); Console.WriteLine();
        }

        #endregion

        #region Установка БД

        /// <summary>
        /// Дабавления таблиц, данные и хранимые процедуры в БД
        /// </summary>
        public void Setup_DataInDB()
        {
            bool isLoadCls = false;
            Console.WriteLine("Данный сервис предназначен для добавления необходимых таблиц и хранимых процедур ");
            Console.WriteLine("Выбрана БД для работы сервиса API: " + Startup.AppSetting.StartupSQLForAPI);
            Console.Write("Добавить все справочные материалы из ССПВО (Cls)? (Y/N)"); 
            string accept = Console.ReadLine();
            if (accept == "Y") isLoadCls = true;
            // if (Startup.AppSetting.ConnectionStrings.Where(a => a.Name == Startup.AppSetting.StartupSQLForAPI).FirstOrDefault().SQLName.ToUpper() == "MSSQL".ToUpper()) ForMSSQL(isLoadCls);
            // if (Startup.AppSetting.ConnectionStrings.Where(a => a.Name == Startup.AppSetting.StartupSQLForAPI).FirstOrDefault().SQLName.ToUpper() == "PostgreSQL".ToUpper()) ForPostgreSQL(isLoadCls);
        }

        private async Task ForMSSQL(bool isLoadCls)
        {
            Console.WriteLine("Добавление таблицы \"Логирования ошибок (RS_RequestLog)\"... ");
            await Manager.InsertSQLText("""
                CREATE TABLE RS_RequestLog (
                Id int identity (1,1),
                Message nvarchar(max) null,
                StackTrace nvarchar(max) null,
                MessageResult nvarchar(max) null,
                Sender nvarchar(max) null,
                DateCreate datetime null
            );
            """);
            
            Console.WriteLine("Добавление таблицы \"Хранения токенов внутренних данных (Own) (RS_PackageTokens)\"");
            await Manager.InsertSQLText("""
            CREATE TABLE RS_PackageTokens (
                IdObject int not null
                Action nvarchar(max) not null,
                Entity nvarchar(max) not null,
                Ogrn nvarchar(max) not null,
                Kpp nvarchar(max) not null,
                Payload nvarchar(max) not null,
                Result nvarchar(max) null,
                Status int not null,
                IdJWT bigint null,
                DelaySecond int null,
                CreateDate datetime null,
                UpdateDate datetime null
            );
            """);

            Console.WriteLine("Добавления таблицы \"Хранения токенов внешних данных (Despatch) (RS_PackageTokens)\"");
            await Manager.InsertSQLText("""
              create table RS_PackageTokensDespatch
              (
                Id int not null identity(1, 1),
                IdJwt bigint null,
                Entity nvarchar(max) null,
                CreatedAt nvarchar(max) null,
                Payload nvarchar(max) null,
                Status int null,
                CreatedDateDB datetime null,
                UpdateDateDB datetime null
              );
            """);

            Console.WriteLine("Добавление таблицы \"Мониторинга для обработки данных из клиентской части (RS_MonitoringApp)\"");
            await Manager.InsertSQLText("""
            CREATE TABLE RS_MonitoringApp (
                IdObject int null,
                StatusApp int null,
                ActionApp nvarchar(max),
                AddTime datetime null
            );
            """);

            Console.WriteLine("Добавление таблицы \"Статусы токенов (RS_StatusListCls)\"");
            await Manager.InsertSQLText("""
            CREATE TABLE RS_StatusListCls (
                Id int identity(1,1),
                Name nvarchar(max) null
            );
            """);

            Console.WriteLine("Внесение данных в таблицу RS_StatusListCls (В обработке: добавление)");
            await Manager.InsertSQLText("insert into RS_StatusListCls (Name) values ('В обработке: добавление');");

            Console.WriteLine("Внесение данных в таблицу RS_StatusListCls (В обработке: обновление)");
            await Manager.InsertSQLText("insert into RS_StatusListCls (Name) values ('В обработке: обновление');");

            Console.WriteLine("Внесение данных в таблицу RS_StatusListCls (В обработке: удаление)");
            await Manager.InsertSQLText("insert into RS_StatusListCls (Name) values ('В обработке: удаление');");

            Console.WriteLine("Внесение данных в таблицу RS_StatusListCls (Загружено)");
            await Manager.InsertSQLText("insert into RS_StatusListCls (Name) values ('Загружено');");

            Console.WriteLine("Внесение данных в таблицу RS_StatusListCls (Выгружена)");
            await Manager.InsertSQLText("insert into RS_StatusListCls (Name) values ('Выгружена');");

            Console.WriteLine("Внесение данных в таблицу RS_StatusListCls (Ошибка)");
            await Manager.InsertSQLText("insert into RS_StatusListCls (Name) values ('Ошибка');");

            Console.WriteLine("Внесение данных в таблицу RS_StatusListCls (В обработке: получен токен)");
            await Manager.InsertSQLText("insert into RS_StatusListCls (Name) values ('В обработке: получен токен');");

            Console.WriteLine("Внесение данных в таблицу RS_StatusListCls (Новый)");
            await Manager.InsertSQLText("insert into RS_StatusListCls (Name) values ('Новый');");

            Console.WriteLine("Добавление хранимой процедуры \"Удаления движения (RS_DeleteActionApp)\"");
            await Manager.InsertSQLText($"""
            GO
            /****** Object:  StoredProcedure [dbo].[RS_DeleteActionApp]    Script Date: {DateTime.Now} ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            -- =============================================
            -- Author:		ReceptionServiceAPI
            -- Create date: {DateTime.Now}
            -- Description:	Удаления движения
            -- =============================================
            CREATE PROCEDURE [dbo].[RS_DeleteActionApp] 
                @IdObject int
            AS
            BEGIN
                delete RS_MonitoringApp where IdObject = @IdObject
            END;
            """);

            Console.WriteLine("Добавление хранимой процедуры \"Просмотр движения (RS_GetActionApp)\"");
            await Manager.InsertSQLText($"""
            GO
            /****** Object:  StoredProcedure [dbo].[RS_GetActionApp]    Script Date: {DateTime.Now} ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            -- =============================================
            -- Author:		ReceptionServiceAPI
            -- Create date: {DateTime.Now}
            -- Description:	Просмотр движения
            -- =============================================
            CREATE PROCEDURE [dbo].[RS_GetActionApp] 
            AS
            BEGIN
                select MA.IdObject, MA.StatusApp, MA.ActionApp, PT.Result, PT.Payload, PT.Status from RS_MonitoringApp MA (nolock)
                left join RS_PackageTokens PT (nolock) on MA.IdObject = PT.IdObject
                order by MA.AddTime
            END;
            """);

            Console.WriteLine("Добавление хранимой процедуры \"Добавления движения (RS_InsertActionApp)\"");
            await Manager.InsertSQLText($"""
            GO
            /****** Object:  StoredProcedure [dbo].[RS_InsertActionApp]    Script Date: {DateTime.Now} ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            -- =============================================
            -- Author:		ReceptionServiceAPI
            -- Create date: {DateTime.Now}
            -- Description:	Добавления движения
            -- =============================================
            CREATE PROCEDURE [dbo].[RS_InsertActionApp] 
                @IdObject int,
                @ActionApp nvarchar(max) null
            AS
            BEGIN
                if exists (select 1 from RS_MonitoringApp where IdObject = @IdObject)
                begin
                    update RS_MonitoringApp
                    set StatusApp = 5
                    where IdObject = @IdObject
                end
                else
                    begin
                    insert into RS_MonitoringApp (IdObject, StatusApp, ActionApp, AddTime)
                    values (@IdObject, 1, @ActionApp, GETDATE())
                end
            END;
            """);

            Console.WriteLine("Добавление хранимой процедуры \"Создание уникального идентификатора объекта (IdObject) (RS_GetIdObject)\"");
            await Manager.InsertSQLText($"""
            GO
            /****** Object:  StoredProcedure [dbo].[RS_GetIdObject]    Script Date: {DateTime.Now} ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            -- =============================================
            -- Author:		ReceptionServiceAPI
            -- Create date: {DateTime.Now}
            -- Description:	Создание IdObject
            -- =============================================
            CREATE PROCEDURE [dbo].[RS_GetIdObject]
            AS
            BEGIN
                select ISNULL(Max(IdObject), 0) + 1 as [IdObject] from RS_PackageTokens
            END;
            """);

            Console.WriteLine("Добавление хранимой процедуры \"Просмотр токенов (RS_GetToken)\"");
            await Manager.InsertSQLText($"""
            GO
            /****** Object:  StoredProcedure [dbo].[RS_GetToken]    Script Date: {DateTime.Now} ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            -- =============================================
            -- Author:		ReceptionServiceAPI
            -- Create date: {DateTime.Now}
            -- Description:	Просмотр токена
            -- =============================================
            CREATE PROCEDURE [dbo].[RS_GetToken]
                @IsDespatch bit = 0,
                @IsGetToken bit = 0
            AS
            BEGIN
                if @IsDespatch = 0
                begin
                    if (@IsGetToken = 1)
                    begin
                        select * from RS_PackageTokens
                        where Status in (7)
                        order by IdObject
                    end
                    else
                        begin
                        select * from RS_PackageTokens
                        where Status in (1, 2, 3)
                        order by IdObject
                    end
                end
                else
                begin
                    if (@IsGetToken = 1)
                    begin
                        select * from RS_PackageTokensDespatch
                        where Status in (7)
                    end
                    else
                    begin
                        select * from RS_PackageTokensDespatch
                        where Status in (9)
                    end
                end
            END;
            """);

            Console.WriteLine("Добавление хранимой процедуры \"Внесения идентификатор JWT (RS_InsertJWT)\"");
            await Manager.InsertSQLText($"""
            GO
            /****** Object:  StoredProcedure [dbo].[RS_InsertJWT]    Script Date: {DateTime.Now} ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            -- =============================================
            -- Author:		ReceptionServiceAPI
            -- Create date: {DateTime.Now}
            -- Description:	Внесения идентификатора JWT
            -- =============================================
            CREATE PROCEDURE [dbo].[RS_InsertJWT]
                -- Разделение таблицы PackageTokens (Own) и PackageTokensDespatch (Despatch)
                @IsDespatch bit,
                
                -- Для значения таблицы PackageTokens (Own)
                @IdObject int null,
                @DelaySecond int null,
                
                -- Общие значения
                @IdJwt int null
            AS
            BEGIN
                if @IsDespatch = 0
                    begin
                        update RS_PackageTokens
                        set IdJwt = @IDJwt, DelaySecond = @DelaySecond, Status = 7
                        where IdObject = @IdObject
                    end
                    else
                    begin
                    if not exists (select top 1 * from RS_PackageTokensDespatch where IdJwt = @IdJwt)
                    begin
                        insert into RS_PackageTokensDespatch (IdJwt, Status, CreatedDateDB)
                        values (@IdJwt, 7, GETDATE())
                    end
                end
            END;
            """);

            Console.WriteLine("Добавление хранимой процедуры \"Внесения токена (RS_InsertToken)\"");
            await Manager.InsertSQLText($"""
            GO
            /****** Object:  StoredProcedure [dbo].[InsertToken]    Script Date: {DateTime.Now} ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            -- =============================================
            -- Author:		ReceptionServiceAPI
            -- Create date: {DateTime.Now}
            -- Description:	Внесения токена
            -- =============================================
            CREATE PROCEDURE [dbo].[RS_InsertToken]
                @IdObject int,
                @Status int,
                @Action nvarchar(max) null,
                @Entity nvarchar(max) null,
                @Ogrn nvarchar(max) null,
                @Kpp nvarchar(max) null,
                @Payload nvarchar(max) null,
                @Result nvarchar(max) null
            AS
            BEGIN
                if (@Payload is not null)
                begin
                    insert RS_PackageTokens (IdObject, Action, Entity, Ogrn, Kpp, Payload, Status, CreateDate) values
                    (@IdObject, @Action, @Entity, @Ogrn, @Kpp, @Payload, @Status, getdate())
                end
                if (@Result is not null)
                begin
                    update RS_PackageTokens
                    set Result = @Result, Status = @Status, UpdateDate = GETDATE()
                    where IdObject = @IdObject
                end
            END;
            """);

            Console.WriteLine("Добавление хранимой процедуры \"Внесения токена (RS_InsertTokenDespatch)\"");
            await Manager.InsertSQLText($"""
            GO
            /****** Object:  StoredProcedure [dbo].[InsertToken]    Script Date: {DateTime.Now} ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            -- =============================================
            -- Author:		ReceptionServiceAPI
            -- Create date: {DateTime.Now}
            -- Description:	Внесения токена (Despatch)
            -- =============================================
            CREATE PROCEDURE [dbo].[InsertTokenDespatch]
                @IdJwt int,
                @Entity nvarchar(max) null,
                @CreatedAt nvarchar(max) null,
                @Payload nvarchar(max) null
            AS
            BEGIN
                if (@Payload is not null) and exists (select top 1 * from PackageTokensDespatch where IdJwt = @IdJwt)
                begin
                    update PackageTokensDespatch
                    set Status = 9, Entity = @Entity, CreatedAt = @CreatedAt, Payload = @Payload, UpdateDateDB = GetDate()
                    where IdJwt = @IdJwt
                end
                else if exists (select top 1 * from PackageTokensDespatch where IdJwt = @IdJwt and Status = 9)
                begin
                    update PackageTokens
                    set Status = 5, UpdateDate = GETDATE()
                    where IdJwt = @IdJwt
                end
            END
            """);

            Console.WriteLine("Добавление хранимой процедуры \"Сохранение логов в случае если произошла ошибка при отправке запроса (RS_SaveLogRequest)\"");
            await Manager.InsertSQLText($"""
            GO
            /****** Object:  StoredProcedure [dbo].[SaveLogRequest]    Script Date: {DateTime.Now} ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            -- =============================================
            -- Author:		ReceptionServiceAPI
            -- Create date: {DateTime.Now}
            -- Description:	Сохранение логов в случае если произошла ошибка при отправке запроса
            -- =============================================
            CREATE PROCEDURE [dbo].[RS_SaveLogRequest] 
                @Message nvarchar(max) = null,
                @StackTrace nvarchar(max) = null,
                @MessageResult nvarchar(max) = null,
                @Sender nvarchar(max) = null
            AS
            BEGIN
                insert into RS_RequestLog ([Message], StackTrace, MessageResult, Sender, DateCreate)
                values (@Message, @StackTrace, @MessageResult, @Sender, GETDATE())
            END;
            """);
        }

        private void ForPostgreSQL(bool isLoadCls)
        {

        }

        #endregion
        
    }
}