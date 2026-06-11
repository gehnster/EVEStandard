using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AccessListSummary : ModelBase<AccessListSummary>
    {
        #region Properties

        /// <summary>
        /// Access List's ID
        /// </summary>
        /// <value>Access List's ID</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        #endregion Properties
    }
}
