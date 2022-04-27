using EVEStandard.Enumerations;
using System.Text.Json.Serialization;
using System;

namespace EVEStandard.Models
{
    public class EventSummary : ModelBase<EventSummary>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        [JsonPropertyName("event_date")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        [JsonPropertyName("event_id")]
        public long EventId { get; set; }

        /// <summary>
        /// Gets or sets the event response.
        /// </summary>
        /// <value>
        /// The event response.
        /// </value>
        [JsonPropertyName("event_response")]
        public EventResponse EventResponse { get; set; }

        /// <summary>
        /// Gets or sets the importance.
        /// </summary>
        /// <value>
        /// The importance.
        /// </value>
        [JsonPropertyName("importance")]
        public int Importance { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        #endregion Properties
    }
}