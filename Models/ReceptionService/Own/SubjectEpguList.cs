using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Own
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Cписок предметов указанных поступающим на ЕПГУ для будущей записи (сущность)
    /// </summary>
    public class SubjectEpguList
    {
        /// <summary>
        /// Объект
        /// </summary>
        public required SubjectEpgu[] SubjectEpgu { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Объект
    /// </summary>
    public class SubjectEpgu 
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidEntrant { get; set; }
        /// <summary>
        /// Предмет. Идентификатор классификатора SubjectCls
        /// </summary>
        public int? IdSubject { get; set; }
    }
}