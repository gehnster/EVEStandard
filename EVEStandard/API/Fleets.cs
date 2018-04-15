using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    using Models;

    public class Fleets : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Fleets>();
        internal Fleets(string dataSource) : base(dataSource)
        {
        }

        public async Task<FleetInfo> GetFleetInfoV1Async(AuthDTO auth, long fleetId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var responseModel = await this.GetAsync("/v1/fleets/" + fleetId + "/", auth);

            checkResponse("GetFleetInfoV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<FleetInfo>(responseModel.JSONString);
        }

        public async Task UpdateFleetV1Async(AuthDTO auth, long fleetId, string motd, bool? isFreeMove)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var new_settings = new
            {
                motd,
                is_free_move = isFreeMove
            };

            var responseModel = await this.PutAsync("/v1/fleets/" + fleetId + "/", auth, new_settings);

            checkResponse("UpdateFleetV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);
        }

        public async Task<CharacterFleetInfo> GetCharacterFleetInfoV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var responseModel = await this.GetAsync("/v1/characters/" + auth.Character.CharacterID + "/fleet/", auth);

            checkResponse("GetCharacterFleetInfoV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<CharacterFleetInfo>(responseModel.JSONString);
        }

        public async Task<List<FleetMember>> GetFleetMembersV1Async(AuthDTO auth, long fleetId, string language)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ??Language.English }
            };

            var responseModel = await this.GetAsync("/v1/fleets/" + fleetId + "/members/", auth);

            checkResponse("GetFleetMembersV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<FleetMember>>(responseModel.JSONString);
        }

        public async Task CreateFleetInvitationV1Async(AuthDTO auth, long fleetId, FleetInvitation invite)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await this.PostAsync("/v1/fleets/" + fleetId + "/members/", auth, invite);

            checkResponse("CreateFleetInvitationV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);
        }

        public async Task KickFleetMemberV1Async(AuthDTO auth, long fleetId, long memberId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await this.DeleteAsync("/v1/fleets/" + fleetId + "/members/" + memberId + "/", auth);

            checkResponse("KickFleetMemberV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);
        }

        public async Task MoveFleetMemberV1Async(AuthDTO auth, long fleetId, long memberId, FleetMemberMove movement)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await this.PutAsync("/v1/fleets/" + fleetId + "/members/" + memberId + "/", auth, movement);

            checkResponse("MoveFleetMemberV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);
        }

        public async Task<List<FleetWing>> GetFleetWingsV1Async(AuthDTO auth, long fleetId, string language)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ??Language.English }
            };

            var responseModel = await this.GetAsync("/v1/fleets/" + fleetId + "/wings/", auth);

            checkResponse("GetFleetWingsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<FleetWing>>(responseModel.JSONString);
        }

        public async Task<long> CreateFleetWingV1Async(AuthDTO auth, long fleetId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await this.PostAsync("/v1/fleets/" + fleetId + "/wings/", auth, null);

            checkResponse("CreateFleetWingV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<long>(responseModel.JSONString);
        }

        public async Task DeleteFleetWingV1Async(AuthDTO auth, long fleetId, long wingId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await this.DeleteAsync("/v1/fleets/" + fleetId + "/wings/" + wingId + "/", auth);

            checkResponse("DeleteFleetWingV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);
        }

        public async Task RenameFleetWingV1Async(AuthDTO auth, long fleetId, long wingId, string name)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var body = new
            {
                name,
            };

            var responseModel = await this.PutAsync("/v1/fleets/" + fleetId + "/wings/" + wingId + "/", auth, body);

            checkResponse("RenameFleetWingV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);
        }

        public async Task<long> CreateFleetSquadV1Async(AuthDTO auth, long fleetId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await this.PostAsync("/v1/fleets/" + fleetId + "/wings/squads/", auth, null);

            checkResponse("CreateFleetSquadV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<long>(responseModel.JSONString);
        }

        public async Task DeleteFleetSquadV1Async(AuthDTO auth, long fleetId, long squadId)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await this.DeleteAsync("/v1/fleets/" + fleetId + "/squads/" + squadId + "/", auth);

            checkResponse("DeleteFleetSquadV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);
        }

        public async Task RenameFleetSquadV1Async(AuthDTO auth, long fleetId, long squadId, string name)
        {
            checkAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var body = new
            {
                name,
            };

            var responseModel = await this.PutAsync("/v1/fleets/" + fleetId + "/squads/" + squadId + "/", auth, body);

            checkResponse("RenameFleetSquadV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);
        }
    }
}
