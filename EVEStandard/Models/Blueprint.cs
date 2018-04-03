using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class Blueprint : ModelBase<Blueprint>
    {
        /// <summary>
        /// Unique ID for this item.
        /// </summary>
        /// <value>Unique ID for this item.</value>
        [JsonProperty("item_id")]
        public long? ItemId { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int? TypeId { get; set; }

        /// <summary>
        /// References a solar system, station or item_id if this blueprint is located within a container. If the return value is an item_id, then the Character AssetList API must be queried to find the container using the given item_id to determine the correct location of the Blueprint.
        /// </summary>
        /// <value>References a solar system, station or item_id if this blueprint is located within a container. If the return value is an item_id, then the Character AssetList API must be queried to find the container using the given item_id to determine the correct location of the Blueprint.</value>
        [JsonProperty("location_id")]
        public long? LocationId { get; set; }
        /// <summary>
        /// Type of the location_id
        /// </summary>
        /// <value>Type of the location_id</value>
        public enum LocationFlagEnum
        {
            AutoFit = 1,
            Cargo = 2,
            CorpseBay = 3,
            DroneBay = 4,
            FleetHangar = 5,
            Deliveries = 6,
            HiddenModifiers = 7,
            Hangar = 8,
            HangarAll = 9,
            LoSlot0 = 10,
            LoSlot1 = 11,
            LoSlot2 = 12,
            LoSlot3 = 13,
            LoSlot4 = 14,
            LoSlot5 = 15,
            LoSlot6 = 16,
            LoSlot7 = 17,
            MedSlot0 = 18,
            MedSlot1 = 19,
            MedSlot2 = 20,
            MedSlot3 = 21,
            MedSlot4 = 22,
            MedSlot5 = 23,
            MedSlot6 = 24,
            MedSlot7 = 25,
            HiSlot0 = 26,
            HiSlot1 = 27,
            HiSlot2 = 28,
            HiSlot3 = 29,
            HiSlot4 = 30,
            HiSlot5 = 31,
            HiSlot6 = 32,
            HiSlot7 = 33,
            AssetSafety = 34,
            Locked = 35,
            Unlocked = 36,
            Implant = 37,
            QuafeBay = 38,
            RigSlot0 = 39,
            RigSlot1 = 40,
            RigSlot2 = 41,
            RigSlot3 = 42,
            RigSlot4 = 43,
            RigSlot5 = 44,
            RigSlot6 = 45,
            RigSlot7 = 46,
            ShipHangar = 47,
            SpecializedFuelBay = 48,
            SpecializedOreHold = 49,
            SpecializedGasHold = 50,
            SpecializedMineralHold = 51,
            SpecializedSalvageHold = 52,
            SpecializedShipHold = 53,
            SpecializedSmallShipHold = 54,
            SpecializedMediumShipHold = 55,
            SpecializedLargeShipHold = 56,
            SpecializedIndustrialShipHold = 57,
            SpecializedAmmoHold = 58,
            SpecializedCommandCenterHold = 59,
            SpecializedPlanetaryCommoditiesHold = 60,
            SpecializedMaterialBay = 61,
            SubSystemSlot0 = 62,
            SubSystemSlot1 = 63,
            SubSystemSlot2 = 64,
            SubSystemSlot3 = 65,
            SubSystemSlot4 = 66,
            SubSystemSlot5 = 67,
            SubSystemSlot6 = 68,
            SubSystemSlot7 = 69,
            FighterBay = 70,
            FighterTube0 = 71,
            FighterTube1 = 72,
            FighterTube2 = 73,
            FighterTube3 = 74,
            FighterTube4 = 75,
            Module = 76
        }

        /// <summary>
        /// Type of the location_id
        /// </summary>
        /// <value>Type of the location_id</value>
        [JsonProperty("location_flag")]
        public LocationFlagEnum? LocationFlag { get; set; }

        /// <summary>
        /// A range of numbers with a minimum of -2 and no maximum value where -1 is an original and -2 is a copy. It can be a positive integer if it is a stack of blueprint originals fresh from the market (e.g. no activities performed on them yet).
        /// </summary>
        /// <value>A range of numbers with a minimum of -2 and no maximum value where -1 is an original and -2 is a copy. It can be a positive integer if it is a stack of blueprint originals fresh from the market (e.g. no activities performed on them yet).</value>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Time Efficiency Level of the blueprint.
        /// </summary>
        /// <value>Time Efficiency Level of the blueprint.</value>
        [JsonProperty("time_efficiency")]
        public int? TimeEfficiency { get; set; }

        /// <summary>
        /// Material Efficiency Level of the blueprint.
        /// </summary>
        /// <value>Material Efficiency Level of the blueprint.</value>
        [JsonProperty("material_efficiency")]
        public int? MaterialEfficiency { get; set; }

        /// <summary>
        /// Number of runs remaining if the blueprint is a copy, -1 if it is an original.
        /// </summary>
        /// <value>Number of runs remaining if the blueprint is a copy, -1 if it is an original.</value>
        [JsonProperty("runs")]
        public int? Runs { get; set; }
    }
}
