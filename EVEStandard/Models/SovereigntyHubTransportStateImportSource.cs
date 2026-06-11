using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubTransportStateImportSource : ModelBase<SovereigntyHubTransportStateImportSource>
    {
        #region Properties

        /// <summary>
        /// Amount imported
        /// </summary>
        /// <value>Amount imported</value>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Source's solar system ID
        /// </summary>
        /// <value>Source's solar system ID</value>
        [JsonPropertyName("solar_system_id")]
        public long SolarSystemId { get; set; }

        #endregion Properties
    }
}
