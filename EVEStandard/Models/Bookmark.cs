using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Bookmark : ModelBase<Bookmark>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the bookmark identifier.
        /// </summary>
        /// <value>
        /// The bookmark identifier.
        /// </value>
        [JsonPropertyName("bookmark_id")]
        public int BookmarkId { get; set; }

        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        /// <value>
        /// The coordinates.
        /// </value>
        [JsonPropertyName("coordinates")]
        public Position Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the creator identifier.
        /// </summary>
        /// <value>
        /// The creator identifier.
        /// </value>
        [JsonPropertyName("creator_id")]
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the folder identifier.
        /// </summary>
        /// <value>
        /// The folder identifier.
        /// </value>
        [JsonPropertyName("folder_id")]
        public int? FolderId { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        [JsonPropertyName("item")]
        public Item Item { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        [JsonPropertyName("label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        #endregion Properties
    }
}