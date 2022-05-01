using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationWallet : ModelBase<CorporationWallet>
    {
        /// <summary>
        /// division integer
        /// </summary>
        /// <value>division integer</value>
        [JsonPropertyName("division")]
        public int Division { get; set; }

        /// <summary>
        /// balance number
        /// </summary>
        /// <value>balance number</value>
        [JsonPropertyName("balance")]
        public double Balance { get; set; }
    }
}
