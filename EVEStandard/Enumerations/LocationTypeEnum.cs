using System.Text.Json.Serialization;

namespace EVEStandard.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LocationTypeEnum
    {
        station,
        solar_system,
        other,
        item
    }
}