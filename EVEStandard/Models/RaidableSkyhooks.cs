using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class RaidableSkyhooks : ModelBase<RaidableSkyhooks>
    {
        #region Properties

        /// <summary>
        /// List of (upcoming) raidable Skyhooks
        /// </summary>
        /// <value>List of (upcoming) raidable Skyhooks</value>
        [JsonPropertyName("skyhooks")]
        public List<RaidableSkyhook> Skyhooks { get; set; }

        #endregion Properties
    }
}
