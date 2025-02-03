using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
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

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
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