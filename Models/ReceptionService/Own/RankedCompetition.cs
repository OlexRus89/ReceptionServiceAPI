using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Identity.Client;

namespace ReceptionServiceCore.Models.ReceptionService.Own
{
    /// <summary>
    /// Конкурсный список (сущность)
    /// </summary>
    public class RankedCompetition
    {
        /// <summary>
        /// Уникальный идентификатор конкурса (CompetitionList) в рамках организации сгенерированный организацией
        /// </summary>
        public required string UidCompetition { get; set; }
        [XmlElement("Entrant", typeof(Entrant))]
        /// <summary>
        /// Информация по абитуриенту для КС
        /// </summary>
        public Entrant[]? Entrant { get; set; }
    }

    /// <summary>
    /// Информация по абитуриенту для КС
    /// </summary>
    public class Entrant 
    {
        /// <summary>
        /// СНИЛС
        /// </summary>
        public string? Snils { get; set; }
        /// <summary>
        /// Уникальный идентификатор профиля поступающего (EntrantList) сгенерированный Сервисом приема
        /// </summary>
        public required Guid GuidEntrant { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public required int Priority { get; set; }
        /// <summary>
        /// Высший приоритет
        /// </summary>
        public required bool TopPriority { get; set; }
        /// <summary>
        /// Ранг (позиция в списке) (Обязательно: от 1 до кол-ва заявлений)
        /// </summary>
        public required int Rating { get; set; }
        /// <summary>
        /// Отметка о поступлении БВИ
        /// </summary>
        public required bool WithoutTests { get; set; }
        /// <summary>
        /// Вступительное испытание №1
        /// </summary>
        public required string EntranceTest1 { get; set; }
        /// <summary>
        /// Балл ВИ1 (до трех знаков после запятой)
        /// </summary>
        public required double Result1 { get; set; }
        /// <summary>
        /// Вступительное испытание №2
        /// </summary>
        public required string EntranceTest2 { get; set; }
        /// <summary>
        /// Балл ВИ2 (до трех знаков после запятой)
        /// </summary>
        public required double Result2 { get; set; }
        /// <summary>
        /// Вступительное испытание №3
        /// </summary>
        public required string EntranceTest3 { get; set; }
        /// <summary>
        /// Балл ВИ3 (до трех знаков после запятой)
        /// </summary>
        public required double Result3 { get; set; }
        /// <summary>
        /// Вступительное испытание №4
        /// </summary>
        public string? EntranceTest4 { get; set; }
        /// <summary>
        /// Балл ВИ4 (до трех знаков после запятой)
        /// </summary>
        public double Result4 { get; set; }
        /// <summary>
        /// Вступительное испытание №5
        /// </summary>
        public string? EntranceTest5 { get; set; }
        /// <summary>
        /// Балл ВИ5 (до трех знаков после запятой)
        /// </summary>
        public double? Result5 { get; set; }
        /// <summary>
        /// Баллы за ИД
        /// </summary>
        public required double AchievementsMark { get; set; }
        /// <summary>
        /// Сумма баллов за ВИ (до трех знаков после запятой)
        /// </summary>
        public required double EntranceTestMark { get; set; }
        /// <summary>
        /// Сумма конкурсных баллов (до трех знаков после запятой)
        /// </summary>
        public required double SumMark { get; set; }
        /// <summary>
        /// Наличие преимущественного права
        /// </summary>
        public required bool Benefit { get; set; }
        /// <summary>
        /// Наличие оригинала документа об образовании
        /// </summary>
        public required bool Original { get; set; }
    }
}