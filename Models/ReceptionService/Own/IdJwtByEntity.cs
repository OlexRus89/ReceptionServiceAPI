using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CryptoCore.Models.ReceptionService.Own
{
    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Получение информации о запросах в Сервисе приема по сущности
    /// </summary>
    public class IdJwtByEntity
    {
        /// <summary>
        /// Получение информации о запросах в Сервисе приема по сущности
        /// Сущности:
        ///     <xs:enumeration value="ApplicationList" />
        ///     <xs:enumeration value="AvailabilityHigherEducationFrdoList" />
        ///     <xs:enumeration value="CampaignEventList" />
        ///     <xs:enumeration value="CampaignList" />
        ///     <xs:enumeration value="CampaignStatusList" />
        ///     <xs:enumeration value="CompetitionList" />
        ///     <xs:enumeration value="CompetitiveGroupAchievementList" />
        ///     <xs:enumeration value="CompetitiveGroupBenefitList" />
        ///     <xs:enumeration value="CompetitiveGroupList" />
        ///     <xs:enumeration value="CompetitiveGroupPriorityList" />
        ///     <xs:enumeration value="CompetitiveGroupResultList" />
        ///     <xs:enumeration value="CompetitiveGroupStatusList" />
        ///     <xs:enumeration value="DictionaryValueList" />
        ///     <xs:enumeration value="DocumentList" />
        ///     <xs:enumeration value="EntranceTestAgreedList" />
        ///     <xs:enumeration value="EntranceTestList" />
        ///     <xs:enumeration value="EntranceTestPlaceList" />
        ///     <xs:enumeration value="EntranceTestResultList" />
        ///     <xs:enumeration value="EntrantList" />
        ///     <xs:enumeration value="NoticeList" />
        ///     <xs:enumeration value="OrgDirectionList" />
        ///     <xs:enumeration value="OriginalEducationDocumentList" />
        ///     <xs:enumeration value="PaidContract" />
        ///     <xs:enumeration value="PaidContractCancel" />
        ///     <xs:enumeration value="RankedCompetitionListPackage" />
        ///     <xs:enumeration value="TargetOrganizationList" />
        /// </summary>
        public required string Entity { get; set; }
        [XmlElement("List", typeof(List))]
        /// <summary>
        /// Список IdJwt
        /// </summary>
        public List? List { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Список IdJwt
    /// </summary>
    public class List
    {
        [XmlElement("Jwt", typeof(Jwt))]
        /// <summary>
        /// Данные по IdJwt
        /// </summary>
        public required Jwt[] Jwt { get; set; }
    }

    [Obsolete(message: "Данная модель является устаревшим от МинОбрНауки", error: true)]
    /// <summary>
    /// Данные по IdJwt
    /// </summary>
    public class Jwt
    {
        /// <summary>
        /// Уникальный идентификатор токена
        /// </summary>
        public required int IdJwt { get; set; }
        /// <summary>
        /// Дата и время запроса по Москве. Формат RFC3339 шаблон "2006-01-02T15:04:05+03:00"
        /// </summary>
        public required string CreatedDateTime { get; set; }
    }
}