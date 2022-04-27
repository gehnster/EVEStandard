using System;
using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Colony : ModelBase<Colony>
    {
        #region Properties

        /// <summary>
        /// last_update string
        /// </summary>
        /// <value>last_update string</value>
        [JsonPropertyName("last_update")]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// num_pins integer
        /// </summary>
        /// <value>num_pins integer</value>
        [JsonPropertyName("num_pins")]
        public int NumPins { get; set; }

        /// <summary>
        /// owner_id integer
        /// </summary>
        /// <value>owner_id integer</value>
        [JsonPropertyName("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// planet_id integer
        /// </summary>
        /// <value>planet_id integer</value>
        [JsonPropertyName("planet_id")]
        public int PlanetId { get; set; }

        /// <summary>
        /// planet_type string
        /// </summary>
        /// <value>planet_type string</value>
        [JsonPropertyName("planet_type")]
        public PlanetTypeEnum PlanetType { get; set; }

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// upgrade_level integer
        /// </summary>
        /// <value>upgrade_level integer</value>
        [JsonPropertyName("upgrade_level")]
        public int UpgradeLevel { get; set; }

        #endregion Properties
    }
}
