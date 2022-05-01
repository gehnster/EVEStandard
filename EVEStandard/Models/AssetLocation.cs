using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AssetLocation : ModelBase<AssetLocation>
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
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        #endregion Properties
    }
}
