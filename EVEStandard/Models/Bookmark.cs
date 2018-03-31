namespace EVEStandard.Models
{
    using System;
    using System.Text;
    using Newtonsoft.Json;

    public class Bookmark : ModelBase<Bookmark>
    {
        [JsonProperty("bookmark_id")] public long BookmarkId { get; set; }

        [JsonProperty("location_id")] public long LocationId { get; set; }

        [JsonProperty("item")] public Item Item { get; set; }

        [JsonProperty("folder_id")] public long FolderId { get; set; }

        [JsonProperty("label")] public string Label { get; set; }

        [JsonProperty("notes")] public string Notes { get; set; }

        [JsonProperty("created")] public DateTime Created { get; set; }

        [JsonProperty("creator_id")] public long CreatorId { get; set; }

        [JsonProperty("coordinates")] public Position Coordinates { get; set; }
    }
}