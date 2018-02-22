using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class CharacterName
    {
        [JsonProperty("character_id")]
        public int ID { get; set; }
        [JsonProperty("character_name")]
        public string Name { get; set; }
    }
}
