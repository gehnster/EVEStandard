using System;
using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class FleetMember : ModelBase<FleetMember>
    {
        #region Properties

        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [JsonPropertyName("character_id")]
        public int CharacterId { get; set; }

        /// <summary>
        /// join_time string
        /// </summary>
        /// <value>join_time string</value>
        [JsonPropertyName("join_time")]
        public DateTime JoinTime { get; set; }

        /// <summary>
        /// Member’s role in fleet
        /// </summary>
        /// <value>Member’s role in fleet</value>
        [JsonPropertyName("role")]
        public FleetRole Role { get; set; }

        /// <summary>
        /// Localized role names
        /// </summary>
        /// <value>Localized role names</value>
        [JsonPropertyName("role_name")]
        public string RoleName { get; set; }

        /// <summary>
        /// ship_type_id integer
        /// </summary>
        /// <value>ship_type_id integer</value>
        [JsonPropertyName("ship_type_id")]
        public int ShipTypeId { get; set; }

        /// <summary>
        /// Solar system the member is located in
        /// </summary>
        /// <value>Solar system the member is located in</value>
        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// ID of the squad the member is in. If not applicable, will be set to -1
        /// </summary>
        /// <value>ID of the squad the member is in. If not applicable, will be set to -1</value>
        [JsonPropertyName("squad_id")]
        public long SquadId { get; set; }

        /// <summary>
        /// Station in which the member is docked in, if applicable
        /// </summary>
        /// <value>Station in which the member is docked in, if applicable</value>
        [JsonPropertyName("station_id")]
        public long? StationId { get; set; }

        /// <summary>
        /// Whether the member take fleet warps
        /// </summary>
        /// <value>Whether the member take fleet warps</value>
        [JsonPropertyName("takes_fleet_warp")]
        public bool TakesFleetWarp { get; set; }

        /// <summary>
        /// ID of the wing the member is in. If not applicable, will be set to -1
        /// </summary>
        /// <value>ID of the wing the member is in. If not applicable, will be set to -1</value>
        [JsonPropertyName("wing_id")]
        public long WingId { get; set; }

        #endregion Properties
    }
}
