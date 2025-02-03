using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Список. Запись на сдачу ВИ (предмета) (сущность)
    /// </summary>
    public class EntranceTestAgreedList
    {
        [XmlElement("EntranceTestAgreed", typeof(EntranceTestAgreed))]
        /// <summary>
        /// Запись на сдачу вступительного испытания (объект)
        /// </summary>
        public required EntranceTestAgreed[] EntranceTestAgreed { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Запись на сдачу вступительного испытания (объект)
    /// </summary>
    public class EntranceTestAgreed
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего (EntrantList) сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidEntrant { get; set; }
        /// <summary>
        /// Предмет (вступительное испытание). Идентификатор классификатора SubjectCls
        /// </summary>
        public int? IdSubject { get; set; }
        /// <summary>
        /// Уникальный идентификатор даты сдачи (EntranceTestPlaceList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidEntranceTestPlace { get; set; }
        /// <summary>
        /// Выбранный язык сдачи. Идентификатор классификатора EntranceTestLanguageCls. Если не указан, то считать, что выбран "русский язык"
        /// </summary>
        public int? IdEntranceTestLanguage { get; set; }
        /// <summary>
        /// Дата и время создания записи на ВИ. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public string? CreatedDateTime { get; set; }
        /// <summary>
        /// Дата и время последнего изменения записи на ВИ. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public string? UpdatedDateTime { get; set; }
    }
}