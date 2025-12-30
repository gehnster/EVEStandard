using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Corporation Projects API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class CorporationProjects : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<CorporationProjects>();

        internal CorporationProjects(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Returns a list of corporation projects.
        /// <para>GET /corporations/{corporation_id}/projects/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// <para>This endpoint uses cursor-based pagination.</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="state">Current state of the projects you return. Defaults to Active with valid options of Active and All</param>
        /// <param name="after">Cursor for pagination (next page). Use the cursor value from a previous response.</param>
        /// <param name="before">Cursor for pagination (previous page). Use the cursor value from a previous response.</param>
        /// <param name="limit">Maximum number of results to return. Default is 100.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation projects.</returns>
        public async Task<ESIModelDTO<List<CorporationProject>>> GetCorporationProjectsAsync(AuthDTO auth, long corporationId, string state = null, string after = null, string before = null, int limit = 10, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_PROJECTS_1);

            var queryParameters = new Dictionary<string, string>();

            if(!string.IsNullOrEmpty(state))
            {
                if(state != "Active" && state != "All")
                {
                    throw new ArgumentException("State must be one of the following values if used (defaults to Active): Active, All", nameof(state));
                }
                queryParameters.Add("state", state);
            }

            if (!string.IsNullOrEmpty(before))
            {
                queryParameters.Add("before", before);
            }

            if (!string.IsNullOrEmpty(after))
            {
                queryParameters.Add("after", after);
            }

            if (limit > 0)
            {
                queryParameters.Add("limit", limit.ToString());
            }

            var responseModel = await GetAsync($"/corporations/{corporationId}/projects/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationProjectsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationProject>>(responseModel);
        }

        /// <summary>
        /// Returns detailed information about a specific corporation project.
        /// <para>GET /corporations/{corporation_id}/projects/{project_id}/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="projectId">A corporation project ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing detailed information about a corporation project.</returns>
        public async Task<ESIModelDTO<CorporationProjectDetail>> GetCorporationProjectsDetailAsync(AuthDTO auth, long corporationId, string projectId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_PROJECTS_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/projects/{projectId}/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationProjectsDetailAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CorporationProjectDetail>(responseModel);
        }

        /// <summary>
        /// Show your contribution to a corporation project.
        /// <para>GET /corporations/{corporation_id}/projects/{project_id}/contribution/{character_id}/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="projectId">A corporation project ID.</param>
        /// <param name="characterId">A character ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the character's contribution to the project.</returns>
        public async Task<ESIModelDTO<CorporationProjectContribution>> GetCorporationProjectContributionAsync(AuthDTO auth, long corporationId, string projectId, long characterId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_PROJECTS_1);

            var responseModel = await GetAsync($"/corporations/{corporationId}/projects/{projectId}/contribution/{characterId}/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationProjectContributionAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CorporationProjectContribution>(responseModel);
        }
    }
}
