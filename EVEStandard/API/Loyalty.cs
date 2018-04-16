using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    using Enumerations;

    public class Loyalty : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Loyalty>();
        internal Loyalty(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<LoyaltyStoreOffer>> ListLoyaltyStoreOffersV1Async(long corporationId)
        {
            var responseModel = await this.GetAsync("/v1/loyalty/stores/" + corporationId + "/offers/");

            checkResponse("ListLoyaltyStoreOffersV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<LoyaltyStoreOffer>>(responseModel.JSONString);
        }

        public async Task<List<LoyaltyPoints>> GetLoyaltyPointsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_LOYALTY_1);

            var responseModel = await this.GetAsync("/v1/characters/" + auth.Character.CharacterID + "/loyalty/points/", auth);

            checkResponse("GetLoyaltyPointsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<LoyaltyPoints>>(responseModel.JSONString);
        }
    }
}
