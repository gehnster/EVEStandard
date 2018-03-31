namespace EVEStandard.Models
{
    using System;
    using System.Text;
    using Enumerations;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class EventAttendee : ModelBase<EventAttendee>
    {
        [JsonProperty("character_id")] public long CharacterId { get; set; }

        [JsonProperty("event_response"), JsonConverter(typeof(StringEnumConverter))]
        public EventResponse EventResponse { get; set; }
    }
}