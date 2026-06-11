using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntySystem : ModelBase<SovereigntySystem>
    {
        #region Properties

        /// <summary>
        /// Claim on this solar system
        /// </summary>
        /// <value>Claim on this solar system</value>
        [JsonPropertyName("claim")]
        public SovereigntySystemClaim Claim { get; set; }

        /// <summary>
        /// ID of the solar system
        /// </summary>
        /// <value>ID of the solar system</value>
        [JsonPropertyName("solar_system_id")]
        public long SolarSystemId { get; set; }

        #endregion Properties
    }
}
