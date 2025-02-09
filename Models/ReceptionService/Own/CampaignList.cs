using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
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
        public required long IdObject { get; set; }
        /// <summary>
        /// Id объекта ПК
        /// </summary>
        /// <value></value>
        public long? Id { get; set; }
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
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
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
        /// URL-ссылка на правила предоставления общежития
        /// </summary>
        /// <value></value>
        public string? UrlHostelPreProvisionRules { get; set; }
        /// <summary>
        /// URL-ссылка на правила приема на военную кафедру
        /// </summary>
        /// <value></value>
        public string? UrlRulesAdmissionMilitaryDepartment { get; set; }
        /// <summary>
        /// URL-ссылка на стажировки
        /// </summary>
        /// <value></value>
        public string? UrlInternship { get; set; }
        /// <summary>
        /// URL-ссылка на научную лабораторию
        /// </summary>
        /// <value></value>
        public string? UrlScientificLaboratory { get; set; }
        /// <summary>
        /// URL-ссылка на особые стипендии
        /// </summary>
        /// <value></value>
        public string? UrlSpecialScholarships { get; set; }
        /// <summary>
        /// URL-ссылка на партнерские проект
        /// </summary>
        /// <value></value>
        public string? UrlPartnerProjects { get; set; }
        /// <summary>
        /// URL-ссылка на правила приема вуза
        /// </summary>
        /// <value></value>
        public string? UrlUniversityAdmissionRules { get; set; }
        /// <summary>
        /// Согласие на использование сервисов VK для общения с поступающими и поступившими
        /// </summary>
        /// <value></value>
        public bool? VkAccept { get; set; }
        /// <summary>
        /// Ссылка на VK-мессенджер для поступающих
        /// </summary>
        /// <value></value>
        public string? UrlVk { get; set; }
        /// <summary>
        /// ID сообщества VK
        /// </summary>
        /// <value></value>
        public string? IdVkCommunity { get; set; }
        /// <summary>
        /// Значение справочника VkGroupChatTypesCls
        /// </summary>
        /// <value></value>
        public int? IdVkGroupChatType { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Подача единого заявления только в головной вуз на бюджетные места во время основного набора
        /// </summary>
        public bool? HeadVuzBudgetBasic { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Подача единого заявления только в головной вуз на платные места во время основного набора
        /// </summary>
        public bool? HeadVuzPaidBasic { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Подача единого заявления только в головной вуз на бюджетные места во время дополнительного набора
        /// </summary>
        public bool? HeadVuzBudgetAdditional { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Подача единого заявления только в головной вуз на платные места во время дополнительного набора
        /// </summary>
        public bool? HeadVuzPaidAdditional { get; set; }
    }
}