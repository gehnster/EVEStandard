using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EveCorpMonNet.Libraries.EVEStandard.Models
{
    public class Ancestry :ModelBase<Ancestry>
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("bloodline_id")] public int BloodlineId { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("short_description")] public  string ShortDescription { get; set; }
        [JsonProperty("icon_id")] public int IconId { get; set; }
    }
}
