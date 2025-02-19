using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Целевые организации
    /// </summary>
    public class TargetOrganizationCls
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        /// <value></value>
        public int? Id { get; set; }
        /// <summary>
        /// Огрн организации
        /// </summary>
        /// <value></value>
        public string? Ogrn { get; set; }
        /// <summary>
        /// Кпп организации
        /// </summary>
        /// <value></value>
        public string? Kpp { get; set; }
        /// <summary>
        /// Полное наименование
        /// </summary>
        /// <value></value>
        public string? Name { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        /// <value></value>
        public bool? Actual { get; set; }
        /// <summary>
        /// Время изменения. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        /// <value></value>
        public string? UpdatedAt { get; set; }
    }
}