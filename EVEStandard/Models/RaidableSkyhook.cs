using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class RaidableSkyhook : ModelBase<RaidableSkyhook>
    {
        #region Properties

        /// <summary>
        /// ID of the planet the Skyhook is anchored on
        /// </summary>
        /// <value>ID of the planet the Skyhook is anchored on</value>
        [JsonPropertyName("planet_id")]
        public long PlanetId { get; set; }

        /// <summary>
        /// ID of the solar system the Skyhook is anchored on
        /// </summary>
        /// <value>ID of the solar system the Skyhook is anchored on</value>
        [JsonPropertyName("solar_system_id")]
        public long SolarSystemId { get; set; }

        /// <summary>
        /// Skyhook's theft vulnerability
        /// </summary>
        /// <value>Skyhook's theft vulnerability</value>
        [JsonPropertyName("theft_vulnerability")]
        public RaidableSkyhookTheftVulnerability TheftVulnerability { get; set; }

        #endregion Properties
    }
}
