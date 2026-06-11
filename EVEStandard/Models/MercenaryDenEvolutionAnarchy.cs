using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryDenEvolutionAnarchy : ModelBase<MercenaryDenEvolutionAnarchy>
    {
        #region Properties

        /// <summary>
        /// Anarchy's cumulative amount (0-100)
        /// </summary>
        /// <value>Anarchy's cumulative amount (0-100)</value>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Anarchy's level Valid values: Unspecified, Level0, Level1, Level2, Level3, Level4.
        /// </summary>
        /// <value>Anarchy's level Valid values: Unspecified, Level0, Level1, Level2, Level3, Level4.</value>
        [JsonPropertyName("level")]
        public string Level { get; set; }

        #endregion Properties
    }
}
