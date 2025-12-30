using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Character's contribution to a corporation project
    /// </summary>
    public class CorporationProjectContribution : ModelBase<CorporationProjectContribution>
    {
        #region Properties

        /// <summary>
        /// Your contribution
        /// </summary>
        [JsonPropertyName("contributed")]
        public long Contributed { get; set; }

        /// <summary>
        /// Moment this information was last modified
        /// </summary>
        [JsonPropertyName("last_modified")]
        public DateTime? LastModified { get; set; }

        #endregion Properties
    }
}
