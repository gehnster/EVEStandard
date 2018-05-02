namespace EVEStandard.Models
{
    using Enumerations;
    using global::System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class EventSummary : ModelBase<EventSummary>
    {
        [JsonProperty("event_id")] public long EventId { get; set; }

        [JsonProperty("event_date")] public DateTime EventDate { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("importance")] public int Importance { get; set; }

        [JsonProperty("event_response"), JsonConverter(typeof(StringEnumConverter))]
        public EventResponse EventResponse { get; set; }
    }
}