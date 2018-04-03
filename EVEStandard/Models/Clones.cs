using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class Clones : ModelBase<Clones>
    {
        /// <summary>
        /// last_clone_jump_date string
        /// </summary>
        /// <value>last_clone_jump_date string</value>
        [JsonProperty("last_clone_jump_date")]
        public DateTime? LastCloneJumpDate { get; set; }

        /// <summary>
        /// Gets or Sets HomeLocation
        /// </summary>
        [JsonProperty("home_location")]
        public Location HomeLocation { get; set; }

        /// <summary>
        /// last_station_change_date string
        /// </summary>
        /// <value>last_station_change_date string</value>
        [JsonProperty("last_station_change_date")]
        public DateTime? LastStationChangeDate { get; set; }

        /// <summary>
        /// jump_clones array
        /// </summary>
        /// <value>jump_clones array</value>
        [JsonProperty("jump_clones")]
        public List<JumpClone> JumpClones { get; set; }
    }
}
