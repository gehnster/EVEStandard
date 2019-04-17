using System.Collections.Generic;
using EVEStandard.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EVEStandard.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FittingItemFlag
    {
        Cargo,
        DroneBay,
        FighterBay,
        HiSlot0,
        HiSlot1,
        HiSlot2,
        HiSlot3,
        HiSlot4,
        HiSlot5,
        HiSlot6,
        HiSlot7,
        Invalid,
        LoSlot0,
        LoSlot1,
        LoSlot2,
        LoSlot3,
        LoSlot4,
        LoSlot5,
        LoSlot6,
        LoSlot7,
        MedSlot0,
        MedSlot1,
        MedSlot2,
        MedSlot3,
        MedSlot4,
        MedSlot5,
        MedSlot6,
        MedSlot7,
        RigSlot0,
        RigSlot1,
        RigSlot2,
        ServiceSlot0,
        ServiceSlot1,
        ServiceSlot2,
        ServiceSlot3,
        ServiceSlot4,
        ServiceSlot5,
        ServiceSlot6,
        ServiceSlot7,
        SubSystemSlot0,
        SubSystemSlot1,
        SubSystemSlot2,
        SubSystemSlot3
    }

    public class FittingItem : ModelBase<FittingItem>
    {
        #region Properties

        /// <summary>
        /// flag integer
        /// </summary>
        /// <value>flag integer</value>
        [JsonProperty("flag")]
        public FittingItemFlag Flag { get; set; }

        /// <summary>
        /// quantity integer
        /// </summary>
        /// <value>quantity integer</value>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }

    public class ShipFitting : ModelBase<ShipFitting>
    {
        #region Properties

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// items array
        /// </summary>
        /// <value>items array</value>
        [JsonProperty("items")]
        public List<FittingItem> Items { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// ship_type_id integer
        /// </summary>
        /// <value>ship_type_id integer</value>
        [JsonProperty("ship_type_id")]
        public int ShipTypeId { get; set; }

        #endregion Properties
    }

    public class ShipFittingCreated
    {
        [JsonProperty("fitting_id")]
        public int FittingId { get; set; }
    }
}
