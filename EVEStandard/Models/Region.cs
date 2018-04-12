using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class Region : ModelBase<Region>
    {
        /// <summary>
        /// region_id integer
        /// </summary>
        /// <value>region_id integer</value>
        [Required]
        [JsonProperty("region_id")]
        public int? RegionId { get; set; }

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
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// constellations array
        /// </summary>
        /// <value>constellations array</value>
        [Required]
        [JsonProperty("constellations")]
        public List<int?> Constellations { get; set; }
    }
}
