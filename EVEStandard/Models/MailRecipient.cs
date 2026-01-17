using System;
﻿using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MailRecipient : ModelBase<MailRecipient>
    {
        #region Enums

        /// <summary>
        /// recipient_type string
        /// </summary>
        /// <value>recipient_type string</value>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum RecipientTypeEnum
        {
            alliance = 1,
            character = 2,
            corporation = 3,
            mailing_list = 4
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// recipient_id integer
        /// </summary>
        /// <value>recipient_id integer</value>
        [JsonPropertyName("recipient_id")]
        public long RecipientId { get; set; }

        /// <summary>
        /// recipient_type string
        /// </summary>
        /// <value>recipient_type string</value>
        [JsonPropertyName("recipient_type")]
        public string RecipientType { get; set; }

        /// <summary>
        /// Gets the RecipientType as enum (may throw exception if unknown value exists).
        /// </summary>
        [Obsolete("This property will be removed in a future version. Use the string property instead and parse manually if needed.")]

        [JsonIgnore]
        public RecipientTypeEnum RecipientTypeToEnum 
        {
            get => (RecipientTypeEnum)Enum.Parse(typeof(RecipientTypeEnum), RecipientType);
        }

        #endregion Properties
    }
}
