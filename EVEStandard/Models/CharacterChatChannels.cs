using System;
using System.Collections.Generic;
using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CharacterChatChannels : ModelBase<CharacterChatChannels>
    {
        /// <summary>
        ///     Unique channel ID. Always negative for player-created channels. Permanent (CCP created) channels have a positive
        ///     ID, but don&#39;t appear in the API
        /// </summary>
        /// <value>
        ///     Unique channel ID. Always negative for player-created channels. Permanent (CCP created) channels have a positive
        ///     ID, but don&#39;t appear in the API
        /// </value>
        [JsonProperty("channel_id")]
        public int? ChannelId { get; set; }

        /// <summary>
        ///     Displayed name of channel
        /// </summary>
        /// <value>Displayed name of channel</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     owner_id integer
        /// </summary>
        /// <value>owner_id integer</value>
        [JsonProperty("owner_id")]
        public int? OwnerId { get; set; }

        /// <summary>
        ///     Normalized, unique string used to compare channel names
        /// </summary>
        /// <value>Normalized, unique string used to compare channel names</value>
        [JsonProperty("comparison_key")]
        public string ComparisonKey { get; set; }

        /// <summary>
        ///     If this is a password protected channel
        /// </summary>
        /// <value>If this is a password protected channel</value>
        [JsonProperty("has_password")]
        public bool? HasPassword { get; set; }

        /// <summary>
        ///     Message of the day for this channel
        /// </summary>
        /// <value>Message of the day for this channel</value>
        [JsonProperty("motd")]
        public string Motd { get; set; }

        /// <summary>
        ///     allowed array
        /// </summary>
        /// <value>allowed array</value>
        [JsonProperty("allowed")]
        public List<ChatChannelsAllowed> Allowed { get; set; }

        /// <summary>
        ///     operators array
        /// </summary>
        /// <value>operators array</value>
        [JsonProperty("operators")]
        public List<ChatChannelOperators> Operators { get; set; }

        /// <summary>
        ///     blocked array
        /// </summary>
        /// <value>blocked array</value>
        [JsonProperty("blocked")]
        public List<ChatChannelsBlocked> Blocked { get; set; }

        /// <summary>
        ///     muted array
        /// </summary>
        /// <value>muted array</value>
        [JsonProperty("muted")]
        public List<ChatChannelsMuted> Muted { get; set; }
    }

    public class ChatChannelsAllowed : ModelBase<ChatChannelsAllowed>
    {
        /// <summary>
        ///     ID of an allowed channel member
        /// </summary>
        /// <value>ID of an allowed channel member</value>
        [JsonProperty("accessor_id")]
        public int? AccessorId { get; set; }

        /// <summary>
        ///     accessor_type string
        /// </summary>
        /// <value>accessor_type string</value>
        [JsonProperty("accessor_type")]
        public AccessorType? AccessorType { get; set; }
    }

    public class ChatChannelsBlocked : ModelBase<ChatChannelsBlocked>
    {
        /// <summary>
        ///     ID of a blocked channel member
        /// </summary>
        /// <value>ID of a blocked channel member</value>
        [JsonProperty("accessor_id")]
        public int? AccessorId { get; set; }

        /// <summary>
        ///     accessor_type string
        /// </summary>
        /// <value>accessor_type string</value>
        [JsonProperty("accessor_type")]
        public AccessorType? AccessorType { get; set; }

        /// <summary>
        ///     Reason this accessor is blocked
        /// </summary>
        /// <value>Reason this accessor is blocked</value>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        ///     Time at which this accessor will no longer be blocked
        /// </summary>
        /// <value>Time at which this accessor will no longer be blocked</value>
        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }
    }

    public class ChatChannelsMuted : ModelBase<ChatChannelsMuted>
    {
        /// <summary>
        ///     ID of a muted channel member
        /// </summary>
        /// <value>ID of a muted channel member</value>
        [JsonProperty("accessor_id")]
        public int? AccessorId { get; set; }

        /// <summary>
        ///     accessor_type string
        /// </summary>
        /// <value>accessor_type string</value>
        [JsonProperty("accessor_type")]
        public AccessorType? AccessorType { get; set; }

        /// <summary>
        ///     Reason this accessor is muted
        /// </summary>
        /// <value>Reason this accessor is muted</value>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        ///     Time at which this accessor will no longer be muted
        /// </summary>
        /// <value>Time at which this accessor will no longer be muted</value>
        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }
    }

    public class ChatChannelOperators : ModelBase<ChatChannelOperators>
    {
        /// <summary>
        ///     ID of a channel operator
        /// </summary>
        /// <value>ID of a channel operator</value>
        [JsonProperty("accessor_id")]
        public int? AccessorId { get; set; }

        /// <summary>
        ///     accessor_type string
        /// </summary>
        /// <value>accessor_type string</value>
        [JsonProperty("accessor_type")]
        public AccessorType? AccessorType { get; set; }
    }
}