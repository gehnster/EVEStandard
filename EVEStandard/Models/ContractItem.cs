using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class ContractItem : ModelBase<ContractItem>
    {
        #region Properties

        /// <summary>
        /// true if the contract issuer has submitted this item with the contract, false if the isser is asking for this item in the contract.
        /// </summary>
        /// <value>true if the contract issuer has submitted this item with the contract, false if the isser is asking for this item in the contract.</value>
        [JsonPropertyName("is_included")]
        public bool IsIncluded { get; set; }

        /// <summary>
        /// is_singleton boolean
        /// </summary>
        /// <value>is_singleton boolean</value>
        [JsonPropertyName("is_singleton")]
        public bool IsSingleton { get; set; }

        /// <summary>
        /// Number of items in the stack
        /// </summary>
        /// <value>Number of items in the stack</value>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// -1 indicates that the item is a singleton (non-stackable). If the item happens to be a Blueprint, -1 is an Original and -2 is a Blueprint Copy
        /// </summary>
        /// <value>-1 indicates that the item is a singleton (non-stackable). If the item happens to be a Blueprint, -1 is an Original and -2 is a Blueprint Copy</value>
        [JsonPropertyName("raw_quantity")]
        public int? RawQuantity { get; set; }

        /// <summary>
        /// Unique ID for the item
        /// </summary>
        /// <value>Unique ID for the item</value>
        [JsonPropertyName("record_id")]
        public long RecordId { get; set; }

        /// <summary>
        /// Type ID for item
        /// </summary>
        /// <value>Type ID for item</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
