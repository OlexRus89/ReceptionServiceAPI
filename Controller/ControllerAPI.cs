using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        /// Внесение справочников
        /// </summary>
        /// <param name="Ogrn">Огрн организации (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп организации (может пустым, берется из конфигуратора приложения первым)</param>
        public void InsertCls(string? Ogrn = null, string? Kpp = null)
        {
            StringExtension strE = new StringExtension();
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            Manager.InsertCls(strE.GetType<AchievementCategoryCls>(), Network.SendRequesAsync<AchievementCategoryCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<AchievementCategoryCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<AdmissionEventCls>(), Network.SendRequesAsync<AdmissionEventCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<AdmissionEventCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<BenefitCls>(), Network.SendRequesAsync<BenefitCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<BenefitCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<CampaignStatusCls>(), Network.SendRequesAsync<CampaignStatusCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<BenefitCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<CompetitiveGroupStatusCls>(), Network.SendRequesAsync<CompetitiveGroupStatusCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<CompetitiveGroupStatusCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<DictionaryTypeCls>(), Network.SendRequesAsync<DictionaryTypeCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<DictionaryTypeCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<DirectionCls>(), Network.SendRequesAsync<DirectionCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<DirectionCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<DocumentCategoryCls>(), Network.SendRequesAsync<DocumentCategoryCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<DocumentCategoryCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<DocumentCheckStatusCls>(), Network.SendRequesAsync<DocumentCheckStatusCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<DocumentCheckStatusCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<DocumentTypeCls>(), Network.SendRequesAsync<DocumentTypeCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<DocumentTypeCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<EducationFormCls>(), Network.SendRequesAsync<EducationFormCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<EducationFormCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<EducationLevelCls>(), Network.SendRequesAsync<EducationLevelCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<EducationLevelCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<EntranceTestLanguageCls>(), Network.SendRequesAsync<EntranceTestLanguageCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<EntranceTestLanguageCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<EntranceTestTypeCls>(), Network.SendRequesAsync<EntranceTestTypeCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<EntranceTestTypeCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<FreeEducationReasonCls>(), Network.SendRequesAsync<FreeEducationReasonCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<FreeEducationReasonCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<GenderCls>(), Network.SendRequesAsync<GenderCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<GenderCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<NoticesTypeCls>(), Network.SendRequesAsync<NoticesTypeCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<NoticesTypeCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<OksmCls>(), Network.SendRequesAsync<OksmCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<OksmCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<OlympicCls>(), Network.SendRequesAsync<OlympicCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<OlympicCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<OlympicDiplomaTypeCls>(), Network.SendRequesAsync<OlympicDiplomaTypeCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<OlympicDiplomaTypeCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<OlympicLevelCls>(), Network.SendRequesAsync<OlympicLevelCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<OlympicLevelCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<OlympicProfileCls>(), Network.SendRequesAsync<OlympicProfileCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<OlympicProfileCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<OlympicProfileSubjectCls>(), Network.SendRequesAsync<OlympicProfileSubjectCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<OlympicProfileSubjectCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<OlympicRelationProfileCls>(), Network.SendRequesAsync<OlympicRelationProfileCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<OlympicRelationProfileCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<PackagesStatusCls>(), Network.SendRequesAsync<PackagesStatusCls[]>(Point.ClsGet, new HeaderClsData { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<PackagesStatusCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<PaidContractStatusCls>(), Network.SendRequesAsync<PaidContractStatusCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<PaidContractStatusCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<PlaceTypeCls>(), Network.SendRequesAsync<PlaceTypeCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<PlaceTypeCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<ReasonsRejectionCls>(), Network.SendRequesAsync<ReasonsRejectionCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<ReasonsRejectionCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<RegionCls>(), Network.SendRequesAsync<RegionCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<RegionCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<SpecialConditionsCls>(), Network.SendRequesAsync<SpecialConditionsCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<SpecialConditionsCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<StagesAdmissionCls>(), Network.SendRequesAsync<StagesAdmissionCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<StagesAdmissionCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<SubjectCls>(), Network.SendRequesAsync<SubjectCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<SubjectCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<TargetAgreeStatusCls>(), Network.SendRequesAsync<TargetAgreeStatusCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<TargetAgreeStatusCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<TargetContractStatusCls>(), Network.SendRequesAsync<TargetContractStatusCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<TargetContractStatusCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<TargetContractTypeCls>(), Network.SendRequesAsync<TargetContractTypeCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<TargetContractTypeCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<TargetDocumentTypeCls>(), Network.SendRequesAsync<TargetDocumentTypeCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<TargetDocumentTypeCls>() }, isCls: true).Item1 ?? []);
            Manager.InsertCls(strE.GetType<TransferMethodOriginalDocumentCls>(), Network.SendRequesAsync<TransferMethodOriginalDocumentCls[]>(Point.ClsGet, new HeaderClsData() { Ogrn = Ogrn, Kpp = Kpp, Cls = strE.GetType<TransferMethodOriginalDocumentCls>() }, isCls: true).Item1 ?? []);
        }

        /// <summary>
        /// Добавления сессии
        /// </summary>
        /// <param name="Ogrn">Огрн организации</param>
        /// <param name="Kpp">Кпп организации</param>
        public void SetSessionKey(string? Ogrn = null, string? Kpp = null)
        {
            Session = Session.SetSession(Startup);
        }

        /// <summary>
        /// Проверка сертификата
        /// </summary>
        /// <param name="Ogrn">Огрн организации (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп организации (может пустым, берется из конфигуратора приложения первым)</param>
        /// <returns>Возвращает целостность сертификата. True - сертификат действующий, False - проблема с сертификатом</returns>
        public (bool, string) CheckCertificate(string? Ogrn = null, string? Kpp = null)
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
        public void GetDelay()
        {
            Console.Write("Выполняется запрос: пропускная способность ... ");
            var data = Network.SendRequesAsync<DelayData>(Point.DelayGet, null, Method: "Get");
            Console.WriteLine("завершение операции с ответом ... " + "\n" + (data.Item1 != null ? (data.Item1.Comment + ".\nКоличество секунд задержки: " + data.Item1.DelayHumanReadable + "\n") : "Ошибка записана в логе!\n"));
        }

        /// <summary>
        /// Получение все доступные реквизиты (Fields), превращая их в модели кода
        /// </summary>
        /// <param name="Ogrn">Огрн (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп (может пустым, берется из конфигуратора приложения первым)</param>
        public void GetFields(string? Ogrn = null, string? Kpp = null)
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
        public TokenData? NewToken<T>(string Action, string? Entity, string? Ogrn = null, string? Kpp = null, T? Tdata = default(T), string? Xml = null) 
        {
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            SetSessionKey(Ogrn, Kpp);
            Console.Write("Выполняется запрос: добавление токена ... ");
            if (Tdata == null && Xml == null)
            {
                Debug.Write("завершение операции с ответом ... ОШИБКА! ВНЕСИТЕ ДАННЫЕ ЗНАЧЕНИИ XML ИЛИ СУЩЕСТВУЮЩИХ МОДЕЛИ ДАННЫХ!");
                return null;
            }
            var data = Network.SendRequesAsync<TokenData>(Point.TokenNew, new HeaderData() { Action = Action, Entity = Entity == null ? new StringExtension().GetType<T>() : Entity, Ogrn = Ogrn, Kpp = Kpp }, Xml == null ? Tdata.EncodeXml<T>().SetPD() : Xml, Session.SessionKey, true);
            Console.Write("завершение операции с ответом ... " + (data.Item1 != null ? data.Item1.IdJwt.ToString().ToUpper() + "\n" : "Ошибка записана в логе!\n"));
            return data.Item1;
        }

        /// <summary>
        /// Результат выполнения отправки токена
        /// </summary>
        /// <param name="IdJwt">Уникальный идентификатор токена</param>
        /// <param name="Ogrn">Огрн (может пустым, берется из конфигуратора приложения первым)</param>
        /// <param name="Kpp">Кпп (может пустым, берется из конфигуратора приложения первым)</param>
        /// <returns>Строчный результат</returns>
        public string? GetOwn(int IdJwt, string? Ogrn = null, string? Kpp = null)
        {
            if (Ogrn == null) Ogrn = Startup.AppSetting.Ogrn;
            if (Kpp == null) Kpp = Startup.AppSetting.Kpp.First().KppOrganization;
            SetSessionKey(Ogrn, Kpp);
            Console.Write("Выполняется запрос: получения токена ... ");
            var data = Network.SendRequesAsync<TokenData>(Point.OwnGet, null, "{ \"IdJwt\" : "  + IdJwt + " }", Session.SessionKey);
            Console.Write("завершение операции с ответом ... " + (data.Item1 != null ? "Имеется токен" + "\n" : "Ошибка записана в логе!\n"));
            if (data.Item1 == null) return null;
            return Encoding.UTF8.GetString(Convert.FromBase64String(data.Item1.Token.Split('.')[1]));
        }

        /// <summary>
        /// Проверка работоспособности БД
        /// </summary>
        /// <returns></returns>
        public async Task<int> Test()
        {
            return await Manager.Test();
        }

        /// <summary>
        /// Отправка токенов в ССПВО (Автоматизированная версия)
        /// </summary>
        /// <returns></returns>
        public async Task SendTokens()
        {
            IEnumerable<GetTokenModel> tokens = await Manager.GetTokens();
            foreach (var item in tokens)
            {
                var data = NewToken<TokenData?>(item.Action, item.Entity, item.Ogrn, item.Kpp, Xml: item.Payload);
                if (data != null)
                {
                    await Manager.UpdateToken(item.IdObject, (int)data.IdJwt, (int)data.DelaySeconds);
                }
                await Task.Delay(2000);
            }
            if (tokens.Count() == 0) Console.WriteLine("Очередь на отправку пуста!"); Console.WriteLine();
        }

        public async Task<int> CreateIdObject()
        {
            return await Manager.CreateIdObject();
        }

        /// <summary>
        /// Принятия результатов токенов из ССПВО (Автоматизированная версия)
        /// </summary>
        /// <returns></returns>
        public async Task GetTokens()
        {
            IEnumerable<GetTokenModel> tokens = await Manager.GetTokens(true);
            foreach (var item in tokens)
            {
                if (item.IdJWT != null)
                {
                    bool isStop = false;
                    string data = GetOwn((int)item.IdJWT, item.Ogrn, item.Kpp);
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
        /// Дабавления таблиц, данные и хранимые процедуры в БД
        /// </summary>
        public void SetupDataInDB()
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
            
            Console.WriteLine("Добавление таблицы \"Хранения токенов (RS_PackageTokens)\"");
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
                @IsGetToken bit = 0
            AS
            BEGIN
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
                @IdObject int,
                @IdJwt int,
                @DelaySecond int
            AS
            BEGIN
                update RS_PackageTokens
                set IdJwt = @IDJwt, DelaySecond = @DelaySecond, Status = 7
                where IdObject = @IdObject
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
    }
}