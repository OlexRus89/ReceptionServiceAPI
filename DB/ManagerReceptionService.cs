using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using ReceptionServiceCore.Extensions;
using ReceptionServiceCore.Models;

namespace ReceptionServiceCore.DB
{
    public class ManagerReceptionService
    {
        protected Concrete Concrete { get; private set; }
        protected StartupModel Startup { get; private set; }
        public ManagerReceptionService(StartupModel startup)
        {
            Startup = startup;
            Concrete = new Concrete(Startup.AppSetting.ConnectionStrings.Where(a => a.Name == startup.AppSetting.StartupSQLForAPI).First().Name, Startup);
        }

        #region Errors
        internal async Task SaveErrorRequest(string Message, string StackTrace, string? MessageResult, string Sender)
        {
            await Concrete.Exec("[dbo].[SaveLogRequest]", new { Message, StackTrace, MessageResult, Sender });
        }
        #endregion

        #region Cls

        /// <summary>
        /// Добавление справочников
        /// Пояснение: Внесите все справочники со значением Cls, как указано в Xml документе.
        /// </summary>
        /// <param name="ClsName">Название справочника</param>
        /// <param name="data">Данные справочника</param>
        internal void InsertCls(string ClsName, dynamic[] data)
        {
            Debug.Write("Выполняется добавление справочника: \"" + ClsName + "\"...  ");
            ExceptionsCls ECls = ExceptionsCls.Null;
            bool isAllCls = true;
            switch (ClsName)
            {
                case "DirectionCls": ECls = ExceptionsCls.DirectionCls; isAllCls = false; break;
                case "DocumentCategoryCls": ECls = ExceptionsCls.DocumentCategoryCls; isAllCls = false; break;
                case "DocumentTypeCls": ECls = ExceptionsCls.DocumentTypeCls; isAllCls = false; break;
                case "NoticesTypeCls": ECls = ExceptionsCls.NoticesTypeCls; isAllCls = false; break;
                case "OlympicCls": ECls = ExceptionsCls.OlympicCls; isAllCls = false; break;
                case "OlympicProfileSubjectCls": ECls = ExceptionsCls.OlympicProfileSubjectCls; isAllCls = false; break;
                case "OlympicRelationProfileCls": ECls = ExceptionsCls.OlympicRelationProfileCls; isAllCls = false; break;
                case "SubjectCls": ECls = ExceptionsCls.SubjectCls; isAllCls = false; break;
            }
            if (data.Count() > 0) Concrete.Exec(!isAllCls ? ("[dbo].[InsertFor" + ClsName + "]") : "[dbo].[InsertAllCls]", new { Table = TableTmp(data, ECls), Name = ClsName });
            else Debug.Write("Ошибка записан в логе");
            Debug.Write("  ...Сеанс окончен\n");
            Task.Delay(1000);
        }
        /// <summary>
        /// Вспомогательная функция, который формирует временные таблицы для отправки в БД.
        /// Есть исключающие справочные материалы, которые имеют свои отклонения (различные переменные).
        /// </summary>
        /// <param name="data">Данные справочника</param>
        /// <param name="ECls">Исключающие справочники</param>
        /// <seealso cref="ClsExtension">Более подробные исключения справочников</seealso>
        /// <returns>Возвращает временную таблицу</returns>
        private DataTable TableTmp(dynamic[] data, ExceptionsCls ECls)
        {
            switch (ECls)
            {
                case ExceptionsCls.DirectionCls: return new ClsExtension().DirectionCls(data);
                case ExceptionsCls.DocumentCategoryCls: return new ClsExtension().DocumentCategoryCls(data);
                case ExceptionsCls.DocumentTypeCls: return new ClsExtension().DocumentTypeCls(data);
                case ExceptionsCls.NoticesTypeCls: return new ClsExtension().NoticesTypeCls(data);
                case ExceptionsCls.OlympicCls: return new ClsExtension().OlympicCls(data);
                case ExceptionsCls.OlympicProfileSubjectCls: return new ClsExtension().OlympicProfileSubjectCls(data);
                case ExceptionsCls.OlympicRelationProfileCls: return new ClsExtension().OlympicRelationProfileCls(data);
                case ExceptionsCls.SubjectCls: return new ClsExtension().SubjectCls(data);
                default: return new ClsExtension().AllCls(data);
            }
        }
        #endregion

        /// <summary>
        /// Создание IdObject
        /// </summary>
        /// <returns>Числовое значение объекта</returns>
        internal async Task<int> CreateIdObject()
        {
            return await Concrete.ExecFirstOfDefault<int>("[dbo].[GetIdObject]");
        }

