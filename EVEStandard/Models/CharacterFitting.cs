using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class CharacterFitting : ModelBase<CharacterFitting>
    {
        /// <summary>
        /// fitting_id integer
        /// </summary>
        /// <value>fitting_id integer</value>
        [JsonProperty("fitting_id")]
        public int? FittingId { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// ship_type_id integer
        /// </summary>
        /// <value>ship_type_id integer</value>
        [JsonProperty("ship_type_id")]
        public int? ShipTypeId { get; set; }

        /// <summary>
        /// items array
        /// </summary>
        /// <value>items array</value>
        [JsonProperty("items")]
        public List<CharacterFittingItem> Items { get; set; }
    }

    public class CharacterFittingItem : ModelBase<CharacterFittingItem>
    {
        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonProperty("type_id")] public int? TypeId { get; set; }

        /// <summary>
        /// flag integer
        /// </summary>
        /// <value>flag integer</value>
        [JsonProperty("flag")] public int? Flag { get; set; }

        /// <summary>
        /// quantity integer
        /// </summary>
        /// <value>quantity integer</value>
        [JsonProperty("quantity")] public int? Quantity { get; set; }
    }
}
