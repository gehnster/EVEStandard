using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class Group : ModelBase<Group>
    {
        /// <summary>
        /// group_id integer
        /// </summary>
        /// <value>group_id integer</value>
        [Required]
        [JsonProperty("group_id")]
        public int? GroupId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// published boolean
        /// </summary>
        /// <value>published boolean</value>
        [Required]
        [JsonProperty("published")]
        public bool? Published { get; set; }

        /// <summary>
        /// category_id integer
        /// </summary>
        /// <value>category_id integer</value>
        [Required]
        [JsonProperty("category_id")]
        public int? CategoryId { get; set; }

        /// <summary>
        /// types array
        /// </summary>
        /// <value>types array</value>
        [Required]
        [JsonProperty("types")]
        public List<int?> Types { get; set; }

    }
}
