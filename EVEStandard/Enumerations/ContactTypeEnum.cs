using System.Text.Json.Serialization;

namespace EVEStandard.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContactTypeEnum
    {
        character = 1,
        corporation = 2,
        alliance = 3,
        faction = 4
    }
}