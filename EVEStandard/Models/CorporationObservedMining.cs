using System;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CorporationObservedMining : ModelBase<CorporationObservedMining>
    {
        /// <summary>
        /// last_updated string
        /// </summary>
        /// <value>last_updated string</value>
        [JsonProperty("last_updated")]
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// The character that did the mining 
        /// </summary>
        /// <value>The character that did the mining </value>
        [JsonProperty("character_id")]
        public int? CharacterId { get; set; }

        /// <summary>
        /// The corporation id of the character at the time data was recorded. 
        /// </summary>
        /// <value>The corporation id of the character at the time data was recorded. </value>
        [JsonProperty("recorded_corporation_id")]
        public int? RecordedCorporationId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        /// <summary>
        /// quantity integer
        /// </summary>
        /// <value>quantity integer</value>
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }
    }
}
