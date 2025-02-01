using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Identity.Client;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Список уведомлений (сущность)
    /// </summary>
    public class NoticeList
    {
        [XmlElement("Notice", typeof(Notice))]
        /// <summary>
        /// Объект
        /// </summary>
        public required Notice[] Notice { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class Notice
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор заявления (ApplicationList) сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidApplication { get; set; }
        /// <summary>
        /// Тип уведомления. Идентификатор классификатора NoticesTypeCls
        /// </summary>
        public int? IdNoticeType { get; set; }
        /// <summary>
        /// Текст уведомления
        /// </summary>
        public string? Comment { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public string? Uid { get; set; }
        /// <summary>
        /// Признак, что отработано на ЕПГУ
        /// </summary>
        public bool? IsDone { get; set; }
        /// <summary>
        /// Время поступления ответа от ЕПГУ. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Возвращается только если IsDone == true
        /// </summary>
        public string? RecieveDate { get; set; }

    }
}