using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SystemJumps : ModelBase<SystemJumps>
    {
        #region Properties

        /// <summary>
        /// ship_jumps integer
        /// </summary>
        /// <value>ship_jumps integer</value>
        [JsonPropertyName("ship_jumps")]
        public int ShipJumps { get; set; }

        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        #endregion Properties
    }
}
