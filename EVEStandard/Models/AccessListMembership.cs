using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class AccessListMembership : ModelBase<AccessListMembership>
    {
        #region Properties

        /// <summary>
        /// Alliances in the Access List
        /// </summary>
        /// <value>Alliances in the Access List</value>
        [JsonPropertyName("alliances")]
        public List<AccessListAllianceEntry> Alliances { get; set; }

        /// <summary>
        /// Whether everyone is allowed unless blocked
        /// </summary>
        /// <value>Whether everyone is allowed unless blocked</value>
        [JsonPropertyName("allow_everyone")]
        public bool AllowEveryone { get; set; }

        /// <summary>
        /// Characters in the Access List
        /// </summary>
        /// <value>Characters in the Access List</value>
        [JsonPropertyName("characters")]
        public List<AccessListCharacterEntry> Characters { get; set; }

        /// <summary>
        /// Corporations in the Access List
        /// </summary>
        /// <value>Corporations in the Access List</value>
        [JsonPropertyName("corporations")]
        public List<AccessListCorporationEntry> Corporations { get; set; }

        #endregion Properties
    }
}
