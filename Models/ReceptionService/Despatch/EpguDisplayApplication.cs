using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Заявление стало отображаться на ЕПГУ
    /// </summary>
    public class EpguDisplayApplication
    {
        /// <summary>
        /// Уникальный идентификатор заявления (ApplicationList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidApplication { get; set; }
    }
}