using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EveCorpMonNet.Libraries.EVEStandard.Enumerations;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class Station : ModelBase<Station>
    {
        /// <summary>
        /// station_id integer
        /// </summary>
        /// <value>station_id integer</value>
        [Required]
        [JsonProperty("station_id")]
        public int? StationId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// ID of the corporation that controls this station
        /// </summary>
        /// <value>ID of the corporation that controls this station</value>
        [JsonProperty("owner")]
        public int? Owner { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [Required]
        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        /// <summary>
        /// race_id integer
        /// </summary>
        /// <value>race_id integer</value>
        [JsonProperty("race_id")]
        public int? RaceId { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [Required]
        [JsonProperty("position")]
        public Position Position { get; set; }

        /// <summary>
        /// The solar system this station is in
        /// </summary>
        /// <value>The solar system this station is in</value>
        [Required]
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }

        /// <summary>
        /// reprocessing_efficiency number
        /// </summary>
        /// <value>reprocessing_efficiency number</value>
        [Required]
        [JsonProperty("reprocessing_efficiency")]
        public float? ReprocessingEfficiency { get; set; }

        /// <summary>
        /// reprocessing_stations_take number
        /// </summary>
        /// <value>reprocessing_stations_take number</value>
        [Required]
        [JsonProperty("reprocessing_stations_take")]
        public float? ReprocessingStationsTake { get; set; }

        /// <summary>
        /// max_dockable_ship_volume number
        /// </summary>
        /// <value>max_dockable_ship_volume number</value>
        [Required]
        [JsonProperty("max_dockable_ship_volume")]
        public float? MaxDockableShipVolume { get; set; }

        /// <summary>
        /// office_rental_cost number
        /// </summary>
        /// <value>office_rental_cost number</value>
        [Required]
        [JsonProperty("office_rental_cost")]
        public float? OfficeRentalCost { get; set; }

        /// <summary>
        /// services array
        /// </summary>
        /// <value>services array</value>
        [Required]
        [JsonProperty("services")]
        public List<ServicesEnum> Services { get; set; }
    }
}
