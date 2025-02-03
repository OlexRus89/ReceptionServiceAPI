using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Справочники вуза (сущность)
    /// </summary>
    public class DictionaryValueList
    {
        [XmlElement("DictionaryValue", typeof(DictionaryValue))]
        /// <summary>
        /// Объект
        /// </summary>
        public DictionaryValue[]? DictionaryValue { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class DictionaryValue
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required long IdObject { get; set; }
        /// <summary>
        /// Id объекта
        /// </summary>
        /// <value></value>
        public int? Id { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public string? Uid { get; set; }
        /// <summary>
        /// Идентификатор классификатора DictionaryTypeCls
        /// </summary>
        public int? IdDictionaryType { get; set; }
        /// <summary>
        /// Новое значение справочника
        /// </summary>
        public string? Value { get; set; }
    }
}