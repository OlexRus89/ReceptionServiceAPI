using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Изменения данных профиля поступающего (в т.ч. документы)
    /// </summary>
    public class PersonProfileChange
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public Guid? GuidEntrant { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        [XmlElement("ChangeList", typeof(ChangeList))]
        /// <summary>
        /// Список изменений
        /// </summary>
        public ChangeList? ChangeList { get; set; }

        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        /// <value></value>
        public required long IdEntrant { get; set; }
        /// <summary>
        /// Уникальный код поступающего (для формирования конкурсных списков и списков поступающих)
        /// </summary>
        /// <value></value>
        public required long UniqueCodeProfile { get; set; }
        /// <summary>
        /// Произошла смена уникального кода поступающего
        /// </summary>
        /// <value></value>
        public required UniqueCodeProfileChanged UniqueCodeProfileChanged { get; set; }
        /// <summary>
        /// Дата рождения поступающего (не передается если нет изменений), в формате "2022-02-02"
        /// </summary>
        /// <value></value>
        public string? Birthdate { get; set; }
        /// <summary>
        /// Место рождения поступающего (не передается если нет изменений)
        /// </summary>
        /// <value></value>
        public string? Birthplace { get; set; }
        /// <summary>
        /// Пол поступающего (не передается если нет изменений)
        /// </summary>
        /// <value></value>
        public int? IdGender { get; set; }
        /// <summary>
        /// Адрес регистрации (не передается если нет изменений)
        /// </summary>
        /// <value></value>
        public string? RegistrationAddress { get; set; }
        /// <summary>
        /// Адрес электронной почты поступающего (не передается если нет изменений)
        /// </summary>
        /// <value></value>
        public string? Email { get; set; }
        /// <summary>
        /// Номер телефона поступающего (не передается если нет изменений)
        /// </summary>
        /// <value></value>
        public string? Phone { get; set; }
        /// <summary>
        /// Уникальный идентификатор файла в Сервисе Приема (фото поступающего, заменить предыдущее фото). По этому идентификатору можно получить файл в /api/file/get
        /// </summary>
        /// <value></value>
        public string? PhotoFui { get; set; }
        /// <summary>
        /// Основания для получения бесплатного образования (для иностранца). Идентификатор классификатора FreeEducationReasonCls (не передается если нет изменений)
        /// </summary>
        /// <value></value>
        public int? IdFreeEducationReason { get; set; }
        /// <summary>
        /// Базовое образование указанное на ЕПГУ (не передается если нет изменений)
        /// </summary>
        /// <value></value>
        public BaseEducationList? BaseEducationList { get; set; }
    }

    /// <summary>
    /// Произошла смена уникального кода поступающего
    /// </summary>
    public class UniqueCodeProfileChanged
    {
        /// <summary>
        /// Новый присвоенный уникальный код поступающего (для формирования конкурсных списков и списков поступающих)
        /// </summary>
        /// <value></value>
        public required long UniqueCodeProfile { get; set; }
        /// <summary>
        /// Время смены уникального кода поступающего. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        /// <value></value>
        public required string UpdatedAt { get; set; }
        /// <summary>
        /// Список согласий поступающего
        /// </summary>
        /// <value></value>
        public ConsentList? ConsentList { get; set; }
    }

    /// <summary>
    /// Список согласий поступающего
    /// </summary>
    public class ConsentList
    {
        /// <summary>
        /// Согласие
        /// </summary>
        /// <value></value>
        public Consent[]? Consent { get; set; }
    }

    /// <summary>
    /// Согласие
    /// </summary>
    public class Consent
    {
        /// <summary>
        /// Согласие подано (TRUE) или отозвано (FALSE)
        /// </summary>
        /// <value></value>
        public required bool Agree { get; set; }
        /// <summary>
        /// Наименование вуза, в который подано согласие. Если не возвращается, значит согласие в вуз не подано
        /// </summary>
        /// <value></value>
        public string? NameOrganization { get; set; }
        /// <summary>
        /// Признак подачи в ваш вуз (TRUE - ваш вуз, FALSE - другой вуз, Отсутствие тэга - согласие не подано или отозвано)
        /// </summary>
        /// <value></value>
        public bool? IsYourOrganization { get; set; }
        /// <summary>
        /// Дата подачи/отзыва согласия. Шаблон "2006-01-02T15:04:05+03:00". Значение только по московскому времени
        /// </summary>
        /// <value></value>
        public required string AgreeDate { get; set; }
        /// <summary>
        /// Группа уровней образования. Идентификатор классификатора EducationLevelGroupCls
        /// </summary>
        /// <value></value>
        public required int IdEducationLevelGroup { get; set; }
        /// <summary>
        /// Способ подачи / отзыва согласия (TRUE - через ЕПГУ, FALSE - через ВУЗ)
        /// </summary>
        /// <value></value>
        public required bool IsOnline { get; set; }
    }

    /// <summary>
    /// Базовое образование указанное на ЕПГУ (не передается если нет изменений)
    /// </summary>
    public class BaseEducationList
    {
        /// <summary>
        /// Базовое образование. Идентификатор справочника BaseEducationCls
        /// </summary>
        /// <value></value>
        public required int[] Id { get; set; }
    }


    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: false)]
    /// <summary>
    /// Список изменений
    /// </summary>
    public class ChangeList
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        [XmlElement("Change", typeof(Change))]
        /// <summary>
        /// Изменение
        /// </summary>
        public Change[]? Change { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Изменение
    /// </summary>
    public class Change
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Тип изменяемой сущности (Entrant (Поступающий), EntrantAddress (Адрес), EntrantPhoto (Фотография поступающего))
        /// </summary>
        public required string EntityType { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        [XmlElement("EntityList", typeof(EntityList))]
        /// <summary>
        /// Список изменяемых сущностей
        /// </summary>
        public required EntityList EntityList { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Список изменяемых сущностей
    /// </summary>
    public class EntityList
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        [XmlElement("Entity", typeof(Entity))]
        /// <summary>
        /// Изменяемая сущность
        /// </summary>
        public required Entity[] Entity { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Изменяемая сущность
    /// </summary>
    public class Entity
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Идентификатор сущности (GuidEntrant - для Entrant,EntrantAddress и EntrantPhoto)
        /// </summary>
        public required Guid GuidType { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Признак актуальности. TRUE – добавлена изменена; FALSE – удалена
        /// </summary>
        public required bool Actual { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        [XmlElement("FieldList", typeof(FieldList))]
        /// <summary>
        /// Список изменяемых параметров
        /// </summary>
        public required FieldList FieldList { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Список изменяемых параметров
    /// </summary>
    public class FieldList
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        [XmlElement("Field", typeof(Field))]
        /// <summary>
        /// Изменяемый параметр
        /// </summary>
        public required Field Field { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    public class Field
    {
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Наименование параметра.
        /// Birthday (Дата рождения), Birthplace (Место рождения), Snils (СНИЛС), IdGender (Пол), Email (Электронная почта), Phone (Телефон), IdFreeEducationReason (Основание для получения бесплатного образования), IdOksmFreeEducationReason (Страна, с которой заключен договор) - для Entrant.
        /// IdRegion (Регион), FullAddress (полный адрес), City (населенный пункт) - для EntrantAddress.
        /// </summary>
        public required string Name { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Изменяемое (старое) значение (равно Field/ NewValue если это новая сущность)
        /// </summary>
        public required string OldValue { get; set; }
        [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
        /// <summary>
        /// Новое значение (равно Field/ OldValue если это новая сущность)
        /// </summary>
        public required string NewValue { get; set; }
    }
}