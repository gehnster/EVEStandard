using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Clones : ModelBase<Clones>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets HomeLocation
        /// </summary>
        [JsonPropertyName("home_location")]
        public Location HomeLocation { get; set; }

        /// <summary>
        /// jump_clones array
        /// </summary>
        /// <value>jump_clones array</value>
        [JsonPropertyName("jump_clones")]
        public List<JumpClone> JumpClones { get; set; }

        /// <summary>
        /// last_clone_jump_date string
        /// </summary>
        /// <value>last_clone_jump_date string</value>
        [JsonPropertyName("last_clone_jump_date")]
        public DateTime? LastCloneJumpDate { get; set; }
        /// <summary>
        /// last_station_change_date string
        /// </summary>
        /// <value>last_station_change_date string</value>
        [JsonPropertyName("last_station_change_date")]
        public DateTime? LastStationChangeDate { get; set; }

        #endregion Properties
    }
}
