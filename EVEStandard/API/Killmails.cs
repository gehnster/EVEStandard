using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Killmails : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Killmails>();
        internal Killmails(string dataSource) : base(dataSource)
        {
        }

        public async Task<Killmail> GetKillmailV1Async(int killmailId, string killmailHash)
        {
            var responseModel = await GetAsync("/v1/killmails/" + killmailId + "/" + killmailHash + "/");

            checkResponse("GetKillmailV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Killmail>(responseModel.JSONString);
        }

        public async Task<List<KillmailIndex>> GetCharacterKillsAndLossesV1Async(AuthDTO auth, int maxCount, int maxKillId)
        {
            checkAuth(auth, Scopes.ESI_KILLMAILS_READ_KILLMAILS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "max_count", maxCount.ToString() },
                { "max_kill_id", maxKillId.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/killmails/recent/", auth, queryParameters);

            checkResponse("GetCharacterKillsAndLossesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<KillmailIndex>>(responseModel.JSONString);
        }

        public async Task<List<KillmailIndex>> GetCorporationKillsAndLossesV1Async(AuthDTO auth, long corporationId, int maxKillId)
        {
            checkAuth(auth, Scopes.ESI_KILLMAILS_READ_CORPORATION_KILLMAILS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "max_kill_id", maxKillId.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/killmails/recent/", auth, queryParameters);

            checkResponse("GetCorporationKillsAndLossesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<KillmailIndex>>(responseModel.JSONString);
        }
    }
}
