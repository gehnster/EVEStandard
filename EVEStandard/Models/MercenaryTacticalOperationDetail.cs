using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class MercenaryTacticalOperationDetail : ModelBase<MercenaryTacticalOperationDetail>
    {
        #region Properties

        /// <summary>
        /// Operation's dungeon type ID
        /// </summary>
        /// <value>Operation's dungeon type ID</value>
        [JsonPropertyName("dungeon_type_id")]
        public long DungeonTypeId { get; set; }

        /// <summary>
        /// Moment the operation will expire
        /// </summary>
        /// <value>Moment the operation will expire</value>
        [JsonPropertyName("expires")]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// Operation's ID
        /// </summary>
        /// <value>Operation's ID</value>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// ID of Mercenary Den offering this operation
        /// </summary>
        /// <value>ID of Mercenary Den offering this operation</value>
        [JsonPropertyName("mercenary_den_id")]
        public long MercenaryDenId { get; set; }

        /// <summary>
        /// Operation's state Valid values: Unspecified, Available, Started, Completed, Expired, Removed.
        /// </summary>
        /// <value>Operation's state Valid values: Unspecified, Available, Started, Completed, Expired, Removed.</value>
        [JsonPropertyName("state")]
        public string State { get; set; }

        #endregion Properties
    }
}
