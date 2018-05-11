using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Location : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Location>();
        internal Location(string dataSource) : base(dataSource)
        {
        }

        public async Task<CharacterLocation> GetCharacterLocationV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_LOCATION_READ_LOCATION_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/location/", auth);

            checkResponse("GetCharacterLocationV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<CharacterLocation>(responseModel.JSONString);
        }

        public async Task<CharacterShip> GetCurrentShipV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_LOCATION_READ_SHIP_TYPE_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/ship/", auth);

            checkResponse("GetCurrentShipV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<CharacterShip>(responseModel.JSONString);
        }

        public async Task<CharacterOnline> GetCharacterOnlineV2Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_LOCATION_READ_ONLINE_1);

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/online/", auth);

            checkResponse("GetCharacterOnlineV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<CharacterOnline>(responseModel.JSONString);
        }
    }
}
