using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Corporation : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Corporation>();
        internal Corporation(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<Shareholder>>> GetCorporationShareholdersV1Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/shareholders/", auth, queryParameters);

            checkResponse("GetCorporationShareholdersV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Shareholder>>(responseModel);
        }

        public async Task<ESIModelDTO<CorporationInfo>> GetCorporationInfoV4Async(int corporationId)
        {
            var responseModel = await GetAsync("/v4/corporations/" + corporationId + "/");

            checkResponse("GetCorporationInfoV4Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<CorporationInfo>(responseModel);
        }

        public async Task<ESIModelDTO<List<AllianceHistory>>> GetAllianceHistoryV2Async(int corporationId)
        {
            var responseModel = await GetAsync("/v2/corporations/" + corporationId + "/alliancehistory/");

            checkResponse("GetAllianceHistoryV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<AllianceHistory>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationName>>> GetCorporationNamesV2Async(List<int> corporationIds)
        {
            var responseModel = await GetAsync("/v2/corporations/names/");

            var queryParameters = new Dictionary<string, string>
            {
                { "corporation_ids", corporationIds == null || corporationIds.Count == 0 ? "" : string.Join(",", corporationIds) }
            };

            checkResponse("GetCorporationNamesV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationName>>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> GetCorporationMembersV3Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var responseModel = await GetAsync("/v3/corporations/" + corporationId + "/members/", auth);

            checkResponse("GetCorporationMembersV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationRoles>>> GetCorporationMemberRolesV1Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/roles/", auth);

            checkResponse("GetCorporationMemberRolesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationRoles>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationRoleHistory>>> GetCorporationMemberRolesHistoryV1Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/roles/history/", auth, queryParameters);

            checkResponse("GetCorporationMemberRolesHistoryV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationRoleHistory>>(responseModel);
        }

        public async Task<ESIModelDTO<Icons>> GetCorporationIconV1Async(int corporationId)
        {
            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/icons/");

            checkResponse("GetCorporationIconV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Icons>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> GetNPCCorporationsV1Async()
        {
            var responseModel = await GetAsync("/v1/corporations/npccorps/");

            checkResponse("GetNPCCorporationsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationStructure>>> GetCorporationStructuresV2Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_STRUCTURES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v2/corporations/" + corporationId + "/structures/", auth, queryParameters);

            checkResponse("GetCorporationStructuresV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationStructure>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationMemberTracking>>> TrackCorporationMembersV1Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/membertracking/", auth);

            checkResponse("TrackCorporationMembersV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationMemberTracking>>(responseModel);
        }

        public async Task<ESIModelDTO<CorporationDivision>> GetCorporationDivisionsV1Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/divisions/", auth);

            checkResponse("GetCorporationDivisionsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<CorporationDivision>(responseModel);
        }

        public async Task<ESIModelDTO<int>> GetCorporationMemberLimitV1Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/members/limit/", auth);

            checkResponse("GetCorporationMemberLimitV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<int>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationTitle>>> GetCorporationTitlesV1Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_TITLES_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/titles/", auth);

            checkResponse("GetCorporationTitlesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationTitle>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationMemberTitles>>> GetCorporationsMembersTitlesV1Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_TITLES_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/members/titles/", auth);

            checkResponse("GetCorporationsMembersTitlesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationMemberTitles>>(responseModel);
        }

        public async Task<ESIModelDTO<List<Blueprint>>> GetCorporationBlueprintsV2Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_BLUEPRINTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v2/corporations/" + corporationId + "/blueprints/", auth, queryParameters);

            checkResponse("GetCorporationBlueprintsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Blueprint>>(responseModel);
        }

        public async Task<ESIModelDTO<List<Standing>>> GetStandingsV1Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_STANDINGS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/standings/", auth);

            checkResponse("GetStandingsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Standing>>(responseModel);
        }

        public async Task<ESIModelDTO<List<Starbase>>> GetCorporationStarbasesV1Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_STARBASES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/starbases/", auth);

            checkResponse("GetCorporationStarbasesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Starbase>>(responseModel);
        }

        public async Task<ESIModelDTO<StarbaseDetail>> GetStarbaseDetailV1Async(AuthDTO auth, int corporationId, long starbaseId, long systemId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_STARBASES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "system_id", systemId.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/starbases/" + starbaseId + "/", auth, queryParameters);

            checkResponse("GetStarbaseDetailV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<StarbaseDetail>(responseModel);
        }

        public async Task<ESIModelDTO<List<ContainerLogs>>> GetAllCorporationALSCLogsV2Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CONTAINER_LOGS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v2/corporations/" + corporationId + "/containers/logs/", auth);

            checkResponse("GetAllCorporationALSCLogsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<ContainerLogs>>(responseModel);
        }

        public async Task<ESIModelDTO<List<Facility>>> GetCorporationFacilitiesV1Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_FACILITIES_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/facilities/", auth);

            checkResponse("GetCorporationFacilitiesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Facility>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationMedal>>> GetCorporationMedalsV1Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_MEDALS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/medals/", auth);

            checkResponse("GetCorporationMedalsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationMedal>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationMedalIssued>>> GetCorporationIssuedMedalsV1Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_MEDALS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/medals/issued/", auth);

            checkResponse("GetCorporationIssuedMedalsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationMedalIssued>>(responseModel);
        }

        public async Task<ESIModelDTO<List<long>>> GetCorporationOutpostsV1Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_OUTPOSTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/outposts/", auth);

            checkResponse("GetCorporationOutpostsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<long>>(responseModel);
        }

        public async Task<ESIModelDTO<OutpostDetail>> GetCorporationOutpostDetailsV1Async(AuthDTO auth, int corporationId, long outpostId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_OUTPOSTS_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/outposts/" + outpostId + "/", auth);

            checkResponse("GetCorporationOutpostDetailsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<OutpostDetail>(responseModel);
        }
    }
}
