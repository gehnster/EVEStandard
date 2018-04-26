using EVEStandard.Models;
using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Character : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Character>();
        internal Character(string dataSource) : base(dataSource)
        {
        }

        public async Task<(List<AggregateStats>, long)> YearlyAggregateStatsV2Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERSTATS_READ_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/stats/", auth, queryParameters);

            checkResponse("YearlyAggregateStatsV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<AggregateStats>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<CharacterInfo> GetCharacterPublicInfoV4Async(long characterId)
        {
            var responseModel = await GetAsync("/v4/characters/" + characterId + "/");

            checkResponse("PublicInfoV4Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<CharacterInfo>(responseModel.JSONString);
        }

        public async Task<List<CharacterAffiliation>> AffiliationV1Async(List<long> characterIds)
        {
            var responseModel = await PostAsync("/v1/characters/affiliation/", null, characterIds);

            checkResponse("AffiliationV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<CharacterAffiliation>>(responseModel.JSONString);
        }

        public async Task<float> CalculationCSPAChargeCostV4Async(AuthDTO auth, List<long> characterIds)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CONTACTS_1);

            var responseModel = await PostAsync("/v4/characters/" + auth.Character.CharacterID + "/cspa/", auth, characterIds);

            checkResponse("CalculationCSPAChargeCostV4Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<float>(responseModel.JSONString);
        }

        public async Task<List<CharacterName>> GetCharacterNamesV1Async(List<long> characterIds)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "character_ids", characterIds == null || characterIds.Count == 0 ? "" : string.Join(",", characterIds) }
            };

            var responseModel = await GetAsync("/v1/characters/names/", queryParameters);

            checkResponse("GetCharacterNamesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<CharacterName>>(responseModel.JSONString);
        }

        public async Task<Icons> GetCharacterPortraitsV2Async(long characterId)
        {
            var responseModel = await GetAsync("/v2/characters/" + characterId + "/portrait/");

            checkResponse("GetCharacterPortraitsV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Icons>(responseModel.JSONString);
        }

        public async Task<(List<CharacterCorporationHistory>, long)> GetCorporationHistoryV1Async(long characterId)
        {
            var responseModel = await GetAsync("/v1/characters/" + characterId + "/corporationhistory/");

            checkResponse("GetCorporationHistoryV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<CharacterCorporationHistory>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<CharacterChatChannels>> GetChatChannelsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CHAT_CHANNELS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/chat_channels/", auth);

            checkResponse("GetChatChannelsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<CharacterChatChannels>>(responseModel.JSONString);
        }

        public async Task<List<CharacterMedals>> GetMedalsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_MEDALS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/medals/", auth);

            checkResponse("GetMedalsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<CharacterMedals>>(responseModel.JSONString);
        }

        public async Task<(List<Standing>, long)> GetStandingsV1Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_STANDINGS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/standings/", auth);

            checkResponse("GetStandingsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<Standing>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<AgentResearch>> GetAgentsResearchV1Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_AGENTS_RESEARCH_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/agents_research/", auth);

            checkResponse("GetAgentsResearchV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<AgentResearch>>(responseModel.JSONString);
        }

        public async Task<(List<Blueprint>, long)> GetBlueprintsV2Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_BLUEPRINTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/blueprints/", auth, queryParameters);

            checkResponse("GetBlueprintsV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<Blueprint>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<Fatigue> GetJumpFatigueV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_FATIGUE_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/fatigue/", auth);

            checkResponse("GetJumpFatigueV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Fatigue>(responseModel.JSONString);
        }

        public async Task<(List<CharacterContactNotification>, long)> GetNewContactNotificationsV1Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERSTATS_READ_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/notifications/contacts/", auth, queryParameters);

            checkResponse("GetNewContactNotificationsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<CharacterContactNotification>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<Notification>> GetCharacterNotificationsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_NOTIFICATIONS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/notifications/", auth);

            checkResponse("GetCharacterNotificationsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<Notification>>(responseModel.JSONString);
        }

        public async Task<CharacterCorporationRoles> GetCharacterCorporationRolesV2Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CORPORATION_ROLES_1);

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/roles/", auth);

            checkResponse("GetCharacterCorporationRolesV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<CharacterCorporationRoles>(responseModel.JSONString);
        }

        public async Task<List<CharacterTitle>> GetCharacterCorporationTitlesV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_TITLES_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/titles/", auth);

            checkResponse("GetCharacterCorporationTitlesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<CharacterTitle>>(responseModel.JSONString);
        }
    }
}
