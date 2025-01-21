using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Выгрузка конкурсных групп вузов (сущность)
    /// </summary>
    public class CompetitiveGroupSyncUpload
    {
        /// <summary>
        /// Огрн организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public required string OgrnOwnerOrganization { get; set; }
        /// <summary>
        /// Кпп организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public required string KppOwnerOrganization { get; set; }
    }
}