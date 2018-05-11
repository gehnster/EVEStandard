using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Alliances : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Alliances>();
        internal Alliances(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<Alliance>> GetAllianceInfoV3Async(int allianceId)
        {
            var responseModel = await GetAsync("/v3/alliances/" + allianceId + "/");

            checkResponse("GetAllianceInfoV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Alliance>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> ListAllianceCorporationsV1Async(int allianceId)
        {
            var responseModel = await GetAsync("/v1/alliances/" + allianceId + "/corporations/");

            checkResponse("ListAllianceCorporationsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<List<AllianceName>>> GetAllianceNamesV2Async(List<int> allianceIds)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "alliance_ids", allianceIds == null || allianceIds.Count == 0 ? "" : string.Join(",", allianceIds) }
            };

            var responseModel = await GetAsync("/v2/alliances/names/", queryParameters);

            checkResponse("GetAllianceNamesV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<AllianceName>>(responseModel);
        }

        public async Task<ESIModelDTO<AllianceIcons>> GetAllianceIconV1Async(int allianceId)
        {
            var responseModel = await GetAsync("/v1/alliances/" + allianceId + "/icons/");

            checkResponse("GetAllianceIconV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<AllianceIcons>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> ListAllAlliancesV1Async()
        {
            var responseModel = await GetAsync("/v1/alliances/");

            checkResponse("ListAllAlliancesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }
    }
}
