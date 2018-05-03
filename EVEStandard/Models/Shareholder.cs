using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Shareholder : ModelBase<Shareholder>
    {
        /// <summary>
        /// shareholder_id integer
        /// </summary>
        /// <value>shareholder_id integer</value>
        [JsonProperty("shareholder_id")]
        public int? ShareholderId { get; set; }
        /// <summary>
        /// shareholder_type string
        /// </summary>
        /// <value>shareholder_type string</value>
        public enum ShareholderTypeEnum
        {
            character = 1,
            corporation = 2
        }

        /// <summary>
        /// shareholder_type string
        /// </summary>
        /// <value>shareholder_type string</value>
        [JsonProperty("shareholder_type")]
        public ShareholderTypeEnum? ShareholderType { get; set; }

        /// <summary>
        /// share_count integer
        /// </summary>
        /// <value>share_count integer</value>
        [JsonProperty("share_count")]
        public long? ShareCount { get; set; }
    }
}
