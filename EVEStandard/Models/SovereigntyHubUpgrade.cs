using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyHubUpgrade : ModelBase<SovereigntyHubUpgrade>
    {
        #region Properties

        /// <summary>
        /// Upgrade's power state Valid values: Unspecified, Online, Offline, Low, Pending.
        /// </summary>
        /// <value>Upgrade's power state Valid values: Unspecified, Online, Offline, Low, Pending.</value>
        [JsonPropertyName("power_state")]
        public string PowerState { get; set; }

        /// <summary>
        /// Upgrade's type ID
        /// </summary>
        /// <value>Upgrade's type ID</value>
        [JsonPropertyName("type_id")]
        public long TypeId { get; set; }

        #endregion Properties
    }
}
