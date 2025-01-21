using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Получение результатов ВИ по одной КГ заявления или по всем КГ заявления (сущность)
    /// </summary>
    public class CompetitiveGroupResultList
    {
        [XmlElement("CompetitiveGroupResult", typeof(CompetitiveGroupResult))]
        /// <summary>
        /// Объект
        /// </summary>
        public required CompetitiveGroupResult[] CompetitiveGroupResult { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class CompetitiveGroupResult
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        /// <summary>
        /// Уникальный идентификатор ВИ (EntranceTestList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidEntranceTest { get; set; }
        /// <summary>
        /// Идентификатор классификатора EntranceTestTypeCls
        /// </summary>
        public int? IdEntranceTestType { get; set; }
        /// <summary>
        /// Идентификатор классификатора SubjectCls
        /// </summary>
        public int? IdSubject { get; set; }
        /// <summary>
        /// Минимальный балл
        /// </summary>
        public int? MinScore { get; set; }
        /// <summary>
        /// Приоритет ВИ
        /// </summary>
        public int? Priority { get; set; }
        /// <summary>
        /// Родительское ВИ. Уникальный идентификатор ВИ (EntranceTestList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidReplaceEntranceTest { get; set; }
        /// <summary>
        /// Выбранная дата сдачи ВИ (предмета). Уникальный идентификатор расписания ВИ (EntranceTestPlaceList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidEntranceTestPlace { get; set; }
        /// <summary>
        /// Язык сдачи ВИ. Идентификатор классификатора EntranceTestLanguageCls
        /// </summary>
        public int? IdEntranceTestLanguage { get; set; }
        [XmlElement("Ege", typeof(Ege))]
        /// <summary>
        /// Единый государственный экзамен
        /// </summary>
        public Ege? Ege { get; set; }
        /// <summary>
        /// Результат ВВИ (до трех знаков после запятой)
        /// </summary>
        public double? ResultVvi { get; set; }
        /// <summary>
        /// Вид спорта. Уникальный идентификатор справочника вуза (DictionaryValueList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidDictionaryValueSport { get; set; }
    }
}