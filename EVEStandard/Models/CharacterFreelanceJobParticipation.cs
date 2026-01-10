using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Character's participation in a freelance job
    /// </summary>
    public class CharacterFreelanceJobParticipation : ModelBase<CharacterFreelanceJobParticipation>
    {
        #region Properties

        /// <summary>
        /// Your participation status
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Your contribution
        /// </summary>
        [JsonPropertyName("contributed")]
        public long Contributed { get; set; }

        /// <summary>
        /// Moment this information was last modified
        /// </summary>
        [JsonPropertyName("last_modified")]
        public DateTime LastModified { get; set; }

        #endregion Properties
    }
}
