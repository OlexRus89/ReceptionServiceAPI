namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Категории индивидуальных достижений
    /// </summary>
    public class AchievementCategoryCls
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