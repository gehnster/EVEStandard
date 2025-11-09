using EVEStandard.Enumerations;
using System.Text.Json.Serialization;
using System;

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


        public string EventResponse { get; set; }


        /// <summary>


        /// Gets the EventResponse as enum (may throw exception if unknown value exists).


        /// </summary>


        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]



        [JsonIgnore]


        public Enumerations.EventResponse EventResponseToEnum 


        {


            get => (Enumerations.EventResponse)Enum.Parse(typeof(Enumerations.EventResponse), EventResponse);


        }
    }
}