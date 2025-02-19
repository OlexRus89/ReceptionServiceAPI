namespace CryptoCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Олимпиады
    /// </summary>
    public class OlympicCls
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
        /// Номер олимпиады
        /// </summary>
        public int? OrderNumber { get; set; }
        /// <summary>
        /// Год проведения олимпиады
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        public bool? Actual { get; set; }
    }
}