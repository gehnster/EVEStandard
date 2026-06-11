using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Structures API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Structures : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Structures>();

        internal Structures(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// List the Mercenary Dens owned by a character.
        /// <para>GET /characters/{character_id}/structures/mercenary-dens</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the character's Mercenary Dens.</returns>
        public async Task<ESIModelDTO<MercenaryDenListing>> ListCharacterMercenaryDensAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_STRUCTURES_READ_CHARACTER_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/structures/mercenary-dens", auth, ifNoneMatch);

            CheckResponse(nameof(ListCharacterMercenaryDensAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<MercenaryDenListing>(responseModel);
        }

        /// <summary>
        /// Get the details of a single Mercenary Den owned by a character.
        /// <para>GET /characters/{character_id}/structures/mercenary-dens/{mercenary_den_id}</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mercenaryDenId">The Mercenary Den item ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the Mercenary Den details.</returns>
        public async Task<ESIModelDTO<MercenaryDenDetail>> GetCharacterMercenaryDenAsync(AuthDTO auth, long mercenaryDenId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_STRUCTURES_READ_CHARACTER_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/structures/mercenary-dens/{mercenaryDenId}", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterMercenaryDenAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<MercenaryDenDetail>(responseModel);
        }

        /// <summary>
        /// List the Skyhooks owned by a corporation.
        /// <para>GET /corporations/{corporation_id}/structures/skyhooks</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the corporation's Skyhooks.</returns>
        public async Task<ESIModelDTO<CorporationSkyhookListing>> ListCorporationSkyhooksAsync(AuthDTO auth, long corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_STRUCTURES_READ_CORPORATION_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/structures/skyhooks", auth, ifNoneMatch);

            CheckResponse(nameof(ListCorporationSkyhooksAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CorporationSkyhookListing>(responseModel);
        }

        /// <summary>
        /// Get the details of a single Skyhook owned by a corporation.
        /// <para>GET /corporations/{corporation_id}/structures/skyhooks/{skyhook_id}</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="skyhookId">The Skyhook item ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the Skyhook details.</returns>
        public async Task<ESIModelDTO<CorporationSkyhookDetail>> GetCorporationSkyhookAsync(AuthDTO auth, long corporationId, long skyhookId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_STRUCTURES_READ_CORPORATION_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/structures/skyhooks/{skyhookId}", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationSkyhookAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CorporationSkyhookDetail>(responseModel);
        }

        /// <summary>
        /// List the Sovereignty Hubs owned by a corporation.
        /// <para>GET /corporations/{corporation_id}/structures/sovereignty-hubs</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the corporation's Sovereignty Hubs.</returns>
        public async Task<ESIModelDTO<SovereigntyHubListing>> ListCorporationSovereigntyHubsAsync(AuthDTO auth, long corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_STRUCTURES_READ_CORPORATION_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/structures/sovereignty-hubs", auth, ifNoneMatch);

            CheckResponse(nameof(ListCorporationSovereigntyHubsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<SovereigntyHubListing>(responseModel);
        }

        /// <summary>
        /// Get the details of a single Sovereignty Hub owned by a corporation.
        /// <para>GET /corporations/{corporation_id}/structures/sovereignty-hubs/{sovereignty_hub_id}</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="sovereigntyHubId">The Sovereignty Hub item ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the Sovereignty Hub details.</returns>
        public async Task<ESIModelDTO<SovereigntyHubDetail>> GetCorporationSovereigntyHubAsync(AuthDTO auth, long corporationId, long sovereigntyHubId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_STRUCTURES_READ_CORPORATION_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/structures/sovereignty-hubs/{sovereigntyHubId}", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationSovereigntyHubAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<SovereigntyHubDetail>(responseModel);
        }
    }
}
