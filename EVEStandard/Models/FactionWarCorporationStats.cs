﻿using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class FactionWarCorporationStats : ModelBase<FactionWarCorporationStats>
    {
        #region Properties

        /// <summary>
        /// The enlistment date of the given corporation into faction warfare. Will not be included if corporation is not enlisted in faction warfare
        /// </summary>
        /// <value>The enlistment date of the given corporation into faction warfare. Will not be included if corporation is not enlisted in faction warfare</value>
        [JsonPropertyName("enlisted_on")]
        public DateTime? EnlistedOn { get; set; }

        /// <summary>
        /// The faction the given corporation is enlisted to fight for. Will not be included if corporation is not enlisted in faction warfare
        /// </summary>
        /// <value>The faction the given corporation is enlisted to fight for. Will not be included if corporation is not enlisted in faction warfare</value>
        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }
        /// <summary>
        /// Gets or Sets Kills
        /// </summary>
        [JsonPropertyName("kills")]
        public FactionWarCorporationStatsTimeframe Kills { get; set; }

        /// <summary>
        /// How many pilots the enlisted corporation has. Will not be included if corporation is not enlisted in faction warfare
        /// </summary>
        /// <value>How many pilots the enlisted corporation has. Will not be included if corporation is not enlisted in faction warfare</value>
        [JsonPropertyName("pilots")]
        public int? Pilots { get; set; }
        /// <summary>
        /// Gets or Sets VictoryPoints
        /// </summary>
        [JsonPropertyName("victory_points")]
        public FactionWarCorporationStatsTimeframe VictoryPoints { get; set; }

        #endregion Properties
    }

    public class FactionWarCorporationStatsTimeframe : ModelBase<FactionWarCorporationStatsTimeframe>
    {
        #region Properties

        /// <summary>
        /// Last week&#39;s total number of kills by members of the given corporation against enemy factions
        /// </summary>
        /// <value>Last week&#39;s total number of kills by members of the given corporation against enemy factions</value>
        [JsonPropertyName("last_week")] public int LastWeek { get; set; }

        /// <summary>
        /// Total number of kills by members of the given corporation against enemy factions since the corporation enlisted
        /// </summary>
        /// <value>Total number of kills by members of the given corporation against enemy factions since the corporation enlisted</value>
        [JsonPropertyName("total")] public int Total { get; set; }

        /// <summary>
        /// Yesterday&#39;s total number of kills by members of the given corporation against enemy factions
        /// </summary>
        /// <value>Yesterday&#39;s total number of kills by members of the given corporation against enemy factions</value>
        [JsonPropertyName("yesterday")] public int Yesterday { get; set; }

        #endregion Properties
    }
}
