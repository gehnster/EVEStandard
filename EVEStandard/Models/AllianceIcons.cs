using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class AllianceIcons
    {
        [JsonProperty("px64x64")]
        public string Size64 { get; set; }
        [JsonProperty("px128x128")]
        public string Size128 { get; set; }
    }
}
