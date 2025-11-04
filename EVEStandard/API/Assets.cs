using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Assets API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Assets : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Assets>();

        internal Assets(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Return a list of the characters assets.
        /// <para>GET /characters/{character_id}/assets/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a flat list of the user's assets.</returns>
        public async Task<ESIModelDTO<List<Asset>>> GetCharacterAssetsAsync(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_ASSETS_READ_ASSETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/assets/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCharacterAssetsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Asset>>(responseModel);
        }

        /// <summary>
        /// Return a list of the corporation assets.
        /// <para>GET /corporations/{corporation_id}/assets/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of assets.</returns>
        public async Task<ESIModelDTO<List<Asset>>> GetCorporationAssetsAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_ASSETS_READ_CORP_ASSETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corporationId}/assets/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationAssetsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Asset>>(responseModel);
        }

        /// <summary>
        /// Return names for a set of item ids, which you can get from character assets endpoint. 
        /// Typically used for items that can customize names, like containers or ships.
        /// <para>POST /characters/{character_id}/assets/names/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="itemIds">A list of item ids.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of asset names.</returns>
        public async Task<ESIModelDTO<List<AssetName>>> GetCharacterAssetNamesAsync(AuthDTO auth, List<long> itemIds)
        {
            CheckAuth(auth, Scopes.ESI_ASSETS_READ_ASSETS_1);

            var responseModel = await PostAsync($"/characters/{auth.CharacterId}/assets/names/", auth, itemIds);

            CheckResponse(nameof(GetCharacterAssetNamesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<AssetName>>(responseModel);
        }

        /// <summary>
        /// Return locations for a set of item ids, which you can get from character assets endpoint. 
        /// Coordinates for items in hangars or stations are set to (0,0,0).
        /// <para>POST /characters/{character_id}/assets/locations/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="itemIds">A list of item ids.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of asset locations.</returns>
        public async Task<ESIModelDTO<List<AssetLocation>>> GetCharacterAssetLocationsAsync(AuthDTO auth, List<long> itemIds)
        {
            CheckAuth(auth, Scopes.ESI_ASSETS_READ_ASSETS_1);

            var responseModel = await PostAsync($"/characters/{auth.CharacterId}/assets/locations/", auth, itemIds);

            CheckResponse(nameof(GetCharacterAssetLocationsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<AssetLocation>>(responseModel);
        }

        /// <summary>
        /// Return names for a set of item ids, which you can get from corporation assets endpoint. 
        /// Only valid for items that can customize names, like containers or ships.
        /// <para>POST /corporations/{corporation_id}/assets/names</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="itemIds">A list of item ids.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of asset names.</returns>
        public async Task<ESIModelDTO<List<AssetName>>> GetCorporationAssetNamesAsync(AuthDTO auth, int corpId, List<long> itemIds)
        {
            CheckAuth(auth, Scopes.ESI_ASSETS_READ_CORP_ASSETS_1);

            var responseModel = await PostAsync($"/corporations/{corpId}/assets/names/", auth, itemIds);

            CheckResponse(nameof(GetCorporationAssetNamesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<AssetName>>(responseModel);
        }

        /// <summary>
        /// Return locations for a set of item ids, which you can get from corporation assets endpoint. 
        /// Coordinates for items in hangars or stations are set to (0,0,0).
        /// <para>POST /corporations/{corporation_id}/assets/locations</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="itemIds">A list of item ids.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of asset locations.</returns>
        public async Task<ESIModelDTO<List<AssetLocation>>> GetCorporationAssetLocationsAsync(AuthDTO auth, int corpId, List<long> itemIds)
        {
            CheckAuth(auth, Scopes.ESI_ASSETS_READ_CORP_ASSETS_1);

            var responseModel = await PostAsync($"/corporations/{corpId}/assets/locations/", auth, itemIds);

            CheckResponse(nameof(GetCorporationAssetLocationsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<AssetLocation>>(responseModel);
        }
    }
}
