using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AccessListDetail : ModelBase<AccessListDetail>
    {
        #region Properties

        /// <summary>
        /// The Access List's description
        /// </summary>
        /// <value>The Access List's description</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The Access List's ID
        /// </summary>
        /// <value>The Access List's ID</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// The Access List's membership
        /// </summary>
        /// <value>The Access List's membership</value>
        [JsonPropertyName("membership")]
        public AccessListMembership Membership { get; set; }

        /// <summary>
        /// The Access List's name
        /// </summary>
        /// <value>The Access List's name</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion Properties
    }
}
