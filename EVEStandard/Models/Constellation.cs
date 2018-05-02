using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Constellation : ModelBase<Constellation>
    {
        /// <summary>
        /// constellation_id integer
        /// </summary>
        /// <value>constellation_id integer</value>
        [Required]
        [JsonProperty("constellation_id")]
        public int? ConstellationId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [Required]
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// The region this constellation is in
        /// </summary>
        /// <value>The region this constellation is in</value>
        [Required]
        [JsonProperty("region_id")]
        public int? RegionId { get; set; }

        /// <summary>
        /// systems array
        /// </summary>
        /// <value>systems array</value>
        [Required]
        [JsonProperty("systems")]
        public List<int?> Systems { get; set; }
    }
}
