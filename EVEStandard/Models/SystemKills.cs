using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class SystemKills : ModelBase<SystemKills>
    {
        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [Required]
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }

        /// <summary>
        /// Number of player ships killed in this system
        /// </summary>
        /// <value>Number of player ships killed in this system</value>
        [Required]
        [JsonProperty("ship_kills")]
        public int? ShipKills { get; set; }

        /// <summary>
        /// Number of NPC ships killed in this system
        /// </summary>
        /// <value>Number of NPC ships killed in this system</value>
        [Required]
        [JsonProperty("npc_kills")]
        public int? NpcKills { get; set; }

        /// <summary>
        /// Number of pods killed in this system
        /// </summary>
        /// <value>Number of pods killed in this system</value>
        [Required]
        [JsonProperty("pod_kills")]
        public int? PodKills { get; set; }
    }
}
