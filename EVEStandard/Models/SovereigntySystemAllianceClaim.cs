using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntySystemAllianceClaim : ModelBase<SovereigntySystemAllianceClaim>
    {
        #region Properties

        /// <summary>
        /// Alliance that claimed this solar system
        /// </summary>
        /// <value>Alliance that claimed this solar system</value>
        [JsonPropertyName("alliance_id")]
        public long AllianceId { get; set; }

        /// <summary>
        /// Time the claim was made
        /// </summary>
        /// <value>Time the claim was made</value>
        [JsonPropertyName("claimed_since")]
        public DateTime? ClaimedSince { get; set; }

        /// <summary>
        /// Corporation that claimed this solar system
        /// </summary>
        /// <value>Corporation that claimed this solar system</value>
        [JsonPropertyName("corporation_id")]
        public long CorporationId { get; set; }

        /// <summary>
        /// Solar system's development
        /// </summary>
        /// <value>Solar system's development</value>
        [JsonPropertyName("development")]
        public SovereigntyDevelopment Development { get; set; }

        /// <summary>
        /// Whether the system is the capital system of the alliance
        /// </summary>
        /// <value>Whether the system is the capital system of the alliance</value>
        [JsonPropertyName("is_capital_system")]
        public bool IsCapitalSystem { get; set; }

        /// <summary>
        /// Sovereignty Hub holding the claim
        /// </summary>
        /// <value>Sovereignty Hub holding the claim</value>
        [JsonPropertyName("sovereignty_hub")]
        public SovereigntySystemHub SovereigntyHub { get; set; }

        #endregion Properties
    }
}
