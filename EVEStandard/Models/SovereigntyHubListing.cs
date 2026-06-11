using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubListing : ModelBase<SovereigntyHubListing>
    {
        #region Properties

        /// <summary>
        /// List of Sovereignty Hubs
        /// </summary>
        /// <value>List of Sovereignty Hubs</value>
        [JsonPropertyName("sovereignty_hubs")]
        public List<SovereigntyHubSummary> SovereigntyHubs { get; set; }

        #endregion Properties
    }
}
