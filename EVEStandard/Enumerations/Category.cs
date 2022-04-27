﻿using System.Text.Json.Serialization;

namespace EVEStandard.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CategoryEnum
    {
        alliance = 1,
        character = 2,
        constellation = 3,
        corporation = 4,
        inventory_type = 5,
        region = 6,
        solar_system = 7,
        station = 8,
        faction = 9
    }
}
