using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CharacterName : ModelBase<CharacterName>
    {
        [JsonProperty("character_id")] public long ID { get; set; }

        [JsonProperty("character_name")] public string Name { get; set; }
    }
}