using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Character API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Character : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Character>();

        internal Character(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Returns aggregate yearly stats for a character.
        /// <para>GET /characters/{character_id}/stats/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing character stats.</returns>
        public async Task<ESIModelDTO<List<AggregateStats>>> YearlyAggregateStatsV2Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERSTATS_READ_1);           

            var responseModel = await GetAsync($"/v2/characters/{auth.CharacterId}/stats/", auth, ifNoneMatch);

            checkResponse(nameof(YearlyAggregateStatsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<AggregateStats>>(responseModel);
        }

        /// <summary>
        /// Public information about a character.
        /// <para>GET /characters/{character_id}/</para>
        /// </summary>
        /// <param name="characterId">An EVE character ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public data for the given character.</returns>
        public async Task<ESIModelDTO<CharacterInfo>> GetCharacterPublicInfoV4Async(int characterId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v4/characters/{characterId}/", ifNoneMatch);

            checkResponse(nameof(GetCharacterPublicInfoV4Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<CharacterInfo>(responseModel);
        }

        /// <summary>
        /// Bulk lookup of character IDs to corporation, alliance and faction.
        /// <para>POST /characters/affiliation/</para>
        /// </summary>
        /// <param name="characterIds">The character IDs to fetch affiliations for. All characters must exist, or none will be returned.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing character corporation, alliance and faction IDs.</returns>
        public async Task<ESIModelDTO<List<CharacterAffiliation>>> AffiliationV1Async(List<int> characterIds)
        {
            var responseModel = await PostAsync("/v1/characters/affiliation/", null, characterIds);

            checkResponse(nameof(AffiliationV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CharacterAffiliation>>(responseModel);
        }

        /// <summary>
        /// Takes a source character ID in the url and a set of target character ID’s in the body, returns a CSPA charge cost.
        /// <para>POST /characters/{character_id}/cspa/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="characterIds">The target characters to calculate the charge for.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing aggregate cost of sending a mail from the source character to the target characters, in ISK.</returns>
        public async Task<ESIModelDTO<float>> CalculateCSPAChargeCostV4Async(AuthDTO auth, List<int> characterIds)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CONTACTS_1);

            var responseModel = await PostAsync($"/v4/characters/{auth.CharacterId}/cspa/", auth, characterIds);

            checkResponse(nameof(CalculateCSPAChargeCostV4Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<float>(responseModel);
        }

        /// <summary>
        /// Resolve a set of character IDs to character names.
        /// <para>GET /characters/names/</para>
        /// </summary>
        /// <param name="characterIds">A comma separated list of character IDs.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of id/name associations.</returns>
        public async Task<ESIModelDTO<List<CharacterName>>> GetCharacterNamesV1Async(List<int> characterIds, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "character_ids", characterIds == null || characterIds.Count == 0 ? "" : string.Join(",", characterIds) }
            };

            var responseModel = await GetAsync("/v1/characters/names/", ifNoneMatch, queryParameters);

            checkResponse(nameof(GetCharacterNamesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CharacterName>>(responseModel);
        }

        /// <summary>
        /// Get portrait urls for a character.
        /// <para>GET /characters/{character_id}/portrait/</para>
        /// </summary>
        /// <param name="characterId">An EVE character ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public data for the given character.</returns>
        public async Task<ESIModelDTO<Icons>> GetCharacterPortraitsV2Async(int characterId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v2/characters/{characterId}/portrait/", ifNoneMatch);

            checkResponse(nameof(GetCharacterPortraitsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<Icons>(responseModel);
        }

        /// <summary>
        /// Get a list of all the corporations a character has been a member of.
        /// <para>GET /characters/{character_id}/corporationhistory/</para>
        /// </summary>
        /// <param name="characterId">An EVE character ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing corporation history for the given character.</returns>
        public async Task<ESIModelDTO<List<CharacterCorporationHistory>>> GetCorporationHistoryV1Async(int characterId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/characters/{characterId}/corporationhistory/", ifNoneMatch);

            checkResponse(nameof(GetCorporationHistoryV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CharacterCorporationHistory>>(responseModel);
        }

        /// <summary>
        /// Return a list of medals the character has.
        /// <para>GET /characters/{character_id}/medals/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of medals.</returns>
        public async Task<ESIModelDTO<List<CharacterMedals>>> GetMedalsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_MEDALS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/medals/", auth, ifNoneMatch);

            checkResponse(nameof(GetMedalsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CharacterMedals>>(responseModel);
        }

        /// <summary>
        /// Return character standings from agents, NPC corporations, and factions.
        /// <para>GET /characters/{character_id}/standings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of standings.</returns>
        public async Task<ESIModelDTO<List<Standing>>> GetStandingsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_STANDINGS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/standings/", auth, ifNoneMatch);

            checkResponse(nameof(GetStandingsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<Standing>>(responseModel);
        }

        /// <summary>
        /// Return a list of agents research information for a character. 
        /// The formula for finding the current research points with an agent is: 
        /// currentPoints = remainderPoints + pointsPerDay * days(currentTime - researchStartDate).
        /// <para>GET /characters/{character_id}/agents_research/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of agents research information.</returns>
        public async Task<ESIModelDTO<List<AgentResearch>>> GetAgentsResearchV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_AGENTS_RESEARCH_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/agents_research/", auth, ifNoneMatch);

            checkResponse(nameof(GetAgentsResearchV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<AgentResearch>>(responseModel);
        }

        /// <summary>
        /// Return a list of blueprints the character owns.
        /// <para>GET /characters/{character_id}/blueprints/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of blueprints.</returns>
        public async Task<ESIModelDTO<List<Blueprint>>> GetBlueprintsV2Async(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_BLUEPRINTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v2/characters/{auth.CharacterId}/blueprints/", auth, ifNoneMatch, queryParameters);

            checkResponse(nameof(GetBlueprintsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<Blueprint>>(responseModel);
        }

        /// <summary>
        /// Return a character’s jump activation and fatigue information.
        /// <para>GET /characters/{character_id}/fatigue/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing jump activation and fatigue information.</returns>
        public async Task<ESIModelDTO<Fatigue>> GetJumpFatigueV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_FATIGUE_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/fatigue/", auth, ifNoneMatch);

            checkResponse(nameof(GetJumpFatigueV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<Fatigue>(responseModel);
        }

        /// <summary>
        /// Return notifications about having been added to someone’s contact list.
        /// <para>GET /characters/{character_id}/notifications/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contact notifications.</returns>
        public async Task<ESIModelDTO<List<CharacterContactNotification>>> GetNewContactNotificationsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERSTATS_READ_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/notifications/contacts/", auth, ifNoneMatch);

            checkResponse(nameof(GetNewContactNotificationsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CharacterContactNotification>>(responseModel);
        }

        /// <summary>
        /// Return character notifications.
        /// <para>GET /characters/{character_id}/notifications/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing your recent notifications.</returns>
        public async Task<ESIModelDTO<List<Notification>>> GetCharacterNotificationsV2Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_NOTIFICATIONS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/notifications/", auth, ifNoneMatch);

            checkResponse(nameof(GetCharacterNotificationsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<Notification>>(responseModel);
        }

        /// <summary>
        /// Returns a character’s corporation roles.
        /// <para>GET /characters/{character_id}/roles/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the character’s roles in thier corporation.</returns>
        public async Task<ESIModelDTO<CharacterCorporationRoles>> GetCharacterCorporationRolesV2Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CORPORATION_ROLES_1);

            var responseModel = await GetAsync($"/v2/characters/{auth.CharacterId}/roles/", auth, ifNoneMatch);

            checkResponse(nameof(GetCharacterCorporationRolesV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<CharacterCorporationRoles>(responseModel);
        }

        /// <summary>
        /// Returns a character’s titles.
        /// <para>GET /characters/{character_id}/titles/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of titles.</returns>
        public async Task<ESIModelDTO<List<CharacterTitle>>> GetCharacterCorporationTitlesV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_TITLES_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/titles/", auth, ifNoneMatch);

            checkResponse(nameof(GetCharacterCorporationTitlesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CharacterTitle>>(responseModel);
        }
    }
}
