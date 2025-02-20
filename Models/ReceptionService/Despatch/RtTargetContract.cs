using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Сведения о заключенном целевом договоре на платформе 'Работа в России'
    /// </summary>
    public class RtTargetContract
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом прием
        /// </summary>
        /// <value></value>
        public required long IdCompetitiveGroup { get; set; }
        /// <summary>
        /// Наименование заказчика
        /// </summary>
        /// <value></value>
        public required string EmployerName { get; set; }
        /// <summary>
        /// ОГРН заказчика
        /// </summary>
        /// <value></value>
        public required string EmployerOgrn { get; set; }
        /// <summary>
        /// КПП заказчика
        /// </summary>
        /// <value></value>
        public required string EmployerKpp { get; set; }
        /// <summary>
        /// ИНН заказчика
        /// </summary>
        /// <value></value>
        public required string EmployerInn { get; set; }
        /// <summary>
        /// Статус целевого договора. Идентификатор классификатора TargetContractStatusCls
        /// </summary>
        /// <value></value>
        public required int IdTargetContractStatusCls { get; set; }
        /// <summary>
        /// Комментарий к статусу
        /// </summary>
        /// <value></value>
        public required string StatusComment { get; set; } 
        /// <summary>
        /// Номер договора
        /// </summary>
        /// <value></value>
        public required string NumberContract { get; set; }
        /// <summary>
        /// Дата договора
        /// </summary>
        /// <value></value>
        public required string DateContract { get; set; }
    }
}