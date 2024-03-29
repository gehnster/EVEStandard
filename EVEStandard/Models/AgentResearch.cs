﻿using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AgentResearch : ModelBase<AgentResearch>
    {
        #region Properties

        /// <summary>
        /// agent_id integer
        /// </summary>
        /// <value>agent_id integer</value>
        [JsonPropertyName("agent_id")]
        public int AgentId { get; set; }

        /// <summary>
        /// points_per_day number
        /// </summary>
        /// <value>points_per_day number</value>
        [JsonPropertyName("points_per_day")]
        public float PointsPerDay { get; set; }

        /// <summary>
        /// remainder_points number
        /// </summary>
        /// <value>remainder_points number</value>
        [JsonPropertyName("remainder_points")]
        public float RemainderPoints { get; set; }

        /// <summary>
        /// skill_type_id integer
        /// </summary>
        /// <value>skill_type_id integer</value>
        [JsonPropertyName("skill_type_id")]
        public int SkillTypeId { get; set; }

        /// <summary>
        /// started_at string
        /// </summary>
        /// <value>started_at string</value>
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        #endregion Properties
    }
}
