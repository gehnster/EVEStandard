using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class RecentKillmail : ModelBase<RecentKillmail>
    {
        /// <summary>
        /// ID of this killmail
        /// </summary>
        /// <value>ID of this killmail</value>
        [JsonProperty("killmail_id")]
        public int? KillmailId { get; set; }

        /// <summary>
        /// A hash of this killmail
        /// </summary>
        /// <value>A hash of this killmail</value>
        [JsonProperty("killmail_hash")]
        public string KillmailHash { get; set; }
    }
}
