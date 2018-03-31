namespace EVEStandard.Models
{
    using System;
    using System.Text;
    using Newtonsoft.Json;

    public class AllianceName : ModelBase<AllianceName>
    {
        [JsonProperty("alliance_id")] public long Id { get; set; }

        [JsonProperty("alliance_name")] public string Name { get; set; }
    }
}