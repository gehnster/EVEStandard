using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Position : ModelBase<Position>
    {
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        [JsonPropertyName("x")]
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        [JsonPropertyName("y")]
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the z.
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        [JsonPropertyName("z")]
        public double Z { get; set; }
    }
}
