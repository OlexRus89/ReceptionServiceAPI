using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Получение информации о наличии документов о высшем образовании в ФРДО (сущность)
    /// </summary>
    public class AvailabilityHigherEducationFrdoList
    {
        [XmlElement("AvailabilityHigherEducationFrdo", typeof(AvailabilityHigherEducationFrdo))]
        /// <summary>
        /// Объект
        /// </summary>
        public required AvailabilityHigherEducationFrdo[] AvailabilityHigherEducationFrdo { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class AvailabilityHigherEducationFrdo
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема. Проверка осуществляется только если у поступающего в профиле есть СНИЛС
        /// </summary>
        public required Guid GuidEntrant { get; set; }
        /// <summary>
        /// Присутствует ли документ в ФРДО
        /// </summary>
        public bool? IsExist { get; set; } 
    }
}