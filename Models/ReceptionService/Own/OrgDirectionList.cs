using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Направления подготовки организации (сущность)
    /// </summary>
    public class OrgDirectionList
    {
        [XmlElement("OrgDirection", typeof(OrgDirection))]
        /// <summary>
        /// Объект
        /// </summary>
        public required OrgDirection[] OrgDirection { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class OrgDirection
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
        /// Идентификатор классификатора DirectionCls
        /// </summary>
        public int? IdDirection { get; set; }
        [XmlElement("DictionaryValueList", typeof(DictionaryValueLists))]
        /// <summary>
        /// Список Uid из справочников вуза (DictionaryValueList) с типами "Образовательная программа" или "Профиль"
        /// </summary>
        public DictionaryValueLists? DictionaryValueList { get; set; }
    }

    /// <summary>
    /// Список Uid из справочников вуза (DictionaryValueList) с типами "Образовательная программа" или "Профиль"
    /// </summary>
    public class DictionaryValueLists
    {
        [XmlElement("Uid", ElementName = "Uid")]
        /// <summary>
        /// Uid значения справочника
        /// </summary>
        public required string[] Uid { get; set; }
    }
}