using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Индивидуальные достижения в рамках КГ заявлений (сущность)
    /// </summary>
    public class CompetitiveGroupAchievementList
    {
        [XmlElement("CompetitiveGroupAchievement", typeof(CompetitiveGroupAchievement))]
        /// <summary>
        /// Объект. Уникально идентифицируется полями GuidCompetitiveGroup + GuidDocument
        /// </summary>
        public required CompetitiveGroupAchievement[] CompetitiveGroupAchievement { get; set; }
    }
    
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Объект. Уникально идентифицируется полями GuidCompetitiveGroup + GuidDocument
    /// </summary>
    public class CompetitiveGroupAchievement
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
        /// Уникальный идентификатор документа (DocumentList) сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidDocument { get; set; }
        /// <summary>
        /// Категория индивидуального достижения. Идентификатор классификатора AchievementCategoryCls
        /// </summary>
        public int? IdAchievementCategory { get; set; }
        /// <summary>
        /// Балл
        /// </summary>
        public double? Mark { get; set; }
        [XmlElement("Document", typeof(Document))]
        /// <summary>
        /// Информация о документе подтверждающего индивидуальное достижение
        /// </summary>
        public Document? Document { get; set; }
    }
}