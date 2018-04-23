using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class MarketPrice : ModelBase<MarketPrice>
    {
        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        /// <summary>
        /// average_price number
        /// </summary>
        /// <value>average_price number</value>
        [JsonProperty("average_price")]
        public double? AveragePrice { get; set; }

        /// <summary>
        /// adjusted_price number
        /// </summary>
        /// <value>adjusted_price number</value>
        [JsonProperty("adjusted_price")]
        public double? AdjustedPrice { get; set; }
    }
}
