using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;

namespace EVEStandard.API
{

    public class Loyalty : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Loyalty>();
        internal Loyalty(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<LoyaltyStoreOffer>> ListLoyaltyStoreOffersV1Async(long corporationId)
        {
            var responseModel = await GetAsync("/v1/loyalty/stores/" + corporationId + "/offers/");

            checkResponse("ListLoyaltyStoreOffersV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<LoyaltyStoreOffer>>(responseModel.JSONString);
        }

        public async Task<List<LoyaltyPoints>> GetLoyaltyPointsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_LOYALTY_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/loyalty/points/", auth);

            checkResponse("GetLoyaltyPointsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<LoyaltyPoints>>(responseModel.JSONString);
        }
    }
}
