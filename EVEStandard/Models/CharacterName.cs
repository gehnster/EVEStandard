using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterName : ModelBase<CharacterName>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonPropertyName("character_id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonPropertyName("character_name")]
        public string Name { get; set; }

        #endregion Properties
    }
}