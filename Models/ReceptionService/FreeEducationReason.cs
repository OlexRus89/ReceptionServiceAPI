using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService
{
    /// <summary>
    /// Основания для получения бесплатного образования (для иностранца)
    /// </summary>
    public class FreeEducationReason
    {
        /// <summary>
        /// Основания для получения бесплатного образования (для иностранца). Идентификатор классификатора FreeEducationReasonCls
        /// </summary>
        public required int IdFreeEducationReason { get; set; }
        /// <summary>
        /// Страна, с которой заключен договор. Идентификатор классификатора OksmCls
        /// </summary>
        public int? IdOksmFreeEducationReason { get; set; }

    }
}