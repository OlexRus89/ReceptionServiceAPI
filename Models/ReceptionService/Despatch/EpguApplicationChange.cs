using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Изменения общих параметров заявления из ЕПГУ
    /// </summary>
    public class EpguApplicationChange
    {
        /// <summary>
        /// Уникальный идентификатор заявления сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidApplication { get; set; }
        /// <summary>
        /// Признак первого образования
        /// </summary>
        public required bool FirstHigherEducation { get; set; }
        /// <summary>
        /// Признак необходимости общежития
        /// </summary>
        public required bool NeedHostel { get; set; }
        /// <summary>
        /// Музыкальный инструмент. Уникальный идентификатор справочника вуза (DictionaryValueList) в рамках организации сгенерированный организацией
        /// </summary>
        public string[]? UidDictionaryValueMusic { get; set; }
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
        /// Список специальных условий сдачи ВИ
        /// </summary>
        public SpecialConditionList? SpecialConditionList { get; set; }
    }
}