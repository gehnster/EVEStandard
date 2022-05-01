using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EVEStandard.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FactionWarfareContested
    {
        captured,
        contested,
        uncontested,
        vulnerable
    }
}
