using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Пакет конкурсного списка (сущность)
    /// </summary>
    public class RankedCompetitionListPackage
    {
        /// <summary>
        /// Наименование пакета
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public required string Uid { get; set; }
        /// <summary>
        /// Файл с xml схемой соответствующей PackageBodyFile.xsd закодированный в base64
        /// </summary>
        public string? Base64File { get; set; }
        /// <summary>
        /// Статус пакета. Идентификатор классификатора PackagesStatusCls
        /// </summary>
        public int? IdStatus { get; set; }
        /// <summary>
        /// Ошибка (если она есть)
        /// </summary>
        public string? Error { get; set; }
    }
}