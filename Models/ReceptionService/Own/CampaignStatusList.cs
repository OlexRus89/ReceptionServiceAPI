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
    public class CampaignStatusList
    {
        [XmlElement("CampaignStatus", typeof(CampaignStatus))]
        /// <summary>
        /// Объект
        /// </summary>
        public required CampaignStatus[] CampaignStatus { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class CampaignStatus
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public required string Uid { get; set; }
        /// <summary>
        /// Идентификатор классификатора CampaignStatusCls
        /// </summary>
        public required int IdCampaignStatus { get; set; }
    }
}