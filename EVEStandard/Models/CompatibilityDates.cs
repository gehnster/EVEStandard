using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace EVEStandard.Models
{
    public class CompatibilityDates : ModelBase<CompatibilityDates>
    {
        /// <summary>
        /// Array of compatibility dates in YYYY-MM-DD format.
        /// </summary>
        [JsonPropertyName("compatibility_dates")]
        public List<string> Dates { get; set; }
    }
}