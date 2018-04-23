using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class CharacterTask : ModelBase<CharacterTask>
    {
        /// <summary>
        /// task_id integer
        /// </summary>
        /// <value>task_id integer</value>
        [JsonProperty("task_id")]
        public int? TaskId { get; set; }

        /// <summary>
        /// task_id integer
        /// </summary>
        /// <value>task_id integer</value>
        [JsonProperty("completed_at ")]
        public string CompletedAt { get; set; }
    }
}
