using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class UpdateMailMetadata : ModelBase<UpdateMailMetadata>
    {
        /// <summary>
        /// Whether the mail is flagged as read
        /// </summary>
        /// <value>Whether the mail is flagged as read</value>
        [JsonProperty("read")]
        public bool? Read { get; set; }

        /// <summary>
        /// Labels to assign to the mail. Pre-existing labels are unassigned.
        /// </summary>
        /// <value>Labels to assign to the mail. Pre-existing labels are unassigned.</value>
        [JsonProperty("labels")]
        public List<long?> Labels { get; set; }
    }
}
