using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class Killmail : ModelBase<Killmail>
    {
        #region Properties

        /// <summary>
        /// attackers array
        /// </summary>
        /// <value>attackers array</value>
        [JsonPropertyName("attackers")]
        public List<KillmailAttacker> Attackers { get; set; }

        /// <summary>
        /// ID of the killmail
        /// </summary>
        /// <value>ID of the killmail</value>
        [JsonPropertyName("killmail_id")]
        public int KillmailId { get; set; }

        /// <summary>
        /// Time that the victim was killed and the killmail generated 
        /// </summary>
        /// <value>Time that the victim was killed and the killmail generated </value>
        [JsonPropertyName("killmail_time")]
        public DateTime KillmailTime { get; set; }

        /// <summary>
        /// Moon if the kill took place at one
        /// </summary>
        /// <value>Moon if the kill took place at one</value>
        [JsonPropertyName("moon_id")]
        public int? MoonId { get; set; }

        /// <summary>
        /// Solar system that the kill took place in 
        /// </summary>
        /// <value>Solar system that the kill took place in </value>
        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }

        /// <summary>
        /// Gets or Sets Victim
        /// </summary>
        [JsonPropertyName("victim")]
        public KillmailVictim Victim { get; set; }
        /// <summary>
        /// War if the killmail is generated in relation to an official war 
        /// </summary>
        /// <value>War if the killmail is generated in relation to an official war </value>
        [JsonPropertyName("war_id")]
        public int? WarId { get; set; }

        #endregion Properties
    }

    public class KillmailAttacker : ModelBase<KillmailAttacker>
    {
        #region Properties

        /// <summary>
        /// alliance_id integer
        /// </summary>
        /// <value>alliance_id integer</value>
        [JsonPropertyName("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [JsonPropertyName("character_id")]
        public int? CharacterId { get; set; }

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonPropertyName("corporation_id")]
        public int? CorporationId { get; set; }
        /// <summary>
        /// damage_done integer
        /// </summary>
        /// <value>damage_done integer</value>
        [JsonPropertyName("damage_done")]
        public int DamageDone { get; set; }

        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }

        /// <summary>
        /// Was the attacker the one to achieve the final blow 
        /// </summary>
        /// <value>Was the attacker the one to achieve the final blow </value>
        [JsonPropertyName("final_blow")]
        public bool FinalBlow { get; set; }

        /// <summary>
        /// Security status for the attacker 
        /// </summary>
        /// <value>Security status for the attacker </value>
        [JsonPropertyName("security_status")]
        public float SecurityStatus { get; set; }
        /// <summary>
        /// What ship was the attacker flying 
        /// </summary>
        /// <value>What ship was the attacker flying </value>
        [JsonPropertyName("ship_type_id")]
        public int? ShipTypeId { get; set; }

        /// <summary>
        /// What weapon was used by the attacker for the kill 
        /// </summary>
        /// <value>What weapon was used by the attacker for the kill </value>
        [JsonPropertyName("weapon_type_id")]
        public int? WeaponTypeId { get; set; }

        #endregion Properties
    }

    public class KillmailHashItem : ModelBase<KillmailHashItem>
    {
        #region Properties

        /// <summary>
        /// Flag for the location of the item 
        /// </summary>
        /// <value>Flag for the location of the item </value>
        [JsonPropertyName("flag")]
        public int Flag { get; set; }

        /// <summary>
        /// items array
        /// </summary>
        /// <value>items array</value>
        [JsonPropertyName("items")]
        public List<KillmailHashItem> Items { get; set; }

        /// <summary>
        /// item_type_id integer
        /// </summary>
        /// <value>item_type_id integer</value>
        [JsonPropertyName("item_type_id")]
        public int ItemTypeId { get; set; }

        /// <summary>
        /// How many of the item were destroyed if any 
        /// </summary>
        /// <value>How many of the item were destroyed if any </value>
        [JsonPropertyName("quantity_destroyed")]
        public long? QuantityDestroyed { get; set; }

        /// <summary>
        /// How many of the item were dropped if any 
        /// </summary>
        /// <value>How many of the item were dropped if any </value>
        [JsonPropertyName("quantity_dropped")]
        public long? QuantityDropped { get; set; }

        /// <summary>
        /// singleton integer
        /// </summary>
        /// <value>singleton integer</value>
        [JsonPropertyName("singleton")]
        public int Singleton { get; set; }

        #endregion Properties
    }

    public class KillmailVictim : ModelBase<KillmailVictim>
    {
        #region Properties

        /// <summary>
        /// alliance_id integer
        /// </summary>
        /// <value>alliance_id integer</value>
        [JsonPropertyName("alliance_id")]
        public int? AllianceId { get; set; }

        /// <summary>
        /// character_id integer
        /// </summary>
        /// <value>character_id integer</value>
        [JsonPropertyName("character_id")]
        public int? CharacterId { get; set; }

        /// <summary>
        /// corporation_id integer
        /// </summary>
        /// <value>corporation_id integer</value>
        [JsonPropertyName("corporation_id")]
        public int? CorporationId { get; set; }
        /// <summary>
        /// How much total damage was taken by the victim 
        /// </summary>
        /// <value>How much total damage was taken by the victim </value>
        [JsonPropertyName("damage_taken")]
        public int DamageTaken { get; set; }

        /// <summary>
        /// faction_id integer
        /// </summary>
        /// <value>faction_id integer</value>
        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }
        /// <summary>
        /// items array
        /// </summary>
        /// <value>items array</value>
        [JsonPropertyName("items")]
        public List<KillmailHashItem> Items { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        /// <summary>
        /// The ship that the victim was piloting and was destroyed 
        /// </summary>
        /// <value>The ship that the victim was piloting and was destroyed </value>
        [JsonPropertyName("ship_type_id")]
        public int ShipTypeId { get; set; }

        #endregion Properties
    }
}
