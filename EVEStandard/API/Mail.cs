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

        internal Mail(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
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
        public async Task<ESIModelDTO<List<Models.Mail>>> ReturnMailHeadersAsync(AuthDTO auth, List<long> labels, long lastMailId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "labels", labels == null || labels.Count == 0 ? "" : string.Join("\n", labels) },
                { "last_mail_id", lastMailId.ToString() }
            };

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/mail/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ReturnMailHeadersAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Models.Mail>>(responseModel);
        }

        /// <summary>
        /// Create and send a new mail.
        /// <para>POST /characters/{character_id}/mail/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mail">The mail to send.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the id of the sent mail.</returns>
        public async Task<ESIModelDTO<long>> SendNewMailAsync(AuthDTO auth, NewMail mail)
        {
            CheckAuth(auth, Scopes.ESI_MAIL_SEND_MAIL_1);

            var responseModel = await PostAsync($"/characters/{auth.CharacterId}/mail/", auth, mail);

            CheckResponse(nameof(SendNewMailAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<long>(responseModel);
        }

        /// <summary>
        /// Return a list of the users mail labels, unread counts for each label and a total unread count.
        /// <para>GET /characters/{character_id}/mail/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of mail labels and unread counts.</returns>
        public async Task<ESIModelDTO<UnreadMail>> GetMailLabelsAndUnreadCountsAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/mail/labels/", auth, ifNoneMatch);

            CheckResponse(nameof(GetMailLabelsAndUnreadCountsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<UnreadMail>(responseModel);
        }

        /// <summary>
        /// Create a mail label.
        /// <para>POST /characters/{character_id}/mail/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="labelName">Label to create.</param>
        /// <param name="labelHexColor">Hexadecimal string representing label color, in RGB format.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing id of the created label.</returns>
        public async Task<ESIModelDTO<long>> CreateMailLabelAsync(AuthDTO auth, string labelName, string labelHexColor)
        {
            CheckAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var body = new
            {
                name = labelName,
                color = labelHexColor
            };

            var responseModel = await PostAsync($"/characters/{auth.CharacterId}/mail/labels/", auth, body);

            CheckResponse(nameof(CreateMailLabelAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<long>(responseModel);
        }

        /// <summary>
        /// Delete a mail label.
        /// <para>DELETE /characters/{character_id}/mail/labels/{label_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="labelId">An EVE label id.</param>
        /// <returns></returns>
        public async Task DeleteMailLabelAsync(AuthDTO auth, long labelId)
        {
            CheckAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await DeleteAsync($"/characters/{auth.CharacterId}/mail/labels/" + labelId + "/", auth);

            CheckResponse(nameof(DeleteMailLabelAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return all mailing lists that the character is subscribed to.
        /// <para>GET /characters/{character_id}/mail/lists/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing mailing lists.</returns>
        public async Task<ESIModelDTO<List<MailList>>> ReturnMailingListSubscriptionsAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/mail/lists/", auth, ifNoneMatch);

            CheckResponse(nameof(ReturnMailingListSubscriptionsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<MailList>>(responseModel);
        }

        /// <summary>
        /// Delete a mail.
        /// <para>DELETE /characters/{character_id}/mail/{mail_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mailId">An EVE mail ID.</param>
        /// <returns></returns>
        public async Task DeleteMailAsync(AuthDTO auth, long mailId)
        {
            CheckAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await DeleteAsync($"/characters/{auth.CharacterId}/mail/" + mailId + "/", auth);

            CheckResponse(nameof(DeleteMailAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return the contents of an EVE mail.
        /// <para>GET /characters/{character_id}/mail/{mail_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mailId">An EVE mail ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing contents of a mail.</returns>
        public async Task<ESIModelDTO<MailContent>> ReturnMailAsync(AuthDTO auth, long mailId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_MAIL_READ_MAIL_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/mail/{mailId}/", auth, ifNoneMatch);

            CheckResponse(nameof(ReturnMailAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<MailContent>(responseModel);
        }

        /// <summary>
        /// Update metadata about a mail.
        /// <para>PUT /characters/{character_id}/mail/{mail_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mailId">An EVE mail ID.</param>
        /// <param name="contents">Data used to update the mail.</param>
        /// <returns></returns>
        public async Task UpdateMetadataAboutMailAsync(AuthDTO auth, long mailId, UpdateMailMetadata contents)
        {
            CheckAuth(auth, Scopes.ESI_MAIL_ORGANIZE_MAIL_1);

            var responseModel = await PutAsync($"/characters/{auth.CharacterId}/mail/{mailId}/", auth, contents);

            CheckResponse(nameof(ReturnMailAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }
    }
}
