using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Identity.Client;
using CryptoCore.Models.ReceptionService.Despatch;

namespace CryptoCore.Models.ReceptionService.Own
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Список заявлений поступающего (сущность)
    /// </summary>
    public class ApplicationList
    {
        [XmlElement("Application", typeof(Application))]
        /// <summary>
        /// Объект
        /// </summary>
        public required Application[] Application { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Объект
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Уникальный идентификатор объекта в рамках данного токена
        /// </summary>
        public required int IdObject { get; set; } 
        /// <summary>
        /// >Уникальный идентификатор сгенерированный Сервисом приема
        /// </summary>
        public Guid? Guid { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidEntrant { get; set; }
        /// <summary>
        /// СНИЛС
        /// </summary>
        public string? Snils { get; set; }
        /// <summary>
        /// Признак создавался ли профиль поступающего одновременно с заявлением. Если вернулся FALSE, тогда возможно в профиле есть документы их можно запросить
        /// </summary>
        public bool? EntrantCreated { get; set; }
        /// <summary>
        /// Огрн организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public string? OgrnOwnerOrganization { get; set; }
        /// <summary>
        /// Кпп организации за которую заполняются данные (организация должна быть либо филиалом либо головной организацией с вашей организацией)
        /// </summary>
        public string? KppOwnerOrganization { get; set; }
        [XmlElement("EntrantChoice", typeof(EntrantChoice))]
        /// <summary>
        /// Информация поступающегося
        /// </summary>
        public EntrantChoice? EntrantChoice { get; set; }
        /// <summary>
        /// Дата регистрации. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Задавать значение только по московскому времени
        /// </summary>
        public string? RegistrationDate { get; set; }
        /// <summary>
        /// Нет высшего образования
        /// </summary>
        public bool? FirstHigherEducation { get; set; }
        /// <summary>
        /// Признак необходимости общежития
        /// </summary>
        public bool? NeedHostel { get; set; }
        /// <summary>
        /// Поступающий разрешил передавать данные на ЕПГУ
        /// </summary>
        public bool? AllowedForEpgu { get; set; }
        /// <summary>
        /// Этап приема. Идентификатор классификатора StagesAdmissionCls
        /// </summary>
        public int? IdStageAdmission { get; set; }
        /// <summary>
        /// Признак бюджет/платное
        /// </summary>
        public bool? IsBudget { get; set; }
        /// <summary>
        /// Музыкальный инструмент. Уникальный идентификатор справочника вуза (DictionaryValueList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidDictionaryValueMusic { get; set; }
        /// <summary>
        /// Признак участия путем сдачи ВИ
        /// </summary>
        public bool? ExtraTestAttribute { get; set; }
        [XmlElement("AddCompetitiveGroupList", typeof(AddCompetitiveGroupList))]
        /// <summary>
        /// Создать вместе с заявлением конкурсные группы (минимум одну)
        /// </summary>
        public AddCompetitiveGroupList? AddCompetitiveGroupList { get; set; }
        [XmlElement("CompetitiveGroupList", typeof(CompetitiveGroupList))]
        /// <summary>
        /// Конкурсная группа (сущность)
        /// </summary>
        public CompetitiveGroupList? CompetitiveGroupList { get; set; }
        [XmlElement("SpecialConditionList", typeof(SpecialConditionList))]
        /// <summary>
        /// Список специальных условий сдачи ВИ
        /// </summary>
        public SpecialConditionList? SpecialConditionList { get; set; }
        [XmlElement("Identification", typeof(Identification))]
        /// <summary>
        /// Данные ДУЛ. Присутствуют в ответе только если было создание профиля поступающего вместе с заявлением
        /// </summary>
        public Identification? Identification { get; set; }
        /// <summary>
        /// Признак актуальности заявления. Если заявление будет отозвано - будет False
        /// </summary>
        public bool? Actual { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Информация поступающегося
    /// </summary>
    public class EntrantChoice
    {
        /// <summary>
        /// Использовать существующий профиль поступающего. Уникальный идентификатор сгенерированный Сервисом приема
        /// </summary>
        public Guid? Guid { get; set; }
        [XmlElement("AddEntrant", typeof(AddEntrant))]
        /// <summary>
        /// Создать новый профиль поступающего, т.к. нет такого
        /// </summary>
        public AddEntrant? AddEntrant { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Добавления нового абитуриента
    /// </summary>
    public class AddEntrant
    {
        [XmlElement("Identification", typeof(Identification))]
        /// <summary>
        /// Документ удостоверяющий личность. ФИО, указанные в нем, будут считаться ФИО поступающего. ДУЛ будет считаться подтвержденным вузом
        /// </summary>
        public required Identification Identification { get; set; }
        /// <summary>
        /// СНИЛС - обязательный для граждан РФ
        /// </summary>
        public string? Snils { get; set; }
        /// <summary>
        /// Идентификатор классификатора GenderCls
        /// </summary>
        public required int IdGender { get; set; }
        /// <summary>
        /// Дата рождения. Шаблон "2006-01-02"
        /// </summary>
        public required string Birthday { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public required string Birthplace { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string? Phone { get; set; } 
        /// <summary>
        /// Электронный адрес
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Гражданство - Идентификатор классификатора OksmCls
        /// </summary>
        public required int IdOksm { get; set; }
        [XmlElement("FreeEducationReason", typeof(FreeEducationReason))]
        /// <summary>
        /// Основания для получения бесплатного образования (для иностранца).
        /// </summary>
        public FreeEducationReason? FreeEducationReason { get; set; }
        [XmlElement("AddressList", typeof(AddressList))]
        /// <summary>
        /// Список адресов абирутиента
        /// </summary>
        public AddressList? AddressList { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Документ удостоверяющий личность. ФИО, указанные в нем, будут считаться ФИО поступающего. ДУЛ будет считаться подтвержденным вузом
    /// </summary>
    public class Identification
    {
        /// <summary>
        /// Уникальный идентификатор ДУЛ сгенерированный Сервисом приема
        /// </summary>
        public Guid? Guid { get; set; }
        /// <summary>
        /// Тип документа. Идентификатор классификатора DocumentTypeCls
        /// </summary>
        public required int IdDocumentType { get; set; }
        /// <summary>
        /// Наименование документа
        /// </summary>
        public required string DocName { get; set; }
        /// <summary>
        /// Серия ДУЛ
        /// </summary>
        public string? DocSeries { get; set; }
        /// <summary>
        /// Номер ДУЛ
        /// </summary>
        public required string DocNumber { get; set; }
        /// <summary>
        /// Дата выдачи. Шаблон "2006-01-02"
        /// </summary>
        public required string IssueDate { get; set; }  
        /// <summary>
        /// Огранизация, выдавшая документ
        /// </summary>
        public required string DocOrganization { get; set; }
        /// <summary>
        /// Реквизиты, в зависимости от типа документа
        /// </summary>
        public Fields? Fields { get; set; }
        /// <summary>
        /// Время создания документа. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        public string? CreatedDateTime { get; set; } 
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Создать вместе с заявлением конкурсные группы (минимум одну)
    /// </summary>
    public class AddCompetitiveGroupList
    {
        [XmlElement("AddCompetitiveGroup", typeof(AddCompetitiveGroup))]
        /// <summary>
        /// Добавить конкурсную группу в заявление
        /// </summary>
        public required AddCompetitiveGroup[] AddCompetitiveGroup { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Добавить конкурсную группу в заявление
    /// </summary>
    public class AddCompetitiveGroup 
    {
        /// <summary>
        /// Уникальный идентификатор конкурса (CompetitionList) в рамках организации сгенерированный организацией
        /// </summary>
        public required string UidCompetition { get; set; }
        /// <summary>
        /// Уникальный идентификатор целевой организации (TargetOrganizationList) в рамках организации сгенерированный организацией
        /// </summary>
        public string? UidTargetOrganization { get; set; }
        /// <summary>
        /// Статус КГ заявления. Идентификатор классификатора CompetitiveGroupStatusCls
        /// </summary>
        public required int IdStatus { get; set; }
        /// <summary>
        /// Приоритет КГ заявления
        /// </summary>
        public required Priority Priority { get; set; }
        [XmlElement("DictionaryValueSportList", typeof(DictionaryValueSportList))]
        /// <summary>
        /// Указать список видов спорта
        /// </summary>
        public DictionaryValueSportList? DictionaryValueSportList { get; set; }
    }
}