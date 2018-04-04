using EVEStandard.Enumerations;
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
    public class Bookmarks : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Bookmarks>();
        internal Bookmarks(string dataSource) : base(dataSource)
        {
        }

        public async Task<(List<Bookmark>, long)> ListBookmarksV2Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_BOOKMARKS_READ_CHARACTER_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v2/characters/" + auth.Character.CharacterID + "/bookmarks/", auth, queryParameters);

            checkResponse("ListBookmarksV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<Bookmark>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<BookmarkFolder>, long)> ListBookmarkFoldersV2Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_BOOKMARKS_READ_CHARACTER_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v2/characters/" + auth.Character.CharacterID + "/bookmarks/folders/", auth, queryParameters);

            checkResponse("ListBookmarkFoldersV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<BookmarkFolder>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<Bookmark>, long)> ListCorporationBookmarksV1Async(AuthDTO auth, long corporationId, long page)
        {
            checkAuth(auth, Scopes.ESI_BOOKMARKS_READ_CORPORATION_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v1/corporation/" + corporationId + "/bookmarks/", auth, queryParameters);

            checkResponse("ListCorporationBookmarksV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<Bookmark>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<BookmarkFolder>, long)> ListCorporationBookmarkFoldersV1Async(AuthDTO auth, long corporationId, long page)
        {
            checkAuth(auth, Scopes.ESI_BOOKMARKS_READ_CORPORATION_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v1/corporation/" + corporationId + "/bookmarks/folders/", auth, queryParameters);

            checkResponse("ListCorporationBookmarkFoldersV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<BookmarkFolder>>(responseModel.JSONString), responseModel.MaxPages);
        }
    }
}
