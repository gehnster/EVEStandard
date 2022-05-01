using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterMedals : ModelBase<CharacterMedals>
    {
        #region Enums

        /// <summary>
        /// status string
        /// </summary>
        /// <value>status string</value>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum StatusEnum
        {
            [EnumMember(Value = "public")]
            publicEnum = 1,
            [EnumMember(Value = "private")]
            privateEnum = 2
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonPropertyName("corporation_id")]
        public int CorporationId { get; set; }

        /// <summary>
        /// date string
        /// </summary>
        /// <value>date string</value>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// graphics array
        /// </summary>
        /// <value>graphics array</value>
        [JsonPropertyName("graphics")]
        public List<MedalGraphics> Graphics { get; set; }

        /// <summary>
        /// issuer_id integer
        /// </summary>
        /// <value>issuer_id integer</value>
        [JsonPropertyName("issuer_id")] public int IssuerId { get; set; }

        /// <summary>
        /// medal_id integer
        /// </summary>
        /// <value>medal_id integer</value>
        [JsonPropertyName("medal_id")]
        public int MedalId { get; set; }

        /// <summary>
        /// reason string
        /// </summary>
        /// <value>reason string</value>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// status string
        /// </summary>
        /// <value>status string</value>
        [JsonPropertyName("status")]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// title string
        /// </summary>
        /// <value>title string</value>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        #endregion Properties
    }

    public class MedalGraphics : ModelBase<MedalGraphics>
    {
        #region Properties

        /// <summary>
        /// color integer
        /// </summary>
        /// <value>color integer</value>
        [JsonPropertyName("color")]
        public int? Color { get; set; }

        /// <summary>
        /// graphic string
        /// </summary>
        /// <value>graphic string</value>
        [JsonPropertyName("graphic")]
        public string Graphic { get; set; }

        /// <summary>
        /// layer integer
        /// </summary>
        /// <value>layer integer</value>
        [JsonPropertyName("layer")]
        public int Layer { get; set; }

        /// <summary>
        /// part integer
        /// </summary>
        /// <value>part integer</value>
        [JsonPropertyName("part")]
        public int Part { get; set; }

        #endregion Properties
    }
}