using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class NewMail : ModelBase<NewMail>
    {
        #region Properties

        /// <summary>
        /// approved_cost integer
        /// </summary>
        /// <value>approved_cost integer</value>
        [JsonPropertyName("approved_cost")]
        public long? ApprovedCost { get; set; }

        /// <summary>
        /// body string
        /// </summary>
        /// <value>body string</value>
        [JsonPropertyName("body")]
        public string Body { get; set; }

        /// <summary>
        /// recipients array
        /// </summary>
        /// <value>recipients array</value>
        [JsonPropertyName("recipients")]
        public List<MailRecipient> Recipients { get; set; }

        /// <summary>
        /// subject string
        /// </summary>
        /// <value>subject string</value>
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        #endregion Properties
    }
}
