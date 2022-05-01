using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class LoyaltyPoints : ModelBase<LoyaltyPoints>
    {
        #region Properties

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonPropertyName("corporation_id")]
        public int CorporationId { get; set; }

        /// <summary>
        /// loyalty_points integer
        /// </summary>
        /// <value>loyalty_points integer</value>
        [JsonPropertyName("loyalty_points")]
        public int Points { get; set; }

        #endregion Properties
    }
}
