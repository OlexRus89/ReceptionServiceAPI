using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Запись (отказ от записи) на сдачу вступительного испытания (с ЕПГУ)
    /// </summary>
    public class EpguTestAgreed
    {
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidEntrant { get; set; }
        /// <summary>
        /// Уникальный идентификатор даты сдачи (EntranceTestPlaceList) в рамках организации сгенерированный организацией
        /// </summary>
        public required string UidEntranceTestPlace { get; set; }
        /// <summary>
        /// Выбранный язык сдачи. Идентификатор классификатора EntranceTestLanguageCls. Если не указан, то считать, что выбран "русский язык"
        /// </summary>
        public int? IdEntranceTestLanguage { get; set; }
        /// <summary>
        /// Признак записи на ВИ (TRUE - запись на ВИ, FALSE - отказ от записи)
        /// </summary>
        public required bool Agree { get; set; }
        /// <summary>
        /// Дата и время создания записи на ВИ. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public required string CreatedDateTime { get; set; }
        /// <summary>
        /// Дата и время последнего изменения записи на ВИ. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public string? UpdatedDateTime { get; set; }
    }
}