using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Industry API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Industry : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Industry>();

        internal Industry(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Return a list of industry facilities.
        /// <para>GET /industry/facilities/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of facilities.</returns>
        public async Task<ESIModelDTO<List<IndustryFacility>>> ListIndustryFacilitiesAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/industry/facilities/", ifNoneMatch);

            CheckResponse(nameof(ListIndustryFacilitiesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<IndustryFacility>>(responseModel);
        }

        /// <summary>
        /// Return cost indices for solar systems.
        /// <para>GET /industry/systems/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of cost indicies.</returns>
        public async Task<ESIModelDTO<List<IndustrySystem>>> ListSolarSystemCostIndiciesAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/industry/systems/", ifNoneMatch);

            CheckResponse(nameof(ListSolarSystemCostIndiciesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<IndustrySystem>>(responseModel);
        }

        /// <summary>
        /// List industry jobs placed by a character.
        /// <para>GET /characters/{character_id}/industry/jobs/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="includeCompleted">Whether retrieve completed character industry jobs as well.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing industry jobs placed by a character.</returns>
        public async Task<ESIModelDTO<List<IndustryJob>>> ListCharacterIndustryJobsAsync(AuthDTO auth, bool includeCompleted, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_INDUSTRY_READ_CHARACTER_JOBS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/industry/jobs/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListCharacterIndustryJobsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<IndustryJob>>(responseModel);
        }

        /// <summary>
        /// Paginated record of all mining done by a character for the past 30 days.
        /// <para>GET /characters/{character_id}/mining/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing mining ledger of a character.</returns>
        public async Task<ESIModelDTO<List<CharacterMining>>> CharacterMiningLedgerAsync(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_INDUSTRY_READ_CHARACTER_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/mining/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(CharacterMiningLedgerAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterMining>>(responseModel);
        }

        /// <summary>
        /// Paginated list of all entities capable of observing and recording mining for a corporation.
        /// <para>GET /corporation/{corporation_id}/mining/observers/</para>
        /// <para>Requires one of the following EVE corporation role(s): Accountant</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing observer list of a corporation.</returns>
        public async Task<ESIModelDTO<List<CorporationMiningObserver>>> CorporationMiningObserversAsync(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporation/{corporationId}/mining/observers/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(CorporationMiningObserversAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMiningObserver>>(responseModel);
        }

        /// <summary>
        /// Paginated record of all mining seen by an observer.
        /// <para>GET /corporation/{corporation_id}/mining/observers/{observer_id}/</para>
        /// <para>Requires one of the following EVE corporation role(s): Accountant</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="observerId">A mining observer id.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing mining ledger of an observer.</returns>
        public async Task<ESIModelDTO<List<CorporationObservedMining>>> ObservedCorporationMiningAsync(AuthDTO auth, int corporationId, long observerId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporation/{corporationId}/mining/observers/{observerId}/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ObservedCorporationMiningAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationObservedMining>>(responseModel);
        }

        /// <summary>
        /// List industry jobs run by a corporation.
        /// <para>GET /corporations/{corporation_id}/industry/jobs/</para>
        /// <para>Requires one of the following EVE corporation role(s): FactoryManager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="includeCompleted">Whether retrieve completed industry jobs as well. Default value: false.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation industry jobs.</returns>
        public async Task<ESIModelDTO<List<IndustryJob>>> ListCorporationIndustryJobsAsync(AuthDTO auth, int corporationId, int page = 1, bool includeCompleted = false, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_JOBS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "include_completed", includeCompleted.ToString() }
            };

            var responseModel = await GetAsync($"/corporation/{corporationId}/industry/jobs/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListCorporationIndustryJobsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<IndustryJob>>(responseModel);
        }

        /// <summary>
        /// Extraction timers for all moon chunks being extracted by refineries belonging to a corporation.
        /// <para>GET /corporation/{corporation_id}/mining/extractions/</para>
        /// <para>Requires one of the following EVE corporation role(s): Structure_manager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of chunk timers.</returns>
        public async Task<ESIModelDTO<List<MiningExtraction>>> MoonExtractionTimersAsync(AuthDTO auth, int corporationId, int page = 1, bool includeCompleted = false, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_INDUSTRY_READ_CORPORATION_MINING_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporation/{corporationId}/mining/extractions/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(MoonExtractionTimersAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<MiningExtraction>>(responseModel);
        }
    }
}
