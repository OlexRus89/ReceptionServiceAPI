using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Ответ от ЕЦП Работа в России по КГ
    /// </summary>
    public class RtTargetOffer
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом приема
        /// </summary>
        /// <value></value>
        public required long IdCompetitiveGroup { get; set; }
        /// <summary>
        /// Номер предложения
        /// </summary>
        /// <value></value>
        public required string TargetOfferNumber { get; set; } 
        /// <summary>
        /// Ответ от ЕЦП Работа в России. Идентификатор классификатора StatusOfferCls
        /// </summary>
        /// <value></value>
        public required int IdStatusOffer { get; set; }
        /// <summary>
        /// Комментарий (при наличии)
        /// </summary>
        /// <value></value>
        public string? StatusOfferComment { get; set; }
        /// <summary>
        /// Кол-во мест в предложении (По данным из ЕЦП Работа в России)
        /// </summary>
        /// <value></value>
        public long? NumberPlaceInOffer { get; set; }
        /// <summary>
        /// Дата и время получения ответа от ЕЦП Работа в России. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        /// <value></value>
        public required string DateTimeRequest { get; set; }
    }
}