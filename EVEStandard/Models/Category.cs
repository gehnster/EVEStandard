using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Category : ModelBase<Category>
    {
        /// <summary>
        /// category_id integer
        /// </summary>
        /// <value>category_id integer</value>
        [Required]
        [JsonProperty("category_id")]
        public int? CategoryId { get; set; }

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
        /// groups array
        /// </summary>
        /// <value>groups array</value>
        [Required]
        [JsonProperty("groups")]
        public List<int?> Groups { get; set; }

    }
}
