using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class CharacterCorporationRoles : ModelBase<CharacterCorporationRoles>
    {
        #region Properties

        /// <summary>
        /// roles array
        /// </summary>
        /// <value>roles array</value>
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }

        /// <summary>
        /// roles_at_base array
        /// </summary>
        /// <value>roles_at_base array</value>
        [JsonPropertyName("roles_at_base")]
        public List<string> RolesAtBase { get; set; }

        /// <summary>
        /// roles_at_hq array
        /// </summary>
        /// <value>roles_at_hq array</value>
        [JsonPropertyName("roles_at_hq")]
        public List<string> RolesAtHq { get; set; }
        /// <summary>
        /// roles_at_other array
        /// </summary>
        /// <value>roles_at_other array</value>
        [JsonPropertyName("roles_at_other")]
        public List<string> RolesAtOther { get; set; }

        #endregion Properties
    }
}
