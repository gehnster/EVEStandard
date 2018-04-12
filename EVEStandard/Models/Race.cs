using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class Race : ModelBase<Race>
    {
        /// <summary>
        /// race_id integer
        /// </summary>
        /// <value>race_id integer</value>
        [Required]
        [JsonProperty("race_id")]
        public int? RaceId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The alliance generally associated with this race
        /// </summary>
        /// <value>The alliance generally associated with this race</value>
        [Required]
        [JsonProperty("alliance_id")]
        public int? AllianceId { get; set; }
    }
}
