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

        public async Task<List<FactionWarData>> DataAboutFactionWarsV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/wars/");

            checkResponse("DataAboutFactionWarsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<FactionWarData>>(responseModel.JSONString);
        }

        public async Task<List<FactionWarStats>> StatsAboutFactionWarsV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/stats/");

            checkResponse("StatsAboutFactionWarsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<FactionWarStats>>(responseModel.JSONString);
        }

        public async Task<List<FactionWarSystem>> FactionWarSystemOwnershipV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/systems/");

            checkResponse("FactionWarSystemOwnershipV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<FactionWarSystem>>(responseModel.JSONString);
        }

        public async Task<FactionWarFactionLeaderboard> TopFactionsV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/");

            checkResponse("TopFactionsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<FactionWarFactionLeaderboard>(responseModel.JSONString);
        }

        public async Task<FactionWarPilotLeaderboard> TopPilotsV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/characters/");

            checkResponse("TopPilotsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<FactionWarPilotLeaderboard>(responseModel.JSONString);
        }

        public async Task<FactionWarCorporationLeaderboard> TopCorporationsV1Async()
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/corporations/");

            checkResponse("TopCorporationsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<FactionWarCorporationLeaderboard>(responseModel.JSONString);
        }

        public async Task<FactionWarCorporationStats> CorporationOverviewInFactionWarsV1Async(AuthDTO auth, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_FW_STATS_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/fw/stats/");

            checkResponse("CorporationOverviewInFactionWarsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<FactionWarCorporationStats>(responseModel.JSONString);
        }

        public async Task<FactionWarCharacterStats> CharacterOverviewInFactionWarsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_FW_STATS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/fw/stats/");

            checkResponse("CharacterOverviewInFactionWarsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<FactionWarCharacterStats>(responseModel.JSONString);
        }
    }
}
