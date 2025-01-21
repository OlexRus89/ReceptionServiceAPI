using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models.ReceptionService
{
    /// <summary>
    /// Список специальных условий сдачи ВИ
    /// </summary>
    public class SpecialConditionList
    {
        /// <summary>
        /// Специальное условие. Идентификатор классификатора SpecialConditionsCls
        /// </summary>
        public required int[]? IdSpecialCondition { get; set; }
    }
}