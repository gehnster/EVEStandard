using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Group : ModelBase<Group>
    {
        #region Properties

        /// <summary>
        /// category_id integer
        /// </summary>
        /// <value>category_id integer</value>
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// group_id integer
        /// </summary>
        /// <value>group_id integer</value>
        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

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
        public bool Published { get; set; }
        /// <summary>
        /// types array
        /// </summary>
        /// <value>types array</value>
        [JsonPropertyName("types")]
        public List<int> Types { get; set; }

        #endregion Properties

    }
}
