using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Список адресов абирутиента
    /// </summary>
    public class AddressList
    {
        [XmlElement("Address", typeof(Address))]
        /// <summary>
        /// Адрес
        /// </summary>
        public required Address[] Address { get; set; }
    }

    /// <summary>
    /// Адрес
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Является ли данный адрес регистрацией поступающего
        /// </summary>
        public required bool IsRegistration { get; set; }
        /// <summary>
        /// Полный адрес
        /// </summary>
        public required string FullAddr { get; set; }
        /// <summary>
        /// Идентификатор классификатора RegionCls
        /// </summary>
        public required int IdRegion { get; set; }
        /// <summary>
        /// Населенный пункт
        /// </summary>
        public required string City { get; set; }
    }
}