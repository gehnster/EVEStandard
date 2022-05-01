﻿using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Facility : ModelBase<Facility>
    {
        #region Properties

        /// <summary>
        /// facility_id integer
        /// </summary>
        /// <value>facility_id integer</value>
        [JsonPropertyName("facility_id")]
        public long FacilityId { get; set; }

        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
