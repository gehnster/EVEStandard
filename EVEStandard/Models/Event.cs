using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class Event
    {
        [JsonProperty("event_id")]
        public long EventId { get; set; }
        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }
        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("duration")]
        public int Duration { get; set; }
        [JsonProperty("importance")]
        public int Importance { get; set; }
        [JsonProperty("response")]
        public string Response { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("owner_type")]
        public string OwnerType { get; set; }
    }
}
