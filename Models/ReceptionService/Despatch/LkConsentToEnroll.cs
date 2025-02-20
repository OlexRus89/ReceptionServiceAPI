using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Подача (отзыв) очного согласия (через ЛК)
    /// </summary>
    public class LkConsentToEnroll
    {
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        /// <value></value>
        public required long IdEntrant { get; set; }
        /// <summary>
        /// Согласие подано (TRUE) или отозвано (FALSE)
        /// </summary>
        /// <value></value>
        public required bool Agree { get; set; }
        /// <summary>
        /// Дата подачи/отзыва согласия. Шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        /// <value></value>
        public required string AgreeDate { get; set; }
        /// <summary>
        /// Группа уровней образования. Идентификатор классификатора EducationLevelGroupCls
        /// </summary>
        /// <value></value>
        public required int IdEducationLevelGroup { get; set; }

    }
}