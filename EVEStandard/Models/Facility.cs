using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class Facility : ModelBase<Facility>
    {
        /// <summary>
        /// facility_id integer
        /// </summary>
        /// <value>facility_id integer</value>
        [JsonProperty("facility_id")]
        public long? FacilityId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }
    }
}
