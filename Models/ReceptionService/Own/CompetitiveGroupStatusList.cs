using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Изменение статусов конкурсных групп списком (сущность)
    /// </summary>
    public class CompetitiveGroupStatusList
    {
        [XmlElement("CompetitiveGroupStatus", typeof(CompetitiveGroupStatus))]
        /// <summary>
        /// Объект
        /// </summary>
        public required CompetitiveGroupStatus[] CompetitiveGroupStatus { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class CompetitiveGroupStatus 
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
        /// Статус КГ заявления. Идентификатор классификатора CompetitiveGroupStatusCls
        /// </summary>
        public required int IdStatus { get; set; }
        /// <summary>
        /// Комментарий к статусу
        /// </summary>
        public string? StatusComment { get; set; }
        /// <summary>
        /// Причина. Идентификатор классификатора ReasonsRejectionCls. Обязательно указывается при назначении статусов "Не прошло по конкурсу" и "Отклонено"
        /// </summary>
        public int? IdReasonRejection { get; set; }
    }
}