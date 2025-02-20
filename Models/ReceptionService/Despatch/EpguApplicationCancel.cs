using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Отзыв заявления на ЕПГУ (при этом все КГ будут в конечных статусах)
    /// </summary>
    public class EpguApplicationCancel
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Уникальный идентификатор заявления (ApplicationList) сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidApplication { get; set; }
        /// <summary>
        /// Уникальный идентификатор заявления
        /// </summary>
        /// <value></value>
        public required long IdApplication { get; set; }
        /// <summary>
        /// Время отзыва. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        /// <value></value>
        public required string UpdatedAt { get; set; }
    }
}