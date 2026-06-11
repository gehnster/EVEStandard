using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubTransportStateImport : ModelBase<SovereigntyHubTransportStateImport>
    {
        #region Properties

        /// <summary>
        /// Sources
        /// </summary>
        /// <value>Sources</value>
        [JsonPropertyName("sources")]
        public List<SovereigntyHubTransportStateImportSource> Sources { get; set; }

        #endregion Properties
    }
}
