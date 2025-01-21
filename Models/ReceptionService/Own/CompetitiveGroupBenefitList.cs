using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Особые права КГ заявлений (сущность)
    /// </summary>
    public class CompetitiveGroupBenefitList
    {
        [XmlElement("CompetitiveGroupBenefit", typeof(CompetitiveGroupBenefit))]
        /// <summary>
        /// Объект. Уникально идентифицируется полями GuidCompetitiveGroup + GuidDocument
        /// </summary>
        public required CompetitiveGroupBenefit[] CompetitiveGroupBenefit { get; set; }
    }

    /// <summary>
    /// Объект. Уникально идентифицируется полями GuidCompetitiveGroup + GuidDocument
    /// </summary>
    public class CompetitiveGroupBenefit
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        /// <summary>
        /// Уникальный идентификатор документа (DocumentList) сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidDocument { get; set; }
        /// <summary>
        /// Идентификатор льготы. Идентификатор классификатора BenefitCls
        /// </summary>
        public int? IdBenefit { get; set; }
        /// <summary>
        /// Подтверждено вузом
        /// </summary>
        public bool? AppliedByVuz { get; set; }
        [XmlElement("Ege100List", typeof(Ege100List))]
        /// <summary>
        /// Вступительные испытания, в которых записать результат ЕГЭ = 100 баллов в результате применения данного особого права
        /// </summary>
        public Ege100List? Ege100List { get; set; }
        [XmlElement("Document", typeof(Document))]
        /// <summary>
        /// Информация о документе подтверждающего особое право (льготу)
        /// </summary>
        public Document? Document { get; set; }
    }

    /// <summary>
    /// Вступительные испытания, в которых записать результат ЕГЭ = 100 баллов в результате применения данного особого права
    /// </summary>
    public class Ege100List
    {
        public required string UidEntranceTest { get; set; }
    }
}