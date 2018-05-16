using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{

    public class FactionWarfare : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<FactionWarfare>();
        internal FactionWarfare(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<FactionWarData>>> DataAboutFactionWarsV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/wars/");

            checkResponse("DataAboutFactionWarsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<FactionWarData>>(responseModel);
        }

        public async Task<ESIModelDTO<List<FactionWarStats>>> StatsAboutFactionWarsV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/stats/");

            checkResponse("StatsAboutFactionWarsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<FactionWarStats>>(responseModel);
        }

        public async Task<ESIModelDTO<List<FactionWarSystem>>> FactionWarSystemOwnershipV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/systems/");

            checkResponse("FactionWarSystemOwnershipV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<FactionWarSystem>>(responseModel);
        }

        public async Task<ESIModelDTO<List<FactionWarSystem>>> FactionWarSystemOwnershipV2Async()
        {
            var responseModel = await GetAsync("/v2/fw/systems/");

            checkResponse("FactionWarSystemOwnershipV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<FactionWarSystem>>(responseModel);
        }

        public async Task<ESIModelDTO<FactionWarFactionLeaderboard>> TopFactionsV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/");

            checkResponse("TopFactionsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<FactionWarFactionLeaderboard>(responseModel);
        }

        public async Task<ESIModelDTO<FactionWarPilotLeaderboard>> TopPilotsV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/characters/");

            checkResponse("TopPilotsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<FactionWarPilotLeaderboard>(responseModel);
        }

        public async Task<ESIModelDTO<FactionWarCorporationLeaderboard>> TopCorporationsV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/corporations/");

            checkResponse("TopCorporationsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<FactionWarCorporationLeaderboard>(responseModel);
        }

        public async Task<ESIModelDTO<FactionWarCorporationStats>> CorporationOverviewInFactionWarsV1Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_FW_STATS_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/fw/stats/");

            checkResponse("CorporationOverviewInFactionWarsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<FactionWarCorporationStats>(responseModel);
        }

        public async Task<ESIModelDTO<FactionWarCharacterStats>> CharacterOverviewInFactionWarsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_FW_STATS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/fw/stats/");

            checkResponse("CharacterOverviewInFactionWarsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<FactionWarCharacterStats>(responseModel);
        }
    }
}
