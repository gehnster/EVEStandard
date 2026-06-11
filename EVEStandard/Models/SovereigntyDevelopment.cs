using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyDevelopment : ModelBase<SovereigntyDevelopment>
    {
        #region Properties

        /// <summary>
        /// Current Activity Defense Multiplier
        /// </summary>
        /// <value>Current Activity Defense Multiplier</value>
        [JsonPropertyName("activity_defense_multiplier")]
        public double ActivityDefenseMultiplier { get; set; }

        /// <summary>
        /// Industrial level (0-5) of this solar system
        /// </summary>
        /// <value>Industrial level (0-5) of this solar system</value>
        [JsonPropertyName("industrial_level")]
        public long IndustrialLevel { get; set; }

        /// <summary>
        /// Military level (0-5) of this solar system
        /// </summary>
        /// <value>Military level (0-5) of this solar system</value>
        [JsonPropertyName("military_level")]
        public long MilitaryLevel { get; set; }

        /// <summary>
        /// Strategic level (0-5) of this solar system
        /// </summary>
        /// <value>Strategic level (0-5) of this solar system</value>
        [JsonPropertyName("strategic_level")]
        public long StrategicLevel { get; set; }

        #endregion Properties
    }
}
