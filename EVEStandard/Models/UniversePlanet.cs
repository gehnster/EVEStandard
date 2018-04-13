using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    class UniversePlanet : ModelBase<UniversePlanet>
    {
        /// <summary>planet_id integer.</summary>
        /// <value>planet_id integer.</value>
        [JsonProperty("planet_id")]
        public int PlanetID { get; set; }

        /// <summary>name string.</summary>
        /// <value>name string.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>type_id integer.</summary>
        /// <value>type_id integer.</value>
        [JsonProperty("type_id")]
        public int TypeID { get; set; }

        /// <summary>position object.</summary>
        /// <value>position object.</value>
        [JsonProperty("position")]
        public UniversePlanetPosition Position { get; set; }

        /// <summary>The solar system this planet is in</summary>
        /// <value>The solar system this planet is in</value>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }

    }

    class UniversePlanetPosition
    {
        /// <summary>x number.</summary>
        /// <value>x number.</value>
        [JsonProperty("x")]
        public float X { get; set; }

        /// <summary>y number.</summary>
        /// <value>y number.</value>
        [JsonProperty("y")]
        public float Y { get; set; }

        /// <summary>z number</summary>
        /// <value>z number</value>
        [JsonProperty("z")]
        public float Z { get; set; }
    }
}
