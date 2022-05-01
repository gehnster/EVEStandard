using System;
using EVEStandard.Enumerations;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterInfo : ModelBase<CharacterInfo>
    {
        #region Properties

        /// <summary>
        ///     The character&#39;s alliance ID
        /// </summary>
        /// <value>The character&#39;s alliance ID</value>
        [JsonPropertyName("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        ///     Creation date of the character
        /// </summary>
        /// <value>Creation date of the character</value>
        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        ///     bloodline_id integer
        /// </summary>
        /// <value>bloodline_id integer</value>
        [JsonPropertyName("bloodline_id")]
        public int BloodlineId { get; set; }

        /// <summary>
        ///     The character&#39;s corporation ID
        /// </summary>
        /// <value>The character&#39;s corporation ID</value>
        [JsonPropertyName("corporation_id")]
        public int CorporationId { get; set; }

        /// <summary>
        ///     description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     ID of the faction the character is fighting for, if the character is enlisted in Factional Warfare
        /// </summary>
        /// <value>ID of the faction the character is fighting for, if the character is enlisted in Factional Warfare</value>
        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }

        /// <summary>
        ///     gender string
        /// </summary>
        /// <value>gender string</value>
        [JsonPropertyName("gender")]
        public GenderEnum Gender { get; set; }

        /// <summary>
        ///     name string
        /// </summary>
        /// <value>name string</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        ///     race_id integer
        /// </summary>
        /// <value>race_id integer</value>
        [JsonPropertyName("race_id")]
        public int RaceId { get; set; }
        /// <summary>
        ///     security_status number
        /// </summary>
        /// <value>security_status number</value>
        [JsonPropertyName("security_status")]
        public float? SecurityStatus { get; set; }

        /// <summary>
        /// The individual title of the character
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        #endregion Properties
    }
}