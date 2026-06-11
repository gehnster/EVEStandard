using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntySystemFactionClaim : ModelBase<SovereigntySystemFactionClaim>
    {
        #region Properties

        /// <summary>
        /// Faction that claimed this solar system
        /// </summary>
        /// <value>Faction that claimed this solar system</value>
        [JsonPropertyName("faction_id")]
        public long FactionId { get; set; }

        #endregion Properties
    }
}
