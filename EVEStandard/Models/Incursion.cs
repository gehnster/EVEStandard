﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Incursion : ModelBase<Incursion>
    {
        #region Enums

        /// <summary>
        /// The state of this incursion
        /// </summary>
        /// <value>The state of this incursion</value>
        public enum StateEnum
        {
            withdrawing = 1,
            mobilizing = 2,
            established = 3
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// The constellation id in which this incursion takes place
        /// </summary>
        /// <value>The constellation id in which this incursion takes place</value>
        [JsonPropertyName("constellation_id")]
        public int ConstellationId { get; set; }

        /// <summary>
        /// The attacking faction&#39;s id
        /// </summary>
        /// <value>The attacking faction&#39;s id</value>
        [JsonPropertyName("faction_id")]
        public int FactionId { get; set; }

        /// <summary>
        /// Whether the final encounter has boss or not
        /// </summary>
        /// <value>Whether the final encounter has boss or not</value>
        [JsonPropertyName("has_boss")]
        public bool HasBoss { get; set; }

        /// <summary>
        /// A list of infested solar system ids that are a part of this incursion
        /// </summary>
        /// <value>A list of infested solar system ids that are a part of this incursion</value>
        [JsonPropertyName("infested_solar_systems")]
        public List<int> InfestedSolarSystems { get; set; }

        /// <summary>
        /// Influence of this incursion as a float from 0 to 1
        /// </summary>
        /// <value>Influence of this incursion as a float from 0 to 1</value>
        [JsonPropertyName("influence")]
        public float Influence { get; set; }

        /// <summary>
        /// Staging solar system for this incursion
        /// </summary>
        /// <value>Staging solar system for this incursion</value>
        [JsonPropertyName("staging_solar_system_id")]
        public int StagingSolarSystemId { get; set; }

        /// <summary>
        /// The state of this incursion
        /// </summary>
        /// <value>The state of this incursion</value>
        [JsonPropertyName("state")]
        public StateEnum State { get; set; }

        /// <summary>
        /// The type of this incursion
        /// </summary>
        /// <value>The type of this incursion</value>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        #endregion Properties
    }
}
