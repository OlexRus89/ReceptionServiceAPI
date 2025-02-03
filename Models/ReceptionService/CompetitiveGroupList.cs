using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService
{
    /// <summary>
    /// Список конкурсных групп
    /// </summary>
    public class CompetitiveGroupList
    {
        [XmlElement("CompetitiveGroup", typeof(CompetitiveGroup))]
        /// <summary>
        /// Конкурсная группа
        /// </summary>
        public required CompetitiveGroup[] CompetitiveGroup { get; set; }
    }

    /// <summary>
    /// Конкурсная группа
    /// </summary>
    public class CompetitiveGroup
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public int? IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidEntrant { get; set; }
        /// <summary>
        /// Уникальный идентификатор заявления сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidApplication { get; set; }
        /// <summary>
        /// Уникальный идентификатор КГ заявления, сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidCompetitiveGroup { get; set; }
        /// <summary>
        /// Уникальный идентификатор конкурса (CompetitionList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidCompetition { get; set; }
        /// <summary>
        /// Уникальный идентификатор целевой организации (TargetOrganizationList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidTargetOrganization { get; set; }
        /// <summary>
        /// Статус КГ заявления. Идентификатор классификатора CompetitiveGroupStatusCls
        /// </summary>
        public int? IdStatus { get; set; }
        /// <summary>
        /// Комментарий к статусу
        /// </summary>
        public string? StatusComment { get; set; }
        /// <summary>
        /// Дата и время создания КГ. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public string? CreatedDateTime { get; set; }
        [XmlElement("Priority", typeof(Priority))]
        /// <summary>
        /// Приоритет КГ заявления
        /// </summary>
        public Priority? Priority { get; set; }
        [XmlElement("DictionaryValueSportList", typeof(DictionaryValueSportList))]
        /// <summary>
        /// Указать список видов спорта
        /// </summary>
        public DictionaryValueSportList? DictionaryValueSportList { get; set; }
        [XmlElement("BenefitList", typeof(BenefitList))]
        /// <summary>
        /// Особые права КГ заявлений
        /// </summary>
        public BenefitList? BenefitList { get; set; }
        /// <summary>
        /// Дата и время отказа от зачисления. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public string? RefuseEnrollmentDate { get; set; }
        /// <summary>
        /// Огрн организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public string? OgrnOwnerOrganization { get; set; }
        /// <summary>
        /// Кпп организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public string? KppOwnerOrganization { get; set; }
        /// <summary>
        /// Время последнего редактирования статуса. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        public string? StatusUpdatedDateTime { get; set; }
        /// <summary>
        /// Признак создания вузом (true - создано вузом, false - поступающим через ЕПГУ)
        /// </summary>
        public bool? IsOovo { get; set; }
        /// <summary>
        /// Время последнего редактирования приоритета. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        public string? PriorityUpdatedDateTime { get; set; }
        /// <summary>
        /// Этап приема конкурса ПК. Идентификатор классификатора StagesAdmissionCls
        /// </summary>
        public int? IdStageAdmission { get; set; }
        /// <summary>
        /// Форма обучения конкурса ПК. Идентификатор классификатора EducationFormCls
        /// </summary>
        public int? IdEducationForm { get; set; }
        /// <summary>
        /// Вид мест конкурса ПК. Идентификатор классификатора PlaceTypeCls
        /// </summary>
        public int? IdPlaceType { get; set; }
        /// <summary>
        /// Наименование (для отображения поступающему на ЕПГУ) конкурса ПК
        /// </summary>
        public string? NameCompetition { get; set; }
        /// <summary>
        /// Уникальный идентификатор НП / УГСН (OrgDirectionList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidOrgDirection { get; set; }
        /// <summary>
        /// Статус договора о платном обучении. Идентификатор классификатора PaidContractStatusCls
        /// </summary>
        public int? IdPaidContractStatus { get; set; }
        /// <summary>
        /// Статус доп соглашения договора о платном обучении. Идентификатор классификатора PaidContractStatusCls
        /// </summary>
        public int? IdAdditionalPaidContractStatus { get; set; }
    }
}