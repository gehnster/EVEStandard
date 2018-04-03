using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class AgentResearch : ModelBase<AgentResearch>
    {
        /// <summary>
        /// agent_id integer
        /// </summary>
        /// <value>agent_id integer</value>
        [JsonProperty("agent_id")]
        public int? AgentId { get; set; }

        /// <summary>
        /// skill_type_id integer
        /// </summary>
        /// <value>skill_type_id integer</value>
        [JsonProperty("skill_type_id")]
        public int? SkillTypeId { get; set; }

        /// <summary>
        /// started_at string
        /// </summary>
        /// <value>started_at string</value>
        [JsonProperty("started_at")]
        public DateTime? StartedAt { get; set; }

        /// <summary>
        /// points_per_day number
        /// </summary>
        /// <value>points_per_day number</value>
        [JsonProperty("points_per_day")]
        public float? PointsPerDay { get; set; }

        /// <summary>
        /// remainder_points number
        /// </summary>
        /// <value>remainder_points number</value>
        [JsonProperty("remainder_points")]
        public float? RemainderPoints { get; set; }
    }
}
