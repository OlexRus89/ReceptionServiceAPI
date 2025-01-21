namespace ReceptionServiceCore.Models.ReceptionService.Cls
{
    /// <summary>
    /// Типы справочников вуза
    /// </summary>
    public class DictionaryTypeCls
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

        public override string ToString()
        {
            return Name;
        }
    }
}