namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Этапы приема
    /// </summary>
    public class StagesAdmissionCls
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