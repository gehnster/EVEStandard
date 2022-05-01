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
        public ShareholderTypeEnum ShareholderType { get; set; }

        #endregion Properties
    }
}
