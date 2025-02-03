using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService
{
    /// <summary>
    /// Указать список видов спорта
    /// </summary>
    public class DictionaryValueSportList
    {
        /// <summary>
        /// Вид спорта. Уникальный идентификатор справочника вуза (DictionaryValueList) в рамках организации сгенерированный организацией
        /// </summary>
        public string[]? UidDictionaryValueSport { get; set; }
    }
}