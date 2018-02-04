using EVEStandard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Alliances : APIBase
    {
        internal Alliances(string dataSource) : base(dataSource)
        {
        }

        public async Task<AllianceIds> ListAllAlliancesAsync()
        {
            var noAuthResponse = await this.GetNoAuthAsync(ESI_BASE + "/v1/alliances/");

            return JsonConvert.DeserializeObject<AllianceIds>(noAuthResponse);
        }

        public async Task<Alliance> GetAllianceInfoAsync(int allianceId)
        {
            var noAuthResponse = await this.GetNoAuthAsync(ESI_BASE + "/v1/alliances/" + "/?datasource=");

            return JsonConvert.DeserializeObject<AllianceIds>(noAuthResponse);
        }

        public async Task<Alliance> ListAllianceCorporationsAsync(int allianceId)
        {
            var noAuthResponse = await this.GetNoAuthAsync(ESI_BASE + "/v1/alliances/" + "/?datasource=");

            return JsonConvert.DeserializeObject<AllianceIds>(noAuthResponse);
        }

        public async Task<Alliance> GetAllianceIconAsync(int allianceId)
        {
            var noAuthResponse = await this.GetNoAuthAsync(ESI_BASE + "/v1/alliances/" + "/?datasource=");

            return JsonConvert.DeserializeObject<AllianceIds>(noAuthResponse);
        }

        public async Task<Alliance> GetAllianceNamesAsync(int allianceId)
        {
            var noAuthResponse = await this.GetNoAuthAsync(ESI_BASE + "/v1/alliances/" + "/?datasource=");

            return JsonConvert.DeserializeObject<AllianceIds>(noAuthResponse);
        }
    }
}
