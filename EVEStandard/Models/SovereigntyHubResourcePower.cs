using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubResourcePower : ModelBase<SovereigntyHubResourcePower>
    {
        #region Properties

        /// <summary>
        /// Allocated power
        /// </summary>
        /// <value>Allocated power</value>
        [JsonPropertyName("allocated")]
        public long Allocated { get; set; }

        /// <summary>
        /// Available power
        /// </summary>
        /// <value>Available power</value>
        [JsonPropertyName("available")]
        public long Available { get; set; }

        #endregion Properties
    }
}
