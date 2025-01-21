using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Удаление документа
    /// </summary>
    public class EpguDocumentCancel
    {
        /// <summary>
        /// Уникальный идентификатор документа сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidDocument { get; set; }
    }
}