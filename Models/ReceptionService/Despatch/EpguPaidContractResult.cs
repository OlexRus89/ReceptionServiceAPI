using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReceptionServiceCore.Models.ReceptionService.Despatch
{
    /// <summary>
    /// Результат подписания платного договор/доп.соглашения на ЕПГУ
    /// </summary>
    public class EpguPaidContractResult
    {
        /// <summary>
        /// Уникальный идентификатор КГ заявления, сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidCompetitiveGroup { get; set; }
        /// <summary>
        /// Статус договора о платном обучении. Идентификатор классификатора PaidContractStatusCls
        /// </summary>
        public required int IdPaidContractStatus { get; set; }
        /// <summary>
        /// Статус доп соглашения договора о платном обучении. Идентификатор классификатора PaidContractStatusCls
        /// </summary>
        public int? IdAdditionalPaidContractStatus { get; set; }
        [XmlElement("Document", typeof(File))]
        /// <summary>
        /// Договор (если договор/доп.соглашение подписан)
        /// </summary>
        public File? Document { get; set; }
        [XmlElement("Signature1", typeof(File))]
        /// <summary>
        /// Подпись вуза (если договор/доп.соглашение подписан)
        /// </summary>
        public File? Signature1 { get; set; }
        [XmlElement("Signature2", typeof(File))]
        /// <summary>
        /// Подпись абитуриента (отправлять договор/доп.соглашение подписан)
        /// </summary>
        public File? Signature2 { get; set; }
        [XmlElement("Signature3", typeof(File))]
        /// <summary>
        /// Подпись второго подписанта (отправлять договор/доп.соглашение подписан)
        /// </summary>
        public File? Signature3 { get; set; }
        [XmlElement("Signature4", typeof(File))]
        /// <summary>
        /// Подпись третьего подписанта (отправлять договор/доп.соглашение подписан)
        /// </summary>
        public File? Signature4 { get; set; }
    }
}