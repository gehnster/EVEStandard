using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Search : ModelBase<Search>
    {
        #region Properties

        /// <summary>
        /// agent array
        /// </summary>
        /// <value>agent array</value>
        [JsonPropertyName("agent")]
        public List<long> Agent { get; set; }

        /// <summary>
        /// alliance array
        /// </summary>
        /// <value>alliance array</value>
        [JsonPropertyName("alliance")]
        public List<long> Alliance { get; set; }

        /// <summary>
        /// character array
        /// </summary>
        /// <value>character array</value>
        [JsonPropertyName("character")]
        public List<long> Character { get; set; }

        /// <summary>
        /// constellation array
        /// </summary>
        /// <value>constellation array</value>
        [JsonPropertyName("constellation")]
        public List<long> Constellation { get; set; }

        /// <summary>
        /// corporation array
        /// </summary>
        /// <value>corporation array</value>
        [JsonPropertyName("corporation")]
        public List<long> Corporation { get; set; }

        /// <summary>
        /// faction array
        /// </summary>
        /// <value>faction array</value>
        [JsonPropertyName("faction")]
        public List<long> Faction { get; set; }

        /// <summary>
        /// inventory_type array
        /// </summary>
        /// <value>inventory_type array</value>
        [JsonPropertyName("inventory_type")]
        public List<long> InventoryType { get; set; }

        /// <summary>
        /// region array
        /// </summary>
        /// <value>region array</value>
        [JsonPropertyName("region")]
        public List<long> Region { get; set; }

        /// <summary>
        /// solar_system array
        /// </summary>
        /// <value>solar_system array</value>
        [JsonPropertyName("solar_system")]
        public List<long> SolarSystem { get; set; }

        /// <summary>
        /// station array
        /// </summary>
        /// <value>station array</value>
        [JsonPropertyName("station")]
        public List<long> Station { get; set; }

        #endregion Properties
    }
}
