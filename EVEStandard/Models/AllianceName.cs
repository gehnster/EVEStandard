using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class AllianceName : ModelBase<AllianceName>
    {
        [JsonProperty("alliance_id")] public long Id { get; set; }

        [JsonProperty("alliance_name")] public string Name { get; set; }
    }
}