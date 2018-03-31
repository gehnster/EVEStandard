

// ReSharper disable InconsistentNaming

namespace EVEStandard.Models
{
    using System;
    using System.Text;
    using Newtonsoft.Json;

    public class Status : ModelBase<Status>
    {
        [JsonProperty("start_time")] public string StartTime { get; set; }

        [JsonProperty("players")] public int Players { get; set; }

        [JsonProperty("server_version")] public string ServerVersion { get; set; }

        [JsonProperty("vip")] public bool VIP { get; set; }
    }
}