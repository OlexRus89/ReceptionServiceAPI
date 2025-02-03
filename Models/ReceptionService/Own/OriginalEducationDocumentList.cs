using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Список оригиналов документов об образовании, поданных очно в вуз (сущность)
    /// </summary>
    public class OriginalEducationDocumentList
    {
        [XmlElement("OriginalEducationDocument", typeof(OriginalEducationDocument))]
        /// <summary>
        /// Объект
        /// </summary>
        public required OriginalEducationDocument OriginalEducationDocument { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Объект
    /// </summary>
    public class OriginalEducationDocument 
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidEntrant { get; set; }
        /// <summary>
        /// Дата и время подачи оригинала. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Задавать значение только по московскому времени
        /// </summary>
        public string? OrigDocDate { get; set; }
        /// <summary>
        /// Способ подачи оригинала. Идентификатор классификатора TransferMethodOriginalDocumentCls. Если не возвращается, значит оригинал в вуз не подан
        /// </summary>
        public int? IdTransferMethodOriginalDocument { get; set; }
        /// <summary>
        /// Сокращенное наименование организации. Если не возвращается, значит оригинал в вуз не подан
        /// </summary>
        public string? OrganizationShortName { get; set; }
        /// <summary>
        /// Дата подачи оригинала. Шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public string? TransferDate { get; set; }
    }
}