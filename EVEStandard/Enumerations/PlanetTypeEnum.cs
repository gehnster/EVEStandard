﻿using System.Text.Json.Serialization;

namespace EVEStandard.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PlanetTypeEnum
    {
        temperate = 1,
        barren = 2,
        oceanic = 3,
        ice = 4,
        gas = 5,
        lava = 6,
        storm = 7,
        plasma = 8
    }
}