using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class FactionWarData : ModelBase<FactionWarData>
    {
        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonProperty("faction_id")]
        public int? FactionId { get; set; }

        /// <summary>
        /// The faction ID of the enemy faction.
        /// </summary>
        /// <value>The faction ID of the enemy faction.</value>
        [JsonProperty("against_id")]
        public int? AgainstId { get; set; }
    }
}
