using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Конкурсы (сущность)
    /// </summary>
    public class CompetitionList
    {
        [XmlElement("Competition", typeof(Competition))]
        /// <summary>
        /// Объект
        /// </summary>
        public required Competition[] Competition { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class  Competition
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required long IdObject { get; set; }
        /// <summary>
        /// Id объекта
        /// </summary>
        /// <value></value>
        public long? Id { get; set; }
        /// <summary>
        /// Огрн организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public string? OgrnOwnerOrganization { get; set; }
        /// <summary>
        /// Кпп организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public string? KppOwnerOrganization { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public string? Uid { get; set; }
        /// <summary>
        /// Уникальный идентификатор Приемной кампании (CampaignList) к которой относится данный объект
        /// </summary>
        /// <value></value>
        public long? IdCampaign { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Уникальный идентификатор Приемной кампании (CampaignList) к которой относится данный объект
        /// </summary>
        public string? UidCampaign { get; set; }
        /// <summary>
        /// Идентификатор классификатора DirectionCls
        /// </summary>
        /// <value></value>
        public int? IdDirection { get; set; }
        /// <summary>
        /// НП из состава УГСН
        /// </summary>
        /// <value></value>
        public OksoUgsnList[]? OksoUgsnList { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Уникальный идентификатор Направления подготовки организации (OrgDirectionList) к которой относится данный объект
        /// </summary>
        public string? UidOrgDirection { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Наименование (для отображения поступающему на ЕПГУ)
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Технический комментарий (для дополнительных сведений вуза)
        /// </summary>
        public string? Comment { get; set; }
        /// <summary>
        /// Идентификатор классификатора EducationLevelCls
        /// </summary>
        public int? IdEducationLevel { get; set; }
        /// <summary>
        /// Идентификатор классификатора EducationFormCls
        /// </summary>
        public int? IdEducationForm { get; set; }
        /// <summary>
        /// Идентификатор классификатора PlaceTypeCls
        /// </summary>
        public int? IdPlaceType { get; set; }
        /// <summary>
        /// Значение справочника BudgetLevelCls
        /// </summary>
        /// <value></value>
        public int? IdBudgetLevel { get; set; }
        /// <summary>
        /// Количество мест
        /// </summary>
        public double? NumberPlaces { get; set; }
        /// <summary>
        /// Этап приема. Идентификатор Классификатор StagesAdmissionCls
        /// </summary>
        public int? IdStageAdmission { get; set; }
        /// <summary>
        /// Признак «Только для иностранных граждан»
        /// </summary>
        public bool? OnlyForForeigners { get; set; }
        /// <summary>
        /// Признак «Только для граждан РФ»
        /// </summary>
        public bool? OnlyCitizensRF { get; set; }
        /// <summary>
        /// Признак «Для поступающих на второе высшее образование в области искусств» (да/нет)
        /// </summary>
        public bool? SecondEducationArts { get; set; }
        /// <summary>
        /// Признак «Наличие предварительных прослушиваний (туров)»
        /// </summary>
        public bool? PreviewTours { get; set; }
        /// <summary>
        /// Признак «Необходимость прикрепления портфолио (творческих работ) к заявлению в виде файла»
        /// </summary>
        public bool? AttachingPortfolio { get; set; }
        /// <summary>
        /// Признак «Необходимость прохождения поступающими обязательного предварительного медицинского осмотра (обследования)"
        /// </summary>
        public bool? MedicalExamination { get; set; }
        [XmlElement("CompetitionParamList", typeof(CompetitionParamList))]
        /// <summary>
        /// Список доп параметров конкурса
        /// </summary>
        public CompetitionParamList? CompetitionParamList{ get; set; }
        /// <summary>
        /// Образовательные программы
        /// </summary>
        /// <value></value>
        public EducationalProgramList? EducationalProgramList { get; set; }
        /// <summary>
        /// Целевые организации
        /// </summary>
        /// <value></value>
        public TargetOrganizationList? TargetOrganizationList { get; set; }
        /// <summary>
        /// Только для ВО
        /// </summary>
        /// <value></value>
        public bool? OnlyForVo { get; set; }
        /// <summary>
        /// Только для СПО
        /// </summary>
        /// <value></value>
        public bool? OnlyForSpo { get; set; }
        /// <summary>
        /// Утверждено учредителем
        /// </summary>
        /// <value></value>
        public bool? ApprovedFoiv { get; set; }
        /// <summary>
        /// Стоимость обучения в рублях
        /// </summary>
        /// <value></value>
        public float? CostOfStudy { get; set; }
    }

    /// <summary>
    /// НП из состава УГСН
    /// </summary>
    public class OksoUgsnList
    {
        /// <summary>
        /// Идентификатор классификатора DirectionCls
        /// </summary>
        /// <value></value>
        public required int IdDirection { get; set; }
    }

    /// <summary>
    /// Список доп параметров конкурса
    /// </summary>
    public class CompetitionParamList
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Uid значения справочника DictionaryValueList. Все значения UidDictionaryValue в теге CompetitionParamList должны быть уникальны, иначе ошибка
        /// </summary>
        public string[]? UidDictionaryValue { get; set; }
        /// <summary>
        /// Id значения справочника DictionaryValueList. Все значения IdDictionaryValue в теге CompetitionParamList должны быть уникальны, иначе ошибка
        /// </summary>
        /// <value></value>
        public required int[] IdDictionaryValue { get; set; }
    }
}