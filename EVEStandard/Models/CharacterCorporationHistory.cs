﻿using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterCorporationHistory : ModelBase<CharacterCorporationHistory>
    {
        #region Properties

        /// <summary>
        ///     corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonPropertyName("corporation_id")]
        public int CorporationId { get; set; }

        /// <summary>
        ///     True if the corporation has been deleted
        /// </summary>
        /// <value>True if the corporation has been deleted</value>
        [JsonPropertyName("is_deleted")]
        public bool? IsDeleted { get; set; }

        /// <summary>
        ///     An incrementing ID that can be used to canonically establish order of records in cases where dates may be ambiguous
        /// </summary>
        /// <value>
        ///     An incrementing ID that can be used to canonically establish order of records in cases where dates may be
        ///     ambiguous
        /// </value>
        [JsonPropertyName("record_id")]
        public int RecordId { get; set; }

        /// <summary>
        ///     start_date string
        /// </summary>
        /// <value>start_date string</value>
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        #endregion Properties
    }
}