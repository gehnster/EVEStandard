using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterContact : ModelBase<CharacterContact>
    {
        #region Properties

        /// <summary>
        /// contact_id integer
        /// </summary>
        /// <value>contact_id integer</value>
        [JsonPropertyName("contact_id")]
        public int ContactId { get; set; }

        /// <summary>
        /// contact_type string
        /// </summary>
        /// <value>contact_type string</value>
        [JsonPropertyName("contact_type")]
        public string ContactType { get; set; }

        /// <summary>
        /// Whether this contact is in the blocked list. Note a missing value denotes unknown, not true or false
        /// </summary>
        /// <value>Whether this contact is in the blocked list. Note a missing value denotes unknown, not true or false</value>
        [JsonPropertyName("is_blocked")]
        public bool? IsBlocked { get; set; }

        /// <summary>
        /// Whether this contact is being watched
        /// </summary>
        /// <value>Whether this contact is being watched</value>
        [JsonPropertyName("is_watched")]
        public bool? IsWatched { get; set; }

        /// <summary>
        /// Custom label of the contact
        /// </summary>
        /// <value>Custom label of the contact</value>
        [JsonPropertyName("label_ids")]
        public List<long> LabelIds { get; set; }

        /// <summary>
        /// Standing of the contact
        /// </summary>
        /// <value>Standing of the contact</value>
        [JsonPropertyName("standing")]
        public float Standing { get; set; }

        #endregion Properties
    }
}
