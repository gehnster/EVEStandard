using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Event : ModelBase<Event>
    {
        #region Enums

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum OwnerTypeEnum
        {
            eve_server,
            corporation,
            faction,
            character,
            alliance
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        [JsonPropertyName("event_id")]
        public long EventId { get; set; }

        /// <summary>
        /// Gets or sets the importance.
        /// </summary>
        /// <value>
        /// The importance.
        /// </value>
        [JsonPropertyName("importance")]
        public long Importance { get; set; }

        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        /// The owner identifier.
        /// </value>
        [JsonPropertyName("owner_id")]
        public long OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the owner.
        /// </summary>
        /// <value>
        /// The name of the owner.
        /// </value>
        [JsonPropertyName("owner_name")]
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets the type of the owner.
        /// </summary>
        /// <value>
        /// The type of the owner.
        /// </value>

        [JsonPropertyName("owner_type")]

        public string OwnerType { get; set; }

        /// <summary>

        /// Gets the OwnerType as enum (may throw exception if unknown value exists).

        /// </summary>

        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]

        public Event.OwnerTypeEnum OwnerTypeToEnum 

        {

            get => (Event.OwnerTypeEnum)Enum.Parse(typeof(Event.OwnerTypeEnum), OwnerType);

        }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        [JsonPropertyName("response")]
        public string Response { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [JsonPropertyName("text")]
        public string Text { get; set; }

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