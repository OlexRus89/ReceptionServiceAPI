using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Список целевых организаций (сущность)
    /// </summary>
    public class TargetOrganizationList
    {
        /// <summary>
        /// Id значения справочника TargetOrganizationsCls. Все значения IdTargetOrganization в теге TargetOrganizationList должны быть уникальны, иначе ошибка
        /// </summary>
        /// <value></value>
        public required int[] IdTargetOrganization { get; set; }
        
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        [XmlElement("TargetOrganization", typeof(TargetOrganization))]
        /// <summary>
        /// Объект
        /// </summary>
        public TargetOrganization[]? TargetOrganization { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: false)]
    /// <summary>
    /// Объект
    /// </summary>
    public class TargetOrganization
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта сгенерированный Сервисом Приема, который нужно использовать при добавлении и чтении целевого договора
        /// </summary>
        public int? IdTargetOrganization { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public string? Uid { get; set; }
        /// <summary>
        /// Огрн организации
        /// </summary>
        public string? Ogrn { get; set; }
        /// <summary>
        /// Кпп организации
        /// </summary>
        public string? Kpp { get; set; }
        /// <summary>
        /// Инн организации
        /// </summary>
        public string? Inn { get; set; }
        /// <summary>
        /// Сокращенное наименование
        /// </summary>
        public string? ShortTitle { get; set; }
        /// <summary>
        /// Полное наименование
        /// </summary>
        public string? FullTitle { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Электронный адрес
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// ФИО директора
        /// </summary>
        public string? ChiefName { get; set; }
    }
}