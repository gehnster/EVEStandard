using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubTransport : ModelBase<SovereigntyHubTransport>
    {
        #region Properties

        /// <summary>
        /// Configured workforce transport
        /// </summary>
        /// <value>Configured workforce transport</value>
        [JsonPropertyName("configuration")]
        public SovereigntyHubTransportConfiguration Configuration { get; set; }

        /// <summary>
        /// Current state of the workforce transport
        /// </summary>
        /// <value>Current state of the workforce transport</value>
        [JsonPropertyName("state")]
        public SovereigntyHubTransportState State { get; set; }

        #endregion Properties
    }
}
