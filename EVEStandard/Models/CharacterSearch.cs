using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterSearch : ModelBase<CharacterSearch>
    {
        #region Properties

        /// <summary>
        /// agent array
        /// </summary>
        /// <value>agent array</value>
        [JsonPropertyName("agent")]
        public List<int> Agent { get; set; }

        /// <summary>
        /// alliance array
        /// </summary>
        /// <value>alliance array</value>
        [JsonPropertyName("alliance")]
        public List<int> Alliance { get; set; }

        /// <summary>
        /// character array
        /// </summary>
        /// <value>character array</value>
        [JsonPropertyName("character")]
        public List<int> Character { get; set; }

        /// <summary>
        /// constellation array
        /// </summary>
        /// <value>constellation array</value>
        [JsonPropertyName("constellation")]
        public List<int> Constellation { get; set; }

        /// <summary>
        /// corporation array
        /// </summary>
        /// <value>corporation array</value>
        [JsonPropertyName("corporation")]
        public List<int> Corporation { get; set; }

        /// <summary>
        /// faction array
        /// </summary>
        /// <value>faction array</value>
        [JsonPropertyName("faction")]
        public List<int> Faction { get; set; }

        /// <summary>
        /// inventory_type array
        /// </summary>
        /// <value>inventory_type array</value>
        [JsonPropertyName("inventory_type")]
        public List<int> InventoryType { get; set; }

        /// <summary>
        /// region array
        /// </summary>
        /// <value>region array</value>
        [JsonPropertyName("region")]
        public List<int> Region { get; set; }

        /// <summary>
        /// solar_system array
        /// </summary>
        /// <value>solar_system array</value>
        [JsonPropertyName("solar_system")]
        public List<int> SolarSystem { get; set; }

        /// <summary>
        /// station array
        /// </summary>
        /// <value>station array</value>
        [JsonPropertyName("station")]
        public List<int> Station { get; set; }

        /// <summary>
        /// structure array
        /// </summary>
        /// <value>structure array</value>
        [JsonPropertyName("structure")]
        public List<long> Structure { get; set; }

        #endregion Properties
    }
}
