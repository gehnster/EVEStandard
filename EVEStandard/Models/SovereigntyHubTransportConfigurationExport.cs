using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubTransportConfigurationExport : ModelBase<SovereigntyHubTransportConfigurationExport>
    {
        #region Properties

        /// <summary>
        /// Amount to be exported
        /// </summary>
        /// <value>Amount to be exported</value>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Destination's solar system ID
        /// </summary>
        /// <value>Destination's solar system ID</value>
        [JsonPropertyName("solar_system_id")]
        public long SolarSystemId { get; set; }

        #endregion Properties
    }
}
