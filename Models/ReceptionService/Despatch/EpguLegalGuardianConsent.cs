using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Согласие законного представителя
    /// </summary>
    public class EpguLegalGuardianConsent
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList)
        /// </summary>
        /// <value></value>
        public required long IdCompetitiveGroup { get; set; }
        /// <summary>
        /// Номер предложения
        /// </summary>
        /// <value></value>
        public required string OfferNumber { get; set; }
        /// <summary>
        /// Дата и время добавления согласия в Сервис приема. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        /// <value></value>
        public required string CreatedDateTime { get; set; }
    }
}