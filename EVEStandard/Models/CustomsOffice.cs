using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CustomsOffice : ModelBase<CustomsOffice>
    {
        #region Enums

        /// <summary>
        /// Access is allowed only for entities with this level of standing or better
        /// </summary>
        /// <value>Access is allowed only for entities with this level of standing or better</value>
        public enum StandingLevelEnum
        {
            bad = 1,
            excellent = 2,
            good = 3,
            neutral = 4,
            terrible = 5
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// Only present if alliance access is allowed
        /// </summary>
        /// <value>Only present if alliance access is allowed</value>
        [JsonPropertyName("alliance_tax_rate")]
        public float? AllianceTaxRate { get; set; }

        /// <summary>
        /// standing_level and any standing related tax rate only present when this is true
        /// </summary>
        /// <value>standing_level and any standing related tax rate only present when this is true</value>
        [JsonPropertyName("allow_access_with_standings")]
        public bool AllowAccessWithStandings { get; set; }

        /// <summary>
        /// allow_alliance_access boolean
        /// </summary>
        /// <value>allow_alliance_access boolean</value>
        [JsonPropertyName("allow_alliance_access")]
        public bool AllowAllianceAccess { get; set; }

        /// <summary>
        /// bad_standing_tax_rate number
        /// </summary>
        /// <value>bad_standing_tax_rate number</value>
        [JsonPropertyName("bad_standing_tax_rate")]
        public float? BadStandingTaxRate { get; set; }

        /// <summary>
        /// corporation_tax_rate number
        /// </summary>
        /// <value>corporation_tax_rate number</value>
        [JsonPropertyName("corporation_tax_rate")]
        public float? CorporationTaxRate { get; set; }

        /// <summary>
        /// Tax rate for entities with excellent level of standing, only present if this level is allowed, same for all other standing related tax rates
        /// </summary>
        /// <value>Tax rate for entities with excellent level of standing, only present if this level is allowed, same for all other standing related tax rates</value>
        [JsonPropertyName("excellent_standing_tax_rate")]
        public float? ExcellentStandingTaxRate { get; set; }

        /// <summary>
        /// good_standing_tax_rate number
        /// </summary>
        /// <value>good_standing_tax_rate number</value>
        [JsonPropertyName("good_standing_tax_rate")]
        public float? GoodStandingTaxRate { get; set; }

        /// <summary>
        /// neutral_standing_tax_rate number
        /// </summary>
        /// <value>neutral_standing_tax_rate number</value>
        [JsonPropertyName("neutral_standing_tax_rate")]
        public float? NeutralStandingTaxRate { get; set; }

        /// <summary>
        /// unique ID of this customs office
        /// </summary>
        /// <value>unique ID of this customs office</value>
        [JsonPropertyName("office_id")]
        public long OfficeId { get; set; }

        /// <summary>
        /// reinforce_exit_end integer
        /// </summary>
        /// <value>reinforce_exit_end integer</value>
        [JsonPropertyName("reinforce_exit_end")]
        public int ReinforceExitEnd { get; set; }

        /// <summary>
        /// Together with reinforce_exit_end, marks a 2-hour period where this customs office could exit reinforcement mode during the day after initial attack
        /// </summary>
        /// <value>Together with reinforce_exit_end, marks a 2-hour period where this customs office could exit reinforcement mode during the day after initial attack</value>
        [JsonPropertyName("reinforce_exit_start")]
        public int ReinforceExitStart { get; set; }

        /// <summary>
        /// Access is allowed only for entities with this level of standing or better
        /// </summary>
        /// <value>Access is allowed only for entities with this level of standing or better</value>
        [JsonPropertyName("standing_level")]
        public StandingLevelEnum? StandingLevel { get; set; }

        /// <summary>
        /// ID of the solar system this customs office is located in
        /// </summary>
        /// <value>ID of the solar system this customs office is located in</value>
        [JsonPropertyName("system_id")]
        public int SystemId { get; set; }
        /// <summary>
        /// terrible_standing_tax_rate number
        /// </summary>
        /// <value>terrible_standing_tax_rate number</value>
        [JsonPropertyName("terrible_standing_tax_rate")]
        public float? TerribleStandingTaxRate { get; set; }

        #endregion Properties
    }
}
