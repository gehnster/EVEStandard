using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class AllianceIcons : ModelBase<AllianceIcons>
    {
        [JsonProperty("px64x64")] public string Px64x64 { get; set; }
        [JsonProperty("px128x128")] public string Px128x128 { get; set; }
    }
}