namespace CryptoCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Уровни образования
    /// </summary>
    public class EducationLevelCls
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
        /// Группа уровня образования. Идентификатор классификатора EducationLevelGroupCls
        /// </summary>
        public int? IdEducationLevelGroup { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        public bool? Actual { get; set; }
    }
}