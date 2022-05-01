using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterShip : ModelBase<CharacterShip>
    {
        #region Properties

        /// <summary>
        /// Item id&#39;s are unique to a ship and persist until it is repackaged. This value can be used to track repeated uses of a ship, or detect when a pilot changes into a different instance of the same ship type.
        /// </summary>
        /// <value>Item id&#39;s are unique to a ship and persist until it is repackaged. This value can be used to track repeated uses of a ship, or detect when a pilot changes into a different instance of the same ship type.</value>
        [JsonPropertyName("ship_item_id")]
        public long ShipItemId { get; set; }

        /// <summary>
        /// ship_name string
        /// </summary>
        /// <value>ship_name string</value>
        [JsonPropertyName("ship_name")]
        public string ShipName { get; set; }

        /// <summary>
        /// ship_type_id integer
        /// </summary>
        /// <value>ship_type_id integer</value>
        [JsonPropertyName("ship_type_id")]
        public int ShipTypeId { get; set; }

        #endregion Properties
    }
}
