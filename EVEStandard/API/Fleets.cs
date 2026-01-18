using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Fleets API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Fleets : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Fleets>();

        internal Fleets(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Return details about a fleet.
        /// <para>GET /fleets/{fleet_id}</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details about a fleet.</returns>
        public async Task<ESIModelDTO<FleetInfo>> GetFleetInfoAsync(AuthDTO auth, long fleetId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var responseModel = await GetAsync($"/fleets/{fleetId}/", auth, ifNoneMatch);

            CheckResponse(nameof(GetFleetInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<FleetInfo>(responseModel);
        }

        /// <summary>
        /// Update settings about a fleet.
        /// <para>PUT /fleets/{fleet_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="motd">New fleet MOTD in CCP flavoured HTML.</param>
        /// <param name="isFreeMove">Should free-move be enabled in the fleet.</param>
        /// <returns></returns>
        public async Task UpdateFleetAsync(AuthDTO auth, long fleetId, string motd, bool? isFreeMove)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var newSettings = new
            {
                motd,
                is_free_move = isFreeMove
            };

            var responseModel = await PutAsync($"/fleets/{fleetId}/", auth, newSettings);

            CheckResponse(nameof(UpdateFleetAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return the fleet ID the character is in, if any.
        /// <para>GET /characters/{character_id}/fleet/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details about the character’s fleet.</returns>
        public async Task<ESIModelDTO<CharacterFleetInfo>> GetCharacterFleetInfoAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/fleet/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterFleetInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterFleetInfo>(responseModel);
        }

        /// <summary>
        /// Return information about fleet members.
        /// <para>GET /fleets/{fleet_id}/members/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="language">Language to use in the response. Available values : de, en-us, fr, ja, ru, zh. Default value: en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet members.</returns>
        public async Task<ESIModelDTO<List<FleetMember>>> GetFleetMembersAsync(AuthDTO auth, long fleetId, string language = Language.English, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ?? Language.English }
            };

            var responseModel = await GetAsync($"/fleets/{fleetId}/members/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetFleetMembersAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<FleetMember>>(responseModel);
        }

        /// <summary>
        /// Invite a character into the fleet. If a character has a CSPA charge set it is not possible to invite them to the fleet using ESI.
        /// <para>POST /fleets/{fleet_id}/members/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="invite">Details of the invitation.</param>
        /// <returns></returns>
        public async Task CreateFleetInvitationAsync(AuthDTO auth, long fleetId, FleetInvitation invite)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PostAsync($"/fleets/{fleetId}/members/", auth, invite);

            CheckResponse(nameof(CreateFleetInvitationAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Kick a fleet member.
        /// <para>DELETE /fleets/{fleet_id}/members/{member_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="memberId">The character ID of a member in this fleet.</param>
        /// <returns></returns>
        public async Task KickFleetMemberAsync(AuthDTO auth, long fleetId, long memberId)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await DeleteAsync($"/fleets/{fleetId}/members/{memberId}/", auth);

            CheckResponse(nameof(KickFleetMemberAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Move a fleet member around.
        /// <para>PUT /fleets/{fleet_id}/members/{member_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="memberId">The character ID of a member in this fleet.</param>
        /// <param name="movement">Details of the invitation.</param>
        /// <returns></returns>
        public async Task MoveFleetMemberAsync(AuthDTO auth, long fleetId, long memberId, FleetMemberMove movement)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PutAsync($"/fleets/{fleetId}/members/{memberId}/", auth, movement);

            CheckResponse(nameof(MoveFleetMemberAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return information about wings in a fleet.
        /// <para>GET /fleets/{fleet_id}/wings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="language">Language to use in the response. Available values : de, en-us, fr, ja, ru, zh. Default value: en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet wings.</returns>
        public async Task<ESIModelDTO<List<FleetWing>>> GetFleetWingsAsync(AuthDTO auth, long fleetId, string language = Language.English, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ?? Language.English }
            };

            var responseModel = await GetAsync($"/fleets/{fleetId}/wings/", auth, ifNoneMatch);

            CheckResponse(nameof(GetFleetWingsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<FleetWing>>(responseModel);
        }

        /// <summary>
        /// Create a new wing in a fleet.
        /// <para>POST /fleets/{fleet_id}/wings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet wing ids.</returns>
        public async Task<ESIModelDTO<long>> CreateFleetWingAsync(AuthDTO auth, long fleetId)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PostAsync($"/fleets/{fleetId}/wings/", auth, null, null, null);

            CheckResponse(nameof(CreateFleetWingAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<long>(responseModel);
        }

        /// <summary>
        /// Delete a fleet wing, only empty wings can be deleted. The wing may contain squads, but the squads must be empty.
        /// <para>DELETE /fleets/{fleet_id}/wings/{wing_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="wingId">The wing to delete.</param>
        /// <returns></returns>
        public async Task DeleteFleetWingAsync(AuthDTO auth, long fleetId, long wingId)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await DeleteAsync($"/fleets/{fleetId}/wings/{wingId}/", auth);

            CheckResponse(nameof(DeleteFleetWingAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Rename a fleet wing
        /// <para>PUT /fleets/{fleet_id}/wings/{wing_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="wingId">The wing to delete.</param>
        /// <param name="name">New name of the wing.</param>
        /// <returns></returns>
        public async Task RenameFleetWingAsync(AuthDTO auth, long fleetId, long wingId, string name)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var body = new
            {
                name
            };

            var responseModel = await PutAsync($"/fleets/{fleetId}/wings/{wingId}/", auth, body);

            CheckResponse(nameof(RenameFleetWingAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Create a new squad in a fleet.
        /// <para>POST /fleets/{fleet_id}/wings/{wing_id}/squads/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet squad ids.</returns>
        public async Task<ESIModelDTO<long>> CreateFleetSquadAsync(AuthDTO auth, long fleetId, long wingId)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PostAsync($"/fleets/{fleetId}/wings/{wingId}/squads/", auth, null, null, null);

            CheckResponse(nameof(CreateFleetSquadAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<long>(responseModel);
        }

        /// <summary>
        /// Delete a fleet squad, only empty squads can be deleted.
        /// <para>DELETE /fleets/{fleet_id}/squads/{squad_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="squadId">The squad to delete.</param>
        /// <returns></returns>
        public async Task DeleteFleetSquadAsync(AuthDTO auth, long fleetId, long squadId)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await DeleteAsync($"/fleets/{fleetId}/squads/{squadId}/", auth);

            CheckResponse(nameof(DeleteFleetSquadAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Rename a fleet squad.
        /// <para>PUT /fleets/{fleet_id}/squads/{squad_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="squadId">The squad to delete.</param>
        /// <param name="name">New name of the squad.</param>
        /// <returns></returns>
        public async Task RenameFleetSquadAsync(AuthDTO auth, long fleetId, long squadId, string name)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var body = new
            {
                name
            };

            var responseModel = await PutAsync($"/fleets/{fleetId}/squads/{squadId}/", auth, body);

            CheckResponse(nameof(RenameFleetSquadAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }
    }
}
