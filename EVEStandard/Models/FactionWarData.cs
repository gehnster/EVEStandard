using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class FactionWarData : ModelBase<FactionWarData>
    {
        #region Properties

        /// <summary>
        /// The faction ID of the enemy faction.
        /// </summary>
        /// <value>The faction ID of the enemy faction.</value>
        [JsonPropertyName("against_id")]
        public int AgainstId { get; set; }

        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonPropertyName("faction_id")]
        public int FactionId { get; set; }

        #endregion Properties
    }
}
