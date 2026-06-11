using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationSkyhookSummary : ModelBase<CorporationSkyhookSummary>
    {
        #region Properties

        /// <summary>
        /// Skyhook's ID
        /// </summary>
        /// <value>Skyhook's ID</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// ID of the planet the Skyhook is anchored on
        /// </summary>
        /// <value>ID of the planet the Skyhook is anchored on</value>
        [JsonPropertyName("planet_id")]
        public long PlanetId { get; set; }

        #endregion Properties
    }
}
