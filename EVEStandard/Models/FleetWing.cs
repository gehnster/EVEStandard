using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class FleetWing : ModelBase<FleetWing>
    {
        #region Properties

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// squads array
        /// </summary>
        /// <value>squads array</value>
        [JsonPropertyName("squads")]
        public List<FleetSquad> Squads { get; set; }

        #endregion Properties
    }

    public class FleetSquad : ModelBase<FleetSquad>
    {
        #region Properties

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [JsonPropertyName("id")] public long Id { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")] public string Name { get; set; }

        #endregion Properties
    }
}
