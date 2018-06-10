using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Fleets : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Fleets>();
        internal Fleets(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<FleetInfo>> GetFleetInfoV1Async(AuthDTO auth, long fleetId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var responseModel = await GetAsync("/v1/fleets/" + fleetId + "/", auth, ifNoneMatch);

            checkResponse("GetFleetInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<FleetInfo>(responseModel);
        }

        public async Task UpdateFleetV1Async(AuthDTO auth, long fleetId, string motd, bool? isFreeMove)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var newSettings = new
            {
                motd,
                is_free_move = isFreeMove
            };

            var responseModel = await PutAsync("/v1/fleets/" + fleetId + "/", auth, newSettings);

            checkResponse("UpdateFleetV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);
        }

        public async Task<ESIModelDTO<CharacterFleetInfo>> GetCharacterFleetInfoV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.CharacterId + "/fleet/", auth, ifNoneMatch);

            checkResponse("GetCharacterFleetInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<CharacterFleetInfo>(responseModel);
        }

        public async Task<ESIModelDTO<List<FleetMember>>> GetFleetMembersV1Async(AuthDTO auth, long fleetId, string language = Language.English, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ??Language.English }
            };

            var responseModel = await GetAsync("/v1/fleets/" + fleetId + "/members/", auth, ifNoneMatch);

            checkResponse("GetFleetMembersV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<FleetMember>>(responseModel);
        }

        public async Task CreateFleetInvitationV1Async(AuthDTO auth, long fleetId, FleetInvitation invite)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PostAsync("/v1/fleets/" + fleetId + "/members/", auth, invite);

            checkResponse("CreateFleetInvitationV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);
        }

        public async Task KickFleetMemberV1Async(AuthDTO auth, long fleetId, long memberId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await DeleteAsync("/v1/fleets/" + fleetId + "/members/" + memberId + "/", auth);

            checkResponse("KickFleetMemberV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);
        }

        public async Task MoveFleetMemberV1Async(AuthDTO auth, long fleetId, long memberId, FleetMemberMove movement)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PutAsync("/v1/fleets/" + fleetId + "/members/" + memberId + "/", auth, movement);

            checkResponse("MoveFleetMemberV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);
        }

        public async Task<ESIModelDTO<List<FleetWing>>> GetFleetWingsV1Async(AuthDTO auth, long fleetId, string language = Language.English, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ??Language.English }
            };

            var responseModel = await GetAsync("/v1/fleets/" + fleetId + "/wings/", auth, ifNoneMatch);

            checkResponse("GetFleetWingsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<FleetWing>>(responseModel);
        }

        public async Task<ESIModelDTO<long>> CreateFleetWingV1Async(AuthDTO auth, long fleetId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PostAsync("/v1/fleets/" + fleetId + "/wings/", auth, null);

            checkResponse("CreateFleetWingV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<long>(responseModel);
        }

        public async Task DeleteFleetWingV1Async(AuthDTO auth, long fleetId, long wingId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await DeleteAsync("/v1/fleets/" + fleetId + "/wings/" + wingId + "/", auth);

            checkResponse("DeleteFleetWingV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);
        }

        public async Task RenameFleetWingV1Async(AuthDTO auth, long fleetId, long wingId, string name)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var body = new
            {
                name
            };

            var responseModel = await PutAsync("/v1/fleets/" + fleetId + "/wings/" + wingId + "/", auth, body);

            checkResponse("RenameFleetWingV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);
        }

        public async Task<ESIModelDTO<long>> CreateFleetSquadV1Async(AuthDTO auth, long fleetId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PostAsync("/v1/fleets/" + fleetId + "/wings/squads/", auth, null);

            checkResponse("CreateFleetSquadV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<long>(responseModel);
        }

        public async Task DeleteFleetSquadV1Async(AuthDTO auth, long fleetId, long squadId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await DeleteAsync("/v1/fleets/" + fleetId + "/squads/" + squadId + "/", auth);

            checkResponse("DeleteFleetSquadV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);
        }

        public async Task RenameFleetSquadV1Async(AuthDTO auth, long fleetId, long squadId, string name)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var body = new
            {
                name
            };

            var responseModel = await PutAsync("/v1/fleets/" + fleetId + "/squads/" + squadId + "/", auth, body);

            checkResponse("RenameFleetSquadV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);
        }
    }
}
