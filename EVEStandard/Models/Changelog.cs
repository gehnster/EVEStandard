using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Changelog : ModelBase<Changelog>
    {
        /// <summary>
        /// Dictionary where the key is a string and the value is an array of changelog entries.
        /// </summary>
        [JsonPropertyName("changelog")]
        public Dictionary<string, List<ChangelogEntry>> Changelogs { get; set; }
    }

    public class ChangelogEntry : ModelBase<ChangelogEntry>
    {
        /// <summary>
        /// Compatibility date in YYYY-MM-DD format.
        /// Kept as string to avoid strict DateTime parsing differences across consumers.
        /// </summary>
        [JsonPropertyName("compatibility_date")]
        public string CompatibilityDate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}