namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Способ передачи оригиналов документов
    /// </summary>
    public class TransferMethodOriginalDocumentCls
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