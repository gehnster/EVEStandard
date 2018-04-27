using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using EVEStandard.Enumerations;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class CorporationWalletJournal : ModelBase<CorporationWalletJournal>
    {
        /// <summary>
        /// Date and time of transaction
        /// </summary>
        /// <value>Date and time of transaction</value>
        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Unique journal reference ID
        /// </summary>
        /// <value>Unique journal reference ID</value>
        [JsonProperty("ref_id")]
        public long? RefId { get; set; }

        /// <summary>
        /// Transaction type, different type of transaction will populate different fields in &#x60;extra_info&#x60; Note: If you have an existing XML API application that is using ref_types, you will need to know which string ESI ref_type maps to which integer. You can use the following gist to see string-&gt;int mappings: https://gist.github.com/ccp-zoetrope/c03db66d90c2148724c06171bc52e0ec
        /// </summary>
        /// <value>Transaction type, different type of transaction will populate different fields in &#x60;extra_info&#x60; Note: If you have an existing XML API application that is using ref_types, you will need to know which string ESI ref_type maps to which integer. You can use the following gist to see string-&gt;int mappings: https://gist.github.com/ccp-zoetrope/c03db66d90c2148724c06171bc52e0ec</value>
        [JsonProperty("ref_type")]
        public TransactionType? RefType { get; set; }

        /// <summary>
        /// first_party_id integer
        /// </summary>
        /// <value>first_party_id integer</value>
        [JsonProperty("first_party_id")]
        public int? FirstPartyId { get; set; }

        /// <summary>
        /// first_party_type string
        /// </summary>
        /// <value>first_party_type string</value>
        [JsonProperty("first_party_type")]
        public PartyType? FirstPartyType { get; set; }

        /// <summary>
        /// second_party_id integer
        /// </summary>
        /// <value>second_party_id integer</value>
        [JsonProperty("second_party_id")]
        public int? SecondPartyId { get; set; }

        /// <summary>
        /// second_party_type string
        /// </summary>
        /// <value>second_party_type string</value>
        [JsonProperty("second_party_type")]
        public PartyType? SecondPartyType { get; set; }

        /// <summary>
        /// Transaction amount. Positive when value transferred to the first party. Negative otherwise
        /// </summary>
        /// <value>Transaction amount. Positive when value transferred to the first party. Negative otherwise</value>
        [JsonProperty("amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// Wallet balance after transaction occurred
        /// </summary>
        /// <value>Wallet balance after transaction occurred</value>
        [JsonProperty("balance")]
        public double? Balance { get; set; }

        /// <summary>
        /// reason string
        /// </summary>
        /// <value>reason string</value>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// the corporation ID receiving any tax paid
        /// </summary>
        /// <value>the corporation ID receiving any tax paid</value>
        [JsonProperty("tax_receiver_id")]
        public int? TaxReceiverId { get; set; }

        /// <summary>
        /// Tax amount received for tax related transactions
        /// </summary>
        /// <value>Tax amount received for tax related transactions</value>
        [JsonProperty("tax")]
        public double? Tax { get; set; }

        /// <summary>
        /// Gets or Sets ExtraInfo
        /// </summary>
        [JsonProperty("extra_info")]
        public CorporationWalletJournalExtraInfo ExtraInfo { get; set; }
    }

    public class CorporationWalletJournalExtraInfo : ModelBase<CorporationWalletJournalExtraInfo>
    {
        /// <summary>
        /// location_id integer
        /// </summary>
        /// <value>location_id integer</value>
        [JsonProperty("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// transaction_id integer
        /// </summary>
        /// <value>transaction_id integer</value>
        [JsonProperty("transaction_id")]
        public long? TransactionId { get; set; }

        /// <summary>
        /// npc_name string
        /// </summary>
        /// <value>npc_name string</value>
        [JsonProperty("npc_name")]
        public string NpcName { get; set; }

        /// <summary>
        /// npc_id integer
        /// </summary>
        /// <value>npc_id integer</value>
        [JsonProperty("npc_id")]
        public int? NpcId { get; set; }

        /// <summary>
        /// destroyed_ship_type_id integer
        /// </summary>
        /// <value>destroyed_ship_type_id integer</value>
        [JsonProperty("destroyed_ship_type_id")]
        public int? DestroyedShipTypeId { get; set; }

        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [JsonProperty("character_id")]
        public int? CharacterId { get; set; }

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonProperty("corporation_id")]
        public int? CorporationId { get; set; }

        /// <summary>
        /// alliance_id integer
        /// </summary>
        /// <value>alliance_id integer</value>
        [JsonProperty("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// job_id integer
        /// </summary>
        /// <value>job_id integer</value>
        [JsonProperty("job_id")]
        public int? JobId { get; set; }

        /// <summary>
        /// contract_id integer
        /// </summary>
        /// <value>contract_id integer</value>
        [JsonProperty("contract_id")]
        public int? ContractId { get; set; }

        /// <summary>
        /// system_id integer
        /// </summary>
        /// <value>system_id integer</value>
        [JsonProperty("system_id")]
        public int? SystemId { get; set; }

        /// <summary>
        /// planet_id integer
        /// </summary>
        /// <value>planet_id integer</value>
        [JsonProperty("planet_id")]
        public int? PlanetId { get; set; }
    }
}
