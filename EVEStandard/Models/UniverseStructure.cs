using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    class UniverseStructure : ModelBase<UniverseStructure>
    {
        /// <summary>The full name of the structure.</summary>
        /// <value>The full name of the structure.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>solar_system_id integer.</summary>
        /// <value>solar_system_id integer.</value>
        [JsonProperty("solar_system_id")]
        public int SolarSystemID { get; set; }

        /// <summary>type_id integer.</summary>
        /// <value>type_id integer.</value>
        [JsonProperty("type_id")]
        public int? TypeID { get; set; }

        /// <summary>Coordinates of the structure in Cartesian space relative to the Sun, in metres.</summary>
        /// <value>Coordinates of the structure in Cartesian space relative to the Sun, in metres.</value>
        [JsonProperty("position")]
        public UniverseStructurePosition Position { get; set; }
    }

    class UniverseStructurePosition : ModelBase<UniverseStructurePosition>
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
