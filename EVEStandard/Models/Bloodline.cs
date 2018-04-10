using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class Bloodline : ModelBase<Bloodline>
    {
        [JsonProperty("bloodline_id")] public int BloodlineId { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("race_id")] public int RaceId { get; set; }
        [JsonProperty("ship_type_id")] public int ShipTypeId { get; set; }
        [JsonProperty("corporation_id")] public int CorporationId { get; set; }
        [JsonProperty("perception")] public int Perception { get; set; }
        [JsonProperty("willpower")] public int Willpower { get; set; }
        [JsonProperty("charisma")] public int Charisma { get; set; }
        [JsonProperty("memory")] public int Memory { get; set; }
        [JsonProperty("intelligence")] public int Intelligence { get; set; }
    }
}
