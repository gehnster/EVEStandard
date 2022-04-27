using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class FactionWarPilotLeaderboard : ModelBase<FactionWarPilotLeaderboard>
    {
        /// <summary>
        /// Gets or Sets Kills
        /// </summary>
        [JsonPropertyName("kills")]
        public FactionWarPilotTimeframe Kills { get; set; }

        /// <summary>
        /// Gets or Sets VictoryPoints
        /// </summary>
        [JsonPropertyName("victory_points")]
        public FactionWarPilotTimeframe VictoryPoints { get; set; }
    }

    public class FactionWarPilotTimeframe : ModelBase<FactionWarPilotTimeframe>
    {
        /// <summary>
        /// Top 4 ranking of factions in the past day
        /// </summary>
        /// <value>Top 4 ranking of factions in the past day</value>
        [JsonPropertyName("yesterday")]
        public List<FactionWarTopPilot> Yesterday { get; set; }

        /// <summary>
        /// Top 4 ranking of factions in the past week
        /// </summary>
        /// <value>Top 4 ranking of factions in the past week</value>
        [JsonPropertyName("last_week")]
        public List<FactionWarTopPilot> LastWeek { get; set; }

        /// <summary>
        /// Top 4 ranking of factions active in faction warfare. A faction is considered \&quot;active\&quot; if they have participated in faction warfare in the past 14 days.
        /// </summary>
        /// <value>Top 4 ranking of factions active in faction warfare. A faction is considered \&quot;active\&quot; if they have participated in faction warfare in the past 14 days.</value>
        [JsonPropertyName("active_total")]
        public List<FactionWarTopPilot> ActiveTotal { get; set; }
    }

    public class FactionWarTopPilot : ModelBase<FactionWarTopPilot>
    {
        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonPropertyName("character_id")]
        public int? CharacterId { get; set; }

        /// <summary>
        /// Amount of kills
        /// </summary>
        /// <value>Amount of kills</value>
        [JsonPropertyName("amount")]
        public int? Amount { get; set; }
    }
}
