using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Listing of public freelance jobs
    /// </summary>
    public class FreelanceJobsListing : ModelBase<FreelanceJobsListing>
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

    /// <summary>
    /// Cursor information for freelance job pagination
    /// </summary>
    public class FreelanceJobCursor : ModelBase<FreelanceJobCursor>
    {
        #region Properties

        /// <summary>
        /// Token to retrieve the previous page of results
        /// </summary>
        [JsonPropertyName("before")]
        public string Before { get; set; }

        /// <summary>
        /// Token to retrieve the next page of results
        /// </summary>
        [JsonPropertyName("after")]
        public string After { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Freelance job information
    /// </summary>
    public class FreelanceJob : ModelBase<FreelanceJob>
    {
        #region Properties

        /// <summary>
        /// Job's ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Job's name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Job's state
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Job's last modified
        /// </summary>
        [JsonPropertyName("last_modified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Job's progress
        /// </summary>
        [JsonPropertyName("progress")]
        public FreelanceJobProgress Progress { get; set; }

        /// <summary>
        /// Job's reward
        /// </summary>
        [JsonPropertyName("reward")]
        public FreelanceJobReward Reward { get; set; }

        #endregion Properties
    }
}
