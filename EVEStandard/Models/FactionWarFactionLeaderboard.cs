using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class FactionWarFactionLeaderboard : ModelBase<FactionWarFactionLeaderboard>
    {
        /// <summary>
        /// Gets or Sets Kills
        /// </summary>
        [JsonPropertyName("kills")]
        public FactionWarFactionTimeframe Kills { get; set; }

        /// <summary>
        /// Gets or Sets VictoryPoints
        /// </summary>
        [JsonPropertyName("victory_points")]
        public FactionWarFactionTimeframe VictoryPoints { get; set; }
    }

    public class FactionWarFactionTimeframe : ModelBase<FactionWarFactionTimeframe>
    {
        /// <summary>
        /// Top 4 ranking of factions in the past day
        /// </summary>
        /// <value>Top 4 ranking of factions in the past day</value>
        [JsonPropertyName("yesterday")]
        public List<FactionWarTopFaction> Yesterday { get; set; }

        /// <summary>
        /// Top 4 ranking of factions in the past week
        /// </summary>
        /// <value>Top 4 ranking of factions in the past week</value>
        [JsonPropertyName("last_week")]
        public List<FactionWarTopFaction> LastWeek { get; set; }

        /// <summary>
        /// Top 4 ranking of factions active in faction warfare. A faction is considered \&quot;active\&quot; if they have participated in faction warfare in the past 14 days.
        /// </summary>
        /// <value>Top 4 ranking of factions active in faction warfare. A faction is considered \&quot;active\&quot; if they have participated in faction warfare in the past 14 days.</value>
        [JsonPropertyName("active_total")]
        public List<FactionWarTopFaction> ActiveTotal { get; set; }
    }

    public class FactionWarTopFaction : ModelBase<FactionWarTopFaction>
    {
        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }

        /// <summary>
        /// Amount of kills
        /// </summary>
        /// <value>Amount of kills</value>
        [JsonPropertyName("amount")]
        public int? Amount { get; set; }
    }
}
