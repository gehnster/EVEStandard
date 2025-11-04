using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Corporation API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Corporation : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Corporation>();

        internal Corporation(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Return the current shareholders of a corporation.
        /// <para>GET /corporations/{corporation_id}/shareholders/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of shareholders.</returns>
        public async Task<ESIModelDTO<List<Shareholder>>> GetCorporationShareholdersAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/shareholders/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationShareholdersAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Shareholder>>(responseModel);
        }

        /// <summary>
        /// Public information about a corporation.
        /// <para>GET /corporations/{corporation_id}/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public information about a corporation.</returns>
        public async Task<ESIModelDTO<CorporationInfo>> GetCorporationInfoAsync(int corporationId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/corporations/{corporationId}/", ifNoneMatch);

            CheckResponse(nameof(GetCorporationInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CorporationInfo>(responseModel);
        }

        /// <summary>
        /// Get a list of all the alliances a corporation has been a member of.
        /// <para>GET /corporations/{corporation_id}/alliancehistory/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing alliance history for the given corporation.</returns>
        public async Task<ESIModelDTO<List<AllianceHistory>>> GetAllianceHistoryAsync(int corporationId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/corporations/{corporationId}/alliancehistory/", ifNoneMatch);

            CheckResponse(nameof(GetAllianceHistoryAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<AllianceHistory>>(responseModel);
        }

        /// <summary>
        /// Return the current member list of a corporation, the token’s character need to be a member of the corporation.
        /// <para>GET /corporations/{corporation_id}/members/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of member character IDs.</returns>
        public async Task<ESIModelDTO<List<int>>> GetCorporationMembersAsync(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/members/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationMembersAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Return the roles of all members if the character has the personnel manager role or any grantable role.
        /// <para>GET /corporations/{corporation_id}/roles/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of member character ID’s and roles.</returns>
        public async Task<ESIModelDTO<List<CorporationRoles>>> GetCorporationMemberRolesAsync(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/roles/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationMemberRolesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationRoles>>(responseModel);
        }

        /// <summary>
        /// Return how roles have changed for a coporation’s members, up to a month.
        /// <para>GET /corporations/{corporation_id}/roles/history/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of role changes.</returns>
        public async Task<ESIModelDTO<List<CorporationRoleHistory>>> GetCorporationMemberRolesHistoryAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/roles/history/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationMemberRolesHistoryAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationRoleHistory>>(responseModel);
        }

        /// <summary>
        /// Get the icon urls for a corporation.
        /// <para>GET /corporations/{corporation_id}/icons/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing urls for icons for the given corporation id and server.</returns>
        public async Task<ESIModelDTO<Icons>> GetCorporationIconAsync(int corporationId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/corporations/{corporationId}/icons/", ifNoneMatch);

            CheckResponse(nameof(GetCorporationIconAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Icons>(responseModel);
        }

        /// <summary>
        /// Get a list of npc corporations.
        /// <para>GET /corporations/npccorps/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of npc corporation ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetNPCCorporationsAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/corporations/npccorps/", ifNoneMatch);

            CheckResponse(nameof(GetNPCCorporationsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get a list of corporation structures.
        /// <para>GET /corporations/{corporation_id}/structures/</para>
        /// <para>Requires one of the following EVE corporation role(s): StationManager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <param name="language">Language to use in the response</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation structures’ information.</returns>
        public async Task<ESIModelDTO<List<CorporationStructure>>> GetCorporationStructuresAsync(AuthDTO auth, int corporationId, int page = 1, string language = Language.English, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_STRUCTURES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "language", language }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/structures/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationStructuresAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationStructure>>(responseModel);
        }

        /// <summary>
        /// Returns additional information about a corporation’s members which helps tracking their activities.
        /// <para>GET /corporations/{corporation_id}/membertracking/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of member character IDs.</returns>
        public async Task<ESIModelDTO<List<CorporationMemberTracking>>> TrackCorporationMembersAsync(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/membertracking/", auth, ifNoneMatch);

            CheckResponse(nameof(TrackCorporationMembersAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMemberTracking>>(responseModel);
        }

        /// <summary>
        /// Return corporation hangar and wallet division names, only show if a division is not using the default name.
        /// <para>GET /corporations/{corporation_id}/divisions/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation division names.</returns>
        public async Task<ESIModelDTO<CorporationDivision>> GetCorporationDivisionsAsync(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/divisions/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationDivisionsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CorporationDivision>(responseModel);
        }

        /// <summary>
        /// Return a corporation’s member limit, not including CEO himself.
        /// <para>GET /corporations/{corporation_id}/members/limit/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the corporation’s member limit.</returns>
        public async Task<ESIModelDTO<int>> GetCorporationMemberLimitAsync(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/members/limit/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationMemberLimitAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<int>(responseModel);
        }

        /// <summary>
        /// Returns a corporation’s titles.
        /// <para>GET /corporations/{corporation_id}/titles/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of titles.</returns>
        public async Task<ESIModelDTO<List<CorporationTitle>>> GetCorporationTitlesAsync(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_TITLES_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/titles/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationTitlesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationTitle>>(responseModel);
        }

        /// <summary>
        /// Returns a corporation’s members’ titles.
        /// <para>GET /corporations/{corporation_id}/members/titles/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of members and theirs titles.</returns>
        public async Task<ESIModelDTO<List<CorporationMemberTitles>>> GetCorporationsMembersTitlesAsync(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_TITLES_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/members/titles/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationsMembersTitlesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMemberTitles>>(responseModel);
        }

        /// <summary>
        /// Returns a list of blueprints the corporation owns.
        /// <para>GET /corporations/{corporation_id}/blueprints/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation blueprints.</returns>
        public async Task<ESIModelDTO<List<Blueprint>>> GetCorporationBlueprintsAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_BLUEPRINTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/blueprints/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationBlueprintsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Blueprint>>(responseModel);
        }

        /// <summary>
        /// Return corporation standings from agents, NPC corporations, and factions.
        /// <para>GET /corporations/{corporation_id}/standings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of standings.</returns>
        public async Task<ESIModelDTO<List<Standing>>> GetStandingsAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_STANDINGS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/standings/", auth, ifNoneMatch);

            CheckResponse(nameof(GetStandingsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Standing>>(responseModel);
        }

        /// <summary>
        /// Returns list of corporation starbases (POSes).
        /// <para>GET /corporations/{corporation_id}/starbases/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of starbases (POSes).</returns>
        public async Task<ESIModelDTO<List<Starbase>>> GetCorporationStarbasesAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_STARBASES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/starbases/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationStarbasesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Starbase>>(responseModel);
        }

        /// <summary>
        /// Returns various settings and fuels of a starbase (POS).
        /// <para>GET /corporations/{corporation_id}/starbases/{starbase_id}/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="starbaseId">An EVE starbase (POS) ID.</param>
        /// <param name="systemId">The solar system this starbase (POS) is located in.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of starbases (POSes).</returns>
        public async Task<ESIModelDTO<StarbaseDetail>> GetStarbaseDetailAsync(AuthDTO auth, int corporationId, long starbaseId, long systemId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_STARBASES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "system_id", systemId.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/starbases/{starbaseId}/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetStarbaseDetailAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<StarbaseDetail>(responseModel);
        }

        /// <summary>
        /// Returns logs recorded in the past seven days from all audit log secure containers (ALSC) owned by a given corporation.
        /// <para>GET /corporations/{corporation_id}/containers/logs/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation ALSC logs.</returns>
        public async Task<ESIModelDTO<List<ContainerLogs>>> GetAllCorporationALSCLogsAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_CONTAINER_LOGS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/containers/logs/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetAllCorporationALSCLogsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContainerLogs>>(responseModel);
        }

        /// <summary>
        /// Return a corporation’s facilities.
        /// <para>GET /corporations/{corporation_id}/facilities/</para>
        /// <para>Requires one of the following EVE corporation role(s): Factory_Manager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation facilities.</returns>
        public async Task<ESIModelDTO<List<Facility>>> GetCorporationFacilitiesAsync(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_FACILITIES_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/facilities/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationFacilitiesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Facility>>(responseModel);
        }

        /// <summary>
        /// Returns a corporation’s medals.
        /// <para>GET /corporations/{corporation_id}/medals/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of medals.</returns>
        public async Task<ESIModelDTO<List<CorporationMedal>>> GetCorporationMedalsAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_MEDALS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/medals/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationMedalsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMedal>>(responseModel);
        }

        /// <summary>
        /// Returns medals issued by a corporation.
        /// <para>GET /corporations/{corporation_id}/medals/issued/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of issued medals.</returns>
        public async Task<ESIModelDTO<List<CorporationMedalIssued>>> GetCorporationIssuedMedalsAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_MEDALS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/medals/issued/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationIssuedMedalsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMedalIssued>>(responseModel);
        }
    }
}
