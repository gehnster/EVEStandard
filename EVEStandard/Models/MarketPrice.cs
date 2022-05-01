using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MarketPrice : ModelBase<MarketPrice>
    {
        #region Properties

        /// <summary>
        /// adjusted_price number
        /// </summary>
        /// <value>adjusted_price number</value>
        [JsonPropertyName("adjusted_price")]
        public double? AdjustedPrice { get; set; }

        /// <summary>
        /// average_price number
        /// </summary>
        /// <value>average_price number</value>
        [JsonPropertyName("average_price")]
        public double? AveragePrice { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
