using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MarketOrder : ModelBase<MarketOrder>
    {
        #region Properties

        /// <summary>
        /// duration integer
        /// </summary>
        /// <value>duration integer</value>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// is_buy_order boolean
        /// </summary>
        /// <value>is_buy_order boolean</value>
        [JsonPropertyName("is_buy_order")]
        public bool IsBuyOrder { get; set; }

        /// <summary>
        /// issued string
        /// </summary>
        /// <value>issued string</value>
        [JsonPropertyName("issued")]
        public DateTime Issued { get; set; }

        /// <summary>
        /// location_id integer
        /// </summary>
        /// <value>location_id integer</value>
        [JsonPropertyName("location_id")]
        public long LocationId { get; set; }

        /// <summary>
        /// min_volume integer
        /// </summary>
        /// <value>min_volume integer</value>
        [JsonPropertyName("min_volume")]
        public int MinVolume { get; set; }

        /// <summary>
        /// order_id integer
        /// </summary>
        /// <value>order_id integer</value>
        [JsonPropertyName("order_id")]
        public long OrderId { get; set; }

        /// <summary>
        /// price number
        /// </summary>
        /// <value>price number</value>
        [JsonPropertyName("price")]
        public double Price { get; set; }

        /// <summary>
        /// range string
        /// </summary>
        /// <value>range string</value>
        [JsonPropertyName("range")]
        public string Range { get; set; }

        /// <summary>
        /// Gets or sets the system identifier.
        /// </summary>
        /// <value>
        /// The system identifier.
        /// </value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        /// <summary>
        /// volume_remain integer
        /// </summary>
        /// <value>volume_remain integer</value>
        [JsonPropertyName("volume_remain")]
        public int VolumeRemain { get; set; }

        /// <summary>
        /// volume_total integer
        /// </summary>
        /// <value>volume_total integer</value>
        [JsonPropertyName("volume_total")]
        public int VolumeTotal { get; set; }

        #endregion Properties
    }
}
