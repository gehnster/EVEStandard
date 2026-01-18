using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Bloodline : ModelBase<Bloodline>
    {
        #region Properties

        /// <summary>
        /// bloodline_id integer
        /// </summary>
        /// <value>bloodline_id integer</value>
        [JsonPropertyName("bloodline_id")]
        public long BloodlineId { get; set; }

        /// <summary>
        /// charisma integer
        /// </summary>
        /// <value>charisma integer</value>
        [JsonPropertyName("charisma")]
        public long Charisma { get; set; }

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonPropertyName("corporation_id")]
        public long CorporationId { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// intelligence integer
        /// </summary>
        /// <value>intelligence integer</value>
        [JsonPropertyName("intelligence")]
        public long Intelligence { get; set; }

        /// <summary>
        /// memory integer
        /// </summary>
        /// <value>memory integer</value>
        [JsonPropertyName("memory")]
        public long Memory { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// perception integer
        /// </summary>
        /// <value>perception integer</value>
        [JsonPropertyName("perception")]
        public long Perception { get; set; }

        /// <summary>
        /// race_id integer
        /// </summary>
        /// <value>race_id integer</value>
        [JsonPropertyName("race_id")]
        public long RaceId { get; set; }

        /// <summary>
        /// ship_type_id integer
        /// </summary>
        /// <value>ship_type_id integer</value>
        [JsonPropertyName("ship_type_id")]
        public long ShipTypeId { get; set; }
        /// <summary>
        /// willpower integer
        /// </summary>
        /// <value>willpower integer</value>
        [JsonPropertyName("willpower")]
        public long Willpower { get; set; }

        #endregion Properties
    }
}
