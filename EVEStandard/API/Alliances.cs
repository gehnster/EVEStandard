using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Alliances : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Alliances>();

        internal Alliances(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<Alliance>> GetAllianceInfoV3Async(int allianceId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v3/alliances/" + allianceId + "/", ifNoneMatch);

            checkResponse("GetAllianceInfoV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<Alliance>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> ListAllianceCorporationsV1Async(int allianceId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/alliances/" + allianceId + "/corporations/", ifNoneMatch);

            checkResponse("ListAllianceCorporationsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<List<AllianceName>>> GetAllianceNamesV2Async(List<int> allianceIds, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "alliance_ids", allianceIds == null || allianceIds.Count == 0 ? "" : string.Join(",", allianceIds) }
            };

            var responseModel = await GetAsync("/v2/alliances/names/", ifNoneMatch, queryParameters);

            checkResponse("GetAllianceNamesV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<AllianceName>>(responseModel);
        }

        public async Task<ESIModelDTO<AllianceIcons>> GetAllianceIconV1Async(int allianceId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/alliances/" + allianceId + "/icons/", ifNoneMatch);

            checkResponse("GetAllianceIconV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<AllianceIcons>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> ListAllAlliancesV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/alliances/", ifNoneMatch);

            checkResponse("ListAllAlliancesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<int>>(responseModel);
        }
    }
}
