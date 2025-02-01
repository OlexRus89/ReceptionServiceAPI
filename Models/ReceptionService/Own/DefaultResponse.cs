using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ReceptionServiceCore.Extensions;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    [Serializable]
    [XmlRoot("PackageData"), XmlType("PackageData")]
    public class DefaultResponse
    {
        /// <summary>
        /// Уникальный идентификатор запроса на обработку данных (токена)
        /// </summary>
        public required int IdJwt { get; set; }
        /// <summary>
        /// Имя сущности и действие над сущностью сконкатенированное через '_'. Например "Campaign_Add"
        /// </summary>
        public required string EntityAction { get; set; }
        /// <summary>
        /// Наименование стадии обработки на которой завершилось выполнение токена
        /// </summary>
        public required string Stage { get; set; }
        [XmlElement("ActualList", typeof(ActualList))]
        /// <summary>
        /// Актуальный список
        /// </summary>
        public ActualList? ActualList { get; set; }
        [XmlElement("NotActualList", typeof(NotActualList))]
        /// <summary>
        /// Отозванные на ЕПГУ заявления
        /// </summary>
        public NotActualList? NotActualList { get; set; }
        public ErrorList? ErrorList { get; set; }
    }

    [Serializable]
    [XmlRoot("PackageData"), XmlType("PackageData")]
    public class DefaultResponse<T>
    {
        /// <summary>
        /// Уникальный идентификатор запроса на обработку данных (токена)
        /// </summary>
        public required int IdJwt { get; set; }
        /// <summary>
        /// Имя сущности и действие над сущностью сконкатенированное через '_'. Например "Campaign_Add"
        /// </summary>
        public required string EntityAction { get; set; }
        /// <summary>
        /// Наименование стадии обработки на которой завершилось выполнение токена
        /// </summary>
        public required string Stage { get; set; }
        [XmlElement("ActualList", typeof(ActualList))]
        /// <summary>
        /// Актуальный список
        /// </summary>
        public ActualList? ActualList { get; set; }
        [XmlElement("NotActualList", typeof(NotActualList))]
        /// <summary>
        /// Отозванные на ЕПГУ заявления
        /// </summary>
        public NotActualList? NotActualList { get; set; }
        [XmlElement("SuccessResultList")]
        /// <summary>
        /// Результат выполнения по модулям
        /// </summary>
        public SuccessResultList<T>? SuccessResultList { get; set; }
        [XmlElement("ErrorList", typeof(ErrorList))]
        public ErrorList? ErrorList { get; set; }
    }

    /// <summary>
    /// Актуальный список
    /// </summary>
    public class ActualList 
    {
        [XmlElement("CompetitiveGroup", typeof(CompetitiveGroup))]
        public required CompetitiveGroup[] CompetitiveGroup { get; set; }
    }

    /// <summary>
    /// Отозванные на ЕПГУ заявления
    /// </summary>
    public class NotActualList
    {
        /// <summary>
        /// Уникальный идентификатор заявления сгенерированный Сервисом приема
        /// </summary>
        public required Guid[] GuidApplication { get; set; }
    }

    public class SuccessResultList<T>
    {
        [XmlElement("ValueData")]
        public required T ValueData { get; set; }
    }

    public class Success
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена. То есть если в токене было создание трех приемных кампаний, они должны быть промаркированы уникальными числами, по каждому объекту вернется либо Success либо Error
        /// </summary>
        public int IdObject { get; set; }
        [XmlElement("Params", typeof(Params))]
        /// <summary>
        /// Нестандартизированный параметр который раскрывает детали обработки
        /// </summary>
        public Params? Params { get; set; }
    }

    public class ErrorList
    {
        [XmlElement("Error", typeof(Error))]
        /// <summary>
        /// Показ ошибок
        /// </summary>
        public required Error[] Error { get; set; }
    }

    public class Error 
    {
        /// <summary>
        /// Уникальный код ошибки. Полный список кодов ошибок и их расшифровок смотрите в документации
        /// </summary>
        public required int Code { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена.
        /// Например, если в токене было передано три объекта, то каждому из них должен быть присвоен
        /// уникальный номер (IdObject), и тогда по каждому объекту вернется либо Success либо Error.
        /// При этом ответ по каждой отдельной сущности вернется только в случае успешно пройденной основной валидации
        /// </summary>
        public int? IdObject { get; set; }
        /// <summary>
        /// Описание кода ошибки
        /// </summary>
        public required string Description { get; set; } 
        [XmlElement("Params", typeof(Params))]
        /// <summary>
        /// Нестандартизированный параметр который раскрывает детали обработки
        /// </summary>
        public Params? Params { get; set; }
        /// <summary>
        /// Время формирования ответа
        /// </summary>
        public required string Time { get; set; }
    }

    public class Params
    {
        [XmlElement("Param", typeof(Param))]
        public required Param[] Param { get; set; }
    }

    /// <summary>
    /// Нестандартизированный параметр который раскрывает детали обработки
    /// </summary>
    public class Param
    {
        /// <summary>
        /// Ключ
        /// </summary>
        public required string Key { get; set; }
        /// <summary>
        /// Данные
        /// </summary>
        public required string Value { get; set; }
    }
}