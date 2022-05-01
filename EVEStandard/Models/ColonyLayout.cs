using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class ColonyLayout : ModelBase<ColonyLayout>
    {
        /// <summary>
        /// links array
        /// </summary>
        /// <value>links array</value>
        [JsonPropertyName("links")]
        public List<ColonyLink> Links { get; set; }

        /// <summary>
        /// pins array
        /// </summary>
        /// <value>pins array</value>
        [JsonPropertyName("pins")]
        public List<ColonyPin> Pins { get; set; }

        /// <summary>
        /// routes array
        /// </summary>
        /// <value>routes array</value>
        [JsonPropertyName("routes")]
        public List<ColonyRoute> Routes { get; set; }
    }

    public class ColonyLink : ModelBase<ColonyLink>
    {
        /// <summary>
        /// source_pin_id integer
        /// </summary>
        /// <value>source_pin_id integer</value>
        [JsonPropertyName("source_pin_id")]
        public long SourcePinId { get; set; }

        /// <summary>
        /// destination_pin_id integer
        /// </summary>
        /// <value>destination_pin_id integer</value>
        [JsonPropertyName("destination_pin_id")]
        public long DestinationPinId { get; set; }

        /// <summary>
        /// link_level integer
        /// </summary>
        /// <value>link_level integer</value>
        [JsonPropertyName("link_level")]
        public int LinkLevel { get; set; }
    }

    public class ColonyPin : ModelBase<ColonyPin>
    {
        /// <summary>
        /// latitude number
        /// </summary>
        /// <value>latitude number</value>
        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// longitude number
        /// </summary>
        /// <value>longitude number</value>
        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }

        /// <summary>
        /// pin_id integer
        /// </summary>
        /// <value>pin_id integer</value>
        [JsonPropertyName("pin_id")]
        public long PinId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        /// <summary>
        /// schematic_id integer
        /// </summary>
        /// <value>schematic_id integer</value>
        [JsonPropertyName("schematic_id")]
        public int? SchematicId { get; set; }

        /// <summary>
        /// Gets or Sets ExtractorDetails
        /// </summary>
        [JsonPropertyName("extractor_details")]
        public ColonyExtractorDetails ExtractorDetails { get; set; }

        /// <summary>
        /// Gets or Sets FactoryDetails
        /// </summary>
        [JsonPropertyName("factory_details")]
        public ColonyFactoryDetails FactoryDetails { get; set; }

        /// <summary>
        /// contents array
        /// </summary>
        /// <value>contents array</value>
        [JsonPropertyName("contents")]
        public List<ColonyContent> Contents { get; set; }

        /// <summary>
        /// install_time string
        /// </summary>
        /// <value>install_time string</value>
        [JsonPropertyName("install_time")]
        public DateTime? InstallTime { get; set; }

        /// <summary>
        /// expiry_time string
        /// </summary>
        /// <value>expiry_time string</value>
        [JsonPropertyName("expiry_time")]
        public DateTime? ExpiryTime { get; set; }

        /// <summary>
        /// last_cycle_start string
        /// </summary>
        /// <value>last_cycle_start string</value>
        [JsonPropertyName("last_cycle_start")]
        public DateTime? LastCycleStart { get; set; }
    }

    public class ColonyRoute : ModelBase<ColonyRoute>
    {
        /// <summary>
        /// route_id integer
        /// </summary>
        /// <value>route_id integer</value>
        [JsonPropertyName("route_id")]
        public long RouteId { get; set; }

        /// <summary>
        /// source_pin_id integer
        /// </summary>
        /// <value>source_pin_id integer</value>
        [JsonPropertyName("source_pin_id")]
        public long SourcePinId { get; set; }

        /// <summary>
        /// destination_pin_id integer
        /// </summary>
        /// <value>destination_pin_id integer</value>
        [JsonPropertyName("destination_pin_id")]
        public long DestinationPinId { get; set; }

        /// <summary>
        /// content_type_id integer
        /// </summary>
        /// <value>content_type_id integer</value>
        [JsonPropertyName("content_type_id")]
        public int ContentTypeId { get; set; }

        /// <summary>
        /// quantity number
        /// </summary>
        /// <value>quantity number</value>
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }

        /// <summary>
        /// list of pin ID waypoints
        /// </summary>
        /// <value>list of pin ID waypoints</value>
        [JsonPropertyName("waypoints")]
        public List<long> Waypoints { get; set; }
    }

    public class ColonyExtractorDetails : ModelBase<ColonyExtractorDetails>
    {
        /// <summary>
        /// heads array
        /// </summary>
        /// <value>heads array</value>
        [JsonPropertyName("heads")]
        public List<ColonyHead> Heads { get; set; }

        /// <summary>
        /// product_type_id integer
        /// </summary>
        /// <value>product_type_id integer</value>
        [JsonPropertyName("product_type_id")]
        public int? ProductTypeId { get; set; }

        /// <summary>
        /// in seconds
        /// </summary>
        /// <value>in seconds</value>
        [JsonPropertyName("cycle_time")]
        public int? CycleTime { get; set; }

        /// <summary>
        /// head_radius number
        /// </summary>
        /// <value>head_radius number</value>
        [JsonPropertyName("head_radius")]
        public float? HeadRadius { get; set; }

        /// <summary>
        /// qty_per_cycle integer
        /// </summary>
        /// <value>qty_per_cycle integer</value>
        [JsonPropertyName("qty_per_cycle")]
        public int? QtyPerCycle { get; set; }
    }

    public class ColonyFactoryDetails : ModelBase<ColonyFactoryDetails>
    {
        /// <summary>
        /// schematic_id integer
        /// </summary>
        /// <value>schematic_id integer</value>
        [JsonPropertyName("schematic_id")]
        public int SchematicId { get; set; }
    }

    public class ColonyContent : ModelBase<ColonyContent>
    {
        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        /// <summary>
        /// amount integer
        /// </summary>
        /// <value>amount integer</value>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }
    }

    public class ColonyHead : ModelBase<ColonyHead>
    {
        /// <summary>
        /// head_id integer
        /// </summary>
        /// <value>head_id integer</value>
        [JsonPropertyName("head_id")]
        public int HeadId { get; set; }

        /// <summary>
        /// latitude number
        /// </summary>
        /// <value>latitude number</value>
        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// longitude number
        /// </summary>
        /// <value>longitude number</value>
        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }
    }
}
