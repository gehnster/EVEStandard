﻿using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Starbase : ModelBase<Starbase>
    {
        #region Enums

        /// <summary>
        /// state string
        /// </summary>
        /// <value>state string</value>
        public enum StateEnum
        {
            offline = 1,
            online = 2,
            onlining = 3,
            reinforced = 4,
            unanchoring = 5
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// The moon this starbase (POS) is anchored on, unanchored POSes do not have this information
        /// </summary>
        /// <value>The moon this starbase (POS) is anchored on, unanchored POSes do not have this information</value>
        [JsonPropertyName("moon_id")]
        public int? MoonId { get; set; }

        /// <summary>
        /// When the POS onlined, for starbases (POSes) in online state
        /// </summary>
        /// <value>When the POS onlined, for starbases (POSes) in online state</value>
        [JsonPropertyName("onlined_since")]
        public DateTime? OnlinedSince { get; set; }

        /// <summary>
        /// When the POS will be out of reinforcement, for starbases (POSes) in reinforced state
        /// </summary>
        /// <value>When the POS will be out of reinforcement, for starbases (POSes) in reinforced state</value>
        [JsonPropertyName("reinforced_until")]
        public DateTime? ReinforcedUntil { get; set; }

        /// <summary>
        /// Unique ID for this starbase (POS)
        /// </summary>
        /// <value>Unique ID for this starbase (POS)</value>
        [JsonPropertyName("starbase_id")]
        public long StarbaseId { get; set; }

        /// <summary>
        /// state string
        /// </summary>
        /// <value>state string</value>
        [JsonPropertyName("state")]
        public StateEnum? State { get; set; }

        /// <summary>
        /// The solar system this starbase (POS) is in, unanchored POSes have this information
        /// </summary>
        /// <value>The solar system this starbase (POS) is in, unanchored POSes have this information</value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }

        /// <summary>
        /// Starbase (POS) type
        /// </summary>
        /// <value>Starbase (POS) type</value>
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }
        /// <summary>
        /// When the POS started unanchoring, for starbases (POSes) in unanchoring state
        /// </summary>
        /// <value>When the POS started unanchoring, for starbases (POSes) in unanchoring state</value>
        [JsonPropertyName("unanchor_at")]
        public DateTime? UnanchorAt { get; set; }

        #endregion Properties
    }
}
