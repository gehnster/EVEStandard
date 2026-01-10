using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Listing of participants in a corporation freelance job
    /// </summary>
    public class CorporationFreelanceJobParticipants : ModelBase<CorporationFreelanceJobParticipants>
    {
        #region Properties

        /// <summary>
        /// List of participants
        /// </summary>
        [JsonPropertyName("participants")]
        public List<FreelanceJobParticipant> Participants { get; set; }

        /// <summary>
        /// Cursor information for pagination
        /// </summary>
        [JsonPropertyName("cursor")]
        public FreelanceJobCursor Cursor { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Participant information for a freelance job
    /// </summary>
    public class FreelanceJobParticipant : ModelBase<FreelanceJobParticipant>
    {
        #region Properties

        /// <summary>
        /// Participant's character ID
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Participant's name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Participant's state
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Participant's contributed progress
        /// </summary>
        [JsonPropertyName("contributed")]
        public long Contributed { get; set; }

        #endregion Properties
    }
}
