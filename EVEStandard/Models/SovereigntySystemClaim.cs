using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Claim on a solar system. Exactly one of the variant properties is populated.
    /// </summary>
    public class SovereigntySystemClaim : ModelBase<SovereigntySystemClaim>
    {
        #region Properties

        /// <summary>
        /// Set when the solar system is claimed by a faction.
        /// </summary>
        /// <value>Set when the solar system is claimed by a faction.</value>
        [JsonPropertyName("faction")]
        public SovereigntySystemFactionClaim Faction { get; set; }

        /// <summary>
        /// Set when the solar system is claimed by an alliance.
        /// </summary>
        /// <value>Set when the solar system is claimed by an alliance.</value>
        [JsonPropertyName("alliance")]
        public SovereigntySystemAllianceClaim Alliance { get; set; }

        /// <summary>
        /// Set to true when the solar system is unclaimed.
        /// </summary>
        /// <value>Set to true when the solar system is unclaimed.</value>
        [JsonPropertyName("unclaimed")]
        public bool? Unclaimed { get; set; }

        #endregion Properties
    }
}
