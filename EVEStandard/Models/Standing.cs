using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Standing : ModelBase<Standing>
    {
        #region Enums

        /// <summary>
        /// from_type string
        /// </summary>
        /// <value>from_type string</value>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum FromTypeEnum
        {
            agent = 1,
            npc_corp = 2,
            faction = 3
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// from_id integer
        /// </summary>
        /// <value>from_id integer</value>
        [JsonPropertyName("from_id")]
        public long FromId { get; set; }

        /// <summary>
        /// from_type string
        /// </summary>
        /// <value>from_type string</value>
        [JsonPropertyName("from_type")]
        public string FromType { get; set; }

        /// <summary>
        /// Gets the FromType as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed."), JsonIgnore]
        public FromTypeEnum FromTypeToEnum 
        {
            get => (FromTypeEnum)Enum.Parse(typeof(FromTypeEnum), FromType);
        }

        /// <summary>
        /// standing number
        /// </summary>
        /// <value>standing number</value>
        [JsonPropertyName("standing")]
        public float StandingValue { get; set; }

        #endregion Properties
    }
}
