using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Выполнение действия на ЕПГУ по уведомлению
    /// </summary>
    public class EpguNoticeDone
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Уникальный идентификатор уведомления (NoticeList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? Uid { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Выполнено на ЕПГУ
        /// </summary>
        public bool? Done { get; set; }
        /// <summary>
        /// Id уведомления (объект сущности NoticeList)
        /// </summary>
        /// <value></value>
        public required int Id { get; set; }
    }
}