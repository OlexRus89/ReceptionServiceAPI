using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ReceptionServiceCore.Models.ReceptionService;
using ReceptionServiceCore.Models.ReceptionService.Despatch;

namespace ReceptionServiceCore.Models.ReceptionService
{
    /// <summary>
    /// Профиль поступающего
    /// </summary>
    public class Entrant
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public int? IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта сгенерированный Сервисом приема
        /// </summary>
        public Guid? Guid { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidEntrant { get; set; }
        /// <summary>
        /// СНИЛС
        /// </summary>
        public string? Snils { get; set; }
        /// <summary>
        /// Пол. Идентификатор классификатора GenderCls
        /// </summary>
        public int? IdGender { get; set; }
        /// <summary>
        /// Дата рождения. Шаблон "2006-01-02"
        /// </summary>
        public string? Birthday { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string? Birthplace { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Электронный адрес
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string? Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }
        /// <summary>
        /// Гражданство - Идентификатор классификатора OksmCls
        /// </summary>
        public int? IdOksm { get; set; }
        [XmlElement("FreeEducationReason", typeof(FreeEducationReason))]
        /// <summary>
        /// Основания для получения бесплатного образования (для иностранца)
        /// </summary>
        public FreeEducationReason? FreeEducationReason { get; set; }
        [XmlElement("AddressList", typeof(AddressList))]
        /// <summary>
        /// Список адресов абирутиента
        /// </summary>
        public AddressList? AddressList { get; set; }
        [XmlElement("DocumentList", typeof(DocumentList))]
        /// <summary>
        /// Список прилагаемых документов
        /// </summary>
        public DocumentList? DocumentList { get; set; }
        [XmlElement("Photo", typeof(Photo))]
        /// <summary>
        /// Фото
        /// </summary>
        public Photo? Photo { get; set; }
        /// <summary>
        /// Месяц рождения (1 - январь, 12 - декабрь)
        /// </summary>
        public int? Month { get; set; }
        /// <summary>
        /// Наличие документов о высшем образовании в ФРДО
        /// </summary>
        public bool? AvailabilityEduDoc { get; set; }
        /// <summary>
        /// Московское время последнего запроса на наличие документа о высшем образовании в ФРДО. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public string? DateAvailabilityEduDoc { get; set; }
    }
}