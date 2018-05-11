using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Industry : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Industry>();
        internal Industry(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<IndustryFacility>>> ListIndustryFacilitiesV1Async()
        {
            var responseModel = await GetAsync("/v1/industry/facilities/");

            checkResponse("ListIndustryFacilitiesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<IndustryFacility>>(responseModel);
        }

        public async Task<ESIModelDTO<List<IndustrySystem>>> ListSolarSystemCostIndiciesV1Async()
        {
            var responseModel = await GetAsync("/v1/industry/systems/");

            checkResponse("ListSolarSystemCostIndiciesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<IndustrySystem>>(responseModel);
        }

        public async Task<ESIModelDTO<List<IndustryJob>>> ListCharacterIndustryJobsV1Async(AuthDTO auth, bool includeCompleted)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CHARACTER_JOBS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/industry/jobs/", auth, queryParameters);

            checkResponse("ListCharacterIndustryJobsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<IndustryJob>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterMining>>> CharacterMiningLedgerV1Async(AuthDTO auth, int page)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CHARACTER_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/mining/", auth, queryParameters);

            checkResponse("CharacterMiningLedgerV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterMining>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationMiningObserver>>> CorporationMiningObserversV1Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/mining/observers/", auth, queryParameters);

            checkResponse("CorporationMiningObserversV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationMiningObserver>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationObservedMining>>> ObservedCorporationMiningV1Async(AuthDTO auth, int page, int corporationId, long observerId)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/mining/observers/" + observerId + "/", auth, queryParameters);

            checkResponse("ObservedCorporationMiningV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationObservedMining>>(responseModel);
        }

        public async Task<ESIModelDTO<List<IndustryJob>>> ListCorporationIndustryJobsV1Async(AuthDTO auth, int page, int corporationId, bool includeCompleted = false)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_JOBS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/industry/jobs/", auth, queryParameters);

            checkResponse("ListCorporationIndustryJobsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<IndustryJob>>(responseModel);
        }

        public async Task<ESIModelDTO<List<MiningExtraction>>> MoonExtractionTimersV1Async(AuthDTO auth, int page, int corporationId, bool includeCompleted = false)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/industry/jobs/", auth, queryParameters);

            checkResponse("MoonExtractionTimersV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<MiningExtraction>>(responseModel);
        }
    }
}
