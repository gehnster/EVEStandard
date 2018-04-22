using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Bloodline : ModelBase<Bloodline>
    {
        /// <summary>
        /// bloodline_id integer
        /// </summary>
        /// <value>bloodline_id integer</value>
        [Required]
        [JsonProperty("bloodline_id")]
        public int? BloodlineId { get; set; }

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
        /// race_id integer
        /// </summary>
        /// <value>race_id integer</value>
        [Required]
        [JsonProperty("race_id")]
        public int? RaceId { get; set; }

        /// <summary>
        /// ship_type_id integer
        /// </summary>
        /// <value>ship_type_id integer</value>
        [Required]
        [JsonProperty("ship_type_id")]
        public int? ShipTypeId { get; set; }

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [Required]
        [JsonProperty("corporation_id")]
        public int? CorporationId { get; set; }

        /// <summary>
        /// perception integer
        /// </summary>
        /// <value>perception integer</value>
        [Required]
        [JsonProperty("perception")]
        public int? Perception { get; set; }

        /// <summary>
        /// willpower integer
        /// </summary>
        /// <value>willpower integer</value>
        [Required]
        [JsonProperty("willpower")]
        public int? Willpower { get; set; }

        /// <summary>
        /// charisma integer
        /// </summary>
        /// <value>charisma integer</value>
        [Required]
        [JsonProperty("charisma")]
        public int? Charisma { get; set; }

        /// <summary>
        /// memory integer
        /// </summary>
        /// <value>memory integer</value>
        [Required]
        [JsonProperty("memory")]
        public int? Memory { get; set; }

        /// <summary>
        /// intelligence integer
        /// </summary>
        /// <value>intelligence integer</value>
        [Required]
        [JsonProperty("intelligence")]
        public int? Intelligence { get; set; }
    }
}
