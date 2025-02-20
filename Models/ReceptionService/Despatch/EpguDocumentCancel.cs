using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Удаление документа
    /// </summary>
    public class EpguDocumentCancel
    {
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
        /// Время отзыва. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        /// <value></value>
        public required string UpdatedAt { get; set; }

    }
}