using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Listing of corporation freelance jobs
    /// </summary>
    public class CorporationFreelanceJobsListing : ModelBase<CorporationFreelanceJobsListing>
    {
        #region Properties

        /// <summary>
        /// List of freelance jobs
        /// </summary>
        [JsonPropertyName("freelance_jobs")]
        public List<FreelanceJob> FreelanceJobs { get; set; }

        /// <summary>
        /// Cursor information for pagination
        /// </summary>
        [JsonPropertyName("cursor")]
        public FreelanceJobCursor Cursor { get; set; }

        #endregion Properties
    }
}
