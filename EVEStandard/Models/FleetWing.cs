using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class FleetWing : ModelBase<FleetWing>
    {
        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [JsonProperty("id")]
        public long? Id { get; set; }

        /// <summary>
        /// squads array
        /// </summary>
        /// <value>squads array</value>
        [JsonProperty("squads")]
        public List<FleetSquad> Squads { get; set; }
    }

    public class FleetSquad : ModelBase<FleetSquad>
    {
        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")] public string Name { get; set; }

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [JsonProperty("id")] public long? Id { get; set; }
    }
}
