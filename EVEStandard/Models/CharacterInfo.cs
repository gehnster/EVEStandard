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
        public long? AllianceId { get; set; }

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
        public long BloodlineId { get; set; }

        /// <summary>
        ///     The character&#39;s corporation ID
        /// </summary>
        /// <value>The character&#39;s corporation ID</value>
        [JsonPropertyName("corporation_id")]
        public long CorporationId { get; set; }

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
        public long? FactionId { get; set; }

        /// <summary>
        ///     gender string
        /// </summary>
        /// <value>gender string</value>

        [JsonPropertyName("gender")]

        public string Gender { get; set; }

        /// <summary>

        /// Gets the Gender as enum (may throw exception if unknown value exists).

        /// </summary>

        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]

        public GenderEnum GenderToEnum 

        {

            get => (GenderEnum)Enum.Parse(typeof(GenderEnum), Gender);

        }

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
        public long RaceId { get; set; }
        /// <summary>
        ///     security_status number
        /// </summary>
        /// <value>security_status number</value>
        [JsonPropertyName("security_status")]
        public float? SecurityStatus { get; set; }

        /// <summary>
        /// The individual title of the character.
        /// </summary>
        /// <remarks>
        /// Renamed to <c>corporation_title</c> by ESI at compatibility date 2026-06-09; populated only at
        /// earlier compatibility dates. Use <see cref="CorporationTitle"/> at 2026-06-09 and later.
        /// See https://developers.eveonline.com/blog/cradle-of-war-on-esi-character-titles-and-achievements
        /// </remarks>
        [Obsolete("Renamed to corporation_title by ESI at compatibility date 2026-06-09. Use CorporationTitle at 2026-06-09 and later.")]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The character's corporation title. Available at compatibility date 2026-06-09 and later
        /// (the renamed replacement for <see cref="Title"/>).
        /// </summary>
        /// <value>The character's corporation title.</value>
        [JsonPropertyName("corporation_title")]
        public string CorporationTitle { get; set; }

        /// <summary>
        /// The ID (UUID) of the title currently displayed by the character. Available at compatibility
        /// date 2026-06-09 and later.
        /// </summary>
        /// <value>The ID of the title currently displayed by the character.</value>
        [JsonPropertyName("character_title_id")]
        public string CharacterTitleId { get; set; }

        /// <summary>
        /// The character's total achievement score. Available at compatibility date 2026-06-09 and later.
        /// </summary>
        /// <value>The character's total achievement score.</value>
        [JsonPropertyName("achievement_score")]
        public long? AchievementScore { get; set; }

        #endregion Properties
    }
}