using Newtonsoft.Json;

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
