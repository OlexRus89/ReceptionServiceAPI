using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Претензия от поступающего по проекту платного договора
    /// </summary>
    public class EpguPaidContractClaim
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления, сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        /// <summary>
        /// Текст претензии
        /// </summary>
        public required string ClaimOffer { get; set; }
    }
}