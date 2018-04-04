using EVEStandard.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EVEStandard.API
{
    public class Alliances : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Alliances>();
        internal Alliances(string dataSource) : base(dataSource)
        {
        }

        public async Task<Alliance> GetAllianceInfoV3Async(long allianceId)
        {
            var responseModel = await this.GetAsync("/v3/alliances/" + allianceId + "/");

            checkResponse("GetAllianceInfoV3Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<Alliance>(responseModel.JSONString);
        }

        public async Task<List<long>> ListAllianceCorporationsV1Async(long allianceId)
        {
            var responseModel = await this.GetAsync("/v1/alliances/" + allianceId + "/corporations/");

            checkResponse("ListAllianceCorporationsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString);
        }

        public async Task<List<AllianceName>> GetAllianceNamesV2Async(List<long> allianceIds)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "alliance_ids", allianceIds == null || allianceIds.Count == 0 ? "" : string.Join(",", allianceIds) }
            };

            var responseModel = await this.GetAsync("/v2/alliances/names/", queryParameters);

            checkResponse("GetAllianceNamesV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<AllianceName>>(responseModel.JSONString);
        }

        public async Task<AllianceIcons> GetAllianceIconV1Async(long allianceId)
        {
            var responseModel = await this.GetAsync("/v1/alliances/" + allianceId + "/icons/");

            checkResponse("GetAllianceIconV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<AllianceIcons>(responseModel.JSONString);
        }

        public async Task<List<long>> ListAllAlliancesV1Async()
        {
            var responseModel = await this.GetAsync("/v1/alliances/");

            checkResponse("ListAllAlliancesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString);
        }
    }
}
