using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Mail : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Mail>();

        internal Mail(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<Mail>>> ReturnMailHeadersV1Async(AuthDTO auth, List<long> labels, long lastMailId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "labels", labels == null || labels.Count == 0 ? "" : string.Join("\n", labels) },
                { "last_mail_id", lastMailId.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/", auth, ifNoneMatch, queryParameters);

            checkResponse("ReturnMailHeadersV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<Mail>>(responseModel);
        }

        public async Task<ESIModelDTO<int>> SendNewMailV1Async(AuthDTO auth, NewMail mail)
        {
            checkAuth(auth, Scopes.ESI_MAIL_SEND_MAIL_1);

            var responseModel = await PostAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/", auth, mail);

            checkResponse("SendNewMailV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<int>(responseModel);
        }

        public async Task<ESIModelDTO<UnreadMail>> GetMailLabelsAndUnreadCountsV3Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync("/v3/characters/" + auth.Character.CharacterID + "/mail/labels/", auth, ifNoneMatch);

            checkResponse("GetMailLabelsAndUnreadCountsV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<UnreadMail>(responseModel);
        }

        public async Task<ESIModelDTO<long>> CreateMailLabelV2Async(AuthDTO auth, string labelName, string labelHexColor)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var body = new
            {
                name = labelName,
                color = labelHexColor
            };

            var responseModel = await PostAsync("/v2/characters/" + auth.Character.CharacterID + "/mail/labels/", auth, body);

            checkResponse("CreateMailLabelV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<long>(responseModel);
        }

        public async Task DeleteMailLabelV1Async(AuthDTO auth, long labelId)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await DeleteAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/labels/" + labelId + "/", auth);

            checkResponse("DeleteMailLabelV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        public async Task<ESIModelDTO<List<MailList>>> ReturnMailingListSubscriptionsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/lists/", auth, ifNoneMatch);

            checkResponse("ReturnMailingListSubscriptionsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<MailList>>(responseModel);
        }

        public async Task DeleteMailV1Async(AuthDTO auth, long mailId)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await DeleteAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/" + mailId + "/", auth);

            checkResponse("DeleteMailV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        public async Task<ESIModelDTO<MailContent>> ReturnMailV1Async(AuthDTO auth, long mailId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/" + mailId + "/", auth, ifNoneMatch);

            checkResponse("ReturnMailV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<MailContent>(responseModel);
        }

        public async Task UpdateMetadataAboutMailV1Async(AuthDTO auth, long mailId, UpdateMailMetadata contents)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await PutAsync("/v1/characters/" + auth.Character.CharacterID + "/mail/" + mailId + "/", auth, contents);

            checkResponse("ReturnMailV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }
    }
}
