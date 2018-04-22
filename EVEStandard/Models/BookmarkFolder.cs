namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class BookmarkFolder : ModelBase<BookmarkFolder>
    {
        [JsonProperty("folder_id")] public long FolderId { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }
}