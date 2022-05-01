using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MailRecipient : ModelBase<MailRecipient>
    {
        #region Enums

        /// <summary>
        /// recipient_type string
        /// </summary>
        /// <value>recipient_type string</value>
        public enum RecipientTypeEnum
        {
            alliance = 1,
            character = 2,
            corporation = 3,
            mailing_list = 4
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// recipient_id integer
        /// </summary>
        /// <value>recipient_id integer</value>
        [JsonPropertyName("recipient_id")]
        public int RecipientId { get; set; }

        /// <summary>
        /// recipient_type string
        /// </summary>
        /// <value>recipient_type string</value>
        [JsonPropertyName("recipient_type")]
        public RecipientTypeEnum RecipientType { get; set; }

        #endregion Properties
    }
}
