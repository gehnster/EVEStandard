using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubResourceWorkforce : ModelBase<SovereigntyHubResourceWorkforce>
    {
        #region Properties

        /// <summary>
        /// Allocated workforce
        /// </summary>
        /// <value>Allocated workforce</value>
        [JsonPropertyName("allocated")]
        public long Allocated { get; set; }

        /// <summary>
        /// Available workforce
        /// </summary>
        /// <value>Available workforce</value>
        [JsonPropertyName("available")]
        public long Available { get; set; }

        #endregion Properties
    }
}
