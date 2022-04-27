using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class UpdateMailMetadata : ModelBase<UpdateMailMetadata>
    {
        #region Properties

        /// <summary>
        /// Labels to assign to the mail. Pre-existing labels are unassigned.
        /// </summary>
        /// <value>Labels to assign to the mail. Pre-existing labels are unassigned.</value>
        [JsonPropertyName("labels")]
        public List<long> Labels { get; set; }

        /// <summary>
        /// Whether the mail is flagged as read
        /// </summary>
        /// <value>Whether the mail is flagged as read</value>
        [JsonPropertyName("read")]
        public bool? Read { get; set; }

        #endregion Properties
    }
}
