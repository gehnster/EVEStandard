using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Market API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Market : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Market>();

        internal Market(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Return a list of prices.
        /// <para>GET /markets/prices/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of prices.</returns>
        public async Task<ESIModelDTO<List<MarketPrice>>> ListMarketPricesAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/markets/prices/", ifNoneMatch);

            CheckResponse(nameof(ListMarketPricesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<MarketPrice>>(responseModel);
        }

        /// <summary>
        /// Return a list of orders in a region.
        /// <para>GET /markets/{region_id}/orders/</para>
        /// </summary>
        /// <param name="regionId">Return orders in this region.</param>
        /// <param name="typeId">Return orders only for this type.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="orderType">Filter buy/sell orders, return all orders by default. If you query without type_id, we always return both buy and sell orders. Available values : buy, sell, all. Default value: all.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of orders.</returns>
        public async Task<ESIModelDTO<List<MarketOrder>>> ListOrdersInRegionAsync(int regionId, long? typeId = null, int page = 1, string orderType = OrderType.All, string ifNoneMatch = null)
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

            var responseModel = await GetAsync($"/markets/{regionId}/orders/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListOrdersInRegionAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<MarketOrder>>(responseModel);
        }

        /// <summary>
        /// Return a list of historical market statistics for the specified type in a region.
        /// <para>GET /markets/{region_id}/history/</para>
        /// </summary>
        /// <param name="regionId">Return statistics in this region.</param>
        /// <param name="typeId">Return statistics for this type.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of historical market statistics.</returns>
        public async Task<ESIModelDTO<List<MarketRegionHistory>>> ListHistoricalMarketStatisticsInRegionAsync(int regionId, int typeId, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "type_id", typeId.ToString() }
            };

            var responseModel = await GetAsync($"/markets/{regionId}/history/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListHistoricalMarketStatisticsInRegionAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<MarketRegionHistory>>(responseModel);
        }

        /// <summary>
        /// Return all orders in a structure.
        /// <para>GET /markets/structures/{structure_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="structureId">Return orders in this structure.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of orders.</returns>
        public async Task<ESIModelDTO<List<MarketOrder>>> ListOrdersInStructureAsync(AuthDTO auth, long structureId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_MARKETS_STRUCTURE_MARKETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/markets/structures/{structureId}/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListOrdersInStructureAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<MarketOrder>>(responseModel);
        }

        /// <summary>
        /// Get a list of item groups.
        /// <para>GET /markets/groups/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of item group ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetItemGroupsAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/markets/groups/", ifNoneMatch);

            CheckResponse(nameof(GetItemGroupsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on an item group.
        /// </summary>
        /// <param name="marketGroupId">An Eve item group ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about an item group.</returns>
        public async Task<ESIModelDTO<MarketGroup>> GetItemGroupInfoAsync(int marketGroupId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ?? Language.English }
            };

            var responseModel = await GetAsync($"/markets/groups/{marketGroupId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetItemGroupInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<MarketGroup>(responseModel);
        }

        /// <summary>
        /// List open market orders placed by a character.
        /// <para>GET /characters/{character_id}/orders/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing open market orders placed by a character.</returns>
        public async Task<ESIModelDTO<List<CharacterMarketOrder>>> ListOpenOrdersFromCharacterAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/orders/", auth, ifNoneMatch);

            CheckResponse(nameof(ListOpenOrdersFromCharacterAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterMarketOrder>>(responseModel);
        }

        /// <summary>
        /// List cancelled and expired market orders placed by a character up to 90 days in the past.
        /// <para>GET /characters/{character_id}/orders/history/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing expired and cancelled market orders placed by a character.</returns>
        public async Task<ESIModelDTO<List<CharacterMarketOrderHistory>>> ListHistoricalOrdersByCharacterAsync(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/orders/history/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListHistoricalOrdersByCharacterAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterMarketOrderHistory>>(responseModel);
        }

        /// <summary>
        /// Return a list of type IDs that have active orders in the region, for efficient market indexing.
        /// <para>GET /markets/{region_id}/types/</para>
        /// </summary>
        /// <param name="regionId">Return statistics in this region.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of type IDs.</returns>
        public async Task<ESIModelDTO<List<long>>> ListTypeIdsRelevantToMarketAsync(int regionId, int page = 1, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/markets/{regionId}/types/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListHistoricalOrdersByCharacterAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<long>>(responseModel);
        }

        /// <summary>
        /// List open market orders placed on behalf of a corporation.
        /// <para>GET /corporations/{corporation_id}/orders/</para>
        /// <para>Requires one of the following EVE corporation role(s): Accountant, Trader</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of open market orders.</returns>
        public async Task<ESIModelDTO<List<CorporationMarketOrder>>> ListOpenOrdersFromCorporationAsync(AuthDTO auth, int corporationId, int page  = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_MARKETS_READ_CORPORATION_ORDERS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/orders/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListOpenOrdersFromCorporationAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMarketOrder>>(responseModel);
        }

        /// <summary>
        /// List cancelled and expired market orders placed on behalf of a corporation up to 90 days in the past.
        /// <para>GET /corporations/{corporation_id}/orders/history/</para>
        /// <para>Requires one of the following EVE corporation role(s): Accountant, Trader</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing expired and cancelled market orders placed on behalf of a corporation.</returns>
        public async Task<ESIModelDTO<List<CorporationMarketOrderHistory>>> ListHistoricalOrdersByCorporationAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/orders/history/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListHistoricalOrdersByCorporationAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMarketOrderHistory>>(responseModel);
        }
    }
}
