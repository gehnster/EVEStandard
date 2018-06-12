using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Mail API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Mail : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Mail>();

        internal Mail(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Return the 50 most recent mail headers belonging to the character that match the query criteria. 
        /// Queries can be filtered by label, and last_mail_id can be used to paginate backwards.
        /// <para>GET /characters/{character_id}/mail/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="labels">Fetch only mails that match one or more of the given labels.</param>
        /// <param name="lastMailId">List only mail with an ID lower than the given ID, if present.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the requested mail.</returns>
        public async Task<ESIModelDTO<List<Mail>>> ReturnMailHeadersV1Async(AuthDTO auth, List<long> labels, long lastMailId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "labels", labels == null || labels.Count == 0 ? "" : string.Join("\n", labels) },
                { "last_mail_id", lastMailId.ToString() }
            };

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/mail/", auth, ifNoneMatch, queryParameters);

            checkResponse(nameof(ReturnMailHeadersV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<Mail>>(responseModel);
        }

        /// <summary>
        /// Create and send a new mail.
        /// <para>POST /characters/{character_id}/mail/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mail">The mail to send.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the id of the sent mail.</returns>
        public async Task<ESIModelDTO<int>> SendNewMailV1Async(AuthDTO auth, NewMail mail)
        {
            checkAuth(auth, Scopes.ESI_MAIL_SEND_MAIL_1);

            var responseModel = await PostAsync($"/v1/characters/{auth.CharacterId}/mail/", auth, mail);

            checkResponse(nameof(SendNewMailV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<int>(responseModel);
        }

        /// <summary>
        /// Return a list of the users mail labels, unread counts for each label and a total unread count.
        /// <para>GET /characters/{character_id}/mail/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of mail labels and unread counts.</returns>
        public async Task<ESIModelDTO<UnreadMail>> GetMailLabelsAndUnreadCountsV3Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync($"/v3/characters/{auth.CharacterId}/mail/labels/", auth, ifNoneMatch);

            checkResponse(nameof(GetMailLabelsAndUnreadCountsV3Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<UnreadMail>(responseModel);
        }

        /// <summary>
        /// Create a mail label.
        /// <para>POST /characters/{character_id}/mail/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="labelName">Label to create.</param>
        /// <param name="labelHexColor">Hexadecimal string representing label color, in RGB format.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing id of the created label.</returns>
        public async Task<ESIModelDTO<long>> CreateMailLabelV2Async(AuthDTO auth, string labelName, string labelHexColor)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var body = new
            {
                name = labelName,
                color = labelHexColor
            };

            var responseModel = await PostAsync($"/v2/characters/{auth.CharacterId}/mail/labels/", auth, body);

            checkResponse(nameof(CreateMailLabelV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<long>(responseModel);
        }

        /// <summary>
        /// Delete a mail label.
        /// <para>DELETE /characters/{character_id}/mail/labels/{label_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="labelId">An EVE label id.</param>
        /// <returns></returns>
        public async Task DeleteMailLabelV1Async(AuthDTO auth, long labelId)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await DeleteAsync($"/v1/characters/{auth.CharacterId}/mail/labels/" + labelId + "/", auth);

            checkResponse(nameof(DeleteMailLabelV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return all mailing lists that the character is subscribed to.
        /// <para>GET /characters/{character_id}/mail/lists/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing mailing lists.</returns>
        public async Task<ESIModelDTO<List<MailList>>> ReturnMailingListSubscriptionsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/mail/lists/", auth, ifNoneMatch);

            checkResponse(nameof(ReturnMailingListSubscriptionsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<MailList>>(responseModel);
        }

        /// <summary>
        /// Delete a mail.
        /// <para>DELETE /characters/{character_id}/mail/{mail_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mailId">An EVE mail ID.</param>
        /// <returns></returns>
        public async Task DeleteMailV1Async(AuthDTO auth, long mailId)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await DeleteAsync($"/v1/characters/{auth.CharacterId}/mail/" + mailId + "/", auth);

            checkResponse(nameof(DeleteMailV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return the contents of an EVE mail.
        /// <para>GET /characters/{character_id}/mail/{mail_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mailId">An EVE mail ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing contents of a mail.</returns>
        public async Task<ESIModelDTO<MailContent>> ReturnMailV1Async(AuthDTO auth, long mailId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/mail/{mailId}/", auth, ifNoneMatch);

            checkResponse(nameof(ReturnMailV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<MailContent>(responseModel);
        }

        /// <summary>
        /// Update metadata about a mail.
        /// <para>PUT /characters/{character_id}/mail/{mail_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mailId">An EVE mail ID.</param>
        /// <param name="contents">Data used to update the mail.</param>
        /// <returns></returns>
        public async Task UpdateMetadataAboutMailV1Async(AuthDTO auth, long mailId, UpdateMailMetadata contents)
        {
            checkAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await PutAsync($"/v1/characters/{auth.CharacterId}/mail/{mailId}/", auth, contents);

            checkResponse(nameof(ReturnMailV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }
    }
}
