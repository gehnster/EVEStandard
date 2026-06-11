using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubReagentBay : ModelBase<SovereigntyHubReagentBay>
    {
        #region Properties

        /// <summary>
        /// Moment the 'amount' value was last updated; use 'burning_per_hour' to calculate the current value
        /// </summary>
        /// <value>Moment the 'amount' value was last updated; use 'burning_per_hour' to calculate the current value</value>
        [JsonPropertyName("last_updated")]
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Sovereignty Hub's reagents
        /// </summary>
        /// <value>Sovereignty Hub's reagents</value>
        [JsonPropertyName("reagents")]
        public List<SovereigntyHubReagent> Reagents { get; set; }

        #endregion Properties
    }
}
