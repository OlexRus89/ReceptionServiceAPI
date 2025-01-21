using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReceptionServiceCore.Models.ReceptionService
{
    public class FieldsJSON
    {
        [JsonProperty("fields")]
        public FieldsData[]? Fields { get; set; }
    }

    public class FieldsData 
    {
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("not_null")]
        public bool? NotNull { get; set; }
        [JsonProperty("xml_name")]
        public string? XmlName { get; set; }
        [JsonProperty("xml_cls")]
        public string? XmlCls { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        public FieldsData[]? Values { get; set; }
    }
}