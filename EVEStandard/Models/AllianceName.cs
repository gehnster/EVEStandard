using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class AllianceName
    {
        [JsonProperty("alliance_id")]
        public int Id { get; set; }
        [JsonProperty("alliance_name")]
        public string Name { get; set; }
    }
}
