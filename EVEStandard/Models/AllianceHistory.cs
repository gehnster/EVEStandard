﻿using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AllianceHistory : ModelBase<AllianceHistory>
    {
        #region Properties

        /// <summary>
        /// alliance_id integer
        /// </summary>
        /// <value>alliance_id integer</value>
        [JsonPropertyName("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// True if the alliance has been closed
        /// </summary>
        /// <value>True if the alliance has been closed</value>
        [JsonPropertyName("is_deleted")]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// An incrementing ID that can be used to canonically establish order of records in cases where dates may be ambiguous
        /// </summary>
        /// <value>An incrementing ID that can be used to canonically establish order of records in cases where dates may be ambiguous</value>
        [JsonPropertyName("record_id")]
        public int RecordId { get; set; }

        /// <summary>
        /// start_date string
        /// </summary>
        /// <value>start_date string</value>
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        #endregion Properties
    }
}
