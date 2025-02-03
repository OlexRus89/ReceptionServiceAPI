using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Отзыв заявления на ЕПГУ (при этом все КГ будут в конечных статусах)
    /// </summary>
    public class EpguApplicationCancel
    {
        /// <summary>
        /// Уникальный идентификатор заявления (ApplicationList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidApplication { get; set; }
    }
}