using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Faction : ModelBase<Faction>
    {
        #region Properties

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonPropertyName("corporation_id")]
        public int? CorporationId { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonPropertyName("faction_id")]
        public int FactionId { get; set; }

        /// <summary>
        /// is_unique boolean
        /// </summary>
        /// <value>is_unique boolean</value>
        [JsonPropertyName("is_unique")]
        public bool IsUnique { get; set; }

        /// <summary>
        /// militia_corporation_id integer
        /// </summary>
        /// <value>militia_corporation_id integer</value>
        [JsonPropertyName("militia_corporation_id")]
        public int? MilitiaCorporationId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// size_factor number
        /// </summary>
        /// <value>size_factor number</value>
        [JsonPropertyName("size_factor")]
        public float SizeFactor { get; set; }

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [JsonPropertyName("solar_system_id")]
        public int? SolarSystemId { get; set; }
        /// <summary>
        /// station_count integer
        /// </summary>
        /// <value>station_count integer</value>
        [JsonPropertyName("station_count")]
        public int StationCount { get; set; }

        /// <summary>
        /// station_system_count integer
        /// </summary>
        /// <value>station_system_count integer</value>
        [JsonPropertyName("station_system_count")]
        public int StationSystemCount { get; set; }

        #endregion Properties
    }
}
