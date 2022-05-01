using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AllianceName : ModelBase<AllianceName>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonPropertyName("alliance_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonPropertyName("alliance_name")]
        public string Name { get; set; }

        #endregion Properties
    }
}