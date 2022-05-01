using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationObservedMining : ModelBase<CorporationObservedMining>
    {
        #region Properties

        /// <summary>
        /// The character that did the mining 
        /// </summary>
        /// <value>The character that did the mining </value>
        [JsonPropertyName("character_id")]
        public int CharacterId { get; set; }

        /// <summary>
        /// last_updated string
        /// </summary>
        /// <value>last_updated string</value>
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }
        /// <summary>
        /// quantity integer
        /// </summary>
        /// <value>quantity integer</value>
        [JsonPropertyName("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// The corporation id of the character at the time data was recorded. 
        /// </summary>
        /// <value>The corporation id of the character at the time data was recorded. </value>
        [JsonPropertyName("recorded_corporation_id")]
        public int RecordedCorporationId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
