using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class OpportunitiesTask : ModelBase<OpportunitiesTask>
    {
        #region Properties

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// notification string
        /// </summary>
        /// <value>notification string</value>
        [JsonPropertyName("notification")]
        public string Notification { get; set; }

        /// <summary>
        /// task_id integer
        /// </summary>
        /// <value>task_id integer</value>
        [JsonPropertyName("task_id")]
        public int TaskId { get; set; }

        #endregion Properties
    }
}
