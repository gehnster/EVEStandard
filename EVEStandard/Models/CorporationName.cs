using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationName : ModelBase<CorporationName>
    {
        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonPropertyName("corporation_id")]
        public int CorporationId { get; set; }

        /// <summary>
        /// corporation_name string
        /// </summary>
        /// <value>corporation_name string</value>
        [JsonPropertyName("corporation_name")]
        public string Name { get; set; }
    }
}
