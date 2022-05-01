using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class IndustryFacility : ModelBase<IndustryFacility>
    {
        #region Properties

        /// <summary>
        /// ID of the facility
        /// </summary>
        /// <value>ID of the facility</value>
        [JsonPropertyName("facility_id")]
        public long FacilityId { get; set; }

        /// <summary>
        /// Owner of the facility
        /// </summary>
        /// <value>Owner of the facility</value>
        [JsonPropertyName("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Region ID where the facility is
        /// </summary>
        /// <value>Region ID where the facility is</value>
        [JsonPropertyName("region_id")]
        public int RegionId { get; set; }

        /// <summary>
        /// Solar system ID where the facility is
        /// </summary>
        /// <value>Solar system ID where the facility is</value>
        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// Tax imposed by the facility
        /// </summary>
        /// <value>Tax imposed by the facility</value>
        [JsonPropertyName("tax")]
        public float? Tax { get; set; }
        /// <summary>
        /// Type ID of the facility
        /// </summary>
        /// <value>Type ID of the facility</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        #endregion Properties
    }
}
