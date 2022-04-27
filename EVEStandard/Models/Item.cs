using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Item : ModelBase<Item>
    {
        #region Properties

        [JsonPropertyName("item_id")]
        public long ItemId { get; set; }

        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
