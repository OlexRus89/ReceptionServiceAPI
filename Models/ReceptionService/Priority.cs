using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService
{
    /// <summary>
    /// Приоритет КГ заявления
    /// </summary>
    public class Priority
    {
        /// <summary>
        /// Приоритет целевой квоты
        /// </summary>
        public int? PriorityTarget { get; set; }
        /// <summary>
        /// Приоритет иных мест
        /// </summary>
        public int? PriorityOther { get; set; }
    }
}