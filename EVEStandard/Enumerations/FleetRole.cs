﻿using System.Text.Json.Serialization;

namespace EVEStandard.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FleetRole
    {
        fleet_commander = 1,
        squad_commander = 2,
        squad_member = 3,
        wing_commander = 4
    }
}