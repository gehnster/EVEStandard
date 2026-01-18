using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Clones API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Clones : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Clones>();

        internal Clones(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// A list of the character’s clones.
        /// <para>GET /characters/{character_id}/clones/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing clone information for the given character.</returns>
        public async Task<ESIModelDTO<Clones>> GetClonesAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CLONES_READ_CLONES_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/clones/", auth, ifNoneMatch);

            CheckResponse(nameof(GetClonesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Clones>(responseModel);
        }

        /// <summary>
        /// Return implants on the active clone of a character.
        /// <para>GET /characters/{character_id}/implants/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of implant type ids.</returns>
        public async Task<ESIModelDTO<List<long>>> GetActiveImplantsAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CLONES_READ_IMPLANTS_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/implants/", auth, ifNoneMatch);

            CheckResponse(nameof(GetActiveImplantsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<long>>(responseModel);
        }
    }
}
