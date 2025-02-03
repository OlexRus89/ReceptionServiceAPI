using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.JsonData
{
    public class JwtListsData
    {
        public IdJwtList? IdJwtList { get; set; }
    }

    public class IdJwtList
    {
        public int? Length { get; set; }
        public int[]? List { get; set; }
    }
}