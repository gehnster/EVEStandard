using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    using System.Threading.Tasks;
    using Enumerations;
    using Models;
    using Models.API;
    using Newtonsoft.Json;

    public class Corporation : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Corporation>();
        internal Corporation(string dataSource) : base(dataSource)
        {
        }

        public async Task<(List<Shareholder>, long)> GetCorporationShareholdersV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/shareholders/", auth, queryParameters);

            checkResponse("GetCorporationShareholdersV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<Shareholder>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<CorporationInfo> GetCorporationInfoV4Async(long corporationId)
        {
            var responseModel = await this.GetAsync("/v4/corporations/" + corporationId + "/");

            checkResponse("GetCorporationInfoV4Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<CorporationInfo>(responseModel.JSONString);
        }

        public async Task<List<AllianceHistory>> GetAllianceHistoryV2Async(long corporationId)
        {
            var responseModel = await this.GetAsync("/v2/corporations/" + corporationId + "/alliancehistory/");

            checkResponse("GetAllianceHistoryV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<AllianceHistory>>(responseModel.JSONString);
        }

        public async Task<List<CorporationName>> GetCorporationNamesV2Async(List<long> corporationIds)
        {
            var responseModel = await this.GetAsync("/v2/corporations/names/");

            var queryParameters = new Dictionary<string, string>
            {
                { "corporation_ids", corporationIds == null || corporationIds.Count == 0 ? "" : string.Join(",", corporationIds) }
            };

            checkResponse("GetCorporationNamesV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<CorporationName>>(responseModel.JSONString);
        }

        public async Task<List<long>> GetCorporationMembersV3Async(AuthDTO auth, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var responseModel = await this.GetAsync("/v3/corporations/" + corporationId + "/members/", auth);

            checkResponse("GetCorporationMembersV3Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString);
        }

        public async Task<List<CorporationRoles>> GetCorporationMemberRolesV1Async(AuthDTO auth, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/roles/", auth);

            checkResponse("GetCorporationMemberRolesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<CorporationRoles>>(responseModel.JSONString);
        }

        public async Task<(List<CorporationRoleHistory>, long)> GetCorporationMemberRolesHistoryV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/roles/history/", auth, queryParameters);

            checkResponse("GetCorporationMemberRolesHistoryV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<CorporationRoleHistory>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<Icons> GetCorporationIconV1Async(long corporationId)
        {
            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/icons/");

            checkResponse("GetCorporationIconV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<Icons>(responseModel.JSONString);
        }

        public async Task<List<long>> GetNPCCorporationsV1Async()
        {
            var responseModel = await this.GetAsync("/v1/corporations/npccorps/");

            checkResponse("GetNPCCorporationsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString);
        }

        public async Task<(List<CorporationStructure>, long)> GetCorporationStructuresV2Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_STRUCTURES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v2/corporations/" + corporationId + "/structures/", auth, queryParameters);

            checkResponse("GetCorporationStructuresV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<CorporationStructure>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<CorporationMemberTracking>> TrackCorporationMembersV1Async(AuthDTO auth, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/membertracking/", auth);

            checkResponse("TrackCorporationMembersV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<CorporationMemberTracking>>(responseModel.JSONString);
        }

        public async Task<CorporationDivision> GetCorporationDivisionsV1Async(AuthDTO auth, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/divisions/", auth);

            checkResponse("GetCorporationDivisionsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<CorporationDivision>(responseModel.JSONString);
        }

        public async Task<int> GetCorporationMemberLimitV1Async(AuthDTO auth, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/members/limit/", auth);

            checkResponse("GetCorporationMemberLimitV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<int>(responseModel.JSONString);
        }

        public async Task<List<CorporationTitle>> GetCorporationTitlesV1Async(AuthDTO auth, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_TITLES_1);

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/titles/", auth);

            checkResponse("GetCorporationTitlesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<CorporationTitle>>(responseModel.JSONString);
        }

        public async Task<List<CorporationMemberTitles>> GetCorporationsMembersTitlesV1Async(AuthDTO auth, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_TITLES_1);

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/members/titles/", auth);

            checkResponse("GetCorporationsMembersTitlesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<CorporationMemberTitles>>(responseModel.JSONString);
        }

        public async Task<(List<Blueprint>, long)> GetCorporationBlueprintsV2Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_BLUEPRINTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v2/corporations/" + corporationId + "/blueprints/", auth, queryParameters);

            checkResponse("GetCorporationBlueprintsV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<Blueprint>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<Standing>, long)> GetStandingsV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_STANDINGS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/standings/", auth);

            checkResponse("GetStandingsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<Standing>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<Starbase>, long)> GetCorporationStarbasesV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_STARBASES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/starbases/", auth);

            checkResponse("GetCorporationStarbasesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<Starbase>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<StarbaseDetail> GetStarbaseDetailV1Async(AuthDTO auth, long corporationId, long starbaseId, long systemId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_STARBASES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "system_id", systemId.ToString() }
            };

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/starbases/" + starbaseId + "/", auth, queryParameters);

            checkResponse("GetStarbaseDetailV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<StarbaseDetail>(responseModel.JSONString);
        }

        public async Task<(List<ContainerLogs>, long)> GetAllCorporationALSCLogsV2Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CONTAINER_LOGS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v2/corporations/" + corporationId + "/containers/logs/", auth);

            checkResponse("GetAllCorporationALSCLogsV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<ContainerLogs>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<Facility>> GetCorporationFacilitiesV1Async(AuthDTO auth, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_FACILITIES_1);

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/facilities/", auth);

            checkResponse("GetCorporationFacilitiesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<Facility>>(responseModel.JSONString);
        }

        public async Task<(List<CorporationMedal>, long)> GetCorporationMedalsV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_MEDALS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/medals/", auth);

            checkResponse("GetCorporationMedalsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<CorporationMedal>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<CorporationMedalIssued>, long)> GetCorporationIssuedMedalsV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_MEDALS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/medals/issued/", auth);

            checkResponse("GetCorporationIssuedMedalsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<CorporationMedalIssued>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<long>, long)> GetCorporationOutpostsV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_OUTPOSTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/outposts/", auth);

            checkResponse("GetCorporationOutpostsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<OutpostDetail> GetCorporationOutpostDetailsV1Async(AuthDTO auth, long corporationId, long outpostId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_OUTPOSTS_1);

            var responseModel = await this.GetAsync("/v1/corporations/" + corporationId + "/outposts/" + outpostId + "/", auth);

            checkResponse("GetCorporationOutpostDetailsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<OutpostDetail>(responseModel.JSONString);
        }
    }
}
