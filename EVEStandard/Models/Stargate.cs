using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Stargate : ModelBase<Stargate>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets Destination
        /// </summary>
        [JsonPropertyName("destination")]
        public StargateDestination Destination { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// stargate_id integer
        /// </summary>
        /// <value>stargate_id integer</value>
        [JsonPropertyName("stargate_id")]
        public int StargateId { get; set; }
        /// <summary>
        /// The solar system this stargate is in
        /// </summary>
        /// <value>The solar system this stargate is in</value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }

    public class StargateDestination : ModelBase<StargateDestination>
    {
        #region Properties

        /// <summary>
        /// The stargate this stargate connects to
        /// </summary>
        /// <value>The stargate this stargate connects to</value>
        [JsonPropertyName("stargate_id")]
        public int StargateId { get; set; }

        /// <summary>
        /// The solar system this stargate connects to
        /// </summary>
        /// <value>The solar system this stargate connects to</value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        #endregion Properties
    }
}
