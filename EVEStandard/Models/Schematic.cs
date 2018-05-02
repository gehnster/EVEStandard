using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Schematic : ModelBase<Schematic>
    {
        /// <summary>
        /// schematic_name string
        /// </summary>
        /// <value>schematic_name string</value>
        [Required]
        [JsonProperty("schematic_name")]
        public string SchematicName { get; set; }

        /// <summary>
        /// Time in seconds to process a run
        /// </summary>
        /// <value>Time in seconds to process a run</value>
        [Required]
        [JsonProperty("cycle_time")]
        public int? CycleTime { get; set; }
    }
}
