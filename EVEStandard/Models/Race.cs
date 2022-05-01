using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Race : ModelBase<Race>
    {
        #region Properties

        /// <summary>
        /// The alliance generally associated with this race
        /// </summary>
        /// <value>The alliance generally associated with this race</value>
        [JsonPropertyName("alliance_id")]
        public int AllianceId { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// race_id integer
        /// </summary>
        /// <value>race_id integer</value>
        [JsonPropertyName("race_id")]
        public int RaceId { get; set; }

        #endregion Properties
    }
}
