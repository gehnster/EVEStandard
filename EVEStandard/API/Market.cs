using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{

    public class Market : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Market>();

        internal Market(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<MarketPrice>>> ListMarketPricesV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/markets/prices/", ifNoneMatch);

            checkResponse("ListMarketPricesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<MarketPrice>>(responseModel);
        }

        public async Task<ESIModelDTO<List<MarketOrder>>> ListOrdersInRegionV1Async(int page, int regionId, long? typeId = null, string orderType = OrderType.All, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "order_type", orderType }
            };

            if (typeId != null)
            {
                queryParameters.Add("type_id", typeId.ToString());
            }

            var responseModel = await GetAsync("/v1/markets/" + regionId + "/orders/", ifNoneMatch, queryParameters);

            checkResponse("ListOrdersInRegionV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<MarketOrder>>(responseModel);
        }

        public async Task<ESIModelDTO<List<MarketRegionHistory>>> ListHistoricalMarketStatisticsInRegionV1Async(int page, int regionId, long typeId, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "type_id", typeId.ToString() }
            };

            var responseModel = await GetAsync("/v1/markets/" + regionId + "/history/", ifNoneMatch, queryParameters);

            checkResponse("ListHistoricalMarketStatisticsInRegionV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<MarketRegionHistory>>(responseModel);
        }

        public async Task<ESIModelDTO<List<MarketOrder>>> ListOrdersInStructureV1Async(AuthDTO auth, int page, long structureId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_STRUCTURE_MARKETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/markets/structures/" + structureId + "/", ifNoneMatch, queryParameters);

            checkResponse("ListOrdersInStructureV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<MarketOrder>>(responseModel);
        }

        public async Task<ESIModelDTO<int>> GetItemGroupsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/markets/groups/", ifNoneMatch);

            checkResponse("GetItemGroupsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<int>(responseModel);
        }

        public async Task<ESIModelDTO<MarketGroup>> GetItemGroupInfoV1Async(int marketGroupId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ??Language.English }
            };

            var responseModel = await GetAsync("/v1/markets/groups/" + marketGroupId + "/", ifNoneMatch, queryParameters);

            checkResponse("GetItemGroupInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<MarketGroup>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterMarketOrder>>> ListOpenOrdersFromCharacterV2Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var responseModel = await GetAsync("/v2/characters/" + auth.CharacterId + "/orders/", auth, ifNoneMatch);

            checkResponse("ListOpenOrdersFromCharacterV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CharacterMarketOrder>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterMarketOrderHistory>>> ListHistoricalOrdersByCharacterV1Async(AuthDTO auth, int page=1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.CharacterId + "/orders/history/", auth, ifNoneMatch, queryParameters);

            checkResponse("ListHistoricalOrdersByCharacterV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CharacterMarketOrderHistory>>(responseModel);
        }

        public async Task<ESIModelDTO<List<long>>> ListTypeIdsRelevantToMarketV1Async(int page, int regionId, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/markets/" + regionId + "/types/", ifNoneMatch, queryParameters);

            checkResponse("ListHistoricalOrdersByCharacterV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<long>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationMarketOrder>>> ListOpenOrdersFromCorporationV2Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CORPORATION_ORDERS_1);

            var responseModel = await GetAsync("/v2/corporations/" + corporationId + "/orders/", ifNoneMatch);

            checkResponse("ListOpenOrdersFromCorporationV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CorporationMarketOrder>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationMarketOrderHistory>>> ListHistoricalOrdersByCorporationV1Async(AuthDTO auth, int page, int corporationId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/orders/history/", ifNoneMatch, queryParameters);

            checkResponse("ListHistoricalOrdersByCorporationV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CorporationMarketOrderHistory>>(responseModel);
        }
    }
}
