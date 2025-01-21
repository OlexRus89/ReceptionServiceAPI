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
        public async Task<int> CreateIdObject()
        {
            return await Concrete.ExecFirstOfDefault<int>("[dbo].[GetIdObject]");
        }

        /// <summary>
        /// Добавления токена в очередь
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
        /// <returns>Числовое значение объекта</returns>
        public async Task CreateToken(int Status, int IdObject, string? Action = null, string? Entity = null, string? Ogrn = null, string? Kpp = null, string? Payload = null, string? Result = null)
        {
            await Concrete.Exec("[dbo].[InsertToken]", new { IdObject, Status, Action, Entity, Ogrn, Kpp, Payload, Result });
        }

        #region Tokens

        internal async Task<IEnumerable<GetTokenModel?>> GetTokens(bool IsGetToken = false)
        {
            return await Concrete.ExecQuery<GetTokenModel>("[dbo].[GetToken]", new { IsGetToken });
        }

        internal async Task UpdateToken(int IdObject, int IdJWT, int DelaySecond)
        {
            await Concrete.Exec("[dbo].[InsertJWT]", new { IdObject, IdJWT, DelaySecond });
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