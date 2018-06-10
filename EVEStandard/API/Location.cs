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

        public async Task<ESIModelDTO<CharacterLocation>> GetCharacterLocationV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_LOCATION_READ_LOCATION_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.CharacterId + "/location/", auth, ifNoneMatch);

            checkResponse("GetCharacterLocationV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<CharacterLocation>(responseModel);
        }

        public async Task<ESIModelDTO<CharacterShip>> GetCurrentShipV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_LOCATION_READ_SHIP_TYPE_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.CharacterId + "/ship/", auth, ifNoneMatch);

            checkResponse("GetCurrentShipV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<CharacterShip>(responseModel);
        }

        public async Task<ESIModelDTO<CharacterOnline>> GetCharacterOnlineV2Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_LOCATION_READ_ONLINE_1);

            var responseModel = await GetAsync("/v2/characters/" + auth.CharacterId + "/online/", auth, ifNoneMatch);

            checkResponse("GetCharacterOnlineV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<CharacterOnline>(responseModel);
        }
    }
}
