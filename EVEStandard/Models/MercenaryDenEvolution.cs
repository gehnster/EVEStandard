using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryDenEvolution : ModelBase<MercenaryDenEvolution>
    {
        #region Properties

        /// <summary>
        /// Mercenary Den's anarchy
        /// </summary>
        /// <value>Mercenary Den's anarchy</value>
        [JsonPropertyName("anarchy")]
        public MercenaryDenEvolutionAnarchy Anarchy { get; set; }

        /// <summary>
        /// Mercenary Den's development
        /// </summary>
        /// <value>Mercenary Den's development</value>
        [JsonPropertyName("development")]
        public MercenaryDenEvolutionDevelopment Development { get; set; }

        #endregion Properties
    }
}
