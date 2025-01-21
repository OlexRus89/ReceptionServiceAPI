using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
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
        public required int IdObject { get; set; }
        /// <summary>
        /// Огрн организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public required string OgrnOwnerOrganization { get; set; }
        /// <summary>
        /// Кпп организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public required string KppOwnerOrganization { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public string? Uid { get; set; }
        /// <summary>
        /// Уникальный идентификатор Приемной кампании (CampaignList) к которой относится данный объект
        /// </summary>
        public string? UidCampaign { get; set; }
        /// <summary>
        /// Уникальный идентификатор Направления подготовки организации (OrgDirectionList) к которой относится данный объект
        /// </summary>
        public string? UidOrgDirection { get; set; }
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
    }

    /// <summary>
    /// Список доп параметров конкурса
    /// </summary>
    public class CompetitionParamList
    {
        /// <summary>
        /// Uid значения справочника DictionaryValueList. Все значения UidDictionaryValue в теге CompetitionParamList должны быть уникальны, иначе ошибка
        /// </summary>
        public required string[] UidDictionaryValue { get; set; }
    }
}