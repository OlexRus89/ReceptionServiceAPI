namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Связь олимпиад и профилей олимпиад
    /// </summary>
    public class OlympicRelationProfileCls
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Идентификатор олимпиады
        /// </summary>
        public int? IdOlympic { get; set; }
        /// <summary>
        /// Идентификатор профиля олимпиады
        /// </summary>
        public int? IdProfile { get; set; }
        /// <summary>
        /// Идентификатор уровня олимпиады
        /// </summary>
        public int? IdLevel { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        public bool? Actual { get; set; }
    }
}