using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Planet : ModelBase<Planet>
    {
        #region Properties

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// planet_id integer
        /// </summary>
        /// <value>planet_id integer</value>
        [JsonPropertyName("planet_id")]
        public int PlanetId { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// The solar system this planet is in
        /// </summary>
        /// <value>The solar system this planet is in</value>
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
}
