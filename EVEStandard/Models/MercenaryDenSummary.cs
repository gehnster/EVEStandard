using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryDenSummary : ModelBase<MercenaryDenSummary>
    {
        #region Properties

        /// <summary>
        /// Mercenary Den's ID
        /// </summary>
        /// <value>Mercenary Den's ID</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// ID of the planet the Skyhook (to which the Mercenary Den is attached) is anchored on
        /// </summary>
        /// <value>ID of the planet the Skyhook (to which the Mercenary Den is attached) is anchored on</value>
        [JsonPropertyName("planet_id")]
        public long PlanetId { get; set; }

        #endregion Properties
    }
}
