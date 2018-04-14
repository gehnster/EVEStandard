using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    public class Wars : ModelBase<Wars>
    {
        /// <summary>Return a list of wars.</summary>
        /// <value>Return a list of wars.</value>
        [JsonProperty("get_wars_ok")]
        public int[] GetWars { get; set; }
    }

    class WarId : ModelBase<WarId>
    {
        /// <summary>ID of the specified war.</summary>
        /// <value>ID of the specified war.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>Time that the war was declared</summary>
        /// <value>Time that the war was declared</value>
        [JsonProperty("declared")]
        public DateTime Declared { get; set; }

        /// <summary>Time when the war started and both sides could shoot each other.</summary>
        /// <value>Time when the war started and both sides could shoot each other.</value>
        [JsonProperty("started")]
        public DateTime? Started { get; set; }

        /// <summary>Time the war was retracted but both sides could still shoot each other.</summary>
        /// <value>Time the war was retracted but both sides could still shoot each other.</value>
        [JsonProperty("retracted")]
        public DateTime? Retracted { get; set; }

        /// <summary>Time the war ended and shooting was no longer allowed.</summary>
        /// <value>Time the war ended and shooting was no longer allowed.</value>
        [JsonProperty("finished")]
        public DateTime? Finished { get; set; }

        /// <summary>Was the war declared mutual by both parties.</summary>
        /// <value>Was the war declared mutual by both parties.</value>
        [JsonProperty("mutual")]
        public bool Mutual { get; set; }

        /// <summary>Is the war currently open for allies or not.</summary>
        /// <value>Is the war currently open for allies or not.</value>
        [JsonProperty("open_for_allies")]
        public bool OpenForAllies { get; set; }

        /// <summary>The aggressor corporation or alliance that declared this war.only contains either corporation_id or alliance_id.</summary>
        /// <value>The aggressor corporation or alliance that declared this war.only contains either corporation_id or alliance_id.</value>
        [JsonProperty("aggressor")]
        public WarIdAggressor Aggressor { get; set; }

        /// <summary>The defending corporation or alliance that declared this war.only contains either corporation_id or alliance_id.</summary>
        /// <value>The defending corporation or alliance that declared this war.only contains either corporation_id or alliance_id.</value>
        [JsonProperty("defender")]
        public WarIdDefender Defender { get; set; }

        /// <summary>allied corporations or alliances.each object contains either corporation_id or alliance_id.</summary>
        /// <value>allied corporations or alliances.each object contains either corporation_id or alliance_id.</value>
        [JsonProperty("ally")]
        public WarIdAlly Ally { get; set; }
    }

    class WarIdAggressor : ModelBase<WarIdAggressor>
    {
        /// <summary>Corporation ID if and only if the aggressor is a corporation.</summary>
        /// <value>Corporation ID if and only if the aggressor is a corporation.</value>
        [JsonProperty("corporation_id")]
        public int? CorporationID { get; set; }

        /// <summary>Alliance ID if and only if the aggressor is an alliance.</summary>
        /// <value>Alliance ID if and only if the aggressor is an alliance.</value>
        [JsonProperty("alliance_id")]
        public int? AllianceID { get; set; }

        /// <summary>The number of ships the aggressor has killed ,</summary>
        /// <value>The number of ships the aggressor has killed ,</value>
        [JsonProperty("ships_killed")]
        public int ShipsKilled{ get; set; }

        /// <summary>ISK value of ships the aggressor has destroyed.</summary>
        /// <value>ISK value of ships the aggressor has destroyed.</value>
        [JsonProperty("isk_destroyed")]
        public float IskDestroyed { get; set; }
    }

    class WarIdDefender : ModelBase<WarIdDefender>
    {
        /// <summary>Corporation ID if and only if the defender is a corporation ,</summary>
        /// <value>Corporation ID if and only if the defender is a corporation ,</value>
        [JsonProperty("corporation_id")]
        public int? CorporationID { get; set; }

        /// <summary>Alliance ID if and only if the defender is an alliance ,</summary>
        /// <value>Alliance ID if and only if the defender is an alliance ,</value>
        [JsonProperty("alliance_id")]
        public int? AllianceID { get; set; }

        /// <summary>The number of ships the defender has killed ,</summary>
        /// <value>The number of ships the defender has killed ,</value>
        [JsonProperty("ships_killed")]
        public int ShipsKilled { get; set; }

        /// <summary>ISK value of ships the defender has killed</summary>
        /// <value>ISK value of ships the defender has killed</value>
        [JsonProperty("isk_destroyed")]
        public float IskDestroyed { get; set; }
    }

    class WarIdAlly : ModelBase<WarIdAlly>
    {
        /// <summary>Corporation ID if and only if this ally is a corporation ,</summary>
        /// <value>Corporation ID if and only if this ally is a corporation ,</value>
        [JsonProperty("corporation_id")]
        public int? CorporationID { get; set; }

        /// <summary>Alliance ID if and only if this ally is an alliance.</summary>
        /// <value>Alliance ID if and only if this ally is an alliance.</value>
        [JsonProperty("alliance_id")]
        public int? AllianceID { get; set; }
    }

    class WarIdKillmails : ModelBase<WarIdKillmails>
    {
        /// <summary>A list of killmail IDs and hashes.</summary>
        /// <value>A list of killmail IDs and hashes.</value>
        [JsonProperty("get_wars_war_id_killmails_200_ok")]
        public List<WarIdKillMailsOk> GetWarsWarIDKillMails { get; set; }
    }

    class WarIdKillMailsOk : ModelBase<WarIdKillMailsOk>
    {
        /// <summary>ID of this killmail.</summary>
        /// <value>ID of this killmail.</value>
        [JsonProperty("killmail_id")]
        public int KillMailId { get; set; }

        /// <summary>A hash of this killmail.</summary>
        /// <value>A hash of this killmail.</value>
        [JsonProperty("killmail_hash")]
        public string KillMailHash { get; set; }
    }

}