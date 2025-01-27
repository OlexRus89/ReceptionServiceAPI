using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReceptionServiceCore.Controller;
using ReceptionServiceCore.Models;

namespace ReceptionServiceAPI.Models.JsonData
{
    public class FileData
    {
        public string Fui { get; set; }
    }

    public class FileResultData
    {
        public string Base64 { get; set; }
        public string Extension { get; set; }
    }

    public class FileDB
    {
        public int? IdObject { get; set; }
        public int? IdJwt { get; set; }
        public string? Name { get; set; }
        public string? NameDirectory { get; set; }
        public int? Status { get; set; }
        public string? NameFile { get; set; }
        public string? Fui { get; set; }
        public DateTime? Expired { get; set; }
    }  
}