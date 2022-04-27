﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class PublicContractItem :ModelBase<PublicContractItem>
    {
        #region Properties
        /// <summary>
        /// is_blueprint_copy boolean
        /// </summary>
        [JsonPropertyName("is_blueprint_copy")]
        public bool? IsBlueprintCopy { get; set; }
        /// <summary>
        /// true if the contract issuer has submitted this item with the contract, false if the isser is asking for this item in the contract
        /// </summary>
        [JsonPropertyName("is_included")]
        public bool IsIncluded { get; set; }
        /// <summary>
        /// Unique ID for the item being sold. Not present if item is being requested by contract rather than sold with contract
        /// </summary>
        [JsonPropertyName("item_id")]
        public long? ItemId { get; set; }
        /// <summary>
        /// Material Efficiency Level of the blueprint
        /// </summary>
        [JsonPropertyName("material_efficiency")]
        public int? MaterialEfficiency { get; set; }
        /// <summary>
        /// Number of items in the stack
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        /// <summary>
        /// Unique ID for the item, used by the contract system
        /// </summary>
        [JsonPropertyName("record_id")]
        public long RecordId { get; set; }
        /// <summary>
        /// Number of runs remaining if the blueprint is a copy, -1 if it is an original
        /// </summary>
        [JsonPropertyName("runs")]
        public int? Runs { get; set; }
        /// <summary>
        /// Time Efficiency Level of the blueprint
        /// </summary>
        [JsonPropertyName("time_efficiency")]
        public int? TimeEfficiency { get; set; }
        /// <summary>
        /// Type ID for item
        /// </summary>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }
        #endregion
    }
}
