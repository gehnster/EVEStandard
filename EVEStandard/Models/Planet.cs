using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class Planet : ModelBase<Planet>
    {
        /// <summary>
        /// planet_id integer
        /// </summary>
        /// <value>planet_id integer</value>
        [Required]
        [JsonProperty("planet_id")]
        public int? PlanetId { get; set; }

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
        /// The solar system this planet is in
        /// </summary>
        /// <value>The solar system this planet is in</value>
        [Required]
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }
    }
}
