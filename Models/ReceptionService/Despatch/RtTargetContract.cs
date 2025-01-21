using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Сведения о заключенном целевом договоре на платформе 'Работа в России'
    /// </summary>
    public class RtTargetContract
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        /// <summary>
        /// Тип договора (по количеству участников). Идентификатор классификатора ContractTypeCls
        /// </summary>
        public required int IdContractType { get; set; }
        /// <summary>
        /// Вид целевого договора. Идентификатор классификатора TargetDocumentTypeCls
        /// </summary>
        public required int IdTargetDocumentType { get; set; }
        /// <summary>
        /// Наименование заказчика
        /// </summary>
        public required string EmployerName { get; set; }
        /// <summary>
        /// ОГРН заказчика
        /// </summary>
        public required string EmployerOgrn { get; set; }
        /// <summary>
        /// КПП заказчика
        /// </summary>
        public required string EmployerKpp { get; set; }
        /// <summary>
        /// ИНН заказчика
        /// </summary>
        public string? EmployerInn { get; set; }
        /// <summary>
        /// Статус целевого договора. Идентификатор классификатора TargetContractStatusCls
        /// </summary>
        public required int IdTargetContractStatusCls { get; set; }
        /// <summary>
        /// Комментарий к статусу
        /// </summary>
        public string? StatusComment { get; set; }
        /// <summary>
        /// Номер договора
        /// </summary>
        public required string NumberContract { get; set; }
        /// <summary>
        /// Дата договора
        /// </summary>
        public required DateTime DateContract { get; set; }
    }
}