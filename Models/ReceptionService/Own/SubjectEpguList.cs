using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
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