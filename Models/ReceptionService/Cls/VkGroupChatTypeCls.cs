using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Типы групповых чатов VK
    /// </summary>
    public class VkGroupChatTypeCls
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        /// <value></value>
        public int? Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        /// <value></value>
        public string? Name { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        /// <value></value>
        public bool? Actual { get; set; }
    }
}