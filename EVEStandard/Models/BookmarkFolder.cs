using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class BookmarkFolder : ModelBase<BookmarkFolder>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the folder identifier.
        /// </summary>
        /// <value>
        /// The folder identifier.
        /// </value>
        [JsonPropertyName("folder_id")]
        public long FolderId { get; set; }

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