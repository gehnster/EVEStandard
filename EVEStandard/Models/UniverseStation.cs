using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    /// <summary>Information about a station.</summary>
    class UniverseStation : ModelBase<UniverseStation>
    {
        [JsonProperty("station_id")]
        public int StationID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public int? Owner { get; set; }

        [JsonProperty("type_id")]
        public int TypeID { get; set; }

        [JsonProperty("race_id")]
        public int RaceID { get; set; }

        [JsonProperty("position")]
        public UniverseStationPosition Position { get; set; }

        [JsonProperty("system_id")]
        public int SystemID { get; set; }

        [JsonProperty("reprocessing_efficiency")]
        public float ReprocessingEfficiency { get; set; }

        [JsonProperty("reprocessing_stations_take")]
        public float ReprocessingStationsTake { get; set; }

        [JsonProperty("max_dockable_ship_volume")]
        public float MaxDockableShipVolume { get; set; }

        [JsonProperty("office_rental_cost")]
        public float OfficeRentalCost { get; set; }

        [JsonProperty("services")]
        public List<string> Services { get; set; }


    }

    class UniverseStationPosition : ModelBase<UniverseStationPosition>
    {
        [JsonProperty("x")]
        public float X { get; set; }

        [JsonProperty("y")]
        public float Y { get; set; }

        [JsonProperty("z")]
        public float Z { get; set; }
    }
}
