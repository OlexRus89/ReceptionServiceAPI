using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Сведения о наличии заявки на платформе 'Работа в России'
    /// </summary>
    public class RtTargetAgree
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        /// <summary>
        /// Статус заявки на целевое обучение. Идентификатор классификатора TargetAgreeStatusCls
        /// </summary>
        public required int IdTargetAgreeStatus { get; set; }
        /// <summary>
        /// Дата и время создания сведения. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public required string CreatedDateTime { get; set; }
    }
}