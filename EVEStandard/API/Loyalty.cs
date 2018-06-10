﻿using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Loyalty : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Loyalty>();

        internal Loyalty(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<LoyaltyStoreOffer>>> ListLoyaltyStoreOffersV1Async(int corporationId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/loyalty/stores/" + corporationId + "/offers/", ifNoneMatch);

            checkResponse("ListLoyaltyStoreOffersV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<LoyaltyStoreOffer>>(responseModel);
        }

        public async Task<ESIModelDTO<List<LoyaltyPoints>>> GetLoyaltyPointsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_LOYALTY_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/loyalty/points/", auth, ifNoneMatch);

            checkResponse("GetLoyaltyPointsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<LoyaltyPoints>>(responseModel);
        }
    }
}
