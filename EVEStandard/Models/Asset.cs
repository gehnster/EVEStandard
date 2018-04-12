namespace EVEStandard.Models
{
    using System;
    using System.Text;
    using Enumerations;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Asset : ModelBase<Asset>
    {
        /// <summary>
        ///     location_type string
        /// </summary>
        /// <value>location_type string</value>
        public enum LocationTypeEnum
        {
            station,
            solar_system,
            other
        }

        [JsonProperty("location_flag"), JsonConverter(typeof(StringEnumConverter))] public LocationFlag LocationFlag { get; set; }

        [JsonProperty("location_id")] public long LocationId { get; set; }

        [JsonProperty("is_singleton")] public bool IsSingleton { get; set; }

        [JsonProperty("type_id")] public int TypeId { get; set; }

        [JsonProperty("item_id")] public long ItemId { get; set; }

        [JsonProperty("location_type"), JsonConverter(typeof(StringEnumConverter))]
        public LocationTypeEnum LocationType { get; set; }

        [JsonProperty("quantity")] public long Quantity { get; set; }
    }
}