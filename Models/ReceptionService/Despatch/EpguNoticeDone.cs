using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Выполнение действия на ЕПГУ по уведомлению
    /// </summary>
    public class EpguNoticeDone
    {
        /// <summary>
        /// Уникальный идентификатор уведомления (NoticeList) в рамках организации сгенерированный организацией
        /// </summary>
        public required string Uid { get; set; }
        /// <summary>
        /// Выполнено на ЕПГУ
        /// </summary>
        public required bool Done { get; set; }
    }
}