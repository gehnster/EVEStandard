using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SolarSystemPlanet : ModelBase<SolarSystemPlanet>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the asteroid belts.
        /// </summary>
        /// <value>
        /// The asteroid belts.
        /// </value>
        [JsonPropertyName("asteroid_belts")]
        public List<long> AsteroidBelts { get; set; }

        /// <summary>
        /// Gets or sets the moons.
        /// </summary>
        /// <value>
        /// The moons.
        /// </value>
        [JsonPropertyName("moons")]
        public List<long> Moons { get; set; }

        /// <summary>
        /// Gets or sets the planet identifier.
        /// </summary>
        /// <value>
        /// The planet identifier.
        /// </value>
        [JsonPropertyName("planet_id")]
        public long PlanetId { get; set; }

        #endregion Properties
    }

    public class System : ModelBase<System>
    {
        #region Properties

        /// <summary>
        /// The constellation this solar system is in
        /// </summary>
        /// <value>The constellation this solar system is in</value>
        [JsonPropertyName("constellation_id")]
        public int ConstellationId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// planets array
        /// </summary>
        /// <value>planets array</value>
        [JsonPropertyName("planets")]
        public List<SolarSystemPlanet> Planets { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// security_class string
        /// </summary>
        /// <value>security_class string</value>
        [JsonPropertyName("security_class")]
        public string SecurityClass { get; set; }

        /// <summary>
        /// security_status number
        /// </summary>
        /// <value>security_status number</value>
        [JsonPropertyName("security_status")]
        public float SecurityStatus { get; set; }

        /// <summary>
        /// stargates array
        /// </summary>
        /// <value>stargates array</value>
        [JsonPropertyName("stargates")]
        public List<int> Stargates { get; set; }

        /// <summary>
        /// star_id integer
        /// </summary>
        /// <value>star_id integer</value>
        [JsonPropertyName("star_id")]
        public int StarId { get; set; }

        /// <summary>
        /// stations array
        /// </summary>
        /// <value>stations array</value>
        [JsonPropertyName("stations")]
        public List<int> Stations { get; set; }

        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        #endregion Properties
    }
}
