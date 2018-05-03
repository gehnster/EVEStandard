using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CharacterMedals : ModelBase<CharacterMedals>
    {
        /// <summary>
        /// medal_id integer
        /// </summary>
        /// <value>medal_id integer</value>
        [JsonProperty("medal_id")] public int? MedalId { get; set; }

        /// <summary>
        /// title string
        /// </summary>
        /// <value>title string</value>
        [JsonProperty("title")] public string Title { get; set; }

        /// <summary>
        /// description string
        /// </summary>
        /// <value>description string</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonProperty("corporation_id")]
        public int? CorporationId { get; set; }

        /// <summary>
        /// issuer_id integer
        /// </summary>
        /// <value>issuer_id integer</value>
        [JsonProperty("issuer_id")] public int? IssuerId { get; set; }

        /// <summary>
        /// date string
        /// </summary>
        /// <value>date string</value>
        [JsonProperty("date")] public DateTime? Date { get; set; }

        /// <summary>
        /// reason string
        /// </summary>
        /// <value>reason string</value>
        [JsonProperty("reason")] public string Reason { get; set; }

        /// <summary>
        /// status string
        /// </summary>
        /// <value>status string</value>
        public enum StatusEnum
        {
            [JsonProperty("public")]
            publicEnum = 1,
            [JsonProperty("private")]
            privateEnum = 2
        }

        /// <summary>
        /// status string
        /// </summary>
        /// <value>status string</value>
        [JsonProperty("status")] public StatusEnum? Status { get; set; }

        /// <summary>
        /// graphics array
        /// </summary>
        /// <value>graphics array</value>
        [JsonProperty("graphics")] public List<MedalGraphics> Graphics { get; set; }
    }

    public class MedalGraphics : ModelBase<MedalGraphics>
    {
        /// <summary>
        /// part integer
        /// </summary>
        /// <value>part integer</value>
        [JsonProperty("part")] public int? Part { get; set; }

        /// <summary>
        /// layer integer
        /// </summary>
        /// <value>layer integer</value>
        [JsonProperty("layer")] public int? Layer { get; set; }

        /// <summary>
        /// graphic string
        /// </summary>
        /// <value>graphic string</value>
        [JsonProperty("graphic")] public string Graphic { get; set; }

        /// <summary>
        /// color integer
        /// </summary>
        /// <value>color integer</value>
        [JsonProperty("color")]
        public int? Color { get; set; }
    }

}