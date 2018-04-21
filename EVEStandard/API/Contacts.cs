using System.Threading.Tasks;
using System.Collections.Generic;
using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using EVEStandard.Models;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Contacts : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Contacts>();
        internal Contacts(string dataSource) : base(dataSource)
        {
        }

        public async Task DeleteContactsV2Async(AuthDTO auth, List<long> contactIds)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_WRITE_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "contact_ids", contactIds == null || contactIds.Count == 0 ? "" : string.Join(",", contactIds) }
            };

            var responseModel = await DeleteAsync("/v2/characters/" + auth.Character.CharacterID + "/contacts/", auth, queryParameters);

            checkResponse("DeleteContactsV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);
        }

        public async Task<(List<Contact>, long)> GetContactsV1Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CONTACTS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/contacts/", auth);

            checkResponse("GetContactsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<Contact>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<long>> AddContactsV1Async(AuthDTO auth, List<long> contactIds, long labelId, float standing, bool isWatched)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_WRITE_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "label_id", labelId.ToString() },
                { "standing", standing.ToString() },
                { "watched", isWatched.ToString() }
            };

            var responseModel = await PostAsync("/v1/characters/" + auth.Character.CharacterID + "/contacts/", auth, contactIds, queryParameters);

            checkResponse("AddContactsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString);
        }

        public async Task EditContactsV1Async(AuthDTO auth, List<long> contactIds, long labelId, float standing, bool isWatched)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_WRITE_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "label_id", labelId.ToString() },
                { "standing", standing.ToString() },
                { "watched", isWatched.ToString() }
            };

            var responseModel = await PutAsync("/v1/characters/" + auth.Character.CharacterID + "/contacts/", auth, contactIds, queryParameters);

            checkResponse("EditContactsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);
        }

        public async Task<(List<Contact>, long)> GetCorporationContactsV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CONTACTS_1);

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/contacts/", auth);

            checkResponse("GetCorporationContactsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<Contact>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<(List<Contact>, long)> GetAllianceContactsV1Async(AuthDTO auth, long page, long allianceId)
        {
            checkAuth(auth, Scopes.ESI_ALLIANCE_READ_CONTACTS_1);

            var responseModel = await GetAsync("/v1/alliances/" + allianceId + "/contacts/", auth);

            checkResponse("GetAllianceContactsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<Contact>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<ContactLabel>> GetContactLabelsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CONTACTS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/contacts/", auth);

            checkResponse("GetContactLabelsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<ContactLabel>>(responseModel.JSONString);
        }
    }
}
