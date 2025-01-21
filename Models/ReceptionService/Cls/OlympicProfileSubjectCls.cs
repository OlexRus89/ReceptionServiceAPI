namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Соответствие профилей олимпиад предметам
    /// </summary>
    public class OlympicProfileSubjectCls
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Идентификатор предмета
        /// </summary>
        public int? IdSubject { get; set; }
        /// <summary>
        /// Идентификатор профиля
        /// </summary>
        public int? IdOlympicRelationProfile { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        public bool? Actual { get; set; }
    }
}