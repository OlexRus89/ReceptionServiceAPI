namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Уровни олимпиад
    /// </summary>
    public class OlympicLevelCls
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        public bool? Actual { get; set; }
    }
}