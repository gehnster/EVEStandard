using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class System : ModelBase<System>
    {
        /// <summary>
        /// star_id integer
        /// </summary>
        /// <value>star_id integer</value>
        [JsonProperty("star_id")]
        public int? StarId { get; set; }

        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// security_status number
        /// </summary>
        /// <value>security_status number</value>
        [JsonProperty("security_status")]
        public float? SecurityStatus { get; set; }

        /// <summary>
        /// security_class string
        /// </summary>
        /// <value>security_class string</value>
        [JsonProperty("security_class")]
        public string SecurityClass { get; set; }

        /// <summary>
        /// The constellation this solar system is in
        /// </summary>
        /// <value>The constellation this solar system is in</value>
        [JsonProperty("constellation_id")]
        public int? ConstellationId { get; set; }

        /// <summary>
        /// planets array
        /// </summary>
        /// <value>planets array</value>
        [JsonProperty("planets")]
        public List<SolarSystemPlanet> Planets { get; set; }

        /// <summary>
        /// stargates array
        /// </summary>
        /// <value>stargates array</value>
        [JsonProperty("stargates")]
        public List<int?> Stargates { get; set; }

        /// <summary>
        /// stations array
        /// </summary>
        /// <value>stations array</value>
        [JsonProperty("stations")]
        public List<int?> Stations { get; set; }
    }

    public class SolarSystemPlanet : ModelBase<SolarSystemPlanet>
    {
        [JsonProperty("asteroid_belts")]
        public List<long> AsteroidBelts { get; set; }
        [JsonProperty("moons")]
        public List<long> Moons { get; set; }
        [JsonProperty("planet_id")]
        public long PlanetId { get; set; }
    }
}
