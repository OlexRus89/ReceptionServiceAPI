namespace CryptoCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Справочник льгот
    /// </summary>
    public class BenefitCls
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