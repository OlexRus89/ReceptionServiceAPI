using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService
{
    /// <summary>
    /// Список прилагаемых документов
    /// </summary>
    public class DocumentList
    {
        [XmlElement("Document", typeof(Document))]
        /// <summary>
        /// Документ
        /// </summary>
        public required Document[] Document { get; set; }
    }

    public class Document
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public int? IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidEntrant { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта сгенерированный Сервисом приема
        /// </summary>
        public Guid? Guid { get; set; }
        /// <summary>
        /// Хэш файла. Есть хэш - есть файл, нет хэша - нет файла
        /// </summary>
        public string? FileHash { get; set; }
        /// <summary>
        /// Тип документа. Идентификатор классификатора DocumentTypeCls
        /// </summary>
        public int? IdDocumentType { get; set; }
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string? DocName { get; set; }
        /// <summary>
        /// Серия документа
        /// </summary>
        public string? DocSeries { get; set; }
        /// <summary>
        /// Номер документа
        /// </summary>
        public string? DocNumber { get; set; }
        /// <summary>
        /// Дата выдачи. Шаблон "2006-01-02"
        /// </summary>
        public string? IssueDate { get; set; }
        /// <summary>
        /// Огранизация, выдавшая документ
        /// </summary>
        public string? DocOrganization { get; set; }
        /// <summary>
        /// Статус проверки документа. Идентификатор классификатора DocumentCheckStatusCls
        /// </summary>
        public int? IdCheckStatus { get; set; }
        /// <summary>
        /// Категория индивидуального достижения. Идентификатор классификатора AchievementCategoryCls
        /// </summary>
        public int? IdAchievementCategory { get; set; }
        /// <summary>
        /// Реквизиты, в зависимости от типа документа
        /// </summary>
        public Fields? Fields { get; set; }
        /// <summary>
        /// Время создания документа. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        public string? CreatedDateTime { get; set; }
        /// <summary>
        /// Время последнего редактирования документа. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        public string? UpdatedDateTime { get; set; }
        /// <summary>
        /// Источник создания документа
        /// </summary>
        public string? Source { get; set; }
        /// <summary>
        /// Файлы
        /// </summary>
        public File? File { get; set; }
    }
}