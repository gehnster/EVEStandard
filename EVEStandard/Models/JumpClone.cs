using System.Collections.Generic;
using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class JumpClone : ModelBase<JumpClone>
    {
        #region Properties

        /// <summary>
        /// implants array
        /// </summary>
        /// <value>implants array</value>
        [JsonPropertyName("implants")]
        public List<int> Implants { get; set; }

        /// <summary>
        /// jump_clone_id integer
        /// </summary>
        /// <value>jump_clone_id integer</value>
        [JsonPropertyName("jump_clone_id")]
        public int JumpCloneId { get; set; }

        /// <summary>
        /// location_id integer
        /// </summary>
        /// <value>location_id integer</value>
        [JsonPropertyName("location_id")]
        public long LocationId { get; set; }

        /// <summary>
        /// location_type string
        /// </summary>
        /// <value>location_type string</value>
        [JsonPropertyName("location_type")]
        public LocationType LocationType { get; set; }

        /// <summary>
        /// name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion Properties
    }
}
