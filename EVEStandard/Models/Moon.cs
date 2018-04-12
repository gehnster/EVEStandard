using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class Moon : ModelBase<Moon>
    {
        /// <summary>
        /// moon_id integer
        /// </summary>
        /// <value>moon_id integer</value>
        [Required]
        [JsonProperty("moon_id")]
        public int? MoonId { get; set; }

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
        /// The solar system this moon is in
        /// </summary>
        /// <value>The solar system this moon is in</value>
        [Required]
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }
    }
}
