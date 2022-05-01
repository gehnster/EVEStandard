using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationMemberTracking : ModelBase<CorporationMemberTracking>
    {
        #region Properties

        /// <summary>
        /// base_id integer
        /// </summary>
        /// <value>base_id integer</value>
        [JsonPropertyName("base_id")]
        public int? BaseId { get; set; }

        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [JsonPropertyName("character_id")]
        public int CharacterId { get; set; }

        /// <summary>
        /// location_id integer
        /// </summary>
        /// <value>location_id integer</value>
        [JsonPropertyName("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// logoff_date string
        /// </summary>
        /// <value>logoff_date string</value>
        [JsonPropertyName("logoff_date")]
        public DateTime? LogoffDate { get; set; }

        /// <summary>
        /// logon_date string
        /// </summary>
        /// <value>logon_date string</value>
        [JsonPropertyName("logon_date")]
        public DateTime? LogonDate { get; set; }

        /// <summary>
        /// ship_type_id integer
        /// </summary>
        /// <value>ship_type_id integer</value>
        [JsonPropertyName("ship_type_id")]
        public int? ShipTypeId { get; set; }

        /// <summary>
        /// start_date string
        /// </summary>
        /// <value>start_date string</value>
        [JsonPropertyName("start_date")]
        public DateTime? StartDate { get; set; }

        #endregion Properties
    }
}
