using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class BookmarkFolder : ModelBase<BookmarkFolder>
    {
        [JsonProperty("folder_id")] public long FolderId { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }
}