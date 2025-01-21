namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Статус целевого договора
    /// </summary>
    public class TargetContractStatusCls
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