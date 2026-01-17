using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AllianceName : ModelBase<AllianceName>
    {
        /// <summary>
        /// alliance_id integer
        /// </summary>
        /// <value>alliance_id integer</value>
        [JsonPropertyName("alliance_id")]
        public long AllianceId { get; set; }

        /// <summary>
        /// alliance_name string
        /// </summary>
        /// <value>alliance_name string</value>
        [JsonPropertyName("alliance_name")]
        public string Name { get; set; }
    }
}