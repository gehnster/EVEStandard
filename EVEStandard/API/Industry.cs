﻿using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Industry : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Industry>();

        internal Industry(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<IndustryFacility>>> ListIndustryFacilitiesV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/industry/facilities/", ifNoneMatch);

            checkResponse("ListIndustryFacilitiesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<IndustryFacility>>(responseModel);
        }

        public async Task<ESIModelDTO<List<IndustrySystem>>> ListSolarSystemCostIndiciesV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/industry/systems/", ifNoneMatch);

            checkResponse("ListSolarSystemCostIndiciesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<IndustrySystem>>(responseModel);
        }

        public async Task<ESIModelDTO<List<IndustryJob>>> ListCharacterIndustryJobsV1Async(AuthDTO auth, bool includeCompleted, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CHARACTER_JOBS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/industry/jobs/", auth, ifNoneMatch, queryParameters);

            checkResponse("ListCharacterIndustryJobsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<IndustryJob>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterMining>>> CharacterMiningLedgerV1Async(AuthDTO auth, int page=1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CHARACTER_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/mining/", auth, ifNoneMatch, queryParameters);

            checkResponse("CharacterMiningLedgerV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CharacterMining>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationMiningObserver>>> CorporationMiningObserversV1Async(AuthDTO auth, int page, int corporationId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/mining/observers/", auth, ifNoneMatch, queryParameters);

            checkResponse("CorporationMiningObserversV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CorporationMiningObserver>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationObservedMining>>> ObservedCorporationMiningV1Async(AuthDTO auth, int page, int corporationId, long observerId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/mining/observers/" + observerId + "/", auth, ifNoneMatch, queryParameters);

            checkResponse("ObservedCorporationMiningV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CorporationObservedMining>>(responseModel);
        }

        public async Task<ESIModelDTO<List<IndustryJob>>> ListCorporationIndustryJobsV1Async(AuthDTO auth, int page, int corporationId, bool includeCompleted = false, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_JOBS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/industry/jobs/", auth, ifNoneMatch, queryParameters);

            checkResponse("ListCorporationIndustryJobsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<IndustryJob>>(responseModel);
        }

        public async Task<ESIModelDTO<List<MiningExtraction>>> MoonExtractionTimersV1Async(AuthDTO auth, int page, int corporationId, bool includeCompleted = false, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/industry/jobs/", auth, ifNoneMatch, queryParameters);

            checkResponse("MoonExtractionTimersV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<MiningExtraction>>(responseModel);
        }
    }
}
