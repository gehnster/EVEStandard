using System;
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
        public string LocationType { get; set; }

        /// <summary>
        /// Gets the LocationType as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public Enumerations.LocationType? LocationTypeToEnum 
        {
            get => LocationType != null ? (Enumerations.LocationType?)Enum.Parse(typeof(Enumerations.LocationType), LocationType) : null;
        }

        #endregion Properties
    }
}
