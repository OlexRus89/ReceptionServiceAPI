using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Конкурсная группа (сущность)
    /// </summary>
    public class CompetitiveGroupList
    {
        [XmlElement("CompetitiveGroup", typeof(CompetitiveGroup))]
        public required CompetitiveGroup[] CompetitiveGroup { get; set; }
    }
}