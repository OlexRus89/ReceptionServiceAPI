using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Образовательные программы
    /// </summary>
    /// <value></value>
    public class EducationalProgramList
    {
        [XmlElement("IdEducationalProgram")]
        /// <summary>
        /// Уникальный идентификатор Образовательной программы (EducationalProgramList). Все значения IdEducationalProgram в теге EducationalProgramList должны быть уникальны, иначе ошибка
        /// </summary>
        /// <value></value>
        public long[]? IdEducationalProgram { get; set; }
        [XmlElement("EducationalProgram", typeof(EducationalProgram))]
        /// <summary>
        /// Объект
        /// </summary>
        /// <value></value>
        public EducationalProgram[]? EducationalProgram { get; set; }
    }

    public class EducationalProgram
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        /// <value></value>
        public required long? IdObject { get; set; }

        /// <summary>
        /// Уникальный идентификатор EducationalProgram
        /// </summary>
        /// <value></value>
        public long? Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        /// <value></value>
        public string? Uid { get; set; }

        /// <summary>
        /// Название образовательной программы
        /// </summary>
        /// <value></value>
        public string? Name { get; set; }

        /// <summary>
        /// Признак true - образовательная программа, false - профиль
        /// </summary>
        /// <value></value>
        public bool? IsProgram { get; set; }

        /// <summary>
        /// Срок обучения, мес.
        /// </summary>
        /// <value></value>
        public int? StudyDuration { get; set; }
    }
}