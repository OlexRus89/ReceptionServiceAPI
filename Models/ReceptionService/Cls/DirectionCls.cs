namespace CryptoCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Общероссийский классификатор специальностей по образованию
    /// </summary>
    public class DirectionCls
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        /// <value></value>
        public int? Id { get; set; }
        /// <summary>
        /// Идентификатор верхнего уровня
        /// </summary>
        public int? IdParent { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        /// <value></value>
        public bool? Actual { get; set; }
        /// <summary>
        /// Раздел
        /// </summary>
        /// <value></value>
        public int? Section { get; set; }
        /// <summary>
        /// Уровень образования. Идентификатор классификатора EducationLevelCls
        /// </summary>
        /// <value></value>
        public int? IdEducationLevel { get; set; }
    }
}