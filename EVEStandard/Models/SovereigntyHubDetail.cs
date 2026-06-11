using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubDetail : ModelBase<SovereigntyHubDetail>
    {
        #region Properties

        /// <summary>
        /// Access List with who can manage Sovereignty Hub's fuel
        /// </summary>
        /// <value>Access List with who can manage Sovereignty Hub's fuel</value>
        [JsonPropertyName("fuel_access_list_id")]
        public long FuelAccessListId { get; set; }

        /// <summary>
        /// Sovereignty Hub's ID
        /// </summary>
        /// <value>Sovereignty Hub's ID</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Sovereignty Hub's reagent bay
        /// </summary>
        /// <value>Sovereignty Hub's reagent bay</value>
        [JsonPropertyName("reagent_bay")]
        public SovereigntyHubReagentBay ReagentBay { get; set; }

        /// <summary>
        /// Sovereignty Hub's resources
        /// </summary>
        /// <value>Sovereignty Hub's resources</value>
        [JsonPropertyName("resources")]
        public SovereigntyHubResources Resources { get; set; }

        /// <summary>
        /// Sovereignty Hub's solar system ID
        /// </summary>
        /// <value>Sovereignty Hub's solar system ID</value>
        [JsonPropertyName("solar_system_id")]
        public long SolarSystemId { get; set; }

        /// <summary>
        /// Sovereignty Hub's installed upgrades
        /// </summary>
        /// <value>Sovereignty Hub's installed upgrades</value>
        [JsonPropertyName("upgrades")]
        public List<SovereigntyHubUpgrade> Upgrades { get; set; }

        /// <summary>
        /// Sovereignty Hub's vulnerability window; if omitted, this Sovereignty Hub is part of an active campaign
        /// </summary>
        /// <value>Sovereignty Hub's vulnerability window; if omitted, this Sovereignty Hub is part of an active campaign</value>
        [JsonPropertyName("vulnerability_window")]
        public SovereigntyHubVulnerabilityWindow VulnerabilityWindow { get; set; }

        /// <summary>
        /// Sovereignty Hub's workforce transport settings
        /// </summary>
        /// <value>Sovereignty Hub's workforce transport settings</value>
        [JsonPropertyName("workforce_transport")]
        public SovereigntyHubTransport WorkforceTransport { get; set; }

        #endregion Properties
    }
}
