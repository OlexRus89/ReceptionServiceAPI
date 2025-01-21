using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Приемная кампания (сущность)
    /// </summary>
    public class CampaignList
    {
        [XmlElement("Campaign", typeof(Campaign))]
        /// <summary>
        /// Объект
        /// </summary>
        public required Campaign[] Campaign { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class Campaign
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public string? Uid { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Учебный год приемной кампании в котором начинается прием
        /// </summary>
        public int? YearStart { get; set; }
        /// <summary>
        /// Идентификатор классификатора CampaignStatusCls
        /// </summary>
        public int? IdCampaignStatus { get; set; }
        /// <summary>
        /// Макс. кол-во специальностей и (или) направлений подготовки для одновременного участия в конкурсе (по программам бакалавриата и программам специалитета)
        /// </summary>
        public int? CountDirections { get; set; }
        /// <summary>
        /// URL-Ссылка на перечень учитываемых вузом ИД
        /// </summary>
        public string? UrlListAchievements { get; set; }
        /// <summary>
        /// URL-Ссылка на список поступающих на бюджет
        /// </summary>
        public string? UrlApplicantsBudget { get; set; }
        /// <summary>
        /// URL-Ссылка на список поступающих на платное
        /// </summary>
        public string? UrlContendersPaid { get; set; }
        /// <summary>
        /// URL-Ссылка на порядок подачи апелляции
        /// </summary>
        public string? UrlProcedureAppeal { get; set; }
        /// <summary>
        /// URL-Ссылка на соответствие профилей олимпиад школьников и спортивных достижений направлениям подготовки и специальностям
        /// </summary>
        public string? UrlOlympiadsSpecialties { get; set; }
        /// <summary>
        /// URL-Ссылка на соответствие профилей олимпиад школьников и спортивных достижений общеобразовательным предметам
        /// </summary>
        public string? UrlOlympiadsSubjects { get; set; }
        /// <summary>
        /// URL-Ссылка на информацию о предоставлении особых прав
        /// </summary>
        public string? UrlGrantingSpecialRights { get; set; }
        /// <summary>
        /// Подача единого заявления только в головной вуз на бюджетные места во время основного набора
        /// </summary>
        public bool? HeadVuzBudgetBasic { get; set; }
        /// <summary>
        /// Подача единого заявления только в головной вуз на платные места во время основного набора
        /// </summary>
        public bool? HeadVuzPaidBasic { get; set; }
        /// <summary>
        /// Подача единого заявления только в головной вуз на бюджетные места во время дополнительного набора
        /// </summary>
        public bool? HeadVuzBudgetAdditional { get; set; }
        /// <summary>
        /// Подача единого заявления только в головной вуз на платные места во время дополнительного набора
        /// </summary>
        public bool? HeadVuzPaidAdditional { get; set; }
    }
}