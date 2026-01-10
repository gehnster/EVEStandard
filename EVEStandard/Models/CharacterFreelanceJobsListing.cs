using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Listing of character freelance jobs
    /// </summary>
    public class CharacterFreelanceJobsListing : ModelBase<CharacterFreelanceJobsListing>
    {
        #region Properties

        /// <summary>
        /// List of freelance jobs
        /// </summary>
        [JsonPropertyName("freelance_jobs")]
        public List<FreelanceJob> FreelanceJobs { get; set; }

        #endregion Properties
    }
}
