using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    /// <summary>
    /// Detailed information about a freelance job
    /// </summary>
    public class FreelanceJobDetail : ModelBase<FreelanceJobDetail>
    {
        #region Properties

        /// <summary>
        /// Job's ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Job's name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Job's state
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Job's last modified
        /// </summary>
        [JsonPropertyName("last_modified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Job's details
        /// </summary>
        [JsonPropertyName("details")]
        public FreelanceJobDetails Details { get; set; }

        /// <summary>
        /// Job's configuration
        /// </summary>
        [JsonPropertyName("configuration")]
        public FreelanceJobConfiguration Configuration { get; set; }

        /// <summary>
        /// Job's access and visibility
        /// </summary>
        [JsonPropertyName("access_and_visibility")]
        public FreelanceJobAccessAndVisibility AccessAndVisibility { get; set; }

        /// <summary>
        /// Job's progress
        /// </summary>
        [JsonPropertyName("progress")]
        public FreelanceJobProgress Progress { get; set; }

        /// <summary>
        /// Job's contribution settings
        /// </summary>
        [JsonPropertyName("contribution")]
        public FreelanceJobContribution Contribution { get; set; }

        /// <summary>
        /// Job's reward
        /// </summary>
        [JsonPropertyName("reward")]
        public FreelanceJobReward Reward { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Job details
    /// </summary>
    public class FreelanceJobDetails : ModelBase<FreelanceJobDetails>
    {
        #region Properties

        /// <summary>
        /// Description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Assigned career path
        /// </summary>
        [JsonPropertyName("career")]
        public string Career { get; set; }

        /// <summary>
        /// Moment this freelance job was created
        /// </summary>
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Moment this freelance job expires
        /// </summary>
        [JsonPropertyName("expires")]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// Moment this freelance job transitioned to a non-active state
        /// </summary>
        [JsonPropertyName("finished")]
        public DateTime? Finished { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        [JsonPropertyName("creator")]
        public FreelanceJobCreator Creator { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Job creator information
    /// </summary>
    public class FreelanceJobCreator : ModelBase<FreelanceJobCreator>
    {
        #region Properties

        /// <summary>
        /// Character that created the job
        /// </summary>
        [JsonPropertyName("character")]
        public FreelanceJobCreatorCharacter Character { get; set; }

        /// <summary>
        /// Corporation that created the job
        /// </summary>
        [JsonPropertyName("corporation")]
        public FreelanceJobCreatorCorporation Corporation { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Character information for job creator
    /// </summary>
    public class FreelanceJobCreatorCharacter : ModelBase<FreelanceJobCreatorCharacter>
    {
        #region Properties

        /// <summary>
        /// Character ID
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Character name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Corporation information for job creator
    /// </summary>
    public class FreelanceJobCreatorCorporation : ModelBase<FreelanceJobCreatorCorporation>
    {
        #region Properties

        /// <summary>
        /// Corporation ID
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Corporation name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Job configuration
    /// </summary>
    public class FreelanceJobConfiguration : ModelBase<FreelanceJobConfiguration>
    {
        #region Properties

        /// <summary>
        /// Contribution method (see SDE for valid values)
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; set; }

        /// <summary>
        /// Version of parameter definition used
        /// </summary>
        [JsonPropertyName("version")]
        public long Version { get; set; }

        /// <summary>
        /// Parameter values (see SDE for parameter definition)
        /// </summary>
        [JsonPropertyName("parameters")]
        public Dictionary<string, FreelanceJobParameter> Parameters { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Base class for freelance job parameters (supports multiple types via discriminator)
    /// </summary>
    public class FreelanceJobParameter : ModelBase<FreelanceJobParameter>
    {
        #region Properties

        /// <summary>
        /// Parameter that matches a type
        /// </summary>
        [JsonPropertyName("matcher")]
        public FreelanceJobParameterMatcher Matcher { get; set; }

        /// <summary>
        /// Parameter that has one or more selected values
        /// </summary>
        [JsonPropertyName("options")]
        public FreelanceJobParameterOptions Options { get; set; }

        /// <summary>
        /// Parameter that can be toggled
        /// </summary>
        [JsonPropertyName("boolean")]
        public FreelanceJobParameterBoolean Boolean { get; set; }

        /// <summary>
        /// Parameter for delivering items to a corporation
        /// </summary>
        [JsonPropertyName("corporation_item_delivery")]
        public FreelanceJobParameterCorporationItemDelivery CorporationItemDelivery { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Parameter that matches a type
    /// </summary>
    public class FreelanceJobParameterMatcher : ModelBase<FreelanceJobParameterMatcher>
    {
        #region Properties

        /// <summary>
        /// Value type(s) and their value(s)
        /// </summary>
        [JsonPropertyName("values")]
        public List<FreelanceJobParameterMatcherValue> Values { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Matcher value with type and ID
    /// </summary>
    public class FreelanceJobParameterMatcherValue : ModelBase<FreelanceJobParameterMatcherValue>
    {
        #region Properties

        /// <summary>
        /// Type of the value(s)
        /// </summary>
        [JsonPropertyName("value_type")]
        public string ValueType { get; set; }

        /// <summary>
        /// Value(s) of this type
        /// </summary>
        [JsonPropertyName("values")]
        public List<string> Values { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Parameter that has one or more selected values
    /// </summary>
    public class FreelanceJobParameterOptions : ModelBase<FreelanceJobParameterOptions>
    {
        /// <summary>
        /// Selected option values
        /// </summary>
        [JsonPropertyName("selected")]
        public List<string> Selected { get; set; }
    }

    /// <summary>
    /// Parameter that can be toggled
    /// </summary>
    public class FreelanceJobParameterBoolean : ModelBase<FreelanceJobParameterBoolean>
    {
        #region Properties

        /// <summary>
        /// Boolean value
        /// </summary>
        [JsonPropertyName("value")]
        public bool Value { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Parameter for delivering items to a corporation
    /// </summary>
    public class FreelanceJobParameterCorporationItemDelivery : ModelBase<FreelanceJobParameterCorporationItemDelivery>
    {
        #region Properties

        /// <summary>
        /// Item(s) to be delivered
        /// </summary>
        [JsonPropertyName("item_type")]
        public FreelanceJobParameterMatcher ItemType { get; set; }

        /// <summary>
        /// Location for delivery
        /// </summary>
        [JsonPropertyName("corporation_office_location")]
        public FreelanceJobParameterMatcher CorporationOfficeLocation { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Job access and visibility settings
    /// </summary>
    public class FreelanceJobAccessAndVisibility : ModelBase<FreelanceJobAccessAndVisibility>
    {
        #region Properties

        /// <summary>
        /// Whether the job is protected by an ACL
        /// </summary>
        [JsonPropertyName("acl_protected")]
        public bool AclProtected { get; set; }

        /// <summary>
        /// Solar systems where the job is broadcast
        /// </summary>
        [JsonPropertyName("broadcast_locations")]
        public List<FreelanceJobBroadcastLocation> BroadcastLocations { get; set; }

        /// <summary>
        /// Restrictions on who can participate
        /// </summary>
        [JsonPropertyName("restrictions")]
        public FreelanceJobRestrictions Restrictions { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Broadcast location for a freelance job
    /// </summary>
    public class FreelanceJobBroadcastLocation : ModelBase<FreelanceJobBroadcastLocation>
    {
        #region Properties

        /// <summary>
        /// Solar system ID
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Solar system name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Restrictions on who can participate in a job
    /// </summary>
    public class FreelanceJobRestrictions : ModelBase<FreelanceJobRestrictions>
    {
        #region Properties

        /// <summary>
        /// List of character IDs with access
        /// </summary>
        [JsonPropertyName("character_ids")]
        public List<long> CharacterIds { get; set; }

        /// <summary>
        /// List of corporation IDs with access
        /// </summary>
        [JsonPropertyName("corporation_ids")]
        public List<long> CorporationIds { get; set; }

        /// <summary>
        /// List of alliance IDs with access
        /// </summary>
        [JsonPropertyName("alliance_ids")]
        public List<long> AllianceIds { get; set; }

        /// <summary>
        /// Minimum security status required
        /// </summary>
        [JsonPropertyName("min_security_status")]
        public float? MinSecurityStatus { get; set; }

        /// <summary>
        /// Minimum standing required
        /// </summary>
        [JsonPropertyName("min_standing")]
        public float? MinStanding { get; set; }

        /// <summary>
        /// Minimum age of the participant, in days
        /// </summary>
        [JsonPropertyName("minimum_age")]
        public long? MinimumAge { get; set; }

        /// <summary>
        /// Maximum age of the participant, in days
        /// </summary>
        [JsonPropertyName("maximum_age")]
        public long? MaximumAge { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Job progress information
    /// </summary>
    public class FreelanceJobProgress : ModelBase<FreelanceJobProgress>
    {
        #region Properties

        /// <summary>
        /// Current progress
        /// </summary>
        [JsonPropertyName("current")]
        public long Current { get; set; }

        /// <summary>
        /// Desired progress
        /// </summary>
        [JsonPropertyName("desired")]
        public long Desired { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Job contribution settings
    /// </summary>
    public class FreelanceJobContribution : ModelBase<FreelanceJobContribution>
    {
        #region Properties

        /// <summary>
        /// Maximum number of participants that can commit to this job
        /// </summary>
        [JsonPropertyName("max_committed_participants")]
        public long MaxCommittedParticipants { get; set; }

        /// <summary>
        /// ISK reward per contribution
        /// </summary>
        [JsonPropertyName("reward_per_contribution")]
        public double? RewardPerContribution { get; set; }

        /// <summary>
        /// Multiplier towards progress per contribution
        /// </summary>
        [JsonPropertyName("submission_multiplier")]
        public double? SubmissionMultiplier { get; set; }

        /// <summary>
        /// Limit on amount of contribution per submission
        /// </summary>
        [JsonPropertyName("submission_limit")]
        public long? SubmissionLimit { get; set; }

        /// <summary>
        /// Limit on the contribution of the individual participant
        /// </summary>
        [JsonPropertyName("contribution_per_participant_limit")]
        public long? ContributionPerParticipantLimit { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Job reward information
    /// </summary>
    public class FreelanceJobReward : ModelBase<FreelanceJobReward>
    {
        #region Properties

        /// <summary>
        /// Original amount of ISK that was reserved for this freelance job
        /// </summary>
        [JsonPropertyName("initial")]
        public double Initial { get; set; }

        /// <summary>
        /// Remaining ISK to be awarded
        /// </summary>
        [JsonPropertyName("remaining")]
        public double Remaining { get; set; }

        #endregion Properties
    }
}
