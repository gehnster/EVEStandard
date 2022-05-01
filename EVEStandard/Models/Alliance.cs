using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Alliance : ModelBase<Alliance>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the creator corporation identifier.
        /// </summary>
        /// <value>
        /// The creator corporation identifier.
        /// </value>
        [JsonPropertyName("creator_corporation_id")]
        public int CreatorCorporationId { get; set; }

        /// <summary>
        /// Gets or sets the creator identifier.
        /// </summary>
        /// <value>
        /// The creator identifier.
        /// </value>
        [JsonPropertyName("creator_id")]
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the date founded.
        /// </summary>
        /// <value>
        /// The date founded.
        /// </value>
        [JsonPropertyName("date_founded")]
        public DateTime DateFounded { get; set; }

        /// <summary>
        /// Gets or sets the executor corporation identifier.
        /// </summary>
        /// <value>
        /// The executor corporation identifier.
        /// </value>
        [JsonPropertyName("executor_corporation_id")]
        public int? ExecutorCorporationId { get; set; }

        /// <summary>
        /// Gets or sets the faction identifier.
        /// </summary>
        /// <value>
        /// The faction identifier.
        /// </value>
        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ticker.
        /// </summary>
        /// <value>
        /// The ticker.
        /// </value>
        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        #endregion Properties
    }
}