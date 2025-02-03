using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.JsonData
{
    public class HeaderData
    {
        public required string Action { get; set; }
        public required string Entity { get; set; }
        public required string Ogrn { get; set; }
        public required string Kpp { get; set; }
    }
}