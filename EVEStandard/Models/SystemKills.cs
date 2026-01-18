using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SystemKills : ModelBase<SystemKills>
    {
        #region Properties

        /// <summary>
        /// Number of NPC ships killed in this system
        /// </summary>
        /// <value>Number of NPC ships killed in this system</value>
        [JsonPropertyName("npc_kills")]
        public long NpcKills { get; set; }

        /// <summary>
        /// Number of pods killed in this system
        /// </summary>
        /// <value>Number of pods killed in this system</value>
        [JsonPropertyName("pod_kills")]
        public long PodKills { get; set; }

        /// <summary>
        /// Number of player ships killed in this system
        /// </summary>
        /// <value>Number of player ships killed in this system</value>
        [JsonPropertyName("ship_kills")]
        public long ShipKills { get; set; }

        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [JsonPropertyName("system_id")]
        public long SystemId { get; set; }

        #endregion Properties
    }
}
