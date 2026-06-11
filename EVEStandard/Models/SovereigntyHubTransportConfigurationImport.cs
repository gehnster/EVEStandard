using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubTransportConfigurationImport : ModelBase<SovereigntyHubTransportConfigurationImport>
    {
        #region Properties

        /// <summary>
        /// Sources
        /// </summary>
        /// <value>Sources</value>
        [JsonPropertyName("sources")]
        public List<SovereigntyHubTransportConfigurationSource> Sources { get; set; }

        #endregion Properties
    }
}
