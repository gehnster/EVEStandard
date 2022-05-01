using System.Text.Json.Serialization;

namespace EVEStandard.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccessorType
    {
        character = 1,
        corporation = 2,
        alliance = 3
    }
}