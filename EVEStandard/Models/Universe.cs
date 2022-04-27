using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class NameToId
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion Properties
    }

    public class Universe : ModelBase<Universe>
    {
        #region Properties

        /// <summary>
        /// agents array
        /// </summary>
        /// <value>agents array</value>
        [JsonPropertyName("agents")]
        public List<NameToId> Agents { get; set; }

        /// <summary>
        /// alliances array
        /// </summary>
        /// <value>alliances array</value>
        [JsonPropertyName("alliances")]
        public List<NameToId> Alliances { get; set; }

        /// <summary>
        /// characters array
        /// </summary>
        /// <value>characters array</value>
        [JsonPropertyName("characters")]
        public List<NameToId> Characters { get; set; }

        /// <summary>
        /// constellations array
        /// </summary>
        /// <value>constellations array</value>
        [JsonPropertyName("constellations")]
        public List<NameToId> Constellations { get; set; }

        /// <summary>
        /// corporations array
        /// </summary>
        /// <value>corporations array</value>
        [JsonPropertyName("corporations")]
        public List<NameToId> Corporations { get; set; }

        /// <summary>
        /// factions array
        /// </summary>
        /// <value>factions array</value>
        [JsonPropertyName("factions")]
        public List<NameToId> Factions { get; set; }

        /// <summary>
        /// inventory_types array
        /// </summary>
        /// <value>inventory_types array</value>
        [JsonPropertyName("inventory_types")]
        public List<NameToId> InventoryTypes { get; set; }

        /// <summary>
        /// regions array
        /// </summary>
        /// <value>regions array</value>
        [JsonPropertyName("regions")]
        public List<NameToId> Regions { get; set; }

        /// <summary>
        /// stations array
        /// </summary>
        /// <value>stations array</value>
        [JsonPropertyName("stations")]
        public List<NameToId> Stations { get; set; }

        /// <summary>
        /// systems array
        /// </summary>
        /// <value>systems array</value>
        [JsonPropertyName("systems")]
        public List<NameToId> Systems { get; set; }

        #endregion Properties
    }
}
