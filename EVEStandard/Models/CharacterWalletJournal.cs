using EVEStandard.Enumerations;
using System.Text.Json.Serialization;
using System;

namespace EVEStandard.Models
{
    public class CharacterWalletJournal : ModelBase<CharacterWalletJournal>
    {

        #region Properties

        /// <summary>
        /// Transaction amount. Positive when value transferred to the first party. Negative otherwise
        /// </summary>
        /// <value>Transaction amount. Positive when value transferred to the first party. Negative otherwise</value>
        [JsonPropertyName("amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// Wallet balance after transaction occurred
        /// </summary>
        /// <value>Wallet balance after transaction occurred</value>
        [JsonPropertyName("balance")]
        public double? Balance { get; set; }

        /// <summary>
        /// Gets or sets the context identifier.
        /// </summary>
        /// <value>
        /// The context identifier.
        /// </value>
        [JsonPropertyName("context_id")]
        public long ContextId { get; set; }

        /// <summary>
        /// Gets or sets the type of the context identifier.
        /// </summary>
        /// <value>
        /// The type of the context identifier.
        /// </value>
        [JsonPropertyName("context_id_type")]
        public ContextType ContextIdType { get; set; }

        /// <summary>
        /// Date and time of transaction
        /// </summary>
        /// <value>Date and time of transaction</value>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// first_party_id integer
        /// </summary>
        /// <value>first_party_id integer</value>
        [JsonPropertyName("first_party_id")]
        public int? FirstPartyId { get; set; }

        /// <summary>
        /// Unique journal reference ID
        /// </summary>
        /// <value>Unique journal reference ID</value>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// reason string
        /// </summary>
        /// <value>reason string</value>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Transaction type, different type of transaction will populate different fields in &#x60;extra_info&#x60; Note: If you have an existing XML API application that is using ref_types, you will need to know which string ESI ref_type maps to which integer. You can use the following gist to see string-&gt;int mappings: https://gist.github.com/ccp-zoetrope/c03db66d90c2148724c06171bc52e0ec
        /// </summary>
        /// <value>Transaction type, different type of transaction will populate different fields in &#x60;extra_info&#x60; Note: If you have an existing XML API application that is using ref_types, you will need to know which string ESI ref_type maps to which integer. You can use the following gist to see string-&gt;int mappings: https://gist.github.com/ccp-zoetrope/c03db66d90c2148724c06171bc52e0ec</value>
        [JsonPropertyName("ref_type")]
        public TransactionType RefType { get; set; }

        /// <summary>
        /// second_party_id integer
        /// </summary>
        /// <value>second_party_id integer</value>
        [JsonPropertyName("second_party_id")]
        public int? SecondPartyId { get; set; }

        /// <summary>
        /// Tax amount received for tax related transactions
        /// </summary>
        /// <value>Tax amount received for tax related transactions</value>
        [JsonPropertyName("tax")]
        public double? Tax { get; set; }

        /// <summary>
        /// the corporation ID receiving any tax paid
        /// </summary>
        /// <value>the corporation ID receiving any tax paid</value>
        [JsonPropertyName("tax_receiver_id")]
        public int? TaxReceiverId { get; set; }

        #endregion Properties
    }
}