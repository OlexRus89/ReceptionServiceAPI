using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Проект платного договора/ доп.соглашения к договору (сущность)
    /// </summary>
    public class PaidContract
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        [XmlElement("Document", typeof(FileType))]
        /// <summary>
        /// Договор/доп.соглашение. Файл (pdf) закодированный в base64. Доп.соглашение можно отправить только если подписан договор
        /// </summary>
        public required FileType Document { get; set; }
        [XmlElement("Signature", typeof(FileType))]
        /// <summary>
        /// Подпись вуза. Файл (sig) закодированный в base64
        /// </summary>
        public required FileType Signature { get; set; }
    }

    /// <summary>
    /// Описание файлов
    /// </summary>
    public class FileType 
    {
        /// <summary>
        /// Тело файла закодированное в base64
        /// </summary>
        public required string Base64 { get; set; }
        /// <summary>
        /// Расширение файла без точки (НЕ mime-type). Пример jpg, pdf, zip, doc, sig...
        /// </summary>
        public required string Extension { get; set; }
        /// <summary>
        /// Наименование файла
        /// </summary>
        public required string Description { get; set; }
    }
}