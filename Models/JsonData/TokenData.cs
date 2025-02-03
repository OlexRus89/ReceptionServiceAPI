using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.JsonData
{
    public class TokenData
    {
        public int? IdJwt { get; set; }
        public int? DelaySeconds { get; set; }
        public string? Token { get; set; }
    }
}