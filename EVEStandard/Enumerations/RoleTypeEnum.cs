﻿using System.Text.Json.Serialization;

namespace EVEStandard.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
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
}