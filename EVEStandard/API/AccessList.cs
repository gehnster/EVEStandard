using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Access List API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class AccessList : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<AccessList>();

        internal AccessList(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// List the access lists a character can manage.
        /// <para>GET /characters/{character_id}/access-lists</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the character's access lists.</returns>
        public async Task<ESIModelDTO<AccessListListing>> ListAccessListsAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_ACCESS_READ_LISTS_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/access-lists", auth, ifNoneMatch);

            CheckResponse(nameof(ListAccessListsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<AccessListListing>(responseModel);
        }

        /// <summary>
        /// Retrieve the entities on an access list: characters, corporations, alliances, and whether they are blocked or allowed.
        /// <para>GET /characters/{character_id}/access-lists/{access_list_id}</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="accessListId">The access list ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the access list details.</returns>
        public async Task<ESIModelDTO<AccessListDetail>> GetAccessListAsync(AuthDTO auth, long accessListId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_ACCESS_READ_LISTS_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/access-lists/{accessListId}", auth, ifNoneMatch);

            CheckResponse(nameof(GetAccessListAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<AccessListDetail>(responseModel);
        }
    }
}
