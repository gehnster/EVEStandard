using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class AllianceHistory : ModelBase<AllianceHistory>
    {
        /// <summary>
        /// start_date string
        /// </summary>
        /// <value>start_date string</value>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// alliance_id integer
        /// </summary>
        /// <value>alliance_id integer</value>
        [JsonProperty("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// True if the alliance has been closed
        /// </summary>
        /// <value>True if the alliance has been closed</value>
        [JsonProperty("is_deleted")]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// An incrementing ID that can be used to canonically establish order of records in cases where dates may be ambiguous
        /// </summary>
        /// <value>An incrementing ID that can be used to canonically establish order of records in cases where dates may be ambiguous</value>
        [JsonProperty("record_id")]
        public int? RecordId { get; set; }
    }
}
