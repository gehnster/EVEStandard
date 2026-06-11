using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryDenDetail : ModelBase<MercenaryDenDetail>
    {
        #region Properties

        /// <summary>
        /// Mercenary Den's evolution
        /// </summary>
        /// <value>Mercenary Den's evolution</value>
        [JsonPropertyName("evolution")]
        public MercenaryDenEvolution Evolution { get; set; }

        /// <summary>
        /// Mercenary Den's ID
        /// </summary>
        /// <value>Mercenary Den's ID</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Mercenary Den's infomorphs
        /// </summary>
        /// <value>Mercenary Den's infomorphs</value>
        [JsonPropertyName("infomorphs")]
        public MercenaryDenInfomorphs Infomorphs { get; set; }

        /// <summary>
        /// Mercenary Den's reinforcement timer (if the structure is reinforced)
        /// </summary>
        /// <value>Mercenary Den's reinforcement timer (if the structure is reinforced)</value>
        [JsonPropertyName("reinforcement_timer")]
        public MercenaryDenReinforcementTimer ReinforcementTimer { get; set; }

        /// <summary>
        /// Skyhook the Mercenary Den is attached to
        /// </summary>
        /// <value>Skyhook the Mercenary Den is attached to</value>
        [JsonPropertyName("skyhook")]
        public MercenaryDenSkyhook Skyhook { get; set; }

        /// <summary>
        /// Mercenary Den's state Valid values: Unspecified, Running, Paused, Disabled.
        /// </summary>
        /// <value>Mercenary Den's state Valid values: Unspecified, Running, Paused, Disabled.</value>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Mercenary Den's type ID
        /// </summary>
        /// <value>Mercenary Den's type ID</value>
        [JsonPropertyName("type_id")]
        public long TypeId { get; set; }

        #endregion Properties
    }
}
