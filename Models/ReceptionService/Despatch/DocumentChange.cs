using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Изменения документа (новый документ)
    /// </summary>
    public class DocumentChange
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidEntrant { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Уникальный идентификатор документа сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidDocument { get; set; }
        /// <summary>
        /// Id документа
        /// </summary>
        /// <value></value>
        public required long IdDocument { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        /// <value></value>
        public required long IdEntrant { get; set; }
        /// <summary>
        /// Тип документа. Идентификатор классификатора DocumentTypeCls
        /// </summary>
        public required int IdDocumentType { get; set; }
        /// <summary>
        /// Наименование документа
        /// </summary>
        public required string DocName { get; set; }
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
        [XmlElement("Fields", typeof(Fields))]
        /// <summary>
        /// Реквизиты, в зависимости от типа документа
        /// </summary>
        public Fields? Fields { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Категория индивидуального достижения. Идентификатор классификатора AchievementCategoryCls
        /// </summary>
        public int? IdAchievementCategory { get; set; }
        [XmlElement("Achievement", typeof(Achievement))]
        /// <summary>
        /// Индивидуальное достижение
        /// </summary>
        /// <value></value>
        public Achievement? Achievement { get; set; }
        /// <summary>
        /// Статус проверки документа. Идентификатор классификатора DocumentCheckStatusCls
        /// </summary>
        public int? IdCheckStatus { get; set; }
        [XmlElement("File", typeof(File))]
        /// <summary>
        /// Имеющие файлы, отправляются по FUI
        /// </summary>
        public File? File { get; set; }
        /// <summary>
        /// Время создания документа. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        public required string CreatedDateTime { get; set; }
        /// <summary>
        /// Время последнего редактирования документа. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        public string? UpdatedDateTime { get; set; }
        /// <summary>
        /// Источник создания документа
        /// </summary>
        public required string Source { get; set; }
    }

    /// <summary>
    /// Индивидуальное достижение
    /// </summary>
    public class Achievement 
    {
        [XmlElement("EducationLevelGroupList", typeof(EducationLevelGroupList))]
        public required EducationLevelGroupList EducationLevelGroupList { get; set; }
        /// <summary>
        /// Категория Индивидуального достижения. Идентификатор справочника AchievementCategoryCls
        /// </summary>
        /// <value></value>
        public required int IdAchievementCategory { get; set; }
    }

    /// <summary>
    /// Группы уровней образования (бак/спец/бво или маг/спец.во или аспирантура)
    /// </summary>
    public class EducationLevelGroupList
    {
        /// <summary>
        /// Группа уровней образования. Идентификатор справочника EducationLevelGroupCls
        /// </summary>
        /// <value></value>
        public required int[] Id { get; set; }
    }
}