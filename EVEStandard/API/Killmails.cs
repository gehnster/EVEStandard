using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Killmails : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Killmails>();

        internal Killmails(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<Killmail>> GetKillmailV1Async(int killmailId, string killmailHash, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/killmails/" + killmailId + "/" + killmailHash + "/", ifNoneMatch);

            checkResponse("GetKillmailV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<Killmail>(responseModel);
        }

        public async Task<ESIModelDTO<List<KillmailIndex>>> GetCharacterKillsAndLossesV1Async(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_KILLMAILS_READ_KILLMAILS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/killmails/recent/", auth, ifNoneMatch, queryParameters);

            checkResponse("GetCharacterKillsAndLossesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<KillmailIndex>>(responseModel);
        }

        public async Task<ESIModelDTO<List<KillmailIndex>>> GetCorporationKillsAndLossesV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_KILLMAILS_READ_CORPORATION_KILLMAILS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/killmails/recent/", auth, ifNoneMatch, queryParameters);

            checkResponse("GetCorporationKillsAndLossesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<KillmailIndex>>(responseModel);
        }
    }
}
