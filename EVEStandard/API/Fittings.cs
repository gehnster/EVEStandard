using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.API
{
    using System.Threading.Tasks;
    using Enumerations;
    using Models;
    using Models.API;
    using Newtonsoft.Json;

    public class Fittings : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Fittings>();
        internal Fittings(string dataSource) : base(dataSource)
        {
        }

        public async Task DeleteFittingV1Async(AuthDTO auth, long fittingId)
        {
            checkAuth(auth, Scopes.ESI_FITTINGS_WRITE_FITTINGS_1);

            var responseModel = await this.DeleteAsync("/v1/characters/" + auth.Character.CharacterID + "/fittings/" + fittingId + "/", auth);

            checkResponse("DeleteFittingV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);
        }

        public async Task<List<CharacterFitting>> GetFittingsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_FITTINGS_READ_FITTINGS_1);

            var responseModel = await this.GetAsync("/v1/characters/" + auth.Character.CharacterID + "/fittings/", auth);

            checkResponse("TrackCorporationMembersV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<CharacterFitting>>(responseModel.JSONString);
        }

        public async Task<long> CreateFittingV1Async(AuthDTO auth, ShipFitting fitting)
        {
            checkAuth(auth, Scopes.ESI_FITTINGS_READ_FITTINGS_1);

            var responseModel = await this.PostAsync("/v1/characters/" + auth.Character.CharacterID + "/fittings/", auth, fitting);

            checkResponse("TrackCorporationMembersV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<long>(responseModel.JSONString);
        }
    }
}
