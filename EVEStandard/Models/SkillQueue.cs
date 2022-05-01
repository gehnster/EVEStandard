using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class SkillQueue : ModelBase<SkillQueue>
    {
        #region Properties

        /// <summary>
        /// Date on which training of the skill will complete. Omitted if the skill queue is paused.
        /// </summary>
        /// <value>finish_date string</value>
        [JsonPropertyName("finish_date")]
        public DateTime? FinishDate { get; set; }

        /// <summary>
        /// finished_level integer
        /// </summary>
        /// <value>finished_level integer</value>
        [JsonPropertyName("finished_level")]
        public int FinishedLevel { get; set; }

        /// <summary>
        /// level_end_sp integer
        /// </summary>
        /// <value>level_end_sp integer</value>
        [JsonPropertyName("level_end_sp")]
        public int? LevelEndSp { get; set; }

        /// <summary>
        /// Amount of SP that was in the skill when it started training it&#39;s current level. Used to calculate % of current level complete.
        /// </summary>
        /// <value>Amount of SP that was in the skill when it started training it&#39;s current level. Used to calculate % of current level complete.</value>
        [JsonPropertyName("level_start_sp")]
        public int? LevelStartSp { get; set; }

        /// <summary>
        /// queue_position integer
        /// </summary>
        /// <value>queue_position integer</value>
        [JsonPropertyName("queue_position")]
        public int QueuePosition { get; set; }

        /// <summary>
        /// skill_id integer
        /// </summary>
        /// <value>skill_id integer</value>
        [JsonPropertyName("skill_id")]
        public int SkillId { get; set; }

        /// <summary>
        /// start_date string
        /// </summary>
        /// <value>start_date string</value>
        [JsonPropertyName("start_date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// training_start_sp integer
        /// </summary>
        /// <value>training_start_sp integer</value>
        [JsonPropertyName("training_start_sp")]
        public int? TrainingStartSp { get; set; }

        #endregion Properties
    }
}
