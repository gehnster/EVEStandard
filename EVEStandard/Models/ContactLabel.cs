using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class ContactLabel : ModelBase<ContactLabel>
    {
        /// <summary>
        /// label_id integer
        /// </summary>
        /// <value>label_id integer</value>
        [JsonPropertyName("label_id")]
        public long LabelId { get; set; }

        /// <summary>
        /// label_name string
        /// </summary>
        /// <value>label_name string</value>
        [JsonPropertyName("label_name")]
        public string LabelName { get; set; }
    }
}
