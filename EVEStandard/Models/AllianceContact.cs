﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AllianceContact : ModelBase<AllianceContact>
    {
        #region Properties

        /// <summary>
        /// contact_id integer
        /// </summary>
        /// <value>contact_id integer</value>
        [JsonPropertyName("contact_id")]
        public int ContactId { get; set; }

        /// <summary>
        /// contact_type string
        /// </summary>
        /// <value>contact_type string</value>
        [JsonPropertyName("contact_type")]
        public string ContactType { get; set; }

        /// <summary>
        /// Custom label of the contact
        /// </summary>
        /// <value>Custom label of the contact</value>
        [JsonPropertyName("label_ids")]
        public List<long> LabelIds { get; set; }

        /// <summary>
        /// Standing of the contact
        /// </summary>
        /// <value>Standing of the contact</value>
        [JsonPropertyName("standing")]
        public float Standing { get; set; }

        #endregion Properties
    }
}
