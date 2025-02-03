using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Cписок профилей поступающих (сущность)
    /// </summary>
    public class EntrantList
    {
        [XmlElement("Entrant", typeof(Models.ReceptionService.Entrant))]
        public required Models.ReceptionService.Entrant[] Entrant { get; set; }
    }
}