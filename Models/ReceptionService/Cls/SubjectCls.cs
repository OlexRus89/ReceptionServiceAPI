namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Предметы
    /// </summary>
    public class SubjectCls
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
        /// Признак предмет ЕГЭ
        /// </summary>
        public bool? Ege { get; set; }
        /// <summary>
        /// Признак предмет олимпиады
        /// </summary>
        public bool? Olympic { get; set; }
        /// <summary>
        /// Признак вид спорта
        /// </summary>
        public bool? Sport { get; set; }
        /// <summary>
        /// Признак актуальности
        /// </summary>
        public bool? Actual { get; set; }
    }
}