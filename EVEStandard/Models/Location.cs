using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Location : ModelBase<Location>
    {
        #region Properties

        /// <summary>
        /// location_id integer
        /// </summary>
        /// <value>location_id integer</value>
        [JsonPropertyName("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// location_type string
        /// </summary>
        /// <value>location_type string</value>
        [JsonPropertyName("location_type")]
        public LocationType? LocationType { get; set; }

        #endregion Properties
    }
}
