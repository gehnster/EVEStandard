using System;
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

        internal Character(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Public information about a character.
        /// <para>GET /characters/{character_id}/</para>
        /// </summary>
        /// <param name="characterId">An EVE character ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public data for the given character.</returns>
        public async Task<ESIModelDTO<CharacterInfo>> GetCharacterPublicInfoAsync(int characterId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/characters/{characterId}/", ifNoneMatch);

            CheckResponse(nameof(GetCharacterPublicInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterInfo>(responseModel);
        }

        /// <summary>
        /// Bulk lookup of character IDs to corporation, alliance and faction.
        /// <para>POST /characters/affiliation/</para>
        /// </summary>
        /// <param name="characterIds">The character IDs to fetch affiliations for. All characters must exist, or none will be returned.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing character corporation, alliance and faction IDs.</returns>
        public async Task<ESIModelDTO<List<CharacterAffiliation>>> AffiliationAsync(List<int> characterIds)
        {
            var responseModel = await PostAsync("/characters/affiliation/", null, characterIds);

            CheckResponse(nameof(AffiliationAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterAffiliation>>(responseModel);
        }

        /// <summary>
        /// Takes a source character ID in the url and a set of target character ID’s in the body, returns a CSPA charge cost.
        /// <para>POST /characters/{character_id}/cspa/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="characterIds">The target characters to calculate the charge for.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing aggregate cost of sending a mail from the source character to the target characters, in ISK.</returns>
        public async Task<ESIModelDTO<float>> CalculateCSPAChargeCostAsync(AuthDTO auth, List<int> characterIds)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_CONTACTS_1);

            var responseModel = await PostAsync($"/characters/{auth.CharacterId}/cspa/", auth, characterIds);

            CheckResponse(nameof(CalculateCSPAChargeCostAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<float>(responseModel);
        }

        /// <summary>
        /// Get portrait urls for a character.
        /// <para>GET /characters/{character_id}/portrait/</para>
        /// </summary>
        /// <param name="characterId">An EVE character ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public data for the given character.</returns>
        public async Task<ESIModelDTO<Icons>> GetCharacterPortraitsAsync(int characterId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/characters/{characterId}/portrait/", ifNoneMatch);

            CheckResponse(nameof(GetCharacterPortraitsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Icons>(responseModel);
        }

        /// <summary>
        /// Get a list of all the corporations a character has been a member of.
        /// <para>GET /characters/{character_id}/corporationhistory/</para>
        /// </summary>
        /// <param name="characterId">An EVE character ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing corporation history for the given character.</returns>
        public async Task<ESIModelDTO<List<CharacterCorporationHistory>>> GetCorporationHistoryAsync(int characterId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/characters/{characterId}/corporationhistory/", ifNoneMatch);

            CheckResponse(nameof(GetCorporationHistoryAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterCorporationHistory>>(responseModel);
        }

        /// <summary>
        /// Return a list of medals the character has.
        /// <para>GET /characters/{character_id}/medals/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of medals.</returns>
        public async Task<ESIModelDTO<List<CharacterMedals>>> GetMedalsAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_MEDALS_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/medals/", auth, ifNoneMatch);

            CheckResponse(nameof(GetMedalsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterMedals>>(responseModel);
        }

        /// <summary>
        /// Return character standings from agents, NPC corporations, and factions.
        /// <para>GET /characters/{character_id}/standings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of standings.</returns>
        public async Task<ESIModelDTO<List<Standing>>> GetStandingsAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_STANDINGS_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/standings/", auth, ifNoneMatch);

            CheckResponse(nameof(GetStandingsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Standing>>(responseModel);
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
        public async Task<ESIModelDTO<List<AgentResearch>>> GetAgentsResearchAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_AGENTS_RESEARCH_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/agents_research/", auth, ifNoneMatch);

            CheckResponse(nameof(GetAgentsResearchAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<AgentResearch>>(responseModel);
        }

        /// <summary>
        /// Return a list of blueprints the character owns.
        /// <para>GET /characters/{character_id}/blueprints/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of blueprints.</returns>
        public async Task<ESIModelDTO<List<Blueprint>>> GetBlueprintsAsync(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_BLUEPRINTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/blueprints/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetBlueprintsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Blueprint>>(responseModel);
        }

        /// <summary>
        /// Return a character’s jump activation and fatigue information.
        /// <para>GET /characters/{character_id}/fatigue/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing jump activation and fatigue information.</returns>
        public async Task<ESIModelDTO<Fatigue>> GetJumpFatigueAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_FATIGUE_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/fatigue/", auth, ifNoneMatch);

            CheckResponse(nameof(GetJumpFatigueAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Fatigue>(responseModel);
        }

        /// <summary>
        /// Return notifications about having been added to someone’s contact list.
        /// <para>GET /characters/{character_id}/notifications/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contact notifications.</returns>
        public async Task<ESIModelDTO<List<CharacterContactNotification>>> GetNewContactNotificationsAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_NOTIFICATIONS_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/notifications/contacts/", auth, ifNoneMatch);

            CheckResponse(nameof(GetNewContactNotificationsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterContactNotification>>(responseModel);
        }

        /// <summary>
        /// Return character notifications.
        /// <para>GET /characters/{character_id}/notifications/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing your recent notifications.</returns>
        public async Task<ESIModelDTO<List<Notification>>> GetCharacterNotificationsAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_NOTIFICATIONS_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/notifications/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterNotificationsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Notification>>(responseModel);
        }

        /// <summary>
        /// Returns a character’s corporation roles.
        /// <para>GET /characters/{character_id}/roles/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the character’s roles in thier corporation.</returns>
        public async Task<ESIModelDTO<CharacterCorporationRoles>> GetCharacterCorporationRolesAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_CORPORATION_ROLES_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/roles/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterCorporationRolesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterCorporationRoles>(responseModel);
        }

        /// <summary>
        /// Returns a character’s titles.
        /// <para>GET /characters/{character_id}/titles/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of titles.</returns>
        public async Task<ESIModelDTO<List<CharacterTitle>>> GetCharacterCorporationTitlesAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_TITLES_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/titles/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterCorporationTitlesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterTitle>>(responseModel);
        }
    }
}
