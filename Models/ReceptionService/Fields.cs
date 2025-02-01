using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models.ReceptionService
{
    /// <summary>
    /// Реквизиты, в зависимости от типа документа
    /// </summary>
    public class Fields
    {
        /// <summary>
        /// Идентификатор олимпиады
        /// <summary>
        public int? IdOlympic { get; set; }

        /// <summary>
        /// Идентификатор типа диплома олимпиады
        /// <summary>
        public int? IdOlympicDiplomaTypes { get; set; }

        /// <summary>
        /// Идентификатор профиля олимпиады
        /// <summary>
        public int? IdOlympicsProfiles { get; set; }

        /// <summary>
        /// Идентификатор предмета
        /// <summary>
        public int? IdSubject { get; set; }

        /// <summary>
        /// Общее количество мероприятий
        /// <summary>
        public int? TotalNumberEvents { get; set; }

        /// <summary>
        /// Общее количество часов
        /// <summary>
        public int? TotalHours { get; set; }

        /// <summary>
        /// Общее количество верифицированных часов
        /// <summary>
        public int? TotalVerifiedHours { get; set; }

        /// <summary>
        /// Год окончания
        /// <summary>
        public int? Year { get; set; }

        /// <summary>
        /// Страна выдачи
        /// <summary>
        public int? IdOksm { get; set; }

        /// <summary>
        /// Год присвоения знака
        /// <summary>
        public int? GTOPassYear { get; set; }

        /// <summary>
        /// Регион
        /// <summary>
        public int? IdRegion { get; set; }

        /// <summary>
        /// Балл по предмету
        /// <summary>
        public int? Mark { get; set; }

        /// <summary>
        /// Список мероприятий
        /// <summary>
        public ListEventsList[]? ListEvents { get; set; }

        /// <summary>
        /// Регистрационный номер
        /// <summary>
        public string? RegisterNumber { get; set; }

        /// <summary>
        /// Код специальности
        /// <summary>
        public string? OksoCode1 { get; set; }

        /// <summary>
        /// Наименование укрупненной группы специальностей
        /// <summary>
        public string? SpecialtyGroupName1 { get; set; }

        /// <summary>
        /// Наименование специальности
        /// <summary>
        public string? SpecialtyName1 { get; set; }

        /// <summary>
        /// Наименование области профессиональной деятельности
        /// <summary>
        public string? ProfessionalArea1 { get; set; }

        /// <summary>
        /// Наименование вида профессиональной деятельности
        /// <summary>
        public string? ProfessionalType1 { get; set; }

        /// <summary>
        /// Наименование квалификации
        /// <summary>
        public string? QualificationName1 { get; set; }

        /// <summary>
        /// Код специальности(в случае наличия второй специальности)
        /// <summary>
        public string? OksoCode2 { get; set; }

        /// <summary>
        /// Наименование укрупненной группы специальностей(в случае наличия второй специальности)
        /// <summary>
        public string? SpecialtyGroupName2 { get; set; }

        /// <summary>
        /// Наименование специальности(в случае наличия второй специальности)
        /// <summary>
        public string? SpecialtyName2 { get; set; }

        /// <summary>
        /// Наименование области профессиональной деятельности(в случае наличия второй специальности)
        /// <summary>
        public string? ProfessionalArea2 { get; set; }

        /// <summary>
        /// Наименование вида профессиональной деятельности(в случае наличия второй специальности)
        /// <summary>
        public string? ProfessionalType2 { get; set; }

        /// <summary>
        /// Наименование квалификации(в случае наличия второй специальности)
        /// <summary>
        public string? QualificationName2 { get; set; }

        /// <summary>
        /// Код специальности(в случае наличия третьей специальности)
        /// <summary>
        public string? OksoCode3 { get; set; }

        /// <summary>
        /// Наименование укрупненной группы специальностей(в случае наличия третьей специальности)
        /// <summary>
        public string? SpecialtyGroupName3 { get; set; }

        /// <summary>
        /// Наименование специальности(в случае наличия третьей специальности)
        /// <summary>
        public string? SpecialtyName3 { get; set; }

        /// <summary>
        /// Наименование области профессиональной деятельности(в случае наличия третьей специальности)
        /// <summary>
        public string? ProfessionalArea3 { get; set; }

        /// <summary>
        /// Наименование вида профессиональной деятельности(в случае наличия третьей специальности)
        /// <summary>
        public string? ProfessionalType3 { get; set; }

        /// <summary>
        /// Наименование квалификации(в случае наличия третьей специальности)
        /// <summary>
        public string? QualificationName3 { get; set; }

        /// <summary>
        /// Группа инвалидности
        /// <summary>
        public string? DisabilityType { get; set; }

        /// <summary>
        /// Причина инвалидности
        /// <summary>
        public string? Reason { get; set; }

        /// <summary>
        /// Наименование олимпиады
        /// <summary>
        public string? EventName { get; set; }

        /// <summary>
        /// Год проведения олимпиады
        /// <summary>
        public string? EventStudyYear { get; set; }

        /// <summary>
        /// Этап олимпиады
        /// <summary>
        public string? EventLevel { get; set; }

        /// <summary>
        /// Класс
        /// <summary>
        public string? EventClass { get; set; }

        /// <summary>
        /// Профиль олимпиады
        /// <summary>
        public string? EventType { get; set; }

        /// <summary>
        /// Тип диплома олимпиады
        /// <summary>
        public string? EventAchievement { get; set; }

        /// <summary>
        /// Предмет
        /// <summary>
        public string? EventSubject { get; set; }

        /// <summary>
        /// Наименование возрастной ступени в рамках которого присвоен знак отличия
        /// <summary>
        public string? GTOAgeLevel { get; set; }

        /// <summary>
        /// Возрастная группа участника в рамках которого присвоен знак отличия
        /// <summary>
        public string? GTOAgeGroup { get; set; }

        /// <summary>
        /// Код организации
        /// <summary>
        public string? SubdivisionCode { get; set; }

        /// <summary>
        /// Фамилия
        /// <summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Имя
        /// <summary>
        public string? Name { get; set; }

        /// <summary>
        /// Отчество
        /// <summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Код специальности
        /// <summary>
        public string? OksoCode { get; set; }

        /// <summary>
        /// Наименование специальности
        /// <summary>
        public string? SpecialtyName { get; set; }

        /// <summary>
        /// Наименование квалификации
        /// <summary>
        public string? QualificationName { get; set; }

        /// <summary>
        /// Наименование образовательной программы
        /// <summary>
        public string? EducationalProgram { get; set; }

        /// <summary>
        /// Дата установления инвалидности
        /// <summary>
        public string? DateFrom { get; set; }

        /// <summary>
        /// Дата следующего освидетельствования
        /// <summary>
        public string? DateOfNextCheck { get; set; }

        /// <summary>
        /// Дата решения ГЭК
        /// <summary>
        public string? ResultDate { get; set; }

        /// <summary>
        /// Дата окончания срока действия
        /// <summary>
        public string? ExpirationDate { get; set; }

        /// <summary>
        /// Дата продления
        /// <summary>
        public string? ProlongationDate { get; set; }
    }

    public class ListEventsList 
    {
        /// <summary>
        /// Наименование мероприятия
        /// <summary>
        public string? Name { get; set; }

        /// <summary>
        /// Тип мероприятия
        /// <summary>
        public string? Type { get; set; }

        /// <summary>
        /// Идентификатор
        /// <summary>
        public string? Id { get; set; }

        /// <summary>
        /// Количество часов
        /// <summary>
        public int? Hours { get; set; }

        /// <summary>
        /// Количество верифицированных часов
        /// <summary>
        public int? VerifiedHours { get; set; }

        /// <summary>
        /// Дата начала мероприятия
        /// <summary>
        public string? StartDate { get; set; }

        /// <summary>
        /// Дата окончания мероприятия
        /// <summary>
        public string? ExpirationDate { get; set; }
    }
}