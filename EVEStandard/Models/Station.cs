using System.Collections.Generic;
using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Station : ModelBase<Station>
    {
        #region Properties

        /// <summary>
        /// max_dockable_ship_volume number
        /// </summary>
        /// <value>max_dockable_ship_volume number</value>
        [JsonPropertyName("max_dockable_ship_volume")]
        public float MaxDockableShipVolume { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// office_rental_cost number
        /// </summary>
        /// <value>office_rental_cost number</value>
        [JsonPropertyName("office_rental_cost")]
        public float OfficeRentalCost { get; set; }

        /// <summary>
        /// ID of the corporation that controls this station
        /// </summary>
        /// <value>ID of the corporation that controls this station</value>
        [JsonPropertyName("owner")]
        public int? Owner { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// race_id integer
        /// </summary>
        /// <value>race_id integer</value>
        [JsonPropertyName("race_id")]
        public int? RaceId { get; set; }

        /// <summary>
        /// reprocessing_efficiency number
        /// </summary>
        /// <value>reprocessing_efficiency number</value>
        [JsonPropertyName("reprocessing_efficiency")]
        public float ReprocessingEfficiency { get; set; }

        /// <summary>
        /// reprocessing_stations_take number
        /// </summary>
        /// <value>reprocessing_stations_take number</value>
        [JsonPropertyName("reprocessing_stations_take")]
        public float ReprocessingStationsTake { get; set; }

        /// <summary>
        /// services array
        /// </summary>
        /// <value>services array</value>
        [JsonPropertyName("services")]
        public List<ServicesEnum> Services { get; set; }

        /// <summary>
        /// station_id integer
        /// </summary>
        /// <value>station_id integer</value>
        [JsonPropertyName("station_id")]
        public int StationId { get; set; }
        /// <summary>
        /// The solar system this station is in
        /// </summary>
        /// <value>The solar system this station is in</value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
