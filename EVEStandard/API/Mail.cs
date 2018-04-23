using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Mail : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Mail>();
        internal Mail(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<Mail>> ReturnMailHeadersV1Async(AuthDTO auth, List<long> labels, long lastMailId)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "labels", labels == null || labels.Count == 0 ? "" : string.Join("\n", labels) },
                { "last_mail_id", lastMailId.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/", auth, queryParameters);

            checkResponse("ReturnMailHeadersV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<Mail>>(responseModel.JSONString);
        }

        public async Task<int> SendNewMailV1Async(AuthDTO auth, NewMail mail)
        {
            checkAuth(auth, Scopes.ESI_MAIL_SEND_MAIL_1);

            var responseModel = await PostAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/", auth, mail);

            checkResponse("SendNewMailV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<int>(responseModel.JSONString);
        }

        public async Task<UnreadMail> GetMailLabelsAndUnreadCountsV3Async(AuthDTO auth, List<long> labels, long lastMailId)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync("/v3/characters/" + auth.Character.CharacterID + "/mail/labels/", auth);

            checkResponse("GetMailLabelsAndUnreadCountsV3Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<UnreadMail>(responseModel.JSONString);
        }

        public async Task<long> CreateMailLabelV2Async(AuthDTO auth, string labelName, string labelHexColor)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var body = new
            {
                name = labelName,
                color = labelHexColor
            };

            var responseModel = await PostAsync("/v2/characters/" + auth.Character.CharacterID + "/mail/labels/", auth, body);

            checkResponse("CreateMailLabelV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<long>(responseModel.JSONString);
        }

        public async Task DeleteMailLabelV1Async(AuthDTO auth, long labelId)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await DeleteAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/labels/" + labelId + "/", auth);

            checkResponse("DeleteMailLabelV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);
        }

        public async Task<List<MailList>> ReturnMailingListSubscriptionsV1Async(AuthDTO auth, List<long> labels, long lastMailId)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/lists/", auth);

            checkResponse("ReturnMailingListSubscriptionsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<MailList>>(responseModel.JSONString);
        }

        public async Task DeleteMailV1Async(AuthDTO auth, long mailId)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await DeleteAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/" + mailId + "/", auth);

            checkResponse("DeleteMailV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);
        }

        public async Task<MailContent> ReturnMailV1Async(AuthDTO auth, long mailId)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/" + mailId + "/", auth);

            checkResponse("ReturnMailV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<MailContent>(responseModel.JSONString);
        }

        public async Task UpdateMetadataAboutMailV1Async(AuthDTO auth, long mailId, UpdateMailMetadata contents)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await PutAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/" + mailId + "/", auth, contents);

            checkResponse("ReturnMailV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);
        }
    }
}
