using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Заявление стало отображаться на ЕПГУ
    /// </summary>
    public class EpguDisplayApplication
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
        /// Уникальный идентификатор заявления на ЕПГУ
        /// </summary>
        /// <value></value>
        public required long IdEpgu { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        /// <value></value>
        public required long IdEntrant { get; set; }
        /// <summary>
        /// Уникальный код поступающего (для формирования конкурсных списков и списков поступающих)
        /// </summary>
        /// <value></value>
        public required long UniqueCodeProfile { get; set; }
        
    }
}