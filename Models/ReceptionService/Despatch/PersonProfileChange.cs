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
        /// <summary>
        /// Уникальный идентификатор профиля поступающего сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidEntrant { get; set; }
        [XmlElement("ChangeList", typeof(ChangeList))]
        /// <summary>
        /// Список изменений
        /// </summary>
        public required ChangeList ChangeList { get; set; }
    }

    /// <summary>
    /// Список изменений
    /// </summary>
    public class ChangeList
    {
        [XmlElement("Change", typeof(Change))]
        /// <summary>
        /// Изменение
        /// </summary>
        public required Change[] Change { get; set; }
    }

    /// <summary>
    /// Изменение
    /// </summary>
    public class Change
    {
        /// <summary>
        /// Тип изменяемой сущности (Entrant (Поступающий), EntrantAddress (Адрес), EntrantPhoto (Фотография поступающего))
        /// </summary>
        public required string EntityType { get; set; }
        [XmlElement("EntityList", typeof(EntityList))]
        /// <summary>
        /// Список изменяемых сущностей
        /// </summary>
        public required EntityList EntityList { get; set; }
    }

    /// <summary>
    /// Список изменяемых сущностей
    /// </summary>
    public class EntityList
    {
        [XmlElement("Entity", typeof(Entity))]
        /// <summary>
        /// Изменяемая сущность
        /// </summary>
        public required Entity[] Entity { get; set; }
    }

    /// <summary>
    /// Изменяемая сущность
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Идентификатор сущности (GuidEntrant - для Entrant,EntrantAddress и EntrantPhoto)
        /// </summary>
        public required Guid GuidType { get; set; }
        /// <summary>
        /// Признак актуальности. TRUE – добавлена изменена; FALSE – удалена
        /// </summary>
        public required bool Actual { get; set; }
        [XmlElement("FieldList", typeof(FieldList))]
        /// <summary>
        /// Список изменяемых параметров
        /// </summary>
        public required FieldList FieldList { get; set; }
    }

    /// <summary>
    /// Список изменяемых параметров
    /// </summary>
    public class FieldList
    {
        [XmlElement("Field", typeof(Field))]
        /// <summary>
        /// Изменяемый параметр
        /// </summary>
        public required Field Field { get; set; }
    }

    public class Field
    {
        /// <summary>
        /// Наименование параметра.
        /// Birthday (Дата рождения), Birthplace (Место рождения), Snils (СНИЛС), IdGender (Пол), Email (Электронная почта), Phone (Телефон), IdFreeEducationReason (Основание для получения бесплатного образования), IdOksmFreeEducationReason (Страна, с которой заключен договор) - для Entrant.
        /// IdRegion (Регион), FullAddress (полный адрес), City (населенный пункт) - для EntrantAddress.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Изменяемое (старое) значение (равно Field/ NewValue если это новая сущность)
        /// </summary>
        public required string OldValue { get; set; }
        /// <summary>
        /// Новое значение (равно Field/ OldValue если это новая сущность)
        /// </summary>
        public required string NewValue { get; set; }
    }
}