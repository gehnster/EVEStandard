using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class CorporationMemberTitles : ModelBase<CorporationMemberTitles>
    {
        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [JsonProperty("character_id")]
        public int? CharacterId { get; set; }

        /// <summary>
        /// A list of title_id
        /// </summary>
        /// <value>A list of title_id</value>
        [JsonProperty("titles")]
        public List<int?> Titles { get; set; }
    }
}
