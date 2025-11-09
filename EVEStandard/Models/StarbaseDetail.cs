using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class StarbaseDetail : ModelBase<StarbaseDetail>
    {
        #region Enums

        /// <summary>
        /// Who can view the starbase (POS)'s fuel bay. Characters either need to have required role or belong to the starbase (POS) owner's corporation or alliance, as described by the enum, all other access settings follows the same scheme
        /// </summary>
        /// <value>Who can view the starbase (POS)'s fuel bay. Characters either need to have required role or belong to the starbase (POS) owner's corporation or alliance, as described by the enum, all other access settings follows the same scheme</value>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum PermissionEnum
        {
            alliance_member = 1,
            config_starbase_equipment_role = 2,
            corporation_member = 3,
            starbase_fuel_technician_role = 4
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// allow_alliance_members boolean
        /// </summary>
        /// <value>allow_alliance_members boolean</value>
        [JsonPropertyName("allow_alliance_members")]
        public bool AllowAllianceMembers { get; set; }

        /// <summary>
        /// allow_corporation_members boolean
        /// </summary>
        /// <value>allow_corporation_members boolean</value>
        [JsonPropertyName("allow_corporation_members")]
        public bool AllowCorporationMembers { get; set; }

        /// <summary>
        /// Who can anchor starbase (POS) and its structures
        /// </summary>
        /// <value>Who can anchor starbase (POS) and its structures</value>
        [JsonPropertyName("anchor")]
        public string Anchor { get; set; }

        /// <summary>
        /// Gets the Anchor as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public PermissionEnum AnchorToEnum 
        {
            get => (PermissionEnum)Enum.Parse(typeof(PermissionEnum), Anchor);
        }

        /// <summary>
        /// attack_if_at_war boolean
        /// </summary>
        /// <value>attack_if_at_war boolean</value>
        [JsonPropertyName("attack_if_at_war")]
        public bool AttackIfAtWar { get; set; }

        /// <summary>
        /// attack_if_other_security_status_dropping boolean
        /// </summary>
        /// <value>attack_if_other_security_status_dropping boolean</value>
        [JsonPropertyName("attack_if_other_security_status_dropping")]
        public bool? AttackIfOtherSecurityStatusDropping { get; set; }

        /// <summary>
        /// Starbase (POS) will attack if target&#39;s security standing is lower than this value
        /// </summary>
        /// <value>Starbase (POS) will attack if target&#39;s security standing is lower than this value</value>
        [JsonPropertyName("attack_security_status_threshold")]
        public float? AttackSecurityStatusThreshold { get; set; }

        /// <summary>
        /// Starbase (POS) will attack if target&#39;s standing is lower than this value
        /// </summary>
        /// <value>Starbase (POS) will attack if target&#39;s standing is lower than this value</value>
        [JsonPropertyName("attack_standing_threshold")]
        public float? AttackStandingThreshold { get; set; }

        /// <summary>
        /// Who can take fuel blocks out of the starbase (POS)&#39;s fuel bay
        /// </summary>
        /// <value>Who can take fuel blocks out of the starbase (POS)&#39;s fuel bay</value>
        [JsonPropertyName("fuel_bay_take")]
        public string FuelBayTake { get; set; }

        /// <summary>
        /// Gets the FuelBayTake as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public PermissionEnum FuelBayTakeToEnum 
        {
            get => (PermissionEnum)Enum.Parse(typeof(PermissionEnum), FuelBayTake);
        }

        /// <summary>
        /// Who can view the starbase (POS)&#39;s fule bay. Characters either need to have required role or belong to the starbase (POS) owner&#39;s corporation or alliance, as described by the enum, all other access settings follows the same scheme
        /// </summary>
        /// <value>Who can view the starbase (POS)&#39;s fule bay. Characters either need to have required role or belong to the starbase (POS) owner&#39;s corporation or alliance, as described by the enum, all other access settings follows the same scheme</value>
        [JsonPropertyName("fuel_bay_view")]
        public string FuelBayView { get; set; }

        /// <summary>
        /// Gets the FuelBayView as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public PermissionEnum FuelBayViewToEnum 
        {
            get => (PermissionEnum)Enum.Parse(typeof(PermissionEnum), FuelBayView);
        }
        /// <summary>
        /// Fuel blocks and other things that will be consumed when operating a starbase (POS)
        /// </summary>
        /// <value>Fuel blocks and other things that will be consumed when operating a starbase (POS)</value>
        [JsonPropertyName("fuels")]
        public List<StarbaseFuel> Fuels { get; set; }

        /// <summary>
        /// Who can offline starbase (POS) and its structures
        /// </summary>
        /// <value>Who can offline starbase (POS) and its structures</value>
        [JsonPropertyName("offline")]
        public string Offline { get; set; }

        /// <summary>
        /// Gets the Offline as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public PermissionEnum OfflineToEnum 
        {
            get => (PermissionEnum)Enum.Parse(typeof(PermissionEnum), Offline);
        }

        /// <summary>
        /// Who can online starbase (POS) and its structures
        /// </summary>
        /// <value>Who can online starbase (POS) and its structures</value>
        [JsonPropertyName("online")]
        public string Online { get; set; }

        /// <summary>
        /// Gets the Online as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public PermissionEnum OnlineToEnum 
        {
            get => (PermissionEnum)Enum.Parse(typeof(PermissionEnum), Online);
        }

        /// <summary>
        /// Who can unanchor starbase (POS) and its structures
        /// </summary>
        /// <value>Who can unanchor starbase (POS) and its structures</value>
        [JsonPropertyName("unanchor")]
        public string Unanchor { get; set; }

        /// <summary>
        /// Gets the Unanchor as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public PermissionEnum UnanchorToEnum 
        {
            get => (PermissionEnum)Enum.Parse(typeof(PermissionEnum), Unanchor);
        }
        /// <summary>
        /// True if the starbase (POS) is using alliance standings, otherwise using corporation&#39;s
        /// </summary>
        /// <value>True if the starbase (POS) is using alliance standings, otherwise using corporation&#39;s</value>
        [JsonPropertyName("use_alliance_standings")]
        public bool UseAllianceStandings { get; set; }

        #endregion Properties
    }

    public class StarbaseFuel : ModelBase<StarbaseFuel>
    {
        #region Properties

        /// <summary>
        /// quantity integer
        /// </summary>
        /// <value>quantity integer</value>
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// type_id integer
        /// </summary>
        /// <value>type_id integer</value>
        [JsonPropertyName("type_id")]
        public int? TypeId { get; set; }

        #endregion Properties
    }
}
