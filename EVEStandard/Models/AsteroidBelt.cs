using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class AsteroidBelt : ModelBase<AsteroidBelt>
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("position")] public Position Position { get; set; }
        [JsonProperty("system_id")] public int SystemId { get; set; }
    }
}
