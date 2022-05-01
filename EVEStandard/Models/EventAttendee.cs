using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class EventAttendee : ModelBase<EventAttendee>
    {
        /// <summary>
        /// Gets or sets the character identifier.
        /// </summary>
        /// <value>
        /// The character identifier.
        /// </value>
        [JsonPropertyName("character_id")]
        public long CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the event response.
        /// </summary>
        /// <value>
        /// The event response.
        /// </value>
        [JsonPropertyName("event_response")]
        public EventResponse EventResponse { get; set; }
    }
}