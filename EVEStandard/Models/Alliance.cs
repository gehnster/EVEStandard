namespace EVEStandard.Models
{
    using System;
    using System.Text;
    using Newtonsoft.Json;

    public class Alliance : ModelBase<Alliance>
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("ticker")] public string Ticker { get; set; }

        [JsonProperty("creator_id")] public long CreatorId { get; set; }

        [JsonProperty("creator_corporation_id")]
        public long CreatorCorporationId { get; set; }

        [JsonProperty("executor_corporation_id")]
        public long? ExecutorCorporationId { get; set; }

        [JsonProperty("date_founded")] public DateTime DateFounded { get; set; }

        [JsonProperty("faction_id")] public long? FactionId { get; set; }
    }
}