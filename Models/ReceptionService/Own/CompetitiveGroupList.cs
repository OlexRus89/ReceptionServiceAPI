using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Конкурсная группа (сущность)
    /// </summary>
    public class CompetitiveGroupList
    {
        [XmlElement("CompetitiveGroup", typeof(CompetitiveGroup))]
        public required CompetitiveGroup[] CompetitiveGroup { get; set; }
    }
}