namespace EVEStandard.Models
{
    using System;
    using System.Text;
    using Newtonsoft.Json;

    public class CharacterName : ModelBase<CharacterName>
    {
        [JsonProperty("character_id")] public long ID { get; set; }

        [JsonProperty("character_name")] public string Name { get; set; }
    }
}