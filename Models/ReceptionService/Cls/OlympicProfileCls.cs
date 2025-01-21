namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Профили олимпиад
    /// </summary>
    public class OlympicProfileCls
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        /// <value></value>
        public int? Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        /// <value></value>
        public string? Name { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        /// <value></value>
        public bool? Actual { get; set; }
    }
}