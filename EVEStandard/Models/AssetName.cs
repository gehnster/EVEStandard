using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class AssetName
    {
        [JsonProperty("item_id")]
        public long ItemId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
