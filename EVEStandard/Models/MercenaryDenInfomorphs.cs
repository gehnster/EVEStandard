using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryDenInfomorphs : ModelBase<MercenaryDenInfomorphs>
    {
        #region Properties

        /// <summary>
        /// Amount of infomorphs
        /// </summary>
        /// <value>Amount of infomorphs</value>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        #endregion Properties
    }
}
