using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Stargate : ModelBase<Stargate>
    {
        /// <summary>
        /// stargate_id integer
        /// </summary>
        /// <value>stargate_id integer</value>
        [Required]
        [JsonProperty("stargate_id")]
        public int? StargateId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [Required]
        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [Required]
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// The solar system this stargate is in
        /// </summary>
        /// <value>The solar system this stargate is in</value>
        [Required]
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }

        /// <summary>
        /// Gets or Sets Destination
        /// </summary>
        [Required]
        [JsonProperty("destination")]
        public Location Destination { get; set; }
    }
}
