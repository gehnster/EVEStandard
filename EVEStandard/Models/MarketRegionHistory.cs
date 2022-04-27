using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MarketRegionHistory : ModelBase<MarketRegionHistory>
    {
        #region Properties

        /// <summary>
        /// average number
        /// </summary>
        /// <value>average number</value>
        [JsonPropertyName("average")]
        public double Average { get; set; }

        /// <summary>
        /// The date of this historical statistic entry
        /// </summary>
        /// <value>The date of this historical statistic entry</value>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// highest number
        /// </summary>
        /// <value>highest number</value>
        [JsonPropertyName("highest")]
        public double Highest { get; set; }

        /// <summary>
        /// lowest number
        /// </summary>
        /// <value>lowest number</value>
        [JsonPropertyName("lowest")]
        public double Lowest { get; set; }

        /// <summary>
        /// Total number of orders happened that day
        /// </summary>
        /// <value>Total number of orders happened that day</value>
        [JsonPropertyName("order_count")]
        public long OrderCount { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        /// <value>Total</value>
        [JsonPropertyName("volume")]
        public long Volume { get; set; }

        #endregion Properties
    }
}
