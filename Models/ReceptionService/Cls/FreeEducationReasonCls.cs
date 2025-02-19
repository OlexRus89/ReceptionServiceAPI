namespace CryptoCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Основания для получения бесплатного образования (для иностранца)
    /// </summary>
    public class FreeEducationReasonCls
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