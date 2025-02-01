using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Данные из ЕПГУ для формирования договора
    /// </summary>
    public class EpguPaidContractData
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления, сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        [XmlElement("SideA", typeof(Side))]
        /// <summary>
        /// Данные стороны А платного договора
        /// </summary>
        public required Side SideA { get; set; }
        [XmlElement("SideB", typeof(Side))]
        /// <summary>
        /// Данные стороны B платного договора
        /// </summary>
        public Side? SideB { get; set; }
        [XmlElement("SideC", typeof(Side))]
        /// <summary>
        /// Данные стороны B платного договора
        /// </summary>
        public Side? SideC { get; set; }
        [XmlElement("Payment", typeof(Payment))]
        /// <summary>
        /// Данные оплаты
        /// </summary>
        public Payment? Payment { get; set; }
        /// <summary>
        /// Нужна ли скидка?
        /// Примечание: работает эта схема после поступления, то есть абитуриент идет в студофис и решает там проблемы
        /// </summary>
        public required bool Discount { get; set; }
    }

    /// <summary>
    /// Данные стороны платного договора
    /// </summary>
    /// <value></value>
    public class Side
    {
        /// <summary>
        /// Является плательщиком
        /// </summary>
        public required bool Payer { get; set; }
        [XmlElement("IndividualSide", typeof(IndividualSideType))]
        /// <summary>
        /// Данные физ.лица
        /// </summary>
        public IndividualSideType? IndividualSide { get; set; }
        [XmlElement("EntitySide", typeof(EntitySideType))]
        /// <summary>
        /// Данные юр.лица
        /// </summary>
        public EntitySideType? EntitySide { get; set; }
        public string[]? Fui { get; set; }
    }

    /// <summary>
    /// Данные физического лица
    /// </summary>
    public class IndividualSideType
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public required string Surname { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }
        /// <summary>
        /// Тип документа, удостоверяющего личность. Идентификатор классификатора DocumentTypeCls
        /// </summary>
        public required int IdDocumentType { get; set; }
        /// <summary>
        /// Серия ДУЛ
        /// </summary>
        public string? DocSeries { get; set; }
        /// <summary>
        /// Номер ДУЛ
        /// </summary>
        public required string DocNumber { get; set; }
        /// <summary>
        /// Огранизация, выдавшая документ
        /// </summary>
        public required string DocOrganization { get; set; }
        /// <summary>
        /// Код подразделения
        /// </summary>
        public string? SubdivisionCode { get; set; }
        /// <summary>
        /// Дата выдачи. Шаблон "2006-01-02"
        /// </summary>
        public string? IssueDate { get; set; }
        /// <summary>
        /// Дата рождения. Шаблон "2006-01-02"
        /// </summary>
        public required string Birthdate { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public required string Birthplace { get; set; }
        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public required string RegistrationAddress { get; set; }
        /// <summary>
        /// СНИЛС
        /// </summary>
        public string? Snils { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string[]? Phone { get; set; }
        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Код ответа.
        ///     1 - Сам абитуриент.
        ///     2 - Родитель.
        ///     3 - Близкий родственник (не родитель).
        ///     4 - Усыновитель.
        ///     5 - Опекун или попечитель.
        ///     6 - Другой человек.
        /// </summary>
        public required int RelationShip { get; set; }
    }

    /// <summary>
    /// Данные юридического лица
    /// </summary>
    public class EntitySideType
    {
        /// <summary>
        /// Наименование организации
        /// </summary>
        public required string IssueOrganizationName { get; set; }
        /// <summary>
        /// КПП
        /// </summary>
        public string? Kpp { get; set; }
        /// <summary>
        /// ИНН
        /// </summary>
        public string? Inn { get; set; }
        /// <summary>
        /// ОГРН
        /// </summary>
        public string? Ogrn { get; set; }
        /// <summary>
        /// БИК
        /// </summary>
        public string? Bik { get; set; }
        /// <summary>
        /// р/счет
        /// </summary>
        public string? Rs { get; set; }
        /// <summary>
        /// к/счет
        /// </summary>
        public string? Ks { get; set; }
        /// <summary>
        /// Адрес организации
        /// </summary>
        public required string RegistrationAddress { get; set; }
        /// <summary>
        /// Номер телефона организации
        /// </summary>
        public string[]? Phone { get; set; }
        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Фамилия должностного лица
        /// </summary>
        public required string Surname { get; set; }
        /// <summary>
        /// Имя должностного лица
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Отчество должностного лица
        /// </summary>
        public string? Patronymic { get; set; }
        /// <summary>
        /// Должность должностного лица
        /// </summary>
        public string? Post { get; set; }
        /// <summary>
        /// Наименование банка
        /// </summary>
        public string? BankName { get; set; }
    }

    /// <summary>
    /// Данные оплаты
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Код ответа.
        /// 1 - Собственные средства.
        /// 2 - Образовательный кредит.
        /// 3 - Материнский капитал.
        /// </summary>
        public required int PaymentMethod { get; set; }
        /// <summary>
        /// Фамилия владельца сертификата маткапитала
        /// </summary>
        public string? Surname { get; set; }
        /// <summary>
        /// Имя владельца сертификата маткапитала
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Отчество владельца сертификата маткапитала
        /// </summary>
        public string? Patronymic { get; set; }
        /// <summary>
        /// Серия сертификата маткапитала
        /// </summary>
        public string? DocSeries { get; set; }
        /// <summary>
        /// Номер сертификата маткапитала
        /// </summary>
        public string? DocNumber { get; set; }
        /// <summary>
        /// Организация, выдавшая сертификат маткапитала
        /// </summary>
        public string? DocOrganization { get; set; }
        /// <summary>
        /// Дата выдачи сертификата маткапитала. Шаблон "2006-01-02"
        /// </summary>
        public string? IssueDate { get; set; }
    }
}