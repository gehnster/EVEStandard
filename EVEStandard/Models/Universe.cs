using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class Universe : ModelBase<Universe>
    {
        /// <summary>
        /// agents array
        /// </summary>
        /// <value>agents array</value>
        [JsonProperty("agents")]
        public List<Agent> Agents { get; set; }

        /// <summary>
        /// alliances array
        /// </summary>
        /// <value>alliances array</value>
        [JsonProperty("alliances")]
        public List<Alliance> Alliances { get; set; }

        /// <summary>
        /// characters array
        /// </summary>
        /// <value>characters array</value>
        [JsonProperty("characters")]
        public List<CharacterInfo> Characters { get; set; }

        /// <summary>
        /// constellations array
        /// </summary>
        /// <value>constellations array</value>
        [JsonProperty("constellations")]
        public List<Constellation> Constellations { get; set; }

        /// <summary>
        /// corporations array
        /// </summary>
        /// <value>corporations array</value>
        [JsonProperty("corporations")]
        public List<CorporationInfo> Corporations { get; set; }

        /// <summary>
        /// factions array
        /// </summary>
        /// <value>factions array</value>
        [JsonProperty("factions")]
        public List<Faction> Factions { get; set; }

        /// <summary>
        /// inventory_types array
        /// </summary>
        /// <value>inventory_types array</value>
        [JsonProperty("inventory_types")]
        public List<Type> InventoryTypes { get; set; }

        /// <summary>
        /// regions array
        /// </summary>
        /// <value>regions array</value>
        [JsonProperty("regions")]
        public List<Region> Regions { get; set; }

        /// <summary>
        /// systems array
        /// </summary>
        /// <value>systems array</value>
        [JsonProperty("systems")]
        public List<System> Systems { get; set; }

        /// <summary>
        /// stations array
        /// </summary>
        /// <value>stations array</value>
        [JsonProperty("stations")]
        public List<Station> Stations { get; set; }
    }
}
