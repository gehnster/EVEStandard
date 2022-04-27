using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AssetName : ModelBase<AssetName>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        [JsonPropertyName("item_id")]
        public long ItemId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion Properties
    }
}
