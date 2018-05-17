using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Character : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Character>();
        internal Character(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<AggregateStats>>> YearlyAggregateStatsV2Async(AuthDTO auth, int page=1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERSTATS_READ_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/stats/", auth, ifNoneMatch, queryParameters);

            checkResponse("YearlyAggregateStatsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<AggregateStats>>(responseModel);
        }

        public async Task<ESIModelDTO<CharacterInfo>> GetCharacterPublicInfoV4Async(int characterId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v4/characters/" + characterId + "/", ifNoneMatch);

            checkResponse("PublicInfoV4Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<CharacterInfo>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterAffiliation>>> AffiliationV1Async(List<int> characterIds, string ifNoneMatch = null)
        {
            var responseModel = await PostAsync("/v1/characters/affiliation/", null, characterIds, ifNoneMatch);

            checkResponse("AffiliationV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterAffiliation>>(responseModel);
        }

        public async Task<ESIModelDTO<float>> CalculationCSPAChargeCostV4Async(AuthDTO auth, List<int> characterIds)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CONTACTS_1);

            var responseModel = await PostAsync("/v4/characters/" + auth.Character.CharacterID + "/cspa/", auth, characterIds);

            checkResponse("CalculationCSPAChargeCostV4Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<float>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterName>>> GetCharacterNamesV1Async(List<int> characterIds, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "character_ids", characterIds == null || characterIds.Count == 0 ? "" : string.Join(",", characterIds) }
            };

            var responseModel = await GetAsync("/v1/characters/names/", ifNoneMatch, queryParameters);

            checkResponse("GetCharacterNamesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterName>>(responseModel);
        }

        public async Task<ESIModelDTO<Icons>> GetCharacterPortraitsV2Async(int characterId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v2/characters/" + characterId + "/portrait/", ifNoneMatch);

            checkResponse("GetCharacterPortraitsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Icons>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterCorporationHistory>>> GetCorporationHistoryV1Async(int characterId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/characters/" + characterId + "/corporationhistory/", ifNoneMatch);

            checkResponse("GetCorporationHistoryV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterCorporationHistory>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterMedals>>> GetMedalsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_MEDALS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/medals/", auth, ifNoneMatch);

            checkResponse("GetMedalsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterMedals>>(responseModel);
        }

        public async Task<ESIModelDTO<List<Standing>>> GetStandingsV1Async(AuthDTO auth, int page=1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_STANDINGS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/standings/", auth, ifNoneMatch);

            checkResponse("GetStandingsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Standing>>(responseModel);
        }

        public async Task<ESIModelDTO<List<AgentResearch>>> GetAgentsResearchV1Async(AuthDTO auth, int page=1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_AGENTS_RESEARCH_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/agents_research/", auth, ifNoneMatch);

            checkResponse("GetAgentsResearchV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<AgentResearch>>(responseModel);
        }

        public async Task<ESIModelDTO<List<Blueprint>>> GetBlueprintsV2Async(AuthDTO auth, int page=1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_BLUEPRINTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/blueprints/", auth, ifNoneMatch, queryParameters);

            checkResponse("GetBlueprintsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Blueprint>>(responseModel);
        }

        public async Task<ESIModelDTO<Fatigue>> GetJumpFatigueV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_FATIGUE_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/fatigue/", auth, ifNoneMatch);

            checkResponse("GetJumpFatigueV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Fatigue>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterContactNotification>>> GetNewContactNotificationsV1Async(AuthDTO auth, int page=1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERSTATS_READ_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/notifications/contacts/", auth, ifNoneMatch, queryParameters);

            checkResponse("GetNewContactNotificationsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterContactNotification>>(responseModel);
        }

        public async Task<ESIModelDTO<List<Notification>>> GetCharacterNotificationsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_NOTIFICATIONS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/notifications/", auth, ifNoneMatch);

            checkResponse("GetCharacterNotificationsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Notification>>(responseModel);
        }

        public async Task<ESIModelDTO<CharacterCorporationRoles>> GetCharacterCorporationRolesV2Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CORPORATION_ROLES_1);

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/roles/", auth, ifNoneMatch);

            checkResponse("GetCharacterCorporationRolesV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<CharacterCorporationRoles>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterTitle>>> GetCharacterCorporationTitlesV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_TITLES_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/titles/", auth, ifNoneMatch);

            checkResponse("GetCharacterCorporationTitlesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterTitle>>(responseModel);
        }
    }
}
