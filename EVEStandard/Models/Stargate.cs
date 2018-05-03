using EVEStandard.Models;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Stargate : ModelBase<Stargate>
    {
        /// <summary>
        /// stargate_id integer
        /// </summary>
        /// <value>stargate_id integer</value>
        [JsonProperty("stargate_id")]
        public int? StargateId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// The solar system this stargate is in
        /// </summary>
        /// <value>The solar system this stargate is in</value>
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }

        /// <summary>
        /// Gets or Sets Destination
        /// </summary>
        [JsonProperty("destination")]
        public StargateDestination Destination { get; set; }
    }

    public class StargateDestination : ModelBase<StargateDestination>
    {
        /// <summary>
        /// The solar system this stargate connects to
        /// </summary>
        /// <value>The solar system this stargate connects to</value>
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }

        /// <summary>
        /// The stargate this stargate connects to
        /// </summary>
        /// <value>The stargate this stargate connects to</value>
        [JsonProperty("stargate_id")]
        public int? StargateId { get; set; }
    }
}
