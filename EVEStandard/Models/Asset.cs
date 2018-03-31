namespace EVEStandard.Models
{
    using System;
    using System.Text;
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

        [JsonProperty("location_flag"), JsonConverter(typeof(StringEnumConverter))] public LocationFlagEnum LocationFlag { get; set; }

        [JsonProperty("location_id")] public long LocationId { get; set; }

        [JsonProperty("is_singleton")] public bool IsSingleton { get; set; }

        [JsonProperty("type_id")] public int TypeId { get; set; }

        [JsonProperty("item_id")] public long ItemId { get; set; }

        [JsonProperty("location_type"), JsonConverter(typeof(StringEnumConverter))]
        public LocationTypeEnum LocationType { get; set; }

        [JsonProperty("quantity")] public long Quantity { get; set; }

        public enum LocationFlagEnum
        {
            AssetSafety,
            AutoFit,
            Cargo,
            CorpseBay,
            Deliveries,
            DroneBay,
            FighterBay,
            FighterTube0,
            FighterTube1,
            FighterTube2,
            FighterTube3,
            FighterTube4,
            FleetHangar,
            Hangar,
            HangarAll,
            HiSlot0,
            HiSlot1,
            HiSlot2,
            HiSlot3,
            HiSlot4,
            HiSlot5,
            HiSlot6,
            HiSlot7,
            HiddenModifiers,
            Implant,
            LoSlot0,
            LoSlot1,
            LoSlot2,
            LoSlot3,
            LoSlot4,
            LoSlot5,
            LoSlot6,
            LoSlot7,
            Locked,
            MedSlot0,
            MedSlot1,
            MedSlot2,
            MedSlot3,
            MedSlot4,
            MedSlot5,
            MedSlot6,
            MedSlot7,
            QuafeBay,
            RigSlot0,
            RigSlot1,
            RigSlot2,
            RigSlot3,
            RigSlot4,
            RigSlot5,
            RigSlot6,
            RigSlot7,
            ShipHangar,
            Skill,
            SpecializedAmmoHold,
            SpecializedCommandCenterHold,
            SpecializedFuelBay,
            SpecializedGasHold,
            SpecializedIndustrialShipHold,
            SpecializedLargeShipHold,
            SpecializedMaterialBay,
            SpecializedMediumShipHold,
            SpecializedMineralHold,
            SpecializedOreHold,
            SpecializedPlanetaryCommoditiesHold,
            SpecializedSalvageHold,
            SpecializedShipHold,
            SpecializedSmallShipHold,
            SubSystemBay,
            SubSystemSlot0,
            SubSystemSlot1,
            SubSystemSlot2,
            SubSystemSlot3,
            SubSystemSlot4,
            SubSystemSlot5,
            SubSystemSlot6,
            SubSystemSlot7,
            Unlocked,
            Wardrobe
        }
    }
}