using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Contacts : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Contacts>();
        internal Contacts(string dataSource) : base(dataSource)
        {
        }

        public async Task DeleteContactsV2Async(AuthDTO auth, List<int> contactIds)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_WRITE_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "contact_ids", contactIds == null || contactIds.Count == 0 ? "" : string.Join(",", contactIds) }
            };

            var responseModel = await DeleteAsync($"/v2/characters/{auth.Character.CharacterID}/contacts/", auth, queryParameters);

            checkResponse("DeleteContactsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);
        }

        public async Task<ESIModelDTO<List<CharacterContact>>> GetContactsV2Async(AuthDTO auth, int page)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CONTACTS_1);

            var responseModel = await GetAsync($"/v2/characters/{auth.Character.CharacterID}/contacts/", auth);

            checkResponse("GetContactsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterContact>>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> AddContactsV2Async(AuthDTO auth, List<int> contactIds, List<long> labelIds, float standing, bool isWatched=false)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_WRITE_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "label_ids", labelIds == null || labelIds.Count == 0 ? "" : string.Join(",", labelIds) },
                { "standing", standing.ToString() },
                { "watched", isWatched.ToString() }
            };

            var responseModel = await PostAsync($"/v2/characters/{auth.Character.CharacterID}/contacts/", auth, contactIds, queryParameters);

            checkResponse("AddContactsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task EditContactsV2Async(AuthDTO auth, List<int> contactIds, List<long> labelIds, float standing, bool isWatched=false)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_WRITE_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "label_ids", labelIds == null || labelIds.Count == 0 ? "" : string.Join(",", labelIds) },
                { "standing", standing.ToString() },
                { "watched", isWatched.ToString() }
            };

            var responseModel = await PutAsync($"/v2/characters/{auth.Character.CharacterID}/contacts/", auth, contactIds, queryParameters);

            checkResponse("EditContactsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);
        }

        public async Task<ESIModelDTO<List<CorporationContact>>> GetCorporationContactsV2Async(AuthDTO auth, int page, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CONTACTS_1);

            var responseModel = await GetAsync($"/v2/corporations/{corporationId}/contacts/", auth);

            checkResponse("GetCorporationContactsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationContact>>(responseModel);
        }

        public async Task<ESIModelDTO<List<AllianceContact>>> GetAllianceContactsV2Async(AuthDTO auth, int page, int allianceId)
        {
            checkAuth(auth, Scopes.ESI_ALLIANCE_READ_CONTACTS_1);

            var responseModel = await GetAsync($"/v2/alliances/{allianceId}/contacts/", auth);

            checkResponse("GetAllianceContactsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<AllianceContact>>(responseModel);
        }

        public async Task<ESIModelDTO<List<ContactLabel>>> GetContactLabelsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_CONTACTS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.Character.CharacterID}/contacts/labels/", auth);

            checkResponse("GetContactLabelsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<ContactLabel>>(responseModel);
        }

        public async Task<ESIModelDTO<List<ContactLabel>>> GetAllianceContactLabelsV1Async(AuthDTO auth, int allianceId)
        {
            checkAuth(auth, Scopes.ESI_ALLIANCE_READ_CONTACTS_1);

            var responseModel = await GetAsync($"/v1/alliances/{allianceId}/contacts/labels/", auth);

            checkResponse("GetAllianceContactLabelsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<ContactLabel>>(responseModel);
        }

        public async Task<ESIModelDTO<List<ContactLabel>>> GetCorporationContactLabelsV1Async(AuthDTO auth, int corporationId)
        {
            checkAuth(auth, Scopes.ESI_CORPORATIONS_READ_CONTACTS_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/contacts/labels/", auth);

            checkResponse("GetCorporationContactLabelsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<ContactLabel>>(responseModel);
        }
    }
}
