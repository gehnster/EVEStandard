using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class AssetName : ModelBase<AssetName>
    {
        [JsonProperty("item_id")]
        public long ItemId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
