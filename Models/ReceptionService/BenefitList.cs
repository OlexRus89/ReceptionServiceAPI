using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService
{
    /// <summary>
    /// Особые права КГ заявлений
    /// </summary>
    public class BenefitList
    {
        [XmlElement("Benefit", typeof(Benefit))]
        /// <summary>
        /// Особое право КГ заявления
        /// </summary>
        public required Benefit[] Benefit { get; set; }
    }

    /// <summary>
    /// Особое право КГ заявления
    /// </summary>
    public class Benefit
    {
        /// <summary>
        /// Уникальный идентификатор документа (DocumentList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidDocument { get; set; }
        /// <summary>
        /// Идентификатор льготы. Идентификатор классификатора BenefitCls
        /// </summary>
        public required int IdBenefit { get; set; }
    }
}