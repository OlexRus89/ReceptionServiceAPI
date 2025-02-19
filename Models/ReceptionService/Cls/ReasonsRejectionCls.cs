namespace CryptoCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Причины отказа
    /// </summary>
    public class ReasonsRejectionCls
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