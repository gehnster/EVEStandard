using System.Text.Json.Serialization;

namespace EVEStandard.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EventResponse
    {
        accepted,
        declined,
        tentative,
        not_responded
    }
}