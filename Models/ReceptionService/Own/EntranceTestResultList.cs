using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Результаты сдачи предметов (ВИ) (сущность)
    /// </summary>
    public class EntranceTestResultList
    {
        [XmlElement("EntranceTestResult", typeof(EntranceTestResult))]
        /// <summary>
        /// Объект
        /// </summary>
        public required EntranceTestResult[] EntranceTestResult { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class EntranceTestResult
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего (EntrantList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidEntrant { get; set; }
        /// <summary>
        /// Предмет. Идентификатор классификатора SubjectCls
        /// </summary>
        public int? IdSubject { get; set; }
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
        /// <summary>
        /// Выбранный на ЕПГУ
        /// </summary>
        public bool? UsingEpgu { get; set; }
        /// <summary>
        /// Уникальный идентификатор расписания ВИ (EntranceTestPlaceList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidEntranceTestPlace { get; set; }
        /// <summary>
        /// >Язык сдачи ВИ. Идентификатор классификатора EntranceTestLanguageCls
        /// </summary>
        public int? IdEntranceTestLanguage { get; set; }
    }

    /// <summary>
    /// Единый государственный экзамен
    /// </summary>
    public class Ege
    {
        /// <summary>
        /// Результат ЕГЭ
        /// </summary>
        public required double ResultEge { get; set;}
        /// <summary>
        /// Подтверждающий результат ЕГЭ документ. Уникальный идентификатор документа поступающего (DocumentList) сгенерированный Сервисом приема
        /// </summary>
        public required string GuidDocument { get; set; }
        /// <summary>
        /// Идентификатор льготы. Идентификатор классификатора BenefitCls. Присутствует только если оценка за ЕГЭ выставлена в результате приемения особого права
        /// </summary>
        public int? IdBenefit { get; set; }
    }
}