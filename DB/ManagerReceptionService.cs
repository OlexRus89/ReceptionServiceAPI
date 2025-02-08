using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using CryptoCore.Models.JsonData;
using CryptoCore.Extensions;
using CryptoCore.Models;

namespace CryptoCore.DB
{
    public class ManagerReceptionService
    {
        protected Concrete Concrete { get; private set; }
        protected StartupModel Startup { get; private set; }
        public ManagerReceptionService(StartupModel startup, string start)
        {
            Startup = startup;
            Concrete = new Concrete(Startup.AppSetting.ConnectionStrings.Where(a => a.Name == start).First().Name, Startup);
        }

        #region Errors
        /// <summary>
        /// Сохранение результатов ошибок
        /// </summary>
        /// <param name="Message">Сообщение</param>
        /// <param name="StackTrace">Трасировка</param>
        /// <param name="MessageResult">Результат ошибки</param>
        /// <param name="Sender">Входные данные</param>
        /// <returns></returns>
        internal async Task SaveErrorRequest(string Message, string StackTrace, string? MessageResult, string Sender)
        {
            await Concrete.Exec("[dbo].[RS_SaveLogRequest]", new { Message, StackTrace, MessageResult, Sender });
        }
        #endregion
    }
}