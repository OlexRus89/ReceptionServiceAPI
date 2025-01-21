using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Расписание вступительных испытаний (сущность)
    /// </summary>
    public class EntranceTestPlaceList
    {
        [XmlElement("EntranceTestPlace", typeof(EntranceTestPlace))]
        /// <summary>
        /// Объект
        /// </summary>
        public required EntranceTestPlace[] EntranceTestPlace { get; set; }
    }

    /// <summary>
    /// Объект
    /// </summary>
    public class EntranceTestPlace
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; }
        /// <summary>
        /// Уникальный идентификатор объекта в рамках организации сгенерированный организацией
        /// </summary>
        public string? Uid { get; set; }
        /// <summary>
        /// Уникальный идентификатор приемной кампании (CampaignList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidCampaign { get; set; }
        /// <summary>
        /// Огрн организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public required string OgrnOwnerOrganization { get; set; }
        /// <summary>
        /// Кпп организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public required string KppOwnerOrganization { get; set; }
        /// <summary>
        /// Дата и время начала сдачи. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Задавать значение только по московскому времени
        /// </summary>
        public DateTime? StartTest { get; set; }
        /// <summary>
        /// Дата и время завершения сдачи. Указывать только если задается период сдачи, иначе тэг не писать. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Задавать значение только по московскому времени
        /// </summary>
        public DateTime? EndTest { get; set; }
        /// <summary>
        /// Дата и время начала записи (значения должны попадать в периоды мероприятий «Проведение ВИ вуза» или «Проведение ДВИ»). Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Задавать значение только по московскому времени
        /// </summary>
        public DateTime? StartRegistration { get; set; }
        /// <summary>
        /// Дата и время завершения записи (значения должны попадать в периоды мероприятий «Проведение ВИ вуза» или «Проведение ДВИ»). Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Задавать значение только по московскому времени
        /// </summary>
        public DateTime? EndRegistration { get; set; }
        /// <summary>
        /// Идентификатор классификатора SubjectCls
        /// </summary>
        public int? IdSubject { get; set; }
        /// <summary>
        /// Тип сдачи (true - очная, false - дистанционная)
        /// </summary>
        public bool? IsIntramural { get; set; }
        /// <summary>
        /// Место сдачи или url
        /// </summary>
        public string? TestLocation { get; set; }
        /// <summary>
        /// Максимальное кол-во поступающих, которое может записаться на эту дату
        /// </summary>
        public int? MaxCountEntrants { get; set; }
        /// <summary>
        /// Комментарий (для указания дополнительной информации, например, логин и пароль для входа на дистанционную сдачу, или, что с собой брать на сдачу или форма проведения ВИ).
        /// </summary>
        public string? Comment { get; set; }
        /// <summary>
        /// Признак «Резервная дата» (да/нет)
        /// </summary>
        public bool? ReserveDate { get; set; }
        /// <summary>
        /// Вид спорта. Уникальный идентификатор справочника вуза (DictionaryValueList) в рамках организации сгенерированный организацией. Указывать ТОЛЬКО если предмет с параметром «Выбор вида спорта» = Да
        /// </summary>
        public string? UidDictionaryValueSport { get; set; }
    }
}