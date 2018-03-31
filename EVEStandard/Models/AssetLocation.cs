using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class AssetLocation : ModelBase<AssetLocation>
    {
        [JsonProperty("item_id")]
        public long ItemId { get; set; }
        [JsonProperty("position")]
        public Position Position { get; set; }
    }
}
