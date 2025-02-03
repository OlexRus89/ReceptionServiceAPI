using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.ReceptionService
{
    /// <summary>
    /// Фото
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Хэш файла по которому можно узнать не менялось ли содержимое
        /// </summary>
        public string? FileHash { get; set; }
        /// <summary>
        /// Уникальный идентификатор файла в Сервисе Приема. По этому идентификатору можно получить файл в /api/file/get
        /// </summary>
        public string? Fui { get; set; }
    }
}