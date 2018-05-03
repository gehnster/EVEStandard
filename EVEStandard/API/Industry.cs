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

        public async Task<List<IndustryFacility>> ListIndustryFacilitiesV1Async()
        {
            var responseModel = await GetAsync("/v1/industry/facilities/");

            checkResponse("ListIndustryFacilitiesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<IndustryFacility>>(responseModel.JSONString);
        }

        public async Task<List<IndustrySystem>> ListSolarSystemCostIndiciesV1Async()
        {
            var responseModel = await GetAsync("/v1/industry/systems/");

            checkResponse("ListSolarSystemCostIndiciesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<IndustrySystem>>(responseModel.JSONString);
        }

        public async Task<List<IndustryJob>> ListCharacterIndustryJobsV1Async(AuthDTO auth, bool includeCompleted)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CHARACTER_JOBS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/industry/jobs/", auth, queryParameters);

            checkResponse("ListCharacterIndustryJobsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<IndustryJob>>(responseModel.JSONString);
        }

        public async Task<(List<CharacterMining>, long)> CharacterMiningLedgerV1Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CHARACTER_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/mining/", auth, queryParameters);

            checkResponse("CharacterMiningLedgerV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<CharacterMining>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<CorporationMiningObserver>, long)> CorporationMiningObserversV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/mining/observers/", auth, queryParameters);

            checkResponse("CorporationMiningObserversV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<CorporationMiningObserver>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<CorporationObservedMining>, long)> ObservedCorporationMiningV1Async(AuthDTO auth, long page, long corporationId, long observerId)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/mining/observers/" + observerId + "/", auth, queryParameters);

            checkResponse("ObservedCorporationMiningV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<CorporationObservedMining>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<IndustryJob>, long)> ListCorporationIndustryJobsV1Async(AuthDTO auth, long page, long corporationId, bool includeCompleted = false)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_JOBS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/industry/jobs/", auth, queryParameters);

            checkResponse("ListCorporationIndustryJobsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<IndustryJob>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<MiningExtraction>, long)> MoonExtractionTimersV1Async(AuthDTO auth, long page, long corporationId, bool includeCompleted = false)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/industry/jobs/", auth, queryParameters);

            checkResponse("MoonExtractionTimersV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<MiningExtraction>>(responseModel.JSONString), responseModel.MaxPages);
        }
    }
}
