using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryDenListing : ModelBase<MercenaryDenListing>
    {
        #region Properties

        /// <summary>
        /// List of Mercenary Dens
        /// </summary>
        /// <value>List of Mercenary Dens</value>
        [JsonPropertyName("mercenary_dens")]
        public List<MercenaryDenSummary> MercenaryDens { get; set; }

        #endregion Properties
    }
}