        /// <summary>
        /// Добавления токена в очередь (Own)
        /// 
        /// Логика: Если вы хотите отправить данные - указываете все, кроме Результата
        /// Логика: Если вы хотите отправить результат, указываете Result и Status
        /// </summary>
        /// <param name="Status">Статус обработки токена</param>
        /// <param name="Action">Вид действия</param>
        /// <param name="Entity">Тип сущности</param>
        /// <param name="Ogrn">ОГРН</param>
        /// <param name="Kpp">КПП</param>
        /// <param name="Payload">Данные для отправки в СП</param>
        /// <param name="Result">Результат из СП</param>
        /// <returns></returns>
        internal async Task CreateToken(int Status, int IdObject, string? Action = null, string? Entity = null, string? Ogrn = null, string? Kpp = null, string? Payload = null, string? Result = null)
        {
            await Concrete.Exec("[dbo].[InsertToken]", new { IdObject, Status, Action, Entity, Ogrn, Kpp, Payload, Result });
        }

        /// <summary>
        /// Добавления токена в очередь (Despatch)
        /// 
        /// Логика: Сначала вытаскиваем все Id JWT (Статус пакета всегда будет: В обработке: получен токен), потом получаем все токены (Статус меняется на "Новое")
        /// Продолжение логики: в реестре заявок (песочнице) их просто начинает обрабатывать и распределять их по БД (Меняется статус на "Выгружена")
        /// </summary>
        /// <param name="IdJwt">Уникальный идентификатор токена</param>
        /// <param name="Payload">Данные для отправки в СП</param>
        /// <param name="Entity">Тип сущности</param>
        /// <param name="CreatedAt">Дата создания токена от ССПВО</param>
        /// <returns></returns>
        internal async Task CreateToken(int IdJwt, string? Payload = null, string? Entity = null, string? CreatedAt = null)
        {
            await Concrete.Exec("[dbo].[InsertTokenDespatch]", new { IdJwt, Entity, CreatedAt, Payload });
        }

        #region Tokens

        /// <summary>
        /// Получения токенов по соответсвующим статусам
        /// Если хотим получить все токены для отправки, указываем значение IsGetToken = false
        /// Если хотим обработать все отправленные токены,указываем значение IsGetToken = true
        /// </summary>
        /// <param name="IsGetToken">Получение токенов по соответствующим статусам</param>
        /// <returns></returns>
        internal async Task<IEnumerable<GetTokenModel?>> GetTokensOwn(bool IsGetToken = false)
        {
            return await Concrete.ExecQuery<GetTokenModel>("[dbo].[GetToken]", new { IsDespatch = false, IsGetToken });
        }

        /// <summary>
        /// Получения токенов по соответсвующим статусам
        /// Если хотим получить все данные токенов от IdJWT, указываем значение IsGetToken = true
        /// Если хотим обработать все токены и распределить все данные по БД, указываем значение IsGetToken = false
        /// </summary>
        /// <param name="IsGetToken">Получение токенов по соответствующим статусам</param>
        /// <returns></returns>
        internal async Task<IEnumerable<GetTokenDespatchModel?>> GetTokensDespatch(bool IsGetToken = true)
        {
            return await Concrete.ExecQuery<GetTokenDespatchModel>("[dbo].[GetToken]", new { IsDespatch = true, IsGetToken });
        }

        /// <summary>
        /// Для внутренних данных (Own)
        /// </summary>
        /// <param name="IdObject"></param>
        /// <param name="IdJWT"></param>
        /// <param name="DelaySecond"></param>
        /// <returns></returns>
        internal async Task UpdateToken(int IdObject, int IdJWT, int DelaySecond)
        {
            await Concrete.Exec("[dbo].[InsertJWT]", new { IsDespatch = false, IdObject, DelaySecond, IdJWT });
        }

        /// <summary>
        /// Для внешних данных (Despatch)
        /// </summary>
        /// <param name="IdJWT"></param>
        /// <returns></returns>
        internal async Task UpdateToken(int IdJWT)
        {
            await Concrete.Exec("[dbo].[InsertJWT]", new { IsDespatch = true, IdJWT });
        }

        internal async Task<int> Test()
        {
            return await Concrete.ExecFirstOfDefault<int>("select 100", type: CommandType.Text);
        }

        internal async Task InsertSQLText(string SQL)
        {
            await Concrete.Exec(SQL, type: CommandType.Text);
        }

        #endregion
    }
}