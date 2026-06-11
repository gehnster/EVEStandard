using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryTacticalOperationSummary : ModelBase<MercenaryTacticalOperationSummary>
    {
        #region Properties

        /// <summary>
        /// Operation's ID
        /// </summary>
        /// <value>Operation's ID</value>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// ID of Mercenary Den offering this operation
        /// </summary>
        /// <value>ID of Mercenary Den offering this operation</value>
        [JsonPropertyName("mercenary_den_id")]
        public long MercenaryDenId { get; set; }

        #endregion Properties
    }
}
