using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Activities API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Activities : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Activities>();

        internal Activities(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Rolling list of Skyhooks that are vulnerable or currently raidable.
        /// <para>GET /skyhooks/raidable</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the raidable Skyhooks.</returns>
        public async Task<ESIModelDTO<RaidableSkyhooks>> ListRaidableSkyhooksAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/skyhooks/raidable", ifNoneMatch);

            CheckResponse(nameof(ListRaidableSkyhooksAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<RaidableSkyhooks>(responseModel);
        }

        /// <summary>
        /// List the Mercenary Tactical Operations available to a character.
        /// <para>GET /characters/{character_id}/mercenary-tactical-operations</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the character's Mercenary Tactical Operations.</returns>
        public async Task<ESIModelDTO<MercenaryTacticalOperationListing>> ListMercenaryTacticalOperationsAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_ACTIVITIES_READ_CHARACTER_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/mercenary-tactical-operations", auth, ifNoneMatch);

            CheckResponse(nameof(ListMercenaryTacticalOperationsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<MercenaryTacticalOperationListing>(responseModel);
        }

        /// <summary>
        /// Get the details of a single Mercenary Tactical Operation.
        /// <para>GET /characters/{character_id}/mercenary-tactical-operations/{operation_id}</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="operationId">The Mercenary Tactical Operation ID (UUID).</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the Mercenary Tactical Operation details.</returns>
        public async Task<ESIModelDTO<MercenaryTacticalOperationDetail>> GetMercenaryTacticalOperationAsync(AuthDTO auth, string operationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_ACTIVITIES_READ_CHARACTER_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/mercenary-tactical-operations/{operationId}", auth, ifNoneMatch);

            CheckResponse(nameof(GetMercenaryTacticalOperationAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<MercenaryTacticalOperationDetail>(responseModel);
        }
    }
}
