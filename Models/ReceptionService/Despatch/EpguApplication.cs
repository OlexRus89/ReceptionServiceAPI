using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Новое заявление из ЕПГУ (и данные профиля)
    /// </summary>
    public class EpguApplication
    {
        [XmlElement("Entrant", typeof(Entrant))]
        /// <summary>
        /// Профиль поступающего
        /// </summary>
        public required Entrant Entrant { get; set; }
        [XmlElement("Application", typeof(Application))]
        /// <summary>
        /// Заявление
        /// </summary>
        public required Application Application { get; set; }
    }
}