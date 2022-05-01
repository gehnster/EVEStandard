using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Moon : ModelBase<Moon>
    {
        #region Properties

        /// <summary>
        /// moon_id integer
        /// </summary>
        /// <value>moon_id integer</value>
        [JsonPropertyName("moon_id")]
        public int MoonId { get; set; }

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
        /// The solar system this moon is in
        /// </summary>
        /// <value>The solar system this moon is in</value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        #endregion Properties
    }
}
