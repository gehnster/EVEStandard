using EVEStandard.Enumerations;
using System.Text.Json.Serialization;
using System;

namespace EVEStandard.Models
{
    public class CharacterFleetInfo : ModelBase<CharacterFleetInfo>
    {
        #region Properties

        /// <summary>
        /// Character ID of the current fleet boss
        /// </summary>
        [JsonPropertyName("fleet_boss_id")]
        public long FleetBossId { get; set; }

        /// <summary>
        /// The character’s current fleet ID
        /// </summary>
        /// <value>The character&#39;s current fleet ID</value>
        [JsonPropertyName("fleet_id")]
        public long FleetId { get; set; }

        /// <summary>
        /// Member’s role in fleet
        /// </summary>
        /// <value>Member’s role in fleet</value>



        [JsonPropertyName("role")]


        public string Role { get; set; }


        /// <summary>


        /// Gets the Role as enum (may throw exception if unknown value exists).


        /// </summary>


        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]



        [JsonIgnore]


        public Enumerations.FleetRole RoleToEnum 


        {


            get => (Enumerations.FleetRole)Enum.Parse(typeof(Enumerations.FleetRole), Role);


        }

        /// <summary>
        /// ID of the squad the member is in. If not applicable, will be set to -1
        /// </summary>
        /// <value>ID of the squad the member is in. If not applicable, will be set to -1</value>
        [JsonPropertyName("squad_id")]
        public long SquadId { get; set; }

        /// <summary>
        /// ID of the wing the member is in. If not applicable, will be set to -1
        /// </summary>
        /// <value>ID of the wing the member is in. If not applicable, will be set to -1</value>
        [JsonPropertyName("wing_id")]
        public long WingId { get; set; }

        #endregion Properties
    }
}
