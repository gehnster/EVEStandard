using EVEStandard.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EVEStandard.Models
{
    public class EventAttendee : ModelBase<EventAttendee>
    {
        [JsonProperty("character_id")] public long CharacterId { get; set; }

        [JsonProperty("event_response"), JsonConverter(typeof(StringEnumConverter))]
        public EventResponse EventResponse { get; set; }
    }
}