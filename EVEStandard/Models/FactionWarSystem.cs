using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class FactionWarSystem : ModelBase<FactionWarSystem>
    {
        #region Properties

        [JsonPropertyName("contested")]
        public FactionWarfareContested Contested { get; set; }

        /// <summary>
        /// occupier_faction_id integer
        /// </summary>
        /// <value>occupier_faction_id integer</value>
        [JsonPropertyName("occupier_faction_id")]
        public int OccupierFactionId { get; set; }

        /// <summary>
        /// owner_faction_id integer
        /// </summary>
        /// <value>owner_faction_id integer</value>
        [JsonPropertyName("owner_faction_id")]
        public int OwnerFactionId { get; set; }

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }
        /// <summary>
        /// victory_points integer
        /// </summary>
        /// <value>victory_points integer</value>
        [JsonPropertyName("victory_points")]
        public int VictoryPoints { get; set; }

        /// <summary>
        /// victory_points_threshold integer
        /// </summary>
        /// <value>victory_points_threshold integer</value>
        [JsonPropertyName("victory_points_threshold")]
        public int VictoryPointsThreshold { get; set; }

        #endregion Properties
    }
}
