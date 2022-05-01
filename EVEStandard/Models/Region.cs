using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Region : ModelBase<Region>
    {
        #region Properties

        /// <summary>
        /// constellations array
        /// </summary>
        /// <value>constellations array</value>
        [JsonPropertyName("constellations")]
        public List<int> Constellations { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// region_id integer
        /// </summary>
        /// <value>region_id integer</value>
        [JsonPropertyName("region_id")]
        public int RegionId { get; set; }

        #endregion Properties
    }
}
