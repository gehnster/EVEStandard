using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubReagent : ModelBase<SovereigntyHubReagent>
    {
        #region Properties

        /// <summary>
        /// Amount of reagent in the bay at the time of 'last_updated'
        /// </summary>
        /// <value>Amount of reagent in the bay at the time of 'last_updated'</value>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Amount of reagent burning per hour
        /// </summary>
        /// <value>Amount of reagent burning per hour</value>
        [JsonPropertyName("burning_per_hour")]
        public long BurningPerHour { get; set; }

        /// <summary>
        /// Reagent's type ID
        /// </summary>
        /// <value>Reagent's type ID</value>
        [JsonPropertyName("type_id")]
        public long TypeId { get; set; }

        #endregion Properties
    }
}
