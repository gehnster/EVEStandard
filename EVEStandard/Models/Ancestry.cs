using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class Ancestry : ModelBase<Ancestry>
    {
        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [Required]
        [JsonProperty("id")]
        public int? Id { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The bloodline associated with this ancestry
        /// </summary>
        /// <value>The bloodline associated with this ancestry</value>
        [Required]
        [JsonProperty("bloodline_id")]
        public int? BloodlineId { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// short_description string
        /// </summary>
        /// <value>short_description string</value>
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// icon_id integer
        /// </summary>
        /// <value>icon_id integer</value>
        [JsonProperty("icon_id")]
        public int? IconId { get; set; }
    }
}
