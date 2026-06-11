using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryDenReinforcementTimer : ModelBase<MercenaryDenReinforcementTimer>
    {
        #region Properties

        /// <summary>
        /// The time when the reinforcement timer will end
        /// </summary>
        /// <value>The time when the reinforcement timer will end</value>
        [JsonPropertyName("end")]
        public DateTime? End { get; set; }

        #endregion Properties
    }
}
