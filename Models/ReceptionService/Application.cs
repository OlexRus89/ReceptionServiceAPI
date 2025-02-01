using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ReceptionServiceCore.Models.ReceptionService.Cls;

namespace ReceptionServiceCore.Models.ReceptionService
{
    /// <summary>
    /// Заявление
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Уникальный идентификатор заявления сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidApplication { get; set; }
        /// <summary>
        /// Огрн организации
        /// </summary>
        public required string OgrnOwnerOrganization { get; set; }
        /// <summary>
        /// Кпп организации
        /// </summary>
        public required string KppOwnerOrganization { get; set; }
        /// <summary>
        /// Дата регистрации. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public required string RegistrationDate { get; set; }
        /// <summary>
        /// Признак первого образования
        /// </summary>
        public required bool FirstHigherEducation { get; set; }
        /// <summary>
        /// Признак необходимости общежития
        /// </summary>
        public required bool NeedHostel { get; set; }
        /// <summary>
        /// Этап приема. Идентификатор классификатора StagesAdmissionCls
        /// </summary>
        public required int IdStageAdmission { get; set; }
        /// <summary>
        /// Признак бюджет/платное
        /// </summary>
        public required bool IsBudget { get; set; }
        /// <summary>
        /// Музыкальный инструмент. Уникальный идентификатор справочника вуза (DictionaryValueList) в рамках организации сгенерированный организацией
        /// </summary>
        public int[]? UidDictionaryValueMusic { get; set; }
        /// <summary>
        /// Признак участия путем сдачи ВИ
        /// </summary>
        public required bool ExtraTestAttribute { get; set; }
        [XmlElement("CompetitiveGroupList", typeof(CompetitiveGroupList))]
        /// <summary>
        /// Список конкурсных групп
        /// </summary>
        public required CompetitiveGroupList CompetitiveGroupList { get; set; }
        [XmlElement("SubjectList", typeof(SubjectList))]
        /// <summary>
        /// Список предметов, выбранных для сдачи
        /// </summary>
        public SubjectList? SubjectList { get; set; }
        [XmlElement("SpecialConditionList", typeof(SpecialConditionList))]
        /// <summary>
        /// Специальное условие. Идентификатор классификатора SpecialConditionsCls
        /// </summary>
        public SpecialConditionList? SpecialConditionList { get; set; }
    }
}