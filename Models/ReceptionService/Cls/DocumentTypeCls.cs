namespace CryptoCore.Models.ReceptionService.Cls
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Типы документов
    /// </summary>
    public class DocumentTypeCls
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Категория документа (классификатор DocumentCategoryCls)
        /// </summary>
        public int? IdCategory { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Реквизиты из расширенного списка в формате json (см. пункт "Документы поступающего. Общее описание" Инструкции API)
        /// </summary>
        public string? FieldsDescription { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        public bool? Actual { get; set; }
    }
}