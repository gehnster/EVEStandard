using Newtonsoft.Json;

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
