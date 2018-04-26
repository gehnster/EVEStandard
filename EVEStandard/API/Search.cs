using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace EVEStandard.API
{
    public class Search : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Search>();
        internal Search(string dataSource) : base(dataSource)
        {
        }

        public async Task<Search> SearchCharacterV3Async(AuthDTO auth, List<string> categories, string search, bool strict=false, string language=Language.English)
        {
            checkAuth(auth, Scopes.ESI_SEARCH_SEARCH_STRUCTURES_1);

            if (categories == null || categories.Count == 0 || search == null)
            {
                throw new ArgumentNullException();
            }

            var queryParameters = new Dictionary<string, string>
            {
                { "categories", string.Join(",", categories) },
                { "language", language },
                { "search", search },
                { "strict", strict.ToString() }
            };

            var responseModel = await GetAsync("/v3/characters/" + auth.Character.CharacterID + "/search/", auth, queryParameters);

            checkResponse("SearchCharacterV3Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Search>(responseModel.JSONString);
        }

        public async Task<Search> SearchV2Async(List<string> categories, string search, bool strict = false, string language = Language.English)
        {
            if (categories == null || categories.Count == 0 || search == null)
            {
                throw new ArgumentNullException();
            }

            var queryParameters = new Dictionary<string, string>
            {
                { "categories", string.Join(",", categories) },
                { "language", language },
                { "search", search },
                { "strict", strict.ToString() }
            };

            var responseModel = await GetAsync("/v2/search/", queryParameters);

            checkResponse("SearchV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Search>(responseModel.JSONString);
        }
    }
}
