using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntySystemHub : ModelBase<SovereigntySystemHub>
    {
        #region Properties

        /// <summary>
        /// ID of the Sovereignty Hub
        /// </summary>
        /// <value>ID of the Sovereignty Hub</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Sovereignty Hub's vulnerability window; if omitted, this Sovereignty Hub is part of an active campaign
        /// </summary>
        /// <value>Sovereignty Hub's vulnerability window; if omitted, this Sovereignty Hub is part of an active campaign</value>
        [JsonPropertyName("vulnerability_window")]
        public SovereigntyVulnerabilityWindow VulnerabilityWindow { get; set; }

        #endregion Properties
    }
}
