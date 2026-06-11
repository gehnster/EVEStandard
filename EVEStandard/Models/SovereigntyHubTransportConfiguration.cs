using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Configured workforce transport. Exactly one of the variant properties is populated.
    /// </summary>
    public class SovereigntyHubTransportConfiguration : ModelBase<SovereigntyHubTransportConfiguration>
    {
        #region Properties

        /// <summary>
        /// Set when workforce is requested to be imported.
        /// </summary>
        /// <value>Set when workforce is requested to be imported.</value>
        [JsonPropertyName("import")]
        public SovereigntyHubTransportConfigurationImport Import { get; set; }

        /// <summary>
        /// Set when workforce is requested to be exported.
        /// </summary>
        /// <value>Set when workforce is requested to be exported.</value>
        [JsonPropertyName("export")]
        public SovereigntyHubTransportConfigurationExport Export { get; set; }

        /// <summary>
        /// Set when workforce is requested to be brought to transit.
        /// </summary>
        /// <value>Set when workforce is requested to be brought to transit.</value>
        [JsonPropertyName("transit")]
        public bool? Transit { get; set; }

        #endregion Properties
    }
}
