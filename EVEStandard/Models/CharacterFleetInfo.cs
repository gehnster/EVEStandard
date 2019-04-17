using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CharacterFleetInfo : ModelBase<CharacterFleetInfo>
    {
        #region Properties

        /// <summary>
        /// Character ID of the current fleet boss
        /// </summary>
        [JsonProperty("fleet_boss_id")]
        public long FleetBossId { get; set; }

        /// <summary>
        /// The character’s current fleet ID
        /// </summary>
        /// <value>The character&#39;s current fleet ID</value>
        [JsonProperty("fleet_id")]
        public long FleetId { get; set; }

        /// <summary>
        /// Member’s role in fleet
        /// </summary>
        /// <value>Member’s role in fleet</value>
        [JsonProperty("role")]
        public FleetRole Role { get; set; }

        /// <summary>
        /// ID of the squad the member is in. If not applicable, will be set to -1
        /// </summary>
        /// <value>ID of the squad the member is in. If not applicable, will be set to -1</value>
        [JsonProperty("squad_id")]
        public long SquadId { get; set; }

        /// <summary>
        /// ID of the wing the member is in. If not applicable, will be set to -1
        /// </summary>
        /// <value>ID of the wing the member is in. If not applicable, will be set to -1</value>
        [JsonProperty("wing_id")]
        public long WingId { get; set; }

        #endregion Properties
    }
}
