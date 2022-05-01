using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MarketGroup : ModelBase<MarketGroup>
    {
        #region Properties

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// market_group_id integer
        /// </summary>
        /// <value>market_group_id integer</value>
        [JsonPropertyName("market_group_id")]
        public int MarketGroupId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// parent_group_id integer
        /// </summary>
        /// <value>parent_group_id integer</value>
        [JsonPropertyName("parent_group_id")]
        public int? ParentGroupId { get; set; }

        /// <summary>
        /// types array
        /// </summary>
        /// <value>types array</value>
        [JsonPropertyName("types")]
        public List<int> Types { get; set; }

        #endregion Properties
    }
}
