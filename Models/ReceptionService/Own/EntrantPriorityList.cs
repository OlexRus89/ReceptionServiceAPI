using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
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

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
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

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
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
    
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
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