using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryDenEvolutionDevelopment : ModelBase<MercenaryDenEvolutionDevelopment>
    {
        #region Properties

        /// <summary>
        /// Development's cumulative amount (0-100)
        /// </summary>
        /// <value>Development's cumulative amount (0-100)</value>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Development's level Valid values: Unspecified, Level0, Level1, Level2, Level3, Level4.
        /// </summary>
        /// <value>Development's level Valid values: Unspecified, Level0, Level1, Level2, Level3, Level4.</value>
        [JsonPropertyName("level")]
        public string Level { get; set; }

        #endregion Properties
    }
}
