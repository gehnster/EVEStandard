using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterMining : ModelBase<CharacterMining>
    {
        #region Properties

        /// <summary>
        /// date string
        /// </summary>
        /// <value>date string</value>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// quantity integer
        /// </summary>
        /// <value>quantity integer</value>
        [JsonPropertyName("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
