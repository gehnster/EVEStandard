using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class SystemJumps : ModelBase<SystemJumps>
    {
        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [Required]
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }

        /// <summary>
        /// ship_jumps integer
        /// </summary>
        /// <value>ship_jumps integer</value>
        [Required]
        [JsonProperty("ship_jumps")]
        public int? ShipJumps { get; set; }

    }
}
