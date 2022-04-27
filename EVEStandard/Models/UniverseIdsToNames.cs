using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class UniverseIdsToNames : ModelBase<UniverseIdsToNames>
    {
        #region Properties

        /// <summary>
        /// category string
        /// </summary>
        /// <value>category string</value>
        [JsonPropertyName("category")]
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// id integer
        /// </summary>
        /// <value>id integer</value>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion Properties
    }
}
