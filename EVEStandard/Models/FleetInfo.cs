using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class FleetInfo : ModelBase<FleetInfo>
    {
        #region Properties

        /// <summary>
        /// Is free-move enabled
        /// </summary>
        /// <value>Is free-move enabled</value>
        [JsonPropertyName("is_free_move")]
        public bool IsFreeMove { get; set; }

        /// <summary>
        /// Does the fleet have an active fleet advertisement
        /// </summary>
        /// <value>Does the fleet have an active fleet advertisement</value>
        [JsonPropertyName("is_registered")]
        public bool IsRegistered { get; set; }

        /// <summary>
        /// Is EVE Voice enabled
        /// </summary>
        /// <value>Is EVE Voice enabled</value>
        [JsonPropertyName("is_voice_enabled")]
        public bool IsVoiceEnabled { get; set; }

        /// <summary>
        /// Fleet MOTD in CCP flavoured HTML
        /// </summary>
        /// <value>Fleet MOTD in CCP flavoured HTML</value>
        [JsonPropertyName("motd")]
        public string Motd { get; set; }

        #endregion Properties
    }
}
