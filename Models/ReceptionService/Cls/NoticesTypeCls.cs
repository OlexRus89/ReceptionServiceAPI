namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Типы уведомлений
    /// </summary>
    public class NoticesTypeCls
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Статус, в котором должна быть хотя бы одна КГ поступающего, чтобы отправить уведомление
        /// </summary>
        public int? IdStatus { get; set; }
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