using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class FleetMemberMove : ModelBase<FleetMemberMove>
    {
        #region Properties

        /// <summary>
        /// If a character is moved to the &#x60;fleet_commander&#x60; role, neither &#x60;wing_id&#x60; or &#x60;squad_id&#x60; should be specified. If a character is moved to the &#x60;wing_commander&#x60; role, only &#x60;wing_id&#x60; should be specified. If a character is moved to the &#x60;squad_commander&#x60; role, both &#x60;wing_id&#x60; and &#x60;squad_id&#x60; should be specified. If a character is moved to the &#x60;squad_member&#x60; role, both &#x60;wing_id&#x60; and &#x60;squad_id&#x60; should be specified.
        /// </summary>
        /// <value>If a character is moved to the &#x60;fleet_commander&#x60; role, neither &#x60;wing_id&#x60; or &#x60;squad_id&#x60; should be specified. If a character is moved to the &#x60;wing_commander&#x60; role, only &#x60;wing_id&#x60; should be specified. If a character is moved to the &#x60;squad_commander&#x60; role, both &#x60;wing_id&#x60; and &#x60;squad_id&#x60; should be specified. If a character is moved to the &#x60;squad_member&#x60; role, both &#x60;wing_id&#x60; and &#x60;squad_id&#x60; should be specified.</value>
        [JsonPropertyName("role")]
        public FleetRole Role { get; set; }

        /// <summary>
        /// squad_id integer
        /// </summary>
        /// <value>squad_id integer</value>
        [JsonPropertyName("squad_id")]
        public long? SquadId { get; set; }

        /// <summary>
        /// wing_id integer
        /// </summary>
        /// <value>wing_id integer</value>
        [JsonPropertyName("wing_id")]
        public long? WingId { get; set; }

        #endregion Properties
    }
}
