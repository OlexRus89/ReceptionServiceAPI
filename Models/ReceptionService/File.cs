using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService
{
    [Serializable]
    [XmlRoot("File")]
    /// <summary>
    /// Имеющие файлы, отправляются по FUI
    /// </summary>
    public class File
    {
        /// <summary>
        /// Хэш файла по которому можно узнать не менялось ли содержимое
        /// </summary>
        public string? FileHash { get; set; }
        /// <summary>
        /// Уникальный идентификатор файла в Сервисе Приема. По этому идентификатору можно получить файл в /api/file/get
        /// </summary>
        public string? Fui { get; set; }
        /// <summary>
        /// Наименование файла
        /// </summary>
        public string? Description { get; set; }
    }
}