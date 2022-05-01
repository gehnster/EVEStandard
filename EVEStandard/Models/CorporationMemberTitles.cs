using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationMemberTitles : ModelBase<CorporationMemberTitles>
    {
        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [JsonPropertyName("character_id")]
        public int CharacterId { get; set; }

        /// <summary>
        /// A list of title_id
        /// </summary>
        /// <value>A list of title_id</value>
        [JsonPropertyName("titles")]
        public List<int> Titles { get; set; }
    }
}
