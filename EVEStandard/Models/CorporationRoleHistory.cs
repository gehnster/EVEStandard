using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models
{
    using Newtonsoft.Json;

    public class CorporationRoleHistory : ModelBase<CorporationRoleHistory>
    {
        /// <summary>
        /// The character whose roles are changed
        /// </summary>
        /// <value>The character whose roles are changed</value>
        [JsonProperty("character_id")]
        public int? CharacterId { get; set; }

        /// <summary>
        /// changed_at string
        /// </summary>
        /// <value>changed_at string</value>
        [JsonProperty("changed_at")]
        public DateTime? ChangedAt { get; set; }

        /// <summary>
        /// ID of the character who issued this change
        /// </summary>
        /// <value>ID of the character who issued this change</value>
        [JsonProperty("issuer_id")]
        public int? IssuerId { get; set; }

        public enum RoleTypeEnum
        {
            grantable_roles,
            grantable_roles_at_base,
            grantable_roles_at_hq,
            grantable_roles_at_other,
            roles,
            roles_at_base,
            roles_at_hq,
            roles_at_other
        }

        /// <summary>
        /// role_type string
        /// </summary>
        /// <value>role_type string</value>
        [JsonProperty("role_type")]
        public RoleTypeEnum? RoleType { get; set; }

        /// <summary>
        /// old_roles array
        /// </summary>
        /// <value>old_roles array</value>
        [JsonProperty("old_roles")]
        public List<string> OldRoles { get; set; }

        /// <summary>
        /// new_roles array
        /// </summary>
        /// <value>new_roles array</value>
        [JsonProperty("new_roles")]
        public List<string> NewRoles { get; set; }
    }
}
