using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CorporationSkyhookReagent : ModelBase<CorporationSkyhookReagent>
    {
        #region Properties

        /// <summary>
        /// Moment the 'SecureStock'/'UnsecuredStock' value had its last cycle; use SDE to calculate the current values
        /// </summary>
        /// <value>Moment the 'SecureStock'/'UnsecuredStock' value had its last cycle; use SDE to calculate the current values</value>
        [JsonPropertyName("last_cycle")]
        public DateTime? LastCycle { get; set; }

        /// <summary>
        /// Secured stock of the reagent at the time of 'last_cycle'
        /// </summary>
        /// <value>Secured stock of the reagent at the time of 'last_cycle'</value>
        [JsonPropertyName("secured_stock")]
        public long SecuredStock { get; set; }

        /// <summary>
        /// Reagent's type ID
        /// </summary>
        /// <value>Reagent's type ID</value>
        [JsonPropertyName("type_id")]
        public long TypeId { get; set; }

        /// <summary>
        /// Unsecured stock of the reagent at the time of 'last_cycle'
        /// </summary>
        /// <value>Unsecured stock of the reagent at the time of 'last_cycle'</value>
        [JsonPropertyName("unsecured_stock")]
        public long UnsecuredStock { get; set; }

        #endregion Properties
    }
}
