using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCore.Models.JsonData
{
    public class DelayData
    {
        public required int DelaySeconds { get; set; }
        public required string DelayHumanReadable { get; set; }
        public required string Comment { get; set; }
    }
}