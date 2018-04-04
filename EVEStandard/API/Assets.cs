using EVEStandard.Models;
using EVEStandard.Models.API;
using EVEStandard.Enumerations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EVEStandard.API
{
    public class Assets : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Assets>();
        internal Assets(string dataSource) : base(dataSource)
        {
        }

        public async Task<(List<Asset>, long)> GetCharacterAssetsV3Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_ASSETS_READ_ASSETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v3/characters/" + auth.Character.CharacterID + "/assets/", auth, queryParameters);

            checkResponse("GetCharacterAssetsV3Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<Asset>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<Asset>, long)> GetCorporationAssetsV2Async(AuthDTO auth, long corporationId, long page)
        {
            checkAuth(auth, Scopes.ESI_ASSETS_READ_CORP_ASSETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v2/corporations/" + corporationId + "/assets/", auth, queryParameters);

            checkResponse("GetCorporationAssetsV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<Asset>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<AssetName>> GetCharacterAssetNamesV1Async(AuthDTO auth, List<long> itemIds)
        {
            checkAuth(auth, Scopes.ESI_ASSETS_READ_ASSETS_1);

            var responseModel = await this.PostAsync("/v1/characters/" + auth.Character.CharacterID + "/assets/names/", auth, itemIds);

            checkResponse("GetCharacterAssetNamesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<AssetName>>(responseModel.JSONString);
        }

        public async Task<List<AssetLocation>> GetCharacterAssetLocationsV2Async(AuthDTO auth, List<long> itemIds)
        {
            checkAuth(auth, Scopes.ESI_ASSETS_READ_ASSETS_1);

            var responseModel = await this.PostAsync("/v2/characters/" + auth.Character.CharacterID + "/assets/locations/", auth, itemIds);

            checkResponse("GetCharacterAssetLocationsV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<AssetLocation>>(responseModel.JSONString);
        }

        public async Task<List<AssetName>> GetCorporationAssetNamesV1Async(AuthDTO auth, List<long> itemIds, long corpId)
        {
            checkAuth(auth, Scopes.ESI_ASSETS_READ_CORP_ASSETS_1);

            var responseModel = await this.PostAsync("/v1/corporations/" + corpId + "/assets/names/", auth, itemIds);

            checkResponse("GetCorporationAssetNamesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<AssetName>>(responseModel.JSONString);
        }

        public async Task<List<AssetLocation>> GetCorporationAssetLocationsV2Async(AuthDTO auth, List<long> itemIds, long corpId)
        {
            checkAuth(auth, Scopes.ESI_ASSETS_READ_CORP_ASSETS_1);

            var responseModel = await this.PostAsync("/v2/corporations/" + corpId + "/assets/locations/", auth, itemIds);

            checkResponse("GetCorporationAssetLocationsV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<AssetLocation>>(responseModel.JSONString);
        }
    }
}
