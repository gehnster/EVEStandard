using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AccessListListing : ModelBase<AccessListListing>
    {
        #region Properties

        /// <summary>
        /// List of Access Lists
        /// </summary>
        /// <value>List of Access Lists</value>
        [JsonPropertyName("access_lists")]
        public List<AccessListSummary> AccessLists { get; set; }

        #endregion Properties
    }
}
