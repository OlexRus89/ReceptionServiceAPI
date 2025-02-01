using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Подача (отзыв) оригинала документа об образовании в вуз онлайн (на ЕПГУ)
    /// </summary>
    public class EpguOriginalEducationDocument
    {
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidEntrant { get; set; }
        /// <summary>
        /// Оригинал подан (TRUE) или отозван (FALSE)
        /// </summary>
        public required bool Agree { get; set; }
        /// <summary>
        /// Дата и время подачи/отзыва оригинала. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public required string OrigDocDate { get; set; }
    }
}