namespace CryptoCore.Models.ReceptionService.Cls
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
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