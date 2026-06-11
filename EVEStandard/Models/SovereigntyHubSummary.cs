using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubSummary : ModelBase<SovereigntyHubSummary>
    {
        #region Properties

        /// <summary>
        /// Sovereignty Hub's ID
        /// </summary>
        /// <value>Sovereignty Hub's ID</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Sovereignty Hub's location
        /// </summary>
        /// <value>Sovereignty Hub's location</value>
        [JsonPropertyName("solar_system_id")]
        public long SolarSystemId { get; set; }

        #endregion Properties
    }
}
