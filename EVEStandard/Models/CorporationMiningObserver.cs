using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationMiningObserver : ModelBase<CorporationMiningObserver>
    {
        /// <summary>
        /// last_updated string
        /// </summary>
        /// <value>last_updated string</value>
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// The entity that was observing the asteroid field when it was mined. 
        /// </summary>
        /// <value>The entity that was observing the asteroid field when it was mined. </value>
        [JsonPropertyName("observer_id")]
        public long ObserverId { get; set; }
        /// <summary>
        /// The category of the observing entity
        /// </summary>
        /// <value>The category of the observing entity</value>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ObserverTypeEnum
        {
            structure = 1
        }

        /// <summary>
        /// The category of the observing entity
        /// </summary>
        /// <value>The category of the observing entity</value>


        [JsonPropertyName("observer_type")]

        public string ObserverType { get; set; }

        /// <summary>

        /// Gets the ObserverType as enum (may throw exception if unknown value exists).

        /// </summary>

        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]


        [JsonIgnore]

        public CorporationMiningObserver.ObserverTypeEnum ObserverTypeToEnum 

        {

            get => (CorporationMiningObserver.ObserverTypeEnum)Enum.Parse(typeof(CorporationMiningObserver.ObserverTypeEnum), ObserverType);

        }
    }
}
