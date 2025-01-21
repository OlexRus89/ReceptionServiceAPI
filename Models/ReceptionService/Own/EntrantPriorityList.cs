using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Изменение приоритетов в заявлениях списком (сущность)
    /// </summary>
    public class EntrantPriorityList
    {
        [XmlElement("EntrantPriority", typeof(EntrantPriority))]
        /// <summary>
        /// Объект
        /// </summary>
        public required EntrantPriority[] EntrantPriority { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class EntrantPriority
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор поступающего (EntrantList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidEntrant { get; set; }
        [XmlElement("CompetitiveGroupPriorityList", typeof(CompetitiveGroupPriorityList))]
        /// <summary>
        /// Список приоритетов + КГ
        /// </summary>
        public required CompetitiveGroupPriorityList CompetitiveGroupPriorityList { get; set; }
    }

    /// <summary>
    /// Список приоритетов + КГ
    /// </summary>
    public class CompetitiveGroupPriorityList
    {
        [XmlElement("CompetitiveGroupPriority", typeof(CompetitiveGroupPriority))]
        /// <summary>
        /// Приоритет + КГ
        /// </summary>
        public required CompetitiveGroupPriority[] CompetitiveGroupPriority { get; set; }
    }
    
    /// <summary>
    /// Приоритет + КГ
    /// </summary>
    public class CompetitiveGroupPriority
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        [XmlElement("Priority", typeof(Priority))]
        /// <summary>
        /// Приоритет КГ заявления
        /// </summary>
        public required Priority Priority { get; set; }
    }
}