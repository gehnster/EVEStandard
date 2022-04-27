using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SovereigntyMap : ModelBase<SovereigntyMap>
    {
        #region Properties

        /// <summary>
        /// alliance_id integer
        /// </summary>
        /// <value>alliance_id integer</value>
        [JsonPropertyName("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonPropertyName("corporation_id")]
        public int? CorporationId { get; set; }

        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }

        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        #endregion Properties
    }
}
