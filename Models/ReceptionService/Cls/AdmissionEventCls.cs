namespace CryptoCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Мероприятия приема
    /// </summary>
    public class AdmissionEventCls
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