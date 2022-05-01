using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Structure : ModelBase<Structure>
    {
        #region Properties

        /// <summary>
        /// The full name of the structure
        /// </summary>
        /// <value>The full name of the structure</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the corporation who owns this particular structure
        /// </summary>
        /// <value>The ID of the corporation who owns this particular structure</value>
        [JsonPropertyName("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int? TypeId { get; set; }

        #endregion Properties
    }
}
