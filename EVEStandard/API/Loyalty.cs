using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{

    public class Loyalty : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Loyalty>();
        internal Loyalty(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<LoyaltyStoreOffer>>> ListLoyaltyStoreOffersV1Async(int corporationId)
        {
            var responseModel = await GetAsync("/v1/loyalty/stores/" + corporationId + "/offers/");

            checkResponse("ListLoyaltyStoreOffersV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<LoyaltyStoreOffer>>(responseModel);
        }

        public async Task<ESIModelDTO<List<LoyaltyPoints>>> GetLoyaltyPointsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_LOYALTY_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/loyalty/points/", auth);

            checkResponse("GetLoyaltyPointsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<LoyaltyPoints>>(responseModel);
        }
    }
}
