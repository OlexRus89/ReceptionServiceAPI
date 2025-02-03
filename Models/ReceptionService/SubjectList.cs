using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService
{
    /// <summary>
    /// Список предметов, выбранных для сдачи
    /// </summary>
    public class SubjectList
    {
        /// <summary>
        /// Идентификатор классификатора SubjectCls
        /// </summary>
        public required int[]? IdSubject { get; set; }
    }
}