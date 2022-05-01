using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class ContractBid : ModelBase<ContractBid>
    {
        #region Properties

        /// <summary>
        /// The amount bid, in ISK
        /// </summary>
        /// <value>The amount bid, in ISK</value>
        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        /// <summary>
        /// Character ID of the bidder
        /// </summary>
        /// <value>Character ID of the bidder</value>
        [JsonPropertyName("bidder_id")]
        public int BidderId { get; set; }

        /// <summary>
        /// Unique ID for the bid
        /// </summary>
        /// <value>Unique ID for the bid</value>
        [JsonPropertyName("bid_id")]
        public int BidId { get; set; }
        /// <summary>
        /// Datetime when the bid was placed
        /// </summary>
        /// <value>Datetime when the bid was placed</value>
        [JsonPropertyName("date_bid")]
        public DateTime DateBid { get; set; }

        #endregion Properties
    }
}
