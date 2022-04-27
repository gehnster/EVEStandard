using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Status : ModelBase<Status>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        [JsonPropertyName("players")]
        public int Players { get; set; }

        /// <summary>
        /// Gets or sets the server version.
        /// </summary>
        /// <value>
        /// The server version.
        /// </value>
        [JsonPropertyName("server_version")]
        public string ServerVersion { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Status"/> is vip.
        /// </summary>
        /// <value>
        ///   <c>true</c> if vip; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("vip")]
        public bool? VIP { get; set; }

        #endregion Properties
    }
}