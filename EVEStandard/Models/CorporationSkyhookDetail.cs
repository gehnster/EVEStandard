using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationSkyhookDetail : ModelBase<CorporationSkyhookDetail>
    {
        #region Properties

        /// <summary>
        /// Skyhook's effective workforce; this can differ from the Skyhook's normal workforce due to the influence of an attached Mercenary Den
        /// </summary>
        /// <value>Skyhook's effective workforce; this can differ from the Skyhook's normal workforce due to the influence of an attached Mercenary Den</value>
        [JsonPropertyName("effective_workforce")]
        public long? EffectiveWorkforce { get; set; }

        /// <summary>
        /// Skyhook's ID
        /// </summary>
        /// <value>Skyhook's ID</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Whether the Skyhook is active and producing workforce/power/reagents
        /// </summary>
        /// <value>Whether the Skyhook is active and producing workforce/power/reagents</value>
        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// ID of the planet the Skyhook is anchored on
        /// </summary>
        /// <value>ID of the planet the Skyhook is anchored on</value>
        [JsonPropertyName("planet_id")]
        public long PlanetId { get; set; }

        /// <summary>
        /// Skyhook's reagents
        /// </summary>
        /// <value>Skyhook's reagents</value>
        [JsonPropertyName("reagents")]
        public List<CorporationSkyhookReagent> Reagents { get; set; }

        /// <summary>
        /// Skyhook's reinforcement timer (if the structure is reinforced)
        /// </summary>
        /// <value>Skyhook's reinforcement timer (if the structure is reinforced)</value>
        [JsonPropertyName("reinforcement_timer")]
        public CorporationSkyhookReinforcementTimer ReinforcementTimer { get; set; }

        /// <summary>
        /// Skyhook's state Valid values: Unspecified, ShieldVulnerable, ArmorReinforced, ArmorVulnerable, HullReinforced, HullVulnerable.
        /// </summary>
        /// <value>Skyhook's state Valid values: Unspecified, ShieldVulnerable, ArmorReinforced, ArmorVulnerable, HullReinforced, HullVulnerable.</value>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Skyhook's theft vulnerability
        /// </summary>
        /// <value>Skyhook's theft vulnerability</value>
        [JsonPropertyName("theft_vulnerability")]
        public CorporationSkyhookTheftVulnerability TheftVulnerability { get; set; }

        #endregion Properties
    }
}
