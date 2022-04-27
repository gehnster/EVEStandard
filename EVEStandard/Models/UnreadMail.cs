using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MailLabel : ModelBase<MailLabel>
    {
        #region Properties

        /// <summary>
        /// color string
        /// </summary>
        /// <value>color string</value>
        [JsonPropertyName("color")]
        public string Color { get; set; }

        /// <summary>
        /// label_id integer
        /// </summary>
        /// <value>label_id integer</value>
        [JsonPropertyName("label_id")]
        public int? LabelId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// unread_count integer
        /// </summary>
        /// <value>unread_count integer</value>
        [JsonPropertyName("unread_count")]
        public int? UnreadCount { get; set; }

        #endregion Properties
    }

    public class UnreadMail : ModelBase<UnreadMail>
    {
        #region Properties

        /// <summary>
        /// labels array
        /// </summary>
        /// <value>labels array</value>
        [JsonPropertyName("labels")]
        public List<MailLabel> Labels { get; set; }

        /// <summary>
        /// total_unread_count integer
        /// </summary>
        /// <value>total_unread_count integer</value>
        [JsonPropertyName("total_unread_count")]
        public int? TotalUnreadCount { get; set; }

        #endregion Properties
    }
}
