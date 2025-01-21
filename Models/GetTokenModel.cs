using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptionServiceCore.Models
{
    public class GetTokenModel
    {
        public required int IdObject { get; set; }
        public required string Action { get; set; }
        public required string Entity { get; set; }
        public required string Ogrn { get; set; }
        public required string Kpp { get; set; }
        public string? Payload { get; set; }
        public string? Result { get; set; }
        public int Status { get; set; }
        public int? IdJWT { get; set; }
        public int? DelaySecond { get; set; }
    }
}
