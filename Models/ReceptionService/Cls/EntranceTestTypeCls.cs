namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Тип вступительного испытания
    /// </summary>
    public class EntranceTestTypeCls
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