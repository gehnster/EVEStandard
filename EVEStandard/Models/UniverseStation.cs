using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    /// <summary>Information about a station.</summary>
    class UniverseStation : ModelBase<UniverseStation>
    {
        /// <summary>station_id integer.</summary>
        /// <value>station_id integer.</value>
        [JsonProperty("station_id")]
        public int StationID { get; set; }

        /// <summary>name string.</summary>
        /// <value>name string.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>ID of the corporation that controls this station.</summary>
        /// <value>ID of the corporation that controls this station.</value>
        [JsonProperty("owner")]
        public int? Owner { get; set; }

        /// <summary> type_id integer.</summary>
        /// <value> type_id integer.</value>
        [JsonProperty("type_id")]
        public int TypeID { get; set; }

        /// <summary>race_id integer.</summary>
        /// <value>race_id integer.</value>
        [JsonProperty("race_id")]
        public int? RaceID { get; set; }

        /// <summary>position object.</summary>
        /// <value>position object.</value>
        [JsonProperty("position")]
        public UniverseStationPosition Position { get; set; }

        /// <summary>The solar system this station is in.</summary>
        /// <value>The solar system this station is in.</value>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }

        /// <summary>The solar system this station is in.</summary>
        /// <value>The solar system this station is in.</value>
        [JsonProperty("reprocessing_efficiency")]
        public float ReprocessingEfficiency { get; set; }

        /// <summary>reprocessing_stations_take number.</summary>
        /// <value>reprocessing_stations_take number.</value>
        [JsonProperty("reprocessing_stations_take")]
        public float ReprocessingStationsTake { get; set; }

        /// <summary>max_dockable_ship_volume number.</summary>
        /// <value>max_dockable_ship_volume number.</value>
        [JsonProperty("max_dockable_ship_volume")]
        public float MaxDockableShipVolume { get; set; }

        /// <summary>office_rental_cost number.</summary>
        /// <value>office_rental_cost number.</value>
        [JsonProperty("office_rental_cost")]
        public float OfficeRentalCost { get; set; }

        /// <summary>services array.</summary>
        /// <value>services array.</value>
        [JsonProperty("services")]
        public List<string> Services { get; set; }


    }

    class UniverseStationPosition : ModelBase<UniverseStationPosition>
    {
        /// <summary>x number.</summary>
        /// <value>x number.</value>
        [JsonProperty("x")]
        public float X { get; set; }

        /// <summary>y number.</summary>
        /// <value>y number.</value>
        [JsonProperty("y")]
        public float Y { get; set; }

        /// <summary>z number</summary>
        /// <value>z number</value>
        [JsonProperty("z")]
        public float Z { get; set; }
    }
}
