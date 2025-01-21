namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Виды целевых договоров
    /// </summary>
    public class TargetDocumentTypeCls
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