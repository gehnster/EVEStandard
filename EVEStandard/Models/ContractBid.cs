using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class ContractBid : ModelBase<ContractBid>
    {
        /// <summary>
        /// Unique ID for the bid
        /// </summary>
        /// <value>Unique ID for the bid</value>
        [JsonProperty("bid_id")]
        public int? BidId { get; set; }

        /// <summary>
        /// Character ID of the bidder
        /// </summary>
        /// <value>Character ID of the bidder</value>
        [JsonProperty("bidder_id")]
        public int? BidderId { get; set; }

        /// <summary>
        /// Datetime when the bid was placed
        /// </summary>
        /// <value>Datetime when the bid was placed</value>
        [JsonProperty("date_bid")]
        public DateTime? DateBid { get; set; }

        /// <summary>
        /// The amount bid, in ISK
        /// </summary>
        /// <value>The amount bid, in ISK</value>
        [JsonProperty("amount")]
        public float? Amount { get; set; }
    }
}
