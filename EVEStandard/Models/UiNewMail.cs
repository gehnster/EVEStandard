﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class UiNewMail
    {
        #region Properties

        /// <summary>
        /// body string
        /// </summary>
        /// <value>body string</value>
        [JsonPropertyName("body")]
        public string Body { get; set; }

        /// <summary>
        /// recipients array
        /// </summary>
        /// <value>recipients array</value>
        [JsonPropertyName("recipients")]
        public List<int> Recipients { get; set; }

        /// <summary>
        /// subject string
        /// </summary>
        /// <value>subject string</value>
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
        /// <summary>
        /// to_corp_or_alliance_id integer
        /// </summary>
        /// <value>to_corp_or_alliance_id integer</value>
        [JsonPropertyName("to_corp_or_alliance_id")]
        public int? ToCorpOrAllianceId { get; set; }

        /// <summary>
        /// Corporations, alliances and mailing lists are all types of mailing groups. You may only send to one mailing group, at a time, so you may fill out either this field or the to_corp_or_alliance_ids field
        /// </summary>
        /// <value>Corporations, alliances and mailing lists are all types of mailing groups. You may only send to one mailing group, at a time, so you may fill out either this field or the to_corp_or_alliance_ids field</value>
        [JsonPropertyName("to_mailing_list_id")]
        public int? ToMailingListId { get; set; }

        #endregion Properties
    }
}
