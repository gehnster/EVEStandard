using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubTransportStateExport : ModelBase<SovereigntyHubTransportStateExport>
    {
        #region Properties

        /// <summary>
        /// Amount exported
        /// </summary>
        /// <value>Amount exported</value>
        [JsonPropertyName("amount")]
        public long? Amount { get; set; }

        /// <summary>
        /// Destination's solar system ID
        /// </summary>
        /// <value>Destination's solar system ID</value>
        [JsonPropertyName("solar_system_id")]
        public long SolarSystemId { get; set; }

        #endregion Properties
    }
}
