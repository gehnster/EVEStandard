using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryDenSkyhook : ModelBase<MercenaryDenSkyhook>
    {
        #region Properties

        /// <summary>
        /// Corporation that owns the Skyhook
        /// </summary>
        /// <value>Corporation that owns the Skyhook</value>
        [JsonPropertyName("corporation_id")]
        public long CorporationId { get; set; }

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
