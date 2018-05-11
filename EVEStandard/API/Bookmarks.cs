using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Bookmarks : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Bookmarks>();
        internal Bookmarks(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<Bookmark>>> ListBookmarksV2Async(AuthDTO auth, int page)
        {
            checkAuth(auth, Scopes.ESI_BOOKMARKS_READ_CHARACTER_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/bookmarks/", auth, queryParameters);

            checkResponse("ListBookmarksV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Bookmark>>(responseModel);
        }

        public async Task<ESIModelDTO<List<BookmarkFolder>>> ListBookmarkFoldersV2Async(AuthDTO auth, int page)
        {
            checkAuth(auth, Scopes.ESI_BOOKMARKS_READ_CHARACTER_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/bookmarks/folders/", auth, queryParameters);

            checkResponse("ListBookmarkFoldersV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<BookmarkFolder>>(responseModel);
        }

        public async Task<ESIModelDTO<List<Bookmark>>> ListCorporationBookmarksV1Async(AuthDTO auth, int corporationId, int page)
        {
            checkAuth(auth, Scopes.ESI_BOOKMARKS_READ_CORPORATION_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/bookmarks/", auth, queryParameters);

            checkResponse("ListCorporationBookmarksV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Bookmark>>(responseModel);
        }

        public async Task<ESIModelDTO<List<BookmarkFolder>>> ListCorporationBookmarkFoldersV1Async(AuthDTO auth, int corporationId, int page)
        {
            checkAuth(auth, Scopes.ESI_BOOKMARKS_READ_CORPORATION_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporation/" + corporationId + "/bookmarks/folders/", auth, queryParameters);

            checkResponse("ListCorporationBookmarkFoldersV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<BookmarkFolder>>(responseModel);
        }
    }
}
