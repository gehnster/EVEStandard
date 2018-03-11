using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class BookmarkFolder
    {
        [JsonProperty("folder_id")]
        public long FolderId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
