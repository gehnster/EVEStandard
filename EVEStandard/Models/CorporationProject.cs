using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Corporation project information
    /// </summary>
    public class CorporationProject : ModelBase<CorporationProject>
    {
        #region Properties

        /// <summary>
        /// Unique identifier for this project
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The type/category of the project
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The title/name of the project
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Description of the project
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Status of the project
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// When the project was created
        /// </summary>
        [JsonPropertyName("created")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// When the project was last modified
        /// </summary>
        [JsonPropertyName("modified")]
        public DateTime Modified { get; set; }

        /// <summary>
        /// Deadline for the project, if any
        /// </summary>
        [JsonPropertyName("deadline")]
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// The character ID of the project creator
        /// </summary>
        [JsonPropertyName("creator_id")]
        public int? CreatorId { get; set; }

        #endregion Properties
    }
}
