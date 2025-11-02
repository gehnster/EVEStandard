EVEStandard\Models\MetaCompatibilityDates.cs
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CompatibilityDates : ModelBase<CompatibilityDates>
    {
        /// <summary>
        /// Array of compatibility dates in YYYY-MM-DD format.
        /// </summary>
        [JsonPropertyName("compatibility_dates")]
        public List<string> CompatibilityDates { get; set; }
    }
}