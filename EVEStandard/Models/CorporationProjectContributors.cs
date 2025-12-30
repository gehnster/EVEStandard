using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// List of contributors to a corporation project
    /// </summary>
    public class CorporationProjectContributors : ModelBase<CorporationProjectContributors>
    {
        #region Properties

        /// <summary>
        /// List of contributors
        /// </summary>
        [JsonPropertyName("contributors")]
        public List<ProjectContributor> Contributors { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Individual contributor information
    /// </summary>
    public class ProjectContributor : ModelBase<ProjectContributor>
    {
        #region Properties

        /// <summary>
        /// Contributor's character ID
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Contributor's contributed progress
        /// </summary>
        [JsonPropertyName("contributed")]
        public long Contributed { get; set; }

        /// <summary>
        /// Contributor's name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion Properties
    }
}
