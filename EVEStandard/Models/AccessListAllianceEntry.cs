using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AccessListAllianceEntry : ModelBase<AccessListAllianceEntry>
    {
        #region Properties

        /// <summary>
        /// Alliance's access Valid values: Unspecified, Allowed, Blocked, Manager, Admin.
        /// </summary>
        /// <value>Alliance's access Valid values: Unspecified, Allowed, Blocked, Manager, Admin.</value>
        [JsonPropertyName("access")]
        public string Access { get; set; }

        /// <summary>
        /// Alliance's ID
        /// </summary>
        /// <value>Alliance's ID</value>
        [JsonPropertyName("alliance_id")]
        public long AllianceId { get; set; }

        #endregion Properties
    }
}
