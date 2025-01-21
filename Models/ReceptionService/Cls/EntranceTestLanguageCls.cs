namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Языки сдачи ВИ 
    /// </summary>
    public class EntranceTestLanguageCls
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