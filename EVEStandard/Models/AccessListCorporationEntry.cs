using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AccessListCorporationEntry : ModelBase<AccessListCorporationEntry>
    {
        #region Properties

        /// <summary>
        /// Corporation's access Valid values: Unspecified, Allowed, Blocked, Manager, Admin.
        /// </summary>
        /// <value>Corporation's access Valid values: Unspecified, Allowed, Blocked, Manager, Admin.</value>
        [JsonPropertyName("access")]
        public string Access { get; set; }

        /// <summary>
        /// Corporation's ID
        /// </summary>
        /// <value>Corporation's ID</value>
        [JsonPropertyName("corporation_id")]
        public long CorporationId { get; set; }

        #endregion Properties
    }
}
