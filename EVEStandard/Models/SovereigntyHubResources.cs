using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubResources : ModelBase<SovereigntyHubResources>
    {
        #region Properties

        /// <summary>
        /// Sovereignty Hub's power
        /// </summary>
        /// <value>Sovereignty Hub's power</value>
        [JsonPropertyName("power")]
        public SovereigntyHubResourcePower Power { get; set; }

        /// <summary>
        /// Sovereignty Hub's workforce
        /// </summary>
        /// <value>Sovereignty Hub's workforce</value>
        [JsonPropertyName("workforce")]
        public SovereigntyHubResourceWorkforce Workforce { get; set; }

        #endregion Properties
    }
}
