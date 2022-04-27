using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class InsurancePrice : ModelBase<InsurancePrice>
    {
        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        /// <summary>
        /// A list of a available insurance levels for this ship type
        /// </summary>
        /// <value>A list of a available insurance levels for this ship type</value>
        [JsonPropertyName("levels")]
        public List<InsurancePricesLevel> Levels { get; set; }
    }

    public class InsurancePricesLevel : ModelBase<InsurancePricesLevel>
    {
        /// <summary>
        /// cost number
        /// </summary>
        /// <value>cost number</value>
        [JsonPropertyName("cost")]
        public float Cost { get; set; }

        /// <summary>
        /// payout number
        /// </summary>
        /// <value>payout number</value>
        [JsonPropertyName("payout")]
        public float Payout { get; set; }

        /// <summary>
        /// Localized insurance level
        /// </summary>
        /// <value>Localized insurance level</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
