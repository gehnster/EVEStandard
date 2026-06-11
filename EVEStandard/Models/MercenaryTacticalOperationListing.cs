using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryTacticalOperationListing : ModelBase<MercenaryTacticalOperationListing>
    {
        #region Properties

        /// <summary>
        /// List of available operations
        /// </summary>
        /// <value>List of available operations</value>
        [JsonPropertyName("operations")]
        public List<MercenaryTacticalOperationSummary> Operations { get; set; }

        #endregion Properties
    }
}
