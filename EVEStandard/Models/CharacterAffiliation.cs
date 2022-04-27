using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterAffiliation : ModelBase<CharacterAffiliation>
    {
        #region Properties

        /// <summary>
        ///     The character&#39;s alliance ID, if their corporation is in an alliance
        /// </summary>
        /// <value>The character&#39;s alliance ID, if their corporation is in an alliance</value>
        [JsonPropertyName("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        ///     The character&#39;s ID
        /// </summary>
        /// <value>The character&#39;s ID</value>
        [JsonPropertyName("character_id")]
        public int CharacterId { get; set; }

        /// <summary>
        ///     The character&#39;s corporation ID
        /// </summary>
        /// <value>The character&#39;s corporation ID</value>
        [JsonPropertyName("corporation_id")]
        public int CorporationId { get; set; }
        /// <summary>
        ///     The character&#39;s faction ID, if their corporation is in a faction
        /// </summary>
        /// <value>The character&#39;s faction ID, if their corporation is in a faction</value>
        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }

        #endregion Properties
    }
}