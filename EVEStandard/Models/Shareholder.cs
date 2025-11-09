using System;
﻿using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Shareholder : ModelBase<Shareholder>
    {
        #region Enums

        /// <summary>
        /// shareholder_type string
        /// </summary>
        /// <value>shareholder_type string</value>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ShareholderTypeEnum
        {
            character = 1,
            corporation = 2
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// share_count integer
        /// </summary>
        /// <value>share_count integer</value>
        [JsonPropertyName("share_count")]
        public long ShareCount { get; set; }

        /// <summary>
        /// shareholder_id integer
        /// </summary>
        /// <value>shareholder_id integer</value>
        [JsonPropertyName("shareholder_id")]
        public int ShareholderId { get; set; }

        /// <summary>
        /// shareholder_type string
        /// </summary>
        /// <value>shareholder_type string</value>
        [JsonPropertyName("shareholder_type")]
        public string ShareholderType { get; set; }

        /// <summary>
        /// Gets the ShareholderType as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public ShareholderTypeEnum ShareholderTypeToEnum 
        {
            get => (ShareholderTypeEnum)Enum.Parse(typeof(ShareholderTypeEnum), ShareholderType);
        }

        #endregion Properties
    }
}
