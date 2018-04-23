using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Enumerations;
    using Newtonsoft.Json;

    public class CharacterFleetInfo : ModelBase<CharacterFleetInfo>
    {
        /// <summary>
        /// The character&#39;s current fleet ID
        /// </summary>
        /// <value>The character&#39;s current fleet ID</value>
        [JsonProperty("fleet_id")]
        public long? FleetId { get; set; }

        /// <summary>
        /// ID of the wing the member is in. If not applicable, will be set to -1
        /// </summary>
        /// <value>ID of the wing the member is in. If not applicable, will be set to -1</value>
        [JsonProperty("wing_id")]
        public long? WingId { get; set; }

        /// <summary>
        /// ID of the squad the member is in. If not applicable, will be set to -1
        /// </summary>
        /// <value>ID of the squad the member is in. If not applicable, will be set to -1</value>
        [JsonProperty("squad_id")]
        public long? SquadId { get; set; }

        /// <summary>
        /// Member’s role in fleet
        /// </summary>
        /// <value>Member’s role in fleet</value>
        [JsonProperty("role")]
        public FleetRole? Role { get; set; }
    }
}
