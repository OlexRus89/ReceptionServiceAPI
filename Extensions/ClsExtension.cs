using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Extensions
{
    internal class ClsExtension
    {

        internal DataTable AllCls(dynamic[] data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Actual", typeof(bool));

            foreach (var item in data.Select(a => new { a.Id, a.Name, a.Actual }))
            {
                table.Rows.Add(item.Id, item.Name, item.Actual);
            }
            return table;
        }

        internal DataTable DirectionCls(dynamic[] data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("IdParent", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Code", typeof(string));
            table.Columns.Add("Actual", typeof(bool));
            table.Columns.Add("Section", typeof(int));

            foreach (var item in data.Select(a => new { a.Id, a.IdParent, a.Name, a.Code, a.Actual, a.Section }))
            {
                table.Rows.Add(item.Id, item.IdParent, item.Name, item.Code, item.Actual, item.Section);
            }
            return table;
        }

        internal DataTable DocumentCategoryCls(dynamic[] data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("IdParent", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Actual", typeof(bool));

            foreach (var item in data.Select(a => new { a.Id, a.IdParent, a.Name, a.Actual }))
            {
                table.Rows.Add(item.Id, item.IdParent, item.Name, item.Actual);
            }
            return table;
        }
        internal DataTable DocumentTypeCls(dynamic[] data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("IdCategory", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("FieldsDescription", typeof(string));
            table.Columns.Add("Actual", typeof(bool));

            foreach (var item in data.Select(a => new { a.Id, a.IdCategory, a.Name, a.FieldsDescription, a.Actual }))
            {
                table.Rows.Add(item.Id, item.IdCategory, item.Name, item.FieldsDescription, item.Actual);
            }
            return table;
        }
        internal DataTable NoticesTypeCls(dynamic[] data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("IdStatus", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Actual", typeof(bool));

            foreach (var item in data.Select(a => new { a.Id, a.IdStatus, a.Name, a.Actual }))
            {
                table.Rows.Add(item.Id, item.IdStatus, item.Name, item.Actual);
            }
            return table;
        }
        internal DataTable OlympicCls(dynamic[] data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("OrderNumber", typeof(int));
            table.Columns.Add("Year", typeof(int));
            table.Columns.Add("Actual", typeof(bool));

            foreach (var item in data.Select(a => new { a.Id, a.Name, a.OrderNumber, a.Year, a.Actual }))
            {
                table.Rows.Add(item.Id, item.Name, item.OrderNumber, item.Year, item.Actual);
            }
            return table;
        }
        internal DataTable OlympicProfileSubjectCls(dynamic[] data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("IdSubject", typeof(int));
            table.Columns.Add("IdOlympicRelationProfile", typeof(int));
            table.Columns.Add("Actual", typeof(bool));

            foreach (var item in data.Select(a => new { a.Id, a.IdSubject, a.IdOlympicRelationProfile, a.Actual }))
            {
                table.Rows.Add(item.Id, item.IdSubject, item.IdOlympicRelationProfile, item.Actual);
            }
            return table;
        }
        internal DataTable OlympicRelationProfileCls(dynamic[] data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("IdOlympic", typeof(int));
            table.Columns.Add("IdProfile", typeof(int));
            table.Columns.Add("IdLevel", typeof(int));
            table.Columns.Add("Actual", typeof(bool));

            foreach (var item in data.Select(a => new { a.Id, a.IdOlympic, a.IdProfile, a.IdLevel, a.Actual }))
            {
                table.Rows.Add(item.Id, item.IdOlympic, item.IdProfile, item.IdLevel, item.Actual);
            }
            return table;
        }
        internal DataTable SubjectCls(dynamic[] data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Ege", typeof(bool));
            table.Columns.Add("Olympic", typeof(bool));
            table.Columns.Add("Sport", typeof(bool));
            table.Columns.Add("Actual", typeof(bool));

            foreach (var item in data.Select(a => new { a.Id, a.Name, a.Ege, a.Olympic, a.Sport, a.Actual }))
            {
                table.Rows.Add(item.Id, item.Name, item.Ege, item.Olympic, item.Sport, item.Actual);
            }
            return table;
        }
    }

     internal enum ExceptionsCls
    {
        DirectionCls,
        DocumentCategoryCls,
        DocumentTypeCls,
        NoticesTypeCls,
        OlympicCls,
        OlympicProfileSubjectCls,
        OlympicRelationProfileCls,
        SubjectCls,
        Null
    }
}