using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AsteroidBelt : ModelBase<AsteroidBelt>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the system identifier.
        /// </summary>
        /// <value>
        /// The system identifier.
        /// </value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        #endregion Properties
    }
}
