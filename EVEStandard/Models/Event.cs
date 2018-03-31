namespace EVEStandard.Models
{
    using System;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Event : ModelBase<Event>
    {
        [JsonProperty("event_id")] public long EventId { get; set; }

        [JsonProperty("owner_id")] public long OwnerId { get; set; }

        [JsonProperty("owner_name")] public string OwnerName { get; set; }

        [JsonProperty("date")] public DateTime Date { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("duration")] public int Duration { get; set; }

        [JsonProperty("importance")] public int Importance { get; set; }

        [JsonProperty("response")] public string Response { get; set; }

        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("owner_type"), JsonConverter(typeof(StringEnumConverter))]
        public OwnerTypeEnum OwnerType { get; set; }

        public enum OwnerTypeEnum
        {
            eve_server,
            corporation,
            faction,
            character,
            alliance
        }
    }
}