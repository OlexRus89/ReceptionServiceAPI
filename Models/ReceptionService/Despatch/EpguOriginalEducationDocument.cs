using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Подача (отзыв) оригинала документа об образовании в вуз онлайн (на ЕПГУ)
    /// </summary>
    public class EpguOriginalEducationDocument
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidEntrant { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Оригинал подан (TRUE) или отозван (FALSE)
        /// </summary>
        public required bool Agree { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Дата и время подачи/отзыва оригинала. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public required string OrigDocDate { get; set; }
    }
}