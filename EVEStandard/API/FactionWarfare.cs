using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{

    public class FactionWarfare : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<FactionWarfare>();

        internal FactionWarfare(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<FactionWarData>>> DataAboutFactionWarsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/wars/", ifNoneMatch);

            checkResponse("DataAboutFactionWarsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<FactionWarData>>(responseModel);
        }

        public async Task<ESIModelDTO<List<FactionWarStats>>> StatsAboutFactionWarsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/stats/", ifNoneMatch);

            checkResponse("StatsAboutFactionWarsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<FactionWarStats>>(responseModel);
        }

        public async Task<ESIModelDTO<List<FactionWarSystem>>> FactionWarSystemOwnershipV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/systems/", ifNoneMatch);

            checkResponse("FactionWarSystemOwnershipV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<FactionWarSystem>>(responseModel);
        }

        public async Task<ESIModelDTO<List<FactionWarSystem>>> FactionWarSystemOwnershipV2Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v2/fw/systems/", ifNoneMatch);

            checkResponse("FactionWarSystemOwnershipV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<FactionWarSystem>>(responseModel);
        }

        public async Task<ESIModelDTO<FactionWarFactionLeaderboard>> TopFactionsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/", ifNoneMatch);

            checkResponse("TopFactionsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<FactionWarFactionLeaderboard>(responseModel);
        }

        public async Task<ESIModelDTO<FactionWarPilotLeaderboard>> TopPilotsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/characters/", ifNoneMatch);

            checkResponse("TopPilotsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<FactionWarPilotLeaderboard>(responseModel);
        }

        public async Task<ESIModelDTO<FactionWarCorporationLeaderboard>> TopCorporationsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/corporations/", ifNoneMatch);

            checkResponse("TopCorporationsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<FactionWarCorporationLeaderboard>(responseModel);
        }

        public async Task<ESIModelDTO<FactionWarCorporationStats>> CorporationOverviewInFactionWarsV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_FW_STATS_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/fw/stats/", ifNoneMatch);

            checkResponse("CorporationOverviewInFactionWarsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<FactionWarCorporationStats>(responseModel);
        }

        public async Task<ESIModelDTO<FactionWarCharacterStats>> CharacterOverviewInFactionWarsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_FW_STATS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.CharacterId + "/fw/stats/", ifNoneMatch);

            checkResponse("CharacterOverviewInFactionWarsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<FactionWarCharacterStats>(responseModel);
        }
    }
}
