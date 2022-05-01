using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MailList : ModelBase<MailList>
    {
        /// <summary>
        /// Mailing list ID
        /// </summary>
        /// <value>Mailing list ID</value>
        [JsonPropertyName("mailing_list_id")]
        public int MailingListId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
