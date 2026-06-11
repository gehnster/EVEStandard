using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubTransportConfigurationSource : ModelBase<SovereigntyHubTransportConfigurationSource>
    {
        #region Properties

        /// <summary>
        /// Source's solar system ID
        /// </summary>
        /// <value>Source's solar system ID</value>
        [JsonPropertyName("solar_system_id")]
        public long SolarSystemId { get; set; }

        #endregion Properties
    }
}
