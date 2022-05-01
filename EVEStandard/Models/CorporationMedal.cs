using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationMedal : ModelBase<CorporationMedal>
    {
        #region Properties

        /// <summary>
        /// created_at string
        /// </summary>
        /// <value>created_at string</value>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// ID of the character who created this medal
        /// </summary>
        /// <value>ID of the character who created this medal</value>
        [JsonPropertyName("creator_id")]
        public int CreatorId { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// medal_id integer
        /// </summary>
        /// <value>medal_id integer</value>
        [JsonPropertyName("medal_id")]
        public int MedalId { get; set; }

        /// <summary>
        /// title string
        /// </summary>
        /// <value>title string</value>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        #endregion Properties
    }
}
