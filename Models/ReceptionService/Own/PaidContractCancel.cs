using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Отказ заключения платного договора (сущность)
    /// </summary>
    public class PaidContractCancel
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        /// <summary>
        /// Комментарий к отказу
        /// </summary>
        public required string Comment { get; set; }
    }
}