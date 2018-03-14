using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class Status
    {
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        [JsonProperty("players")]
        public int Players { get; set; }
        [JsonProperty("server_version")]
        public string ServerVersion { get; set; }
        [JsonProperty("vip")]
        public bool VIP { get; set; }
    }
}
