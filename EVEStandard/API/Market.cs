using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{

    public class Market : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Market>();
        internal Market(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<MarketPrice>>> ListMarketPricesV1Async()
        {
            var responseModel = await GetAsync("/v1/markets/prices/");

            checkResponse("ListMarketPricesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<MarketPrice>>(responseModel);
        }

        public async Task<ESIModelDTO<List<MarketOrder>>> ListOrdersInRegionV1Async(int page, int regionId, long? typeId = null, string orderType = OrderType.All)
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

            var responseModel = await GetAsync("/v1/markets/" + regionId + "/orders/", queryParameters);

            checkResponse("ListOrdersInRegionV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<MarketOrder>>(responseModel);
        }

        public async Task<ESIModelDTO<List<MarketRegionHistory>>> ListHistoricalMarketStatisticsInRegionV1Async(int page, int regionId, long typeId)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "type_id", typeId.ToString() }
            };

            var responseModel = await GetAsync("/v1/markets/" + regionId + "/history/", queryParameters);

            checkResponse("ListHistoricalMarketStatisticsInRegionV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<MarketRegionHistory>>(responseModel);
        }

        public async Task<ESIModelDTO<List<MarketOrder>>> ListOrdersInStructureV1Async(AuthDTO auth, int page, long structureId)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_STRUCTURE_MARKETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/markets/structures/" + structureId + "/", queryParameters);

            checkResponse("ListOrdersInStructureV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<MarketOrder>>(responseModel);
        }

        public async Task<ESIModelDTO<int>> GetItemGroupsV1Async()
        {
            var responseModel = await GetAsync("/v1/markets/groups/");

            checkResponse("GetItemGroupsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<int>(responseModel);
        }

        public async Task<ESIModelDTO<MarketGroup>> GetItemGroupInfoV1Async(int marketGroupId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ??Language.English }
            };

            var responseModel = await GetAsync("/v1/markets/groups/" + marketGroupId + "/", queryParameters);

            checkResponse("GetItemGroupInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<MarketGroup>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterMarketOrder>>> ListOpenOrdersFromCharacterV2Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/orders/");

            checkResponse("ListOpenOrdersFromCharacterV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterMarketOrder>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterMarketOrderHistory>>> ListHistoricalOrdersByCharacterV1Async(AuthDTO auth, int page)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/orders/history/", queryParameters);

            checkResponse("ListHistoricalOrdersByCharacterV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterMarketOrderHistory>>(responseModel);
        }

        public async Task<ESIModelDTO<List<long>>> ListTypeIdsRelevantToMarketV1Async(int page, int regionId)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/markets/" + regionId + "/types/", queryParameters);

            checkResponse("ListHistoricalOrdersByCharacterV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<long>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationMarketOrder>>> ListOpenOrdersFromCorporationV2Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CORPORATION_ORDERS_1);

            var responseModel = await GetAsync("/v2/corporations/" + corporationId + "/orders/");

            checkResponse("ListOpenOrdersFromCorporationV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationMarketOrder>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationMarketOrderHistory>>> ListHistoricalOrdersByCorporationV1Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/orders/history/", queryParameters);

            checkResponse("ListHistoricalOrdersByCorporationV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationMarketOrderHistory>>(responseModel);
        }
    }
}
