using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Сведения о заключенном целевом договоре на платформе 'Работа в России' (сущность)
    /// </summary>
    public class TargetContractList
    {
        [XmlElement("TargetContract", typeof(TargetContract))]
        /// <summary>
        /// Объект
        /// </summary>
        public required TargetContract[] TargetContract { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class TargetContract 
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        /// <summary>
        /// Тип договора (по количеству участников). Идентификатор классификатора ContractTypeCls
        /// </summary>
        public int? IdContractType { get; set; }
        /// <summary>
        /// Вид целевого договора. Идентификатор классификатора TargetDocumentTypeCls
        /// </summary>
        public int? IdTargetDocumentType { get; set; }
        /// <summary>
        /// Наименование заказчика
        /// </summary>
        public string? EmployerName { get; set; }
        /// <summary>
        /// ОГРН заказчика
        /// </summary>
        public string? EmployerOgrn { get; set; }
        /// <summary>
        /// КПП заказчика
        /// </summary>
        public string? EmployerKpp { get; set; }
        /// <summary>
        /// ИНН заказчика
        /// </summary>
        public string? EmployerInn { get; set; }
        /// <summary>
        /// Статус целевого договора. Идентификатор классификатора TargetContractStatusCls
        /// </summary>
        public int? IdTargetContractStatusCls { get; set; }
        /// <summary>
        /// Комментарий к статусу
        /// </summary>
        public string? StatusComment { get; set; }
        /// <summary>
        /// Номер договора
        /// </summary>
        public string? NumberContract { get; set; }
        /// <summary>
        /// Дата договора
        /// </summary>
        public string? DateContract { get; set; }
    }
}