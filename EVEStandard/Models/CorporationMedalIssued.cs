using System;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CorporationMedalIssued : ModelBase<CorporationMedalIssued>
    {
        /// <summary>
        /// medal_id integer
        /// </summary>
        /// <value>medal_id integer</value>
        [JsonProperty("medal_id")]
        public int? MedalId { get; set; }

        /// <summary>
        /// ID of the character who was rewarded this medal
        /// </summary>
        /// <value>ID of the character who was rewarded this medal</value>
        [JsonProperty("character_id")]
        public int? CharacterId { get; set; }

        /// <summary>
        /// reason string
        /// </summary>
        /// <value>reason string</value>
        [JsonProperty("reason")]
        public string Reason { get; set; }
        /// <summary>
        /// status string
        /// </summary>
        /// <value>status string</value>
        public enum StatusEnum
        {
            Private = 1,
            Public = 2
        }

        /// <summary>
        /// status string
        /// </summary>
        /// <value>status string</value>
        [JsonProperty("status")]
        public StatusEnum? Status { get; set; }

        /// <summary>
        /// ID of the character who issued the medal
        /// </summary>
        /// <value>ID of the character who issued the medal</value>
        [JsonProperty("issuer_id")]
        public int? IssuerId { get; set; }

        /// <summary>
        /// issued_at string
        /// </summary>
        /// <value>issued_at string</value>
        [JsonProperty("issued_at")]
        public DateTime? IssuedAt { get; set; }
}
}
