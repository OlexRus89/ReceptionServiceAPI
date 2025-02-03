using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Вступительные испытания (сущность)
    /// </summary>
    public class EntranceTestList
    {
        [XmlElement("EntranceTest", typeof(EntranceTest))]
        /// <summary>
        /// Объект
        /// </summary>
        public required EntranceTest[] EntranceTest { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class EntranceTest 
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required long IdObject { get; set; }
        /// <summary>
        /// Id объекта EntranceTest
        /// </summary>
        /// <value></value>
        public long? Id { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public string? Uid { get; set; }
        /// <summary>
        /// Уникальный идентификатор конкурса (CompetitionList)
        /// </summary>
        /// <value></value>
        public long? IdCompetition { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Уникальный идентификатор конкурса (CompetitionList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidCompetition { get; set; }
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
        /// Максимальный балл
        /// </summary>
        /// <value></value>
        public int? MaxScore { get; set; }
        [XmlElement("LanguageList", typeof(LanguageList))]
        /// <summary>
        /// Список языков сдачи ВИ
        /// </summary>
        public LanguageList? LanguageList { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public int? Priority { get; set; }
        /// <summary>
        /// Родительское ВИ. ВИ может ссылаться на другое ВИ другого типа (это называется соответствующее ВИ). ВИ может ссылаться на другое ВИ того же типа (это называется ООВИ с предметами по выбору). При этом приоритеты у этих ВИ (то, что ссылается, и то, на кого ссылаются) должны совпадать
        /// </summary>
        public string? UidReplaceEntranceTest { get; set; }
    }

    /// <summary>
    /// Список языков сдачи ВИ
    /// </summary>
    public class LanguageList
    {
        /// <summary>
        /// Язык сдачи ВИ. Идентификатор классификатора EntranceTestLanguageCls
        /// </summary>
        public required int[]? IdEntranceTestLanguage { get; set; } 
    }
}