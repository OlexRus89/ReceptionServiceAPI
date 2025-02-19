namespace CryptoCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Специальные условия поступления
    /// </summary>
    public class SpecialConditionsCls
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