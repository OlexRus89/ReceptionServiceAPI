using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
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
        public required long IdObject { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public string? Uid { get; set; }
        /// <summary>
        /// Идентификатор классификатора DirectionCls
        /// </summary>
        public int? IdDirection { get; set; }
        /// <summary>
        /// Основное направление
        /// </summary>
        /// <value></value>
        public bool? PriorityDirection { get; set; }
        /// <summary>
        /// Минимальный проходной балл (основной бюджет очное)
        /// </summary>
        /// <value></value>
        public int? MinPassingScoreBudget { get; set; }
        /// <summary>
        /// Минимальный проходной балл (очное платное)
        /// </summary>
        /// <value></value>
        public int? MinPassingScorePaid { get; set; }

        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        [XmlElement("DictionaryValueList", typeof(DictionaryValueLists))]
        /// <summary>
        /// Список Uid из справочников вуза (DictionaryValueList) с типами "Образовательная программа" или "Профиль"
        /// </summary>
        public DictionaryValueLists? DictionaryValueList { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: false)]
    /// <summary>
    /// Список Uid из справочников вуза (DictionaryValueList) с типами "Образовательная программа" или "Профиль"
    /// </summary>
    public class DictionaryValueLists
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        [XmlElement("Uid", ElementName = "Uid")]
        /// <summary>
        /// Uid значения справочника
        /// </summary>
        public required string[] Uid { get; set; }
    }
}