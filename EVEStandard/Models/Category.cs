using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Category : ModelBase<Category>
    {
        #region Properties

        /// <summary>
        /// category_id integer
        /// </summary>
        /// <value>category_id integer</value>
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// groups array
        /// </summary>
        /// <value>groups array</value>
        [JsonPropertyName("groups")]
        public List<int> Groups { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// published boolean
        /// </summary>
        /// <value>published boolean</value>
        [JsonPropertyName("published")]
        public bool? Published { get; set; }

        #endregion Properties
    }
}
