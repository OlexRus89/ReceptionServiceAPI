using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CryptoCore.Extensions;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using CryptoCore.Models.ReceptionService;
using CryptoCore.Models.ReceptionService.Own;
using Microsoft.IdentityModel.Tokens;
using System.IO;

namespace CryptoCore.Models
{
    public class StartupModel
    {
        public AppSetting? AppSetting { get; set; }
        public StartupModel? Startup(bool isEdit = false)
        {
            StartupModel startup = new StartupModel();
            CryptographyExtension crypro = new CryptographyExtension();
            var file = DirectoryFiles();
            if (!file.FileAppData.Exists)
            {
                if (!file.FileSetup.Exists)
                {
                    if (!isEdit)
                    {
                        Console.WriteLine("""
                        Перед запуском программы, убедитесь, что у вас имеется специальный файл конфигуратора UserSettings.setting!
                        Без этого конфигуратора, вы не можете работать в дальнейшем!
                        """);
                        return HelpContext();
                    }
                    else return null;
                }
            }

            if (file.FileSetup.Exists)
            {
                try
                {
                    using (StreamReader stringReader = new StreamReader(file.FileSetup.ToString()))
                    {
                        startup = JsonConvert.DeserializeObject<StartupModel>(stringReader.ReadToEnd());
                        stringReader.Close();
                    }
                    file.FileTempAppData.Create();
                    using (StreamWriter writer = new StreamWriter(file.FileAppData.ToString(), false))
                    {
                        writer.WriteLine(crypro.EncodeToBase64(JsonConvert.SerializeObject(startup)));
                        writer.Close();
                    }
                    file.FileSetup.Delete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка при формировании JSON документа: " + ex.Message + " Исправьте данные ошибки конфигуратора!");
                    Console.WriteLine("Нажмите на любую клавишу для выхода из терминала...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                if (IsValid(startup)) return startup;
                else
                {
                    IsValidComment(startup);
                }
            }

            if (file.FileAppData.Exists)
            {
                try
                {
                    using (StreamReader stringReader = new StreamReader(file.FileAppData.ToString()))
                    {
                        startup = JsonConvert.DeserializeObject<StartupModel>(crypro.DecodeToBase64(stringReader.ReadToEnd()));
                        stringReader.Close();
                    }
                    if (IsValid(startup)) return startup;
                    else 
                    {
                        IsValidComment(startup);
                        return null;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка при формировании JSON документа: " + ex.Message + " Исправьте данные ошибки конфигуратора!");
                    Console.WriteLine("Нажмите на любую клавишу для выхода из терминала...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                if (IsValid(startup)) return startup;
                else
                {
                    IsValidComment(startup);
                }
            }
            return null;
        }

        public StartupModel? HelpContext(bool isEdit = false)
        {
            var os = Environment.OSVersion;
            var a = Enum.GetValues(typeof(Environment.SpecialFolder))
                .Cast<Environment.SpecialFolder>()
                .Select(specialFolder => new
                {
                    Name = specialFolder.ToString(),
                    Path = Environment.GetFolderPath(specialFolder)
                })
                .OrderBy(item => item.Path.ToLower());
            FileInfo FileAppData = new FileInfo(a.First(a => a.Name == "MyDocuments").Path + (os.Platform == PlatformID.Win32NT ? "\\UserSettings.setting" : "/UserSettings.setting"));
            FileInfo TemplateSetting = new FileInfo(os.Platform == PlatformID.Win32NT ? "Template\\UserSettings.setting" : "Template/UserSettings.setting");
            StartupModel startup = new StartupModel();
            if (isEdit) startup = startup.Startup(isEdit);
            while (true)
            {
                Console.WriteLine($"""
                        
                Действия:
                |    -- Перезапустить - Перезапустить программу
                |    -- Шаблон - Скачать шаблон конфигуратора UserSettings.setting
                |    -- {(isEdit ? "Изменить" : "Создать")} - {(isEdit ? "Изменить" : "Создать")} собственный конфигуратор
                |    -- Помощь - Помощь по конфигуратору
                |    -- Выход - Выход из программы

                """);

                Console.Write("Команда: ");
                var key = Console.ReadLine();

                Console.WriteLine();

                if (key == "Перезапустить")
                {
                    return Startup();
                }
                if (key == "Шаблон") HelpContextPattern(startup, TemplateSetting, FileAppData);
                if (key == "Помощь") HelpContextHelp();
                if (key == $"{((isEdit ? "Изменить" : "Создать"))}") HelpContextCreate(startup, isEdit);
                if (key == "Я программист") break;
                if (!(key == "Шаблон" || key == "Помощь" || key == "Перезапустить" || key == $"{((isEdit ? "Изменить" : "Создать"))}")) Environment.Exit(0);
            }
            return null;
        }

        private void HelpContextPattern(StartupModel? startup, FileInfo TemplateSetting, FileInfo FileAppData)
        {
            try
            {
                using (StreamReader stringReader = new StreamReader(TemplateSetting.ToString()))
                {
                    startup = JsonConvert.DeserializeObject<StartupModel>(stringReader.ReadToEnd());
                    stringReader.Close();
                }
                using (StreamWriter writer = new StreamWriter(FileAppData.ToString(), false))
                {
                    writer.WriteLine(JsonConvert.SerializeObject(startup));
                    writer.Close();
                }
                Console.WriteLine("""
                Шаблон конфигуратора находится в папке "Мои Документы"!
                После добавления/изменении конфигурации переместите данный файл на рабочий стол!
                """);
                Console.WriteLine();
                Console.WriteLine("Нажмите на любую клавишу для возвращения назад...");
                Console.ReadLine();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();

            }
        }

        private void HelpContextHelp()
        {
            Console.WriteLine("""
            Вопросы и ответы:
               
            Q: Почему программа не работает?
            A: Вы должны установить специальный файл UserSettings с готовыми настройками, чтобы данная программа могла функционировать.

            Q: Как установить данный файл?
            A: Для ее установки Вам нужно указать в команде "Шаблон", файл будет скачан в папке "Мои документы", внесите свои конфигурации.

            Q: Куда размещать данный файл?
            A: Переместите данный файл на рабочий стол. Программа автоматически найдет и удалит файл из рабочего стола.

            Q: Если мне нужно изменить коррективы в файле с настройками?
            A: Имеется 2 варианта. 
            1 Способ: Вы можете использовать готовый шаблон или Ваш измененный конфигуратор, переместить на рабочий стол. Программа обнаружит изменения и исправит их на актуальность работоспособности программы
            2 Способ: С помощью консоли, указывая команду "Создать"

            Q: У меня не работает программа, выдает ошибку или вылетает
            A: Проверьте корректность конфигуратора. 
            Если не все в порядке с файлами настройками, напишите в ВК (@olexrus89) c фотографиями ошибки или позвоните по номеру 8(8652)95-68-00, внутр. 1467, чтобы мы могли вам помочь с данными проблемами!
            """);
            Console.WriteLine();
            Console.WriteLine("Нажмите на любую клавишу для возвращения назад...");
            Console.ReadLine();
            HelpContext();
        }

        private void HelpContextCreate(StartupModel? startup, bool IsEdit = false)
        {
            if (!IsEdit)
            {
                startup.AppSetting = new AppSetting()
                {
                    URLs = [],
                    StartupURL = "",
                    ConnectionStrings = [],
                    StartupSQLForAPI = "",
                    StartupSQLForClient = "",
                    Ogrn = "",
                    Kpp = [],
                    CerificateName = "",
                    StartupDelay = -1,
                    Key = "",
                    SaveFileDirectory = "",
                    Source = ""
                };
            }

            bool IsExit = false;
            while (!IsExit)
            {
                string Keyword = "";
                Console.WriteLine($"""
                Для {(!IsEdit ? "создания нового" : "изменения текущего")} конфигуратора вам доступны следующие команды:
                |    -- URL - Массив url-адресов для входа в ССПВО {(startup.AppSetting.URLs.Count() > 0 ? $"(Внесено: {startup.AppSetting.URLs.Count()})" : "")}
                |    |   -- UrlName - Наименование url-адреса
                |    |   -- Url - Url-адрес
                |    -- StartupURL: Наименование запуска Url-адреса {(startup.AppSetting.StartupURL != "" ? "✓" : "")}
                |    -- ConnectionStrings: Массив базы данных {(startup.AppSetting.ConnectionStrings.Count() > 0 ? $"(Внесено: {startup.AppSetting.ConnectionStrings.Count()})" : "")}
                |    |   -- Name - Наименование базы данных
                |    |   -- SQLName - Тип подключения
                |    |   -- ConnectionString - Путь подключения БД
                |    -- StartupSQLForAPI - Наименование запуска БД для API (Присваивается из ConnectionStrings) (Для данной программы) {(startup.AppSetting.StartupSQLForAPI != "" ? "✓" : "")}
                |    -- StartupSQLForClient - Наименование запуска БД для клиентской части (Присваивается из ConnectionStrings) (Для работы с программой ССПВО для технических секретарей) {(startup.AppSetting.StartupSQLForClient != "" ? "✓" : "")}
                |    -- Ogrn - ОГРН организации {(startup.AppSetting.Ogrn != "" ? "✓" : "")}
                |    -- Kpp - Массив КПП организации {(startup.AppSetting.Kpp.Count() > 0 ? $"(Внесено: {startup.AppSetting.Kpp.Count()})" : "")}
                |    |   -- NameKpp - Наименование КПП организации
                |    |   -- KppOrganization - КПП организации
                |    -- SaveFileDirectory - Наименование сохранения файла (например, для Windows - С:\Users\Пользователь\Desktop\Файл, для Linux - /home/Пользователь/Desktop/Файл) {(startup.AppSetting.SaveFileDirectory != "" ? "✓" : "")}
                |    -- CerificateName - Наименование сертификата (по правилу указать 1 слово вашего сертификата из программы КриптоПро) {(startup.AppSetting.CerificateName != "" ? "✓" : "")}
                |    -- StartupDelay - Задержка времени (в сек.) работоспособности программы во избежание постоянных отправок данных в ССПВО, значение можно поставить от 2 секунд и выше {(startup.AppSetting.StartupDelay != -1 ? "✓" : "")}
                |    -- Key - Ваш ключ шифрорвания/дешифрования для доступа к конфигурации, БД и токенов {(startup.AppSetting.Key != "" ? "✓" : "")}
                |    -- Source - Наименование конфигурации {(startup.AppSetting.Source != "" ? "✓" : "")}
                |
                |    -- Сохранить - Сохранить конфигуратор
                |    -- Выход - Выход из создания конфигуратора
                """);
                Console.WriteLine();
                Console.Write("Введите команду: ");
                Keyword = Console.ReadLine();

                switch (Keyword)
                {
                    case "StartupURL":
                        if (startup.AppSetting.StartupURL == null || startup.AppSetting.StartupURL == "" || startup.AppSetting.StartupURL == "Test" || startup.AppSetting.StartupURL == "Base")
                        {
                            Console.Write("Применить данные по умолчанию? (Y/N): ");
                            string defaultString = Console.ReadLine();
                            if (defaultString.ToUpper() == "Y")
                            {
                                bool IsBase = false;
                                Console.Write("Укажите данные по умолчанию Test или Base (0/1): ");
                                if (Console.ReadLine() == "1") startup.AppSetting.StartupURL = "Base";
                                else startup.AppSetting.StartupURL = "Test";
                                continue;
                            }
                            else
                            {
                                Console.Write("Укажите данные для ключа StartupURL: ");
                                startup.AppSetting.StartupURL = Console.ReadLine();
                                continue;
                            }
                        }
                        else
                        {
                            Console.Write($"Укажите данные для ключа StartupURL {(startup.AppSetting.StartupURL != "" ? "(Имеются данные: " + startup.AppSetting.StartupURL + ", если не хотите изменять, скопируйте-вставьте данные и нажмите на Enter)" : "")}: ");
                            startup.AppSetting.StartupURL = Console.ReadLine();
                            continue;
                        }

                    case "StartupSQLForAPI":
                        Console.Write($"Укажите данные для ключа StartupSQLForAPI {(startup.AppSetting.StartupSQLForAPI != "" ? "(Имеются данные: " + startup.AppSetting.StartupSQLForAPI + ", если не хотите изменять, скопируйте-вставьте данные и нажмите на Enter)" : "")}: ");
                        startup.AppSetting.StartupSQLForAPI = Console.ReadLine();
                        continue;
                    case "StartupSQLForClient":
                        Console.Write($"Укажите данные для ключа StartupSQLForClient {(startup.AppSetting.StartupSQLForClient != "" ? "(Имеются данные: " + startup.AppSetting.StartupSQLForClient + ", если не хотите изменять, скопируйте-вставьте данные и нажмите на Enter)" : "")}: ");
                        startup.AppSetting.StartupSQLForClient = Console.ReadLine();
                        continue;
                    case "Ogrn":
                        Console.Write($"Укажите данные для ключа Ogrn {(startup.AppSetting.Ogrn != "" ? "(Имеются данные: " + startup.AppSetting.Ogrn + ", если не хотите изменять, скопируйте-вставьте данные и нажмите на Enter)" : "")}: ");
                        startup.AppSetting.Ogrn = Console.ReadLine();
                        continue;
                    case "CerificateName":
                        Console.Write($"Укажите данные для ключа CerificateName {(startup.AppSetting.CerificateName != "" ? "(Имеются данные: " + startup.AppSetting.CerificateName + ", если не хотите изменять, скопируйте-вставьте данные и нажмите на Enter)" : "")}: ");
                        startup.AppSetting.CerificateName = Console.ReadLine();
                        continue;
                    case "Key":
                        Console.Write($"Укажите данные для ключа Key {(startup.AppSetting.Key != "" ? "(Имеются данные: " + startup.AppSetting.Key + ", если не хотите изменять, скопируйте-вставьте данные и нажмите на Enter)" : "")}: ");
                        startup.AppSetting.Key = Console.ReadLine();
                        continue;
                    case "Source":
                        Console.Write($"Укажите данные для ключа Source {(startup.AppSetting.Source != "" ? "(Имеются данные: " + startup.AppSetting.Source + ", если не хотите изменять, скопируйте-вставьте данные и нажмите на Enter)" : "")}: ");
                        startup.AppSetting.Source = Console.ReadLine();
                        continue;
                    case "StartupDelay":
                        Console.Write($"Укажите данные для ключа StartupDelay {(startup.AppSetting.StartupDelay != -1 ? "(Имеются данные: " + startup.AppSetting.StartupDelay + ", если не хотите изменять, скопируйте-вставьте данные и нажмите на Enter)" : "")}: ");
                        startup.AppSetting.StartupDelay = (Console.ReadLine()).IsValidInt().ResultInt;
                        continue;
                    case "SaveFileDirectory":
                        Console.Write($"Укажите данные для ключа SaveFileDirectory {(startup.AppSetting.SaveFileDirectory != "" ? "(Имеются данные: " + startup.AppSetting.SaveFileDirectory + ", если не хотите изменять, скопируйте-вставьте данные и нажмите на Enter" : "")}: ");
                        startup.AppSetting.Source = Console.ReadLine();
                        continue;

                    case "URL":
                        if (startup.AppSetting.URLs.Count() == 0)
                        {
                            Console.Write("Применить данные по умолчанию? (Y/N): ");
                            string defaultString = Console.ReadLine();
                            if (defaultString.ToUpper() == "Y")
                            {
                                List<URLs> ls = new List<URLs>();
                                ls.Add(new URLs()
                                {
                                    UrlName = "Test",
                                    Url = "http://85.142.162.22:8100"
                                });
                                ls.Add(new URLs()
                                {
                                    UrlName = "Base",
                                    Url = "http://10.3.60.3:8100"
                                });
                                startup.AppSetting.URLs = ls.ToArray();
                            }
                            else
                            {
                                int Count = 0;
                                Console.Write("Укажите количество URL-адресов для ключа URL: ");
                                Count = Console.ReadLine().IsValidInt().ResultInt;
                                List<URLs> ls = new List<URLs>();
                                while (Count != 0)
                                {
                                    URLs strings = new URLs()
                                    {
                                        UrlName = "",
                                        Url = ""
                                    };

                                    Console.WriteLine("Массив " + (ls.Count() + 1));
                                    Console.Write("Укажите данные для ключа UrlName: ");
                                    strings.UrlName = Console.ReadLine();
                                    Console.Write("Укажите данные для ключа Url (пример http(s)://XXX.XXX.XXX.XXX): ");
                                    strings.Url = Console.ReadLine();
                                    Console.WriteLine();

                                    if (ls.Where(a => a.UrlName == strings.UrlName).IsNullOrEmpty())
                                    {
                                        ls.Add(strings);
                                        Count--;
                                    }
                                    else
                                    {
                                        Console.WriteLine("ОШИБКА! Не должно быть дублирующих данных!");
                                        Console.Write("Нажмите на Enter для продолжения создания данных...");
                                        Console.ReadLine();
                                    }
                                }
                                startup.AppSetting.URLs = ls.ToArray();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Имеются следующие данные:");
                            foreach (var t in startup.AppSetting.URLs)
                            {
                                Console.WriteLine("Данные " + t.UrlName + "\n" + "UrlName: " + t.UrlName + "\n" + "Url: " + t.Url);
                                Console.WriteLine();
                            }

                            Console.Write("Выберите команду: [Создать/Обновить/Удалить/Выход]: ");
                            string Action = Console.ReadLine();
                            while (Action == "Создать" || Action == "Обновить" || Action == "Удалить")
                            {
                                if (Action == "Создать")
                                {
                                    bool IsValid = true;
                                    while (IsValid)
                                    {
                                        List<URLs> ls = new List<URLs>();
                                        ls.AddRange(startup.AppSetting.URLs);
                                        URLs strings = new URLs()
                                        {
                                            UrlName = "",
                                            Url = ""
                                        };

                                        Console.Write("Укажите данные для ключа UrlName: ");
                                        strings.UrlName = Console.ReadLine();
                                        Console.Write("Укажите данные для ключа Url (пример http(s)://XXX.XXX.XXX.XXX): ");
                                        strings.Url = Console.ReadLine();

                                        if (ls.Where(a => a.UrlName == strings.UrlName).IsNullOrEmpty())
                                        {
                                            ls.Add(strings);
                                            startup.AppSetting.URLs = ls.ToArray();
                                            IsValid = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ОШИБКА! Не должно быть дублирующих данных!");
                                            Console.Write("Нажмите на Enter для продолжения создания данных...");
                                            Console.ReadLine();
                                        }
                                    }
                                }

                                if (Action == "Обновить" || Action == "Удалить")
                                {
                                    Console.Write("Выберите наименования Url-адреса: ");
                                    string data = Console.ReadLine() ?? "";
                                    URLs? origin = startup.AppSetting.URLs.Where(a => a.UrlName == data).FirstOrDefault();
                                    if (origin == null)
                                    {
                                        Console.WriteLine("Нет данных");
                                    }

                                    if (origin != null)
                                    {
                                        if (Action == "Обновить")
                                        {
                                            URLs strings = new URLs()
                                            {
                                                UrlName = "",
                                                Url = ""
                                            };

                                            Console.Write("Укажите данные для ключа Url (пример http(s)://XXX.XXX.XXX.XXX) (Сохраненные данные: " + origin.Url + "): ");
                                            strings.Url = Console.ReadLine() ?? "";
                                            startup.AppSetting.URLs.Where(a => a.UrlName == origin.UrlName).First().Url = strings.Url;
                                        }

                                        if (Action == "Удалить")
                                        {
                                            List<URLs> ls = new List<URLs>();
                                            ls.AddRange(startup.AppSetting.URLs);
                                            ls.Remove(origin);
                                            startup.AppSetting.URLs = ls.ToArray();
                                        }
                                    }
                                }
                                Console.Write("Выберите команду: [Создать/Обновить/Удалить/Выход]: ");
                                Action = Console.ReadLine();
                            }
                        }
                        continue;

                    case "ConnectionStrings":
                        if (startup.AppSetting.ConnectionStrings.Count() == 0)
                        {
                            int Count = 0;
                            Console.Write("Укажите количество подключения БД для ключа ConnectionStrings: ");
                            Count = Console.ReadLine().IsValidInt().ResultInt;
                            List<ConnectionStrings> ls = new List<ConnectionStrings>();
                            while (Count != 0)
                            {
                                ConnectionStrings strings = new ConnectionStrings()
                                {
                                    Name = "",
                                    SQLName = "",
                                    ProviderName = null,
                                    ConnectionString = ""
                                };

                                Console.Write("Укажите данные для ключа Name: ");
                                strings.Name = Console.ReadLine();
                                Console.Write("Укажите данные для ключа ConnectionString: ");
                                strings.ConnectionString = Console.ReadLine();
                                Console.Write("Укажите, какую базу данных будете подключать [MSSQL/PostgreSQL]: ");
                                strings.SQLName = Console.ReadLine();
                                if (strings.SQLName == "MSSQL")
                                {
                                    strings.ProviderName = "System.Data.SqlClient";
                                }

                                if (ls.Where(a => a.Name == strings.Name).IsNullOrEmpty())
                                {
                                    ls.Add(strings);
                                    Count--;
                                }
                                else
                                {
                                    Console.WriteLine("ОШИБКА! Не должно быть дублирующих данных!");
                                    Console.Write("Нажмите на Enter для продолжения создания данных...");
                                    Console.ReadLine();
                                }
                            }
                            startup.AppSetting.ConnectionStrings = ls.ToArray();
                        }
                        else
                        {
                            Console.WriteLine("Имеются следующие данные:");
                            foreach (var t in startup.AppSetting.ConnectionStrings)
                            {
                                Console.WriteLine("Данные " + t.Name + "\n" + "Name: " + t.Name + "\n" + "Тип подключения БД: " + t.SQLName + "\n" + "ConnectionString: " + t.ConnectionString);
                                Console.WriteLine();
                            }

                            Console.Write("Выберите команду: [Создать/Обновить/Удалить/Выход]: ");
                            string Action = Console.ReadLine();
                            while (Action == "Создать" || Action == "Обновить" || Action == "Удалить")
                            {
                                if (Action == "Создать")
                                {
                                    bool IsValid = true;
                                    while (IsValid)
                                    {
                                        List<ConnectionStrings> ls = new List<ConnectionStrings>();
                                        ls.AddRange(startup.AppSetting.ConnectionStrings);
                                        ConnectionStrings strings = new ConnectionStrings()
                                        {
                                            Name = "",
                                            SQLName = "",
                                            ProviderName = null,
                                            ConnectionString = ""
                                        };

                                        Console.Write("Укажите данные для ключа Name: ");
                                        strings.Name = Console.ReadLine();
                                        Console.Write("Укажите данные для ключа ConnectionString: ");
                                        strings.ConnectionString = Console.ReadLine();
                                        Console.Write("Укажите, какую базу данных будете подключать [MSSQL/PostgreSQL]: ");
                                        strings.SQLName = Console.ReadLine();
                                        if (strings.SQLName == "MSSQL")
                                        {
                                            strings.ProviderName = "System.Data.SqlClient";
                                        }

                                        if (ls.Where(a => a.Name == strings.Name).IsNullOrEmpty())
                                        {
                                            ls.Add(strings);
                                            startup.AppSetting.ConnectionStrings = ls.ToArray();
                                            IsValid = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ОШИБКА! Не должно быть дублирующих данных!");
                                            Console.Write("Нажмите на Enter для продолжения создания данных...");
                                            Console.ReadLine();
                                        }
                                    }
                                }

                                if (Action == "Обновить" || Action == "Удалить")
                                {
                                    Console.Write("Выберите наименования базы данных: ");
                                    string data = Console.ReadLine();
                                    ConnectionStrings? origin = startup.AppSetting.ConnectionStrings.Where(a => a.Name == data).FirstOrDefault();
                                    if (origin == null)
                                    {
                                        Console.WriteLine("Нет данных");
                                    }

                                    if (origin != null)
                                    {
                                        if (Action == "Обновить")
                                        {
                                            ConnectionStrings strings = new ConnectionStrings()
                                            {
                                                Name = "",
                                                SQLName = "",
                                                ProviderName = null,
                                                ConnectionString = ""
                                            };

                                            Console.Write("Укажите данные для ключа ConnectionString (Сохраненные данные: " + origin.ConnectionString + "): ");
                                            strings.ConnectionString = Console.ReadLine();
                                            Console.Write("Укажите, какую базу данных будете подключать [MSSQL/PostgreSQL] (Сохраненные данные: " + origin.SQLName + "): ");
                                            strings.SQLName = Console.ReadLine();
                                            if (strings.SQLName == "MSSQL")
                                            {
                                                strings.ProviderName = "System.Data.SqlClient";
                                            }

                                            startup.AppSetting.ConnectionStrings.Where(a => a.Name == origin.Name).First().SQLName = strings.SQLName;
                                            startup.AppSetting.ConnectionStrings.Where(a => a.Name == origin.Name).First().ProviderName = strings.ProviderName;
                                            startup.AppSetting.ConnectionStrings.Where(a => a.Name == origin.Name).First().ConnectionString = strings.ConnectionString;
                                        }

                                        if (Action == "Удалить")
                                        {
                                            List<ConnectionStrings> ls = new List<ConnectionStrings>();
                                            ls.AddRange(startup.AppSetting.ConnectionStrings);
                                            ls.Remove(origin);
                                            startup.AppSetting.ConnectionStrings = ls.ToArray();
                                        }
                                    }
                                }
                                Console.Write("Выберите команду: [Создать/Обновить/Удалить/Выход]: ");
                                Action = Console.ReadLine();
                            }
                        }
                        continue;

                    case "Kpp":
                        if (startup.AppSetting.Kpp.Count() == 0)
                        {
                            int Count = 0;
                            Console.Write("Укажите количество КПП организации для ключа Kpp: ");
                            Count = Console.ReadLine().IsValidInt().ResultInt;
                            List<Kpp> ls = new List<Kpp>();
                            while (Count != 0)
                            {
                                Kpp strings = new Kpp()
                                {
                                    NameKpp = "",
                                    KppOrganization = ""
                                };

                                Console.Write("Укажите данные для ключа NameKpp: ");
                                strings.NameKpp = Console.ReadLine();
                                Console.Write("Укажите данные для ключа KppOrganization: ");
                                strings.KppOrganization = Console.ReadLine();
                                if (ls.Where(a => a.NameKpp == strings.NameKpp).IsNullOrEmpty())
                                {
                                    ls.Add(strings);
                                    Count--;
                                }
                                else
                                {
                                    Console.WriteLine("ОШИБКА! Не должно быть дублирующих данных!");
                                    Console.Write("Нажмите на Enter для продолжения создания данных...");
                                    Console.ReadLine();
                                }
                            }
                            startup.AppSetting.Kpp = ls.ToArray();
                        }
                        else
                        {
                            Console.WriteLine("Имеются следующие данные:");
                            foreach (var t in startup.AppSetting.Kpp)
                            {
                                Console.WriteLine("Данные " + t.NameKpp + "\n" + "NameKpp: " + t.NameKpp + "\n" + "KppOrganization: " + t.KppOrganization);
                                Console.WriteLine();
                            }

                            Console.Write("Выберите команду: [Создать/Обновить/Удалить/Выход]: ");
                            string Action = Console.ReadLine();
                            while (Action == "Создать" || Action == "Обновить" || Action == "Удалить")
                            {
                                if (Action == "Создать")
                                {
                                    bool IsValid = true;
                                    while (IsValid)
                                    {
                                        List<Kpp> ls = new List<Kpp>();
                                        ls.AddRange(startup.AppSetting.Kpp);
                                        Kpp strings = new Kpp()
                                        {
                                            NameKpp = "",
                                            KppOrganization = ""
                                        };

                                        Console.Write("Укажите данные для ключа NameKpp: ");
                                        strings.NameKpp = Console.ReadLine();
                                        Console.Write("Укажите данные для ключа KppOrganization: ");
                                        strings.KppOrganization = Console.ReadLine();

                                        if (ls.Where(a => a.NameKpp == strings.NameKpp).IsNullOrEmpty())
                                        {
                                            ls.Add(strings);
                                            startup.AppSetting.Kpp = ls.ToArray();
                                            IsValid = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ОШИБКА! Не должно быть дублирующих данных!");
                                            Console.Write("Нажмите на Enter для продолжения создания данных...");
                                            Console.ReadLine();
                                        }
                                    }
                                }

                                if (Action == "Обновить" || Action == "Удалить")
                                {
                                    Console.Write("Выберите наименования КПП: ");
                                    string data = Console.ReadLine();
                                    Kpp? origin = startup.AppSetting.Kpp.Where(a => a.NameKpp == data).FirstOrDefault();
                                    if (origin == null)
                                    {
                                        Console.WriteLine("Нет данных");
                                    }

                                    if (origin != null)
                                    {
                                        if (Action == "Обновить")
                                        {
                                            Kpp strings = new Kpp()
                                            {
                                                NameKpp = origin.NameKpp,
                                                KppOrganization = ""
                                            };

                                            Console.Write("Укажите данные для ключа KppOrganization (Сохраненные данные: " + origin.KppOrganization + "): ");
                                            strings.KppOrganization = Console.ReadLine();

                                            startup.AppSetting.Kpp.Where(a => a.NameKpp == origin.NameKpp).First().KppOrganization = strings.KppOrganization;
                                        }

                                        if (Action == "Удалить")
                                        {
                                            List<Kpp> ls = new List<Kpp>();
                                            ls.AddRange(startup.AppSetting.Kpp);
                                            ls.Remove(origin);
                                            startup.AppSetting.Kpp = ls.ToArray();
                                        }
                                    }
                                }
                                Console.Write("Выберите команду: [Создать/Обновить/Удалить/Выход]: ");
                                Action = Console.ReadLine();
                            }
                        }
                        continue;

                    case "Сохранить": 
                        Console.WriteLine("Проверьте вашу конфигурацию:");
                        Console.WriteLine("|    -- URL:");
                        int count = 1;
                        foreach(var url in startup.AppSetting.URLs)
                        {
                            Console.WriteLine("|    | -- Массив " + count + ":");
                            Console.WriteLine("|    |    -- UrlName: " + url.UrlName);
                            Console.WriteLine("|    |    -- Url: " + url.Url);
                            count++;
                        }
                        Console.WriteLine("|    -- StartupURL: " + startup.AppSetting.StartupURL);
                        Console.WriteLine("|    -- ConnectionStrings:");
                        count = 1;
                        foreach(var cs in startup.AppSetting.ConnectionStrings)
                        {
                            Console.WriteLine("|    | -- Массив " + count + ":");
                            Console.WriteLine("|    |    -- Name: " + cs.Name);
                            Console.WriteLine("|    |    -- SQLName: " + cs.SQLName);
                            Console.WriteLine("|    |    -- ConnectionString: " + cs.ConnectionString);
                            count++;
                        }
                        Console.WriteLine("|    -- StartupSQLForAPI: " + startup.AppSetting.StartupSQLForAPI);
                        Console.WriteLine("|    -- StartupSQLForClient: " + startup.AppSetting.StartupSQLForClient);
                        Console.WriteLine("|    -- Ogrn: " + startup.AppSetting.Ogrn);
                        Console.WriteLine("|    -- Kpp:");
                        count = 1;
                        foreach(var kpp in startup.AppSetting.Kpp)
                        {
                            Console.WriteLine("|    | -- Массив " + count + ":");
                            Console.WriteLine("|    |    -- NameKpp: " + kpp.NameKpp);
                            Console.WriteLine("|    |    -- KppOrganization: " + kpp.KppOrganization);
                            count++;
                        }
                        Console.WriteLine("|    -- SaveFileDirectory: " + startup.AppSetting.SaveFileDirectory);
                        Console.WriteLine("|    -- CerificateName: " + startup.AppSetting.CerificateName);
                        Console.WriteLine("|    -- StartupDelay: " + startup.AppSetting.StartupDelay);
                        Console.WriteLine("|    -- Key: " + startup.AppSetting.Key);
                        Console.WriteLine("|    -- Source: " + startup.AppSetting.Source);

                        Console.WriteLine();
                        Console.Write("Вы хотите сохранить конфигурацию? (Y/N)");
                        if (Console.ReadLine() == "Y")
                        {
                            if (IsValid(startup))
                            {
                                CryptographyExtension crypro = new CryptographyExtension();
                                var file = DirectoryFiles();
                                try
                                {
                                    if (!file.FileTempAppData.Exists) file.FileTempAppData.Create();
                                    using (StreamWriter writer = new StreamWriter(file.FileAppData.ToString(), false))
                                    {
                                        writer.WriteLine(crypro.EncodeToBase64(JsonConvert.SerializeObject(startup)));
                                        writer.Close();
                                    }
                                    IsExit = true;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Произошла ошибка при записи файла, " + ex.Message + " Исправьте необходимые данные из ошибки сообщении!");
                                    Console.WriteLine("Нажмите на Enter для возвращения назад...");
                                    Console.ReadLine();
                                } 
                            }
                            else IsValidComment(startup);
                        }
                        continue;

                    case "Выход":
                        Console.Write("ВНИМАНИЕ! Если вы выйдете из создания UserSettings, данные не сохранятся! Продолжить? (Y/N) ");
                        if (Console.ReadLine() == "Y") IsExit = true;
                        Console.WriteLine();
                        continue;
                }
            }
        }

        private bool IsValid(StartupModel? startup)
        {
            if (startup == null) return false;
            if (startup.AppSetting == null) return false;
            bool isValid = true;
            if (startup.AppSetting.URLs.IsNullOrEmpty()) isValid = false;
            foreach(var t in startup.AppSetting.URLs)
            {
                if (t.UrlName == null || t.UrlName == "") isValid = false;
                if (t.Url == null || t.Url == "") isValid = false;
                else if (t.Url != "" && !t.Url.IsValidURI()) isValid = false;
            }
            if (startup.AppSetting.StartupURL == null || startup.AppSetting.StartupURL == "") isValid = false;
            if (startup.AppSetting.ConnectionStrings.IsNullOrEmpty()) isValid = false;
            if (startup.AppSetting.SaveFileDirectory == null || startup.AppSetting.SaveFileDirectory == "") isValid = false;
            else if (startup.AppSetting.SaveFileDirectory != "" && !startup.AppSetting.SaveFileDirectory.IsValidFile()) isValid = false;
            foreach(var t in startup.AppSetting.ConnectionStrings)
            {
                if (t.Name == null || t.Name == "") isValid = false;
                if (t.SQLName == null || t.SQLName == "") isValid = false;
                else if (t.SQLName == "MSSQL" && (t.ProviderName == null || t.ProviderName == "")) isValid = false;
                if (t.ConnectionString == null || t.ConnectionString == "") isValid = false;
            }
            if (startup.AppSetting.StartupSQLForAPI == null || startup.AppSetting.StartupSQLForAPI == "") isValid = false;
            if (startup.AppSetting.StartupSQLForClient == null || startup.AppSetting.StartupSQLForClient == "") isValid = false;
            if (startup.AppSetting.Ogrn == null || startup.AppSetting.Ogrn == "") isValid = false;
            if (startup.AppSetting.Kpp.IsNullOrEmpty()) isValid = false;
            foreach(var t in startup.AppSetting.Kpp)
            {
                if (t.NameKpp == null || t.NameKpp == "") isValid = false;
                if (t.KppOrganization == null || t.KppOrganization == "") isValid = false;
            }
            if (startup.AppSetting.CerificateName == null || startup.AppSetting.CerificateName == "") isValid = false;
            if (startup.AppSetting.StartupDelay == null || startup.AppSetting.StartupDelay == -1) isValid = false;
            else if (startup.AppSetting.StartupDelay < 2) isValid = false;
            if (startup.AppSetting.Key == null || startup.AppSetting.Key == "") isValid = false;
            if (startup.AppSetting.Source == null || startup.AppSetting.Source == "") isValid = false;
            return isValid;
        }

        private void IsValidComment(StartupModel? startup)
        {
            Console.WriteLine("При проверке конфигурации произошла ошибка!\nПроверьте данные указанные внизу:");
            if (startup == null) Console.WriteLine("Отсутствует полноценного конфигуратора, добавьте конфигурацию приложения!");
            if (startup != null)
            {
                if (startup.AppSetting == null) Console.WriteLine("Отсутствует ключевого конфигуратора, добавьте объект \"AppSetting\"!");
                if (startup.AppSetting != null)
                {
                    if (startup.AppSetting.URLs.IsNullOrEmpty()) Console.WriteLine("-- Отсутствуют URL-адреса (URLs), внесите необходимые данные!");
                    foreach(var t in startup.AppSetting.URLs)
                    {
                        if (t.UrlName == null || t.UrlName == "") Console.WriteLine("-- Отсутствует наименования URL-адреса (UrlName) из массива URL-адреса (URLs), внесите необходимые данные!");
                        if (t.Url == null || t.Url == "") Console.WriteLine("-- Отсутствует URL-адрес (Url) из массива URL-адреса (URLs), внесите необходимые данные!");
                        else if (t.Url != "" && !t.Url.IsValidURI()) Console.WriteLine("-- Неправильно составлена схема URL-адреса (Url) из массива URL-адреса (URLs), внесите по соответсвующим требованиям (например, http(s)://XXX.XXX.XXX.XXX:XXXX)!");
                    }
                    if (startup.AppSetting.SaveFileDirectory == null || startup.AppSetting.SaveFileDirectory == "") Console.WriteLine("-- Отсутствует папка для сохранения файлов (SaveFileDirectory), внесите необходимые данные!");
                    else if (startup.AppSetting.SaveFileDirectory != "" && !startup.AppSetting.SaveFileDirectory.IsValidFile()) Console.WriteLine("-- Неправильно составлена папка для сохранения файлов (SaveFileDirectory), убедитесь, что вы внесли првильный путь на сохранения фйлов (например: для Windows: С:\\Users\\Пользователь\\Desktop\\Файл, для Linux: /home/Пользователь/Рабочий стол/Файл)!");
                    if (startup.AppSetting.StartupURL == null || startup.AppSetting.StartupURL == "") Console.WriteLine("-- Отсутствует первоначальный запуск URL-адреса (StartupURL), внесите необходимые данные!");
                    if (startup.AppSetting.ConnectionStrings.IsNullOrEmpty()) Console.WriteLine("-- Отсутствуют строки подключения БД (ConnectionStrings), внесите необходимые данные!");
                    foreach(var t in startup.AppSetting.ConnectionStrings)
                    {
                        if (t.Name == null || t.Name == "") Console.WriteLine("-- Отсутствует наименования строки подключения БД (Name) из массива строк подключения БД (ConnectionStrings), внесите необходимые данные!");
                        if (t.SQLName == null || t.SQLName == "") Console.WriteLine("-- Отсутствует тип подключения БД (SQLName) из массива строк подключения БД (ConnectionStrings), внесите необходимые данные!");
                        else if (t.SQLName == "MSSQL" && (t.ProviderName == null || t.ProviderName == "")) Console.WriteLine("-- Вы пытаетесь добавить тип подключения \"MSSQL\" из массива строк подключения БД (ConnectionStrings), но отсутствует его провайдер, добавьте в поле ProviderName значение \"System.Data.SqlClient\"!");
                        if (t.ConnectionString == null || t.ConnectionString == "") Console.WriteLine("-- Отсутствует строка для подключения БД (ConnectionString) из массива строк подключения БД (ConnectionStrings), внесите необходимые данные!");
                    }
                    if (startup.AppSetting.StartupSQLForAPI == null || startup.AppSetting.StartupSQLForAPI == "") Console.WriteLine("-- Отсутствует первоначальный запуск подключения БД для работы API (StartupSQLForAPI), внесите необходимые данные!");
                    if (startup.AppSetting.StartupSQLForClient == null || startup.AppSetting.StartupSQLForClient == "") Console.WriteLine("-- Отсутствует первоначальный запуск подключения БД для работы клиентской части (StartupSQLForClient), внесите необходимые данные!");
                    if (startup.AppSetting.Ogrn == null || startup.AppSetting.Ogrn == "")  Console.WriteLine("-- Отсутствует ОГРН организации (Ogrn), внесите необходимые данные!");
                    if (startup.AppSetting.Kpp.IsNullOrEmpty()) Console.WriteLine("-- Отсутствуют КПП организации (Kpp), внесите необходимые данные!");
                    foreach(var t in startup.AppSetting.Kpp)
                    {
                        if (t.NameKpp == null || t.NameKpp == "") Console.WriteLine("-- Отсутствует наименования КПП (NameKpp) из массива КПП организации (Kpp), внесите необходимые данные!");
                        if (t.KppOrganization == null || t.KppOrganization == "") Console.WriteLine("-- Отсутствует КПП (KppOrganization) из массива КПП организации (Kpp), внесите необходимые данные!");
                    }
                    if (startup.AppSetting.CerificateName == null || startup.AppSetting.CerificateName == "") Console.WriteLine("-- Отсутствует наименования сертификата для работы КриптоПро (CerificateName), внесите необходимые данные!");
                    if (startup.AppSetting.StartupDelay == null || startup.AppSetting.StartupDelay == -1) Console.WriteLine("-- Отсутствует задержки времени (в сек.) работоспособности программы (StartupDelay), внесите необходимые данные!");
                    else if (startup.AppSetting.StartupDelay < 2) Console.WriteLine("-- Вы пытаетесь добавить задержку времени для работоспособности приложения со значением меншьше 2-х секунд, измените необходимые данные!");
                    if (startup.AppSetting.Key == null || startup.AppSetting.Key == "") Console.WriteLine("-- Отсутствует ключ для шифрования/дешифрования данных (Key), внесите необходимые данные!");
                    if (startup.AppSetting.Source == null || startup.AppSetting.Source == "") Console.WriteLine("-- Отсутствует наименования приложения (Source), внесите необходимые данные!");
                }
            }
            DirectoryFiles().FileAppData.Delete();
            Console.WriteLine();
            Console.Write("Нажмите на Enter для возвращения назад...");
            Console.ReadLine();
            Console.WriteLine();
        }

        private (FileInfo FileSetup, FileInfo FileAppData, DirectoryInfo FileTempAppData) DirectoryFiles()
        {
            var os = Environment.OSVersion;
            var a = Enum.GetValues(typeof(Environment.SpecialFolder))
                .Cast<Environment.SpecialFolder>()
                .Select(specialFolder => new
                {
                    Name = specialFolder.ToString(),
                    Path = Environment.GetFolderPath(specialFolder)
                })
                .OrderBy(item => item.Path.ToLower());
            FileInfo FileSetup = new FileInfo(a.First(a => a.Name == "Desktop").Path + (os.Platform == PlatformID.Win32NT ? "\\UserSettings.setting" : "/UserSettings.setting"));
            FileInfo FileAppData = new FileInfo(a.First(a => a.Name == "LocalApplicationData").Path + (os.Platform == PlatformID.Win32NT ? "\\SSCoreApp\\UserSettings.setting" : "/SSCoreApp/UserSettings.setting"));
            DirectoryInfo FileTempAppData = new DirectoryInfo(a.First(a => a.Name == "LocalApplicationData").Path + (os.Platform == PlatformID.Win32NT ? "\\SSCoreApp" : "/SSCoreApp"));
            return (FileSetup, FileAppData, FileTempAppData);
        }
    }

    public class AppSetting
    {
        public required URLs[] URLs { get; set; }
        public required string StartupURL { get; set; }
        public required ConnectionStrings[] ConnectionStrings { get; set; }
        public required string StartupSQLForAPI { get; set; }
        public required string StartupSQLForClient { get; set; }
        public required string Ogrn { get; set; }
        public required Kpp[] Kpp { get; set; }
        public required string CerificateName { get; set; }
        public required string SaveFileDirectory { get; set; } // TODO: Добавить в инструкцию
        public required int? StartupDelay { get; set; }
        public required string Key { get; set; }
        public required string Source { get; set; }
    }

    public class URLs
    {
        public required string UrlName { get; set; }
        public required string Url { get; set; }
    }

    public class ConnectionStrings
    {
        public required string Name { get; set; }
        public required string SQLName { get; set; }
        public string? ProviderName { get; set; }
        public required string ConnectionString { get; set; }
    }

    public class Kpp
    {
        public required string NameKpp { get; set; }
        public required string KppOrganization { get; set; }
    }
}