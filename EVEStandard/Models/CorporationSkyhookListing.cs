using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationSkyhookListing : ModelBase<CorporationSkyhookListing>
    {
        #region Properties

        /// <summary>
        /// List of Skyhooks
        /// </summary>
        /// <value>List of Skyhooks</value>
        [JsonPropertyName("skyhooks")]
        public List<CorporationSkyhookSummary> Skyhooks { get; set; }

        #endregion Properties
    }
}
