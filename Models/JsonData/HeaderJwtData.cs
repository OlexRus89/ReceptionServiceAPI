using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.JsonData
{
    public class HeaderJwtData
    {
        public int? IdJwt { get; set; }
        public string? Entity { get; set; }
        public string? Action { get; set; }
        public string? CreatedAt { get; set; }
    }
}