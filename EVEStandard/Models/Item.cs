using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class Item : ModelBase<Item>
    {
        [JsonProperty("type_id")]
        public long TypeId { get; set; }
        [JsonProperty("item_id")]
        public long ItemId { get; set; }
    }
}
