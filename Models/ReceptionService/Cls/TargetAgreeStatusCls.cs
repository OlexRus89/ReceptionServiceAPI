namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Статусы заявок на целевое обучение 
    /// </summary>
    public class TargetAgreeStatusCls
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