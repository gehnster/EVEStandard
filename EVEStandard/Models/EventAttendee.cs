using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class EventAttendee
    {
        [JsonProperty("character_id")]
        public long CharacterId { get; set; }
        [JsonProperty("event_response")]
        public string EventResponse { get; set; }
    }
}
