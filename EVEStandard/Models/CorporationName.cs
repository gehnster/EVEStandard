using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class CorporationName : ModelBase<CorporationName>
    {
        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonProperty("corporation_id")]
        public int? CorporationId { get; set; }

        /// <summary>
        /// corporation_name string
        /// </summary>
        /// <value>corporation_name string</value>
        [JsonProperty("corporation_name")]
        public string Name { get; set; }
    }
}
