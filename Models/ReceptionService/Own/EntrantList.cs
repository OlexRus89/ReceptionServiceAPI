using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Cписок профилей поступающих (сущность)
    /// </summary>
    public class EntrantList
    {
        [XmlElement("Entrant", typeof(Models.ReceptionService.Entrant))]
        public required Models.ReceptionService.Entrant[] Entrant { get; set; }
    }
}