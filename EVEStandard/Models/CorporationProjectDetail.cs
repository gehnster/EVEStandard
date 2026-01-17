using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Detailed information about a corporation project
    /// </summary>
    public class CorporationProjectDetail : ModelBase<CorporationProjectDetail>
    {
        #region Properties

        /// <summary>
        /// Project's ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Project's name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Project's current state
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Moment this project was last modified. Project contributions also count as a modification
        /// </summary>
        [JsonPropertyName("last_modified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Project's details
        /// </summary>
        [JsonPropertyName("details")]
        public ProjectDetails Details { get; set; }

        /// <summary>
        /// Project's creator
        /// </summary>
        [JsonPropertyName("creator")]
        public ProjectCreator Creator { get; set; }

        /// <summary>
        /// Project's configuration
        /// </summary>
        [JsonPropertyName("configuration")]
        public ProjectConfiguration Configuration { get; set; }

        /// <summary>
        /// Project's progress
        /// </summary>
        [JsonPropertyName("progress")]
        public ProjectProgress Progress { get; set; }

        /// <summary>
        /// Project's contribution settings
        /// </summary>
        [JsonPropertyName("contribution")]
        public ProjectContribution Contribution { get; set; }

        /// <summary>
        /// Project's reward
        /// </summary>
        [JsonPropertyName("reward")]
        public ProjectReward Reward { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Project details
    /// </summary>
    public class ProjectDetails : ModelBase<ProjectDetails>
    {
        #region Properties

        /// <summary>
        /// Project description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Project creation time
        /// </summary>
        [JsonPropertyName("created")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Project expiration time
        /// </summary>
        [JsonPropertyName("expires")]
        public DateTime? Expires { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Project creator information
    /// </summary>
    public class ProjectCreator : ModelBase<ProjectCreator>
    {
        #region Properties

        /// <summary>
        /// Character ID of the project creator
        /// </summary>
        [JsonPropertyName("character_id")]
        public long CharacterId { get; set; }

        /// <summary>
        /// Corporation ID of the project creator
        /// </summary>
        [JsonPropertyName("corporation_id")]
        public long? CorporationId { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Project configuration (supports multiple types via discriminator)
    /// </summary>
    public class ProjectConfiguration : ModelBase<ProjectConfiguration>
    {
        #region Properties

        /// <summary>
        /// Capture factional warfare complex configuration
        /// </summary>
        [JsonPropertyName("capture_fw_complex")]
        public CaptureFwComplexConfig CaptureFwComplex { get; set; }

        /// <summary>
        /// Damage ship configuration
        /// </summary>
        [JsonPropertyName("damage_ship")]
        public DamageShipConfig DamageShip { get; set; }

        /// <summary>
        /// Defend factional warfare complex configuration
        /// </summary>
        [JsonPropertyName("defend_fw_complex")]
        public DefendFwComplexConfig DefendFwComplex { get; set; }

        /// <summary>
        /// Deliver item configuration
        /// </summary>
        [JsonPropertyName("deliver_item")]
        public DeliverItemConfig DeliverItem { get; set; }

        /// <summary>
        /// Destroy NPC configuration
        /// </summary>
        [JsonPropertyName("destroy_npc")]
        public DestroyNpcConfig DestroyNpc { get; set; }

        /// <summary>
        /// Destroy ship configuration
        /// </summary>
        [JsonPropertyName("destroy_ship")]
        public DestroyShipConfig DestroyShip { get; set; }

        /// <summary>
        /// Earn loyalty point configuration
        /// </summary>
        [JsonPropertyName("earn_loyalty_point")]
        public EarnLoyaltyPointConfig EarnLoyaltyPoint { get; set; }

        /// <summary>
        /// Lost ship configuration
        /// </summary>
        [JsonPropertyName("lost_ship")]
        public LostShipConfig LostShip { get; set; }

        /// <summary>
        /// Manual contribution configuration
        /// </summary>
        [JsonPropertyName("manual")]
        public ManualConfig Manual { get; set; }

        /// <summary>
        /// Manufacture item configuration
        /// </summary>
        [JsonPropertyName("manufacture_item")]
        public ManufactureItemConfig ManufactureItem { get; set; }

        /// <summary>
        /// Mine material configuration
        /// </summary>
        [JsonPropertyName("mine_material")]
        public MineMaterialConfig MineMaterial { get; set; }

        /// <summary>
        /// Remote boost shield configuration
        /// </summary>
        [JsonPropertyName("remote_boost_shield")]
        public RemoteBoostShieldConfig RemoteBoostShield { get; set; }

        /// <summary>
        /// Remote repair armor configuration
        /// </summary>
        [JsonPropertyName("remote_repair_armor")]
        public RemoteRepairArmorConfig RemoteRepairArmor { get; set; }

        /// <summary>
        /// Salvage wreck configuration
        /// </summary>
        [JsonPropertyName("salvage_wreck")]
        public SalvageWreckConfig SalvageWreck { get; set; }

        /// <summary>
        /// Scan signature configuration
        /// </summary>
        [JsonPropertyName("scan_signature")]
        public ScanSignatureConfig ScanSignature { get; set; }

        /// <summary>
        /// Ship insurance configuration
        /// </summary>
        [JsonPropertyName("ship_insurance")]
        public ShipInsuranceConfig ShipInsurance { get; set; }

        /// <summary>
        /// Unknown configuration
        /// </summary>
        [JsonPropertyName("unknown")]
        public UnknownConfig Unknown { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Project progress information
    /// </summary>
    public class ProjectProgress : ModelBase<ProjectProgress>
    {
        #region Properties

        /// <summary>
        /// Current progress value
        /// </summary>
        [JsonPropertyName("current")]
        public long? Current { get; set; }

        /// <summary>
        /// Target progress value
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        /// <summary>
        /// Progress percentage
        /// </summary>
        [JsonPropertyName("percentage")]
        public float? Percentage { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Project contribution settings
    /// </summary>
    public class ProjectContribution : ModelBase<ProjectContribution>
    {
        #region Properties

        /// <summary>
        /// Whether contributions are allowed
        /// </summary>
        [JsonPropertyName("allowed")]
        public bool? Allowed { get; set; }

        /// <summary>
        /// Minimum contribution amount
        /// </summary>
        [JsonPropertyName("minimum")]
        public long? Minimum { get; set; }

        /// <summary>
        /// Maximum contribution amount
        /// </summary>
        [JsonPropertyName("maximum")]
        public long? Maximum { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Project reward information
    /// </summary>
    public class ProjectReward : ModelBase<ProjectReward>
    {
        #region Properties

        /// <summary>
        /// Reward amount
        /// </summary>
        [JsonPropertyName("amount")]
        public long? Amount { get; set; }

        /// <summary>
        /// Reward type ID
        /// </summary>
        [JsonPropertyName("type_id")]
        public long? TypeId { get; set; }

        /// <summary>
        /// Reward description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        #endregion Properties
    }

    #region Configuration Types

    /// <summary>
    /// Capture factional warfare complex configuration
    /// </summary>
    public class CaptureFwComplexConfig : ModelBase<CaptureFwComplexConfig>
    {
        #region Properties

        /// <summary>
        /// Target number of captures
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Damage ship configuration
    /// </summary>
    public class DamageShipConfig : ModelBase<DamageShipConfig>
    {
        #region Properties

        /// <summary>
        /// Target damage amount
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Defend factional warfare complex configuration
    /// </summary>
    public class DefendFwComplexConfig : ModelBase<DefendFwComplexConfig>
    {
        #region Properties

        /// <summary>
        /// Target number of defenses
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Deliver item configuration
    /// </summary>
    public class DeliverItemConfig : ModelBase<DeliverItemConfig>
    {
        #region Properties

        /// <summary>
        /// Item type ID to deliver
        /// </summary>
        [JsonPropertyName("type_id")]
        public long? TypeId { get; set; }

        /// <summary>
        /// Target quantity to deliver
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Destroy NPC configuration
    /// </summary>
    public class DestroyNpcConfig : ModelBase<DestroyNpcConfig>
    {
        #region Properties

        /// <summary>
        /// Target number of NPCs to destroy
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Destroy ship configuration
    /// </summary>
    public class DestroyShipConfig : ModelBase<DestroyShipConfig>
    {
        #region Properties

        /// <summary>
        /// Target number of ships to destroy
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Earn loyalty point configuration
    /// </summary>
    public class EarnLoyaltyPointConfig : ModelBase<EarnLoyaltyPointConfig>
    {
        #region Properties

        /// <summary>
        /// Corporation ID for loyalty points
        /// </summary>
        [JsonPropertyName("corporation_id")]
        public long? CorporationId { get; set; }

        /// <summary>
        /// Target loyalty points to earn
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Lost ship configuration
    /// </summary>
    public class LostShipConfig : ModelBase<LostShipConfig>
    {
        #region Properties

        /// <summary>
        /// Target number of ships lost
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Manual contribution configuration
    /// </summary>
    public class ManualConfig : ModelBase<ManualConfig>
    {
        #region Properties

        /// <summary>
        /// Target amount for manual contribution
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Manufacture item configuration
    /// </summary>
    public class ManufactureItemConfig : ModelBase<ManufactureItemConfig>
    {
        #region Properties

        /// <summary>
        /// Item type ID to manufacture
        /// </summary>
        [JsonPropertyName("type_id")]
        public long? TypeId { get; set; }

        /// <summary>
        /// Target quantity to manufacture
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Mine material configuration
    /// </summary>
    public class MineMaterialConfig : ModelBase<MineMaterialConfig>
    {
        #region Properties

        /// <summary>
        /// Material type ID to mine
        /// </summary>
        [JsonPropertyName("type_id")]
        public long? TypeId { get; set; }

        /// <summary>
        /// Target quantity to mine
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Remote boost shield configuration
    /// </summary>
    public class RemoteBoostShieldConfig : ModelBase<RemoteBoostShieldConfig>
    {
        #region Properties

        /// <summary>
        /// Target shield boost amount
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Remote repair armor configuration
    /// </summary>
    public class RemoteRepairArmorConfig : ModelBase<RemoteRepairArmorConfig>
    {
        #region Properties

        /// <summary>
        /// Target armor repair amount
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Salvage wreck configuration
    /// </summary>
    public class SalvageWreckConfig : ModelBase<SalvageWreckConfig>
    {
        #region Properties

        /// <summary>
        /// Target number of wrecks to salvage
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Scan signature configuration
    /// </summary>
    public class ScanSignatureConfig : ModelBase<ScanSignatureConfig>
    {
        #region Properties

        /// <summary>
        /// Target number of signatures to scan
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Ship insurance configuration
    /// </summary>
    public class ShipInsuranceConfig : ModelBase<ShipInsuranceConfig>
    {
        #region Properties

        /// <summary>
        /// Target insurance amount
        /// </summary>
        [JsonPropertyName("target")]
        public long? Target { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Unknown configuration type
    /// </summary>
    public class UnknownConfig : ModelBase<UnknownConfig>
    {
        #region Properties

        /// <summary>
        /// Raw configuration data
        /// </summary>
        [JsonPropertyName("data")]
        public Dictionary<string, object> Data { get; set; }

        #endregion Properties
    }

    #endregion Configuration Types
}
