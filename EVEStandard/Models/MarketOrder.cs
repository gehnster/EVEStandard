using System;
using System.Text;
using System.Text.Json;
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
        public long Duration { get; set; }

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
        public long MinVolume { get; set; }

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
        [JsonConverter(typeof(EveRangeStringConverter))]
        public string Range { get; set; }

        /// <summary>
        /// Gets or sets the system identifier.
        /// </summary>
        /// <value>
        /// The system identifier.
        /// </value>
        [JsonPropertyName("system_id")]
        public long SystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public long TypeId { get; set; }

        /// <summary>
        /// volume_remain integer
        /// </summary>
        /// <value>volume_remain integer</value>
        [JsonPropertyName("volume_remain")]
        public long VolumeRemain { get; set; }

        /// <summary>
        /// volume_total integer
        /// </summary>
        /// <value>volume_total integer</value>
        [JsonPropertyName("volume_total")]
        public long VolumeTotal { get; set; }

        #endregion Properties

        #region JSON Converters

        /**
         * Converts the range strings using Spans.
         * <br/>
         * Why? It is about 10% faster compared to the base method, and as string literals are interned by default, it
         * also reduces the memory usage of the MarketOrder objects in memory.
         */
        public class EveRangeStringConverter : JsonConverter<string>
        {
            // Note: ValueTextEquals accepts a ReadonlySpan<T> as parameter, strings are not directly convertable to this,
            // as a result, we need to convert them manually down to byte[] which will implicitly convert to Span during
            // use.
            // Currently, the project uses C#8, but with C#11 we could remove these and use u8 literals in the Read function,
            // such as <code>if (reader.ValueTextEquals("station"u8)) return "station";</code>.
            private static readonly byte[] StationUtf8 = Encoding.UTF8.GetBytes("station");
            private static readonly byte[] RegionUtf8 = Encoding.UTF8.GetBytes("region");
            private static readonly byte[] SolarSystemUtf8 = Encoding.UTF8.GetBytes("solarsystem");
            private static readonly byte[] Range1Utf8 = Encoding.UTF8.GetBytes("1");
            private static readonly byte[] Range2Utf8 = Encoding.UTF8.GetBytes("2");
            private static readonly byte[] Range3Utf8 = Encoding.UTF8.GetBytes("3");
            private static readonly byte[] Range4Utf8 = Encoding.UTF8.GetBytes("4");
            private static readonly byte[] Range5Utf8 = Encoding.UTF8.GetBytes("5");
            private static readonly byte[] Range10Utf8 = Encoding.UTF8.GetBytes("10");
            private static readonly byte[] Range20Utf8 = Encoding.UTF8.GetBytes("20");
            private static readonly byte[] Range30Utf8 = Encoding.UTF8.GetBytes("30");
            private static readonly byte[] Range40Utf8 = Encoding.UTF8.GetBytes("40");

            public override string Read(ref Utf8JsonReader reader, global::System.Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.ValueTextEquals(StationUtf8)) return "station";
                if (reader.ValueTextEquals(RegionUtf8)) return "region";
                if (reader.ValueTextEquals(SolarSystemUtf8)) return "solarsystem";
                if (reader.ValueTextEquals(Range1Utf8)) return "1";
                if (reader.ValueTextEquals(Range2Utf8)) return "2";
                if (reader.ValueTextEquals(Range3Utf8)) return "3";
                if (reader.ValueTextEquals(Range4Utf8)) return "4";
                if (reader.ValueTextEquals(Range5Utf8)) return "5";
                if (reader.ValueTextEquals(Range10Utf8)) return "10";
                if (reader.ValueTextEquals(Range20Utf8)) return "20";
                if (reader.ValueTextEquals(Range30Utf8)) return "30";
                if (reader.ValueTextEquals(Range40Utf8)) return "40";

                return reader.GetString();
            }

            public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value);
            }
        }

        #endregion
    }
}
