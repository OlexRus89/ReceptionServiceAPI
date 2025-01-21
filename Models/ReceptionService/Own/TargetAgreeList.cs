using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Сведения о наличии заявки на платформе 'Работа в России' (сущность)
    /// </summary>
    public class TargetAgreeList
    {
        [XmlElement("TargetAgree", typeof(TargetAgree))]
        /// <summary>
        /// Объект
        /// </summary>
        public required TargetAgree[] TargetAgree { get; set; }
    }

    public class TargetAgree 
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Огрн организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public string? OgrnOwnerOrganization { get; set; }
        /// <summary>
        /// Кпп организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public string? KppOwnerOrganization { get; set; }
        /// <summary>
        /// Уникальный идентификатор КГ заявления (CompetitiveGroupList) сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidCompetitiveGroup { get; set; }
        [XmlElement("StatusList", typeof(StatusList))]
        /// <summary>
        /// Список статусов заявок
        /// </summary>
        public StatusList? StatusList { get; set; }
    }

    /// <summary>
    /// Список статусов заявок
    /// </summary>
    public class StatusList 
    {
        [XmlElement("Status", typeof(Status))]
        /// <summary>
        /// Cтатус заявки
        /// </summary>
        public required Status[] Status { get; set; }
    }

    /// <summary>
    /// Cтатус заявки
    /// </summary>
    public class Status 
    {
        /// <summary>
        /// Статус заявки на целевое обучение. Идентификатор классификатора TargetAgreeStatusCls
        /// </summary>
        public required int IdTargetAgreeStatus { get; set; }
        /// <summary>
        /// Признак создания вузом (true - создано вузом, false - поступило из платформы "Работа в России")
        /// </summary>
        public required bool IsOovo { get; set; }
        /// <summary>
        /// Дата и время создания сведения. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public required DateTime CreatedDateTime { get; set; }
    }
}