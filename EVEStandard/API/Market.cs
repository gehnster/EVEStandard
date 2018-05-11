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

        public async Task<List<MarketPrice>> ListMarketPricesV1Async()
        {
            var responseModel = await GetAsync("/v1/markets/prices/");

            checkResponse("ListMarketPricesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<MarketPrice>>(responseModel.JSONString);
        }

        public async Task<(List<MarketOrder>, long)> ListOrdersInRegionV1Async(long page, int regionId, long? typeId = null, string orderType = OrderType.All)
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

            return (JsonConvert.DeserializeObject<List<MarketOrder>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<MarketRegionHistory>> ListHistoricalMarketStatisticsInRegionV1Async(long page, int regionId, long typeId)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "type_id", typeId.ToString() }
            };

            var responseModel = await GetAsync("/v1/markets/" + regionId + "/history/", queryParameters);

            checkResponse("ListHistoricalMarketStatisticsInRegionV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<MarketRegionHistory>>(responseModel.JSONString);
        }

        public async Task<(List<MarketOrder>, long)> ListOrdersInStructureV1Async(AuthDTO auth, long page, long structureId)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_STRUCTURE_MARKETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/markets/structures/" + structureId + "/", queryParameters);

            checkResponse("ListOrdersInStructureV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<MarketOrder>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<int> GetItemGroupsV1Async()
        {
            var responseModel = await GetAsync("/v1/markets/groups/");

            checkResponse("GetItemGroupsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<int>(responseModel.JSONString);
        }

        public async Task<(MarketGroup, string)> GetItemGroupInfoV1Async(int marketGroupId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ??Language.English }
            };

            var responseModel = await GetAsync("/v1/markets/groups/" + marketGroupId + "/", queryParameters);

            checkResponse("GetItemGroupInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<MarketGroup>(responseModel.JSONString), responseModel.Language);
        }

        public async Task<List<CharacterMarketOrder>> ListOpenOrdersFromCharacterV2Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/orders/");

            checkResponse("ListOpenOrdersFromCharacterV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<CharacterMarketOrder>>(responseModel.JSONString);
        }

        public async Task<(List<CharacterMarketOrderHistory>, long)> ListHistoricalOrdersByCharacterV1Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/orders/history/", queryParameters);

            checkResponse("ListHistoricalOrdersByCharacterV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<CharacterMarketOrderHistory>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<long>, long)> ListTypeIdsRelevantToMarketV1Async(long page, int regionId)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/markets/" + regionId + "/types/", queryParameters);

            checkResponse("ListHistoricalOrdersByCharacterV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<CorporationMarketOrder>> ListOpenOrdersFromCorporationV2Async(AuthDTO auth, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CORPORATION_ORDERS_1);

            var responseModel = await GetAsync("/v2/corporations/" + corporationId + "/orders/");

            checkResponse("ListOpenOrdersFromCorporationV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<CorporationMarketOrder>>(responseModel.JSONString);
        }

        public async Task<(List<CorporationMarketOrderHistory>, long)> ListHistoricalOrdersByCorporationV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/orders/history/", queryParameters);

            checkResponse("ListHistoricalOrdersByCorporationV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<CorporationMarketOrderHistory>>(responseModel.JSONString), responseModel.MaxPages);
        }
    }
}
