using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Current state of the workforce transport. Exactly one of the variant properties is populated.
    /// </summary>
    public class SovereigntyHubTransportState : ModelBase<SovereigntyHubTransportState>
    {
        #region Properties

        /// <summary>
        /// Set when workforce is being imported.
        /// </summary>
        /// <value>Set when workforce is being imported.</value>
        [JsonPropertyName("import")]
        public SovereigntyHubTransportStateImport Import { get; set; }

        /// <summary>
        /// Set when workforce is being exported.
        /// </summary>
        /// <value>Set when workforce is being exported.</value>
        [JsonPropertyName("export")]
        public SovereigntyHubTransportStateExport Export { get; set; }

        /// <summary>
        /// Set when workforce is being brought to transit.
        /// </summary>
        /// <value>Set when workforce is being brought to transit.</value>
        [JsonPropertyName("transit")]
        public bool? Transit { get; set; }

        #endregion Properties
    }
}
