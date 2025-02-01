using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Identity.Client;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Мероприятия ПК (сущность)
    /// </summary>
    public class CampaignEventList
    {
        [XmlElement("CampaignEvent", typeof(CampaignEvent))]
        /// <summary>
        /// Объект
        /// </summary>
        public required CampaignEvent[] CampaignEvent { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class CampaignEvent
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
        /// Уникальный идентификатор Приемной кампании (CampaignList) к которой относится данный объект
        /// </summary>
        public string? UidCampaign { get; set; }
        /// <summary>
        /// Огрн организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public required string OgrnOwnerOrganization { get; set; }
        /// <summary>
        /// Кпп организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public required string KppOwnerOrganization { get; set; }
        /// <summary>
        /// Идентификатор классификатора AdmissionEventCls
        /// </summary>
        public int? IdAdmissionEvent { get; set; }
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
        /// Идентификатор классификатора StagesAdmissionCls
        /// </summary>
        public int? IdStagesAdmission { get; set; }
        /// <summary>
        /// Дата и время начала мероприятия. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Задавать значение только по московскому времени
        /// </summary>
        public string? StartEvent { get; set; }
        /// <summary>
        /// Дата и время окончания мероприятия. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Задавать значение только по московскому времени
        /// </summary>
        public string? EndEvent { get; set; }
    }
}