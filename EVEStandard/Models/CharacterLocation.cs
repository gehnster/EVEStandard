using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterLocation : ModelBase<CharacterLocation>
    {
        #region Properties

        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// station_id integer
        /// </summary>
        /// <value>station_id integer</value>
        [JsonPropertyName("station_id")]
        public int? StationId { get; set; }

        /// <summary>
        /// structure_id integer
        /// </summary>
        /// <value>structure_id integer</value>
        [JsonPropertyName("structure_id")]
        public long? StructureId { get; set; }

        #endregion Properties
    }
}
