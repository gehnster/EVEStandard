using System.Text.Json.Serialization;

namespace EVEStandard.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContextType
    {
        structure_id,
        station_id,
        market_transaction_id,
        character_id,
        corporation_id,
        alliance_id,
        eve_system,
        industry_job_id,
        contract_id,
        planet_id,
        system_id,
        type_id
    }
}
