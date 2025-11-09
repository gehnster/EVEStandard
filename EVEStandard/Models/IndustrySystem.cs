using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class IndustrySystem : ModelBase<IndustrySystem>
    {
        /// <summary>
        /// solar_system_id integer
        /// </summary>
        /// <value>solar_system_id integer</value>
        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// cost_indices array
        /// </summary>
        /// <value>cost_indices array</value>
        [JsonPropertyName("cost_indices")]
        public List<IndustrySystemCostIndice> CostIndices { get; set; }
    }

    public class IndustrySystemCostIndice : ModelBase<IndustrySystemCostIndice>
    {
        /// <summary>
        /// activity string
        /// </summary>
        /// <value>activity string</value>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ActivityEnum
        {
            copying = 1,
            duplicating = 2,
            invention = 3,
            manufacturing = 4,
            none = 5,
            reaction = 6,
            researching_material_efficiency = 7,
            researching_technology = 8,
            researching_time_efficiency = 9,
            reverse_engineering = 10
        }

        /// <summary>
        /// activity string
        /// </summary>
        /// <value>activity string</value>
        [JsonPropertyName("activity")]
        public string Activity { get; set; }

        /// <summary>
        /// Gets the Activity as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public ActivityEnum ActivityToEnum 
        {
            get => (ActivityEnum)Enum.Parse(typeof(ActivityEnum), Activity);
        }

        /// <summary>
        /// cost_index number
        /// </summary>
        /// <value>cost_index number</value>
        [JsonPropertyName("cost_index")]
        public float CostIndex { get; set; }
    }
}
