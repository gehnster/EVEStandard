using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    //Response: get_universe_systems_ok
    class UniverseSystemIDs : ModelBase<UniverseSystemIDs>
    {
        /// <summary>A list of solar system ids</summary>
        /// <value>A list of solar system ids</value>
        [JsonProperty("get_universe_systems_ok")]
        public List<int> UniverseSytems { get; set; }
    }

    //Response: get_universe_system_id_ok
    class UniverseSystemInfo : ModelBase<UniverseSystemInfo>
    {
        /// <summary>star_id integer.</summary>
        /// <value>star_id integer.</value>
        [JsonProperty("get_universe_systems_system_id_ok")]
        public int StarId { get; set; }

        /// <summary>system_id integer.</summary>
        /// <value>system_id integer.</value>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }

        /// <summary>name string.</summary>
        /// <value>name string.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>position object.</summary>
        /// <value>position object.</value>
        [JsonProperty("position")]
        public UniverseSystemPosition Position { get; set; }

        /// <summary>security_status number.</summary>
        /// <value>security_status number.</value>
        [JsonProperty("security_status")]
        public float SecurityStatus { get; set; }

        /// <summary>security_class string.</summary>
        /// <value>security_class string.</value>
        [JsonProperty("security_class")]
        public string SecurityClass { get; set; }

        /// <summary>The constellation this solar system is in.</summary>
        /// <value>The constellation this solar system is in.</value>
        [JsonProperty("constellation_id")]
        public int ConstellationID { get; set; }

        /// <summary>planets list.</summary>
        /// <value>planets list.</value>
        [JsonProperty("planets")]
        public List<UniverseSystemIDPlanet> Planets { get; set; }

        /// <summary>stargates list.</summary>
        /// <value>stargates list.</value>
        [JsonProperty("stargates")]
        public List<int?> Stargates { get; set; }

        /// <summary>stations list.</summary>
        /// <value>stations list.</value>
        [JsonProperty("stations")]
        public List<int?> Stations { get; set; }
}

    //Response: get_universe_system_system_id_position
    class UniverseSystemPosition : ModelBase<UniverseSystemPosition>
    {
        /// <summary>x number.</summary>
        /// <value>x number.</value>
        [JsonProperty("x")]
        public float X { get; set; }

        /// <summary>y number.</summary>
        /// <value>y number.</value>
        [JsonProperty("y")]
        public float Y { get; set; }

        /// <summary>z number.</summary>
        /// <value>z number.</value>
        [JsonProperty("z")]
        public float Z { get; set; }
    }

    //Response: get_universe_systems_system_id_planet
    class UniverseSystemIDPlanet : ModelBase<UniverseSystemIDPlanet>
    {
        /// <summary>planet_id integer.</summary>
        /// <value>planet_id integer.</value>
        [JsonProperty("planet_id")]
        public int PlanetID { get; set; }

        /// <summary>moons list.</summary>
        /// <value>moons list.</value>
        [JsonProperty("moons")]
        public List<int?> Moons { get; set; }

        /// <summary>asteroid_belts list.</summary>
        /// <value>asteroid_belts list.</value>
        [JsonProperty("asteroid_belts")]
        public List<int?> AsteroidBelts { get; set; }
}
}
