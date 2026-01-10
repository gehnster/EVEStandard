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
    /// Freelance Jobs API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class FreelanceJobs : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<FreelanceJobs>();

        internal FreelanceJobs(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Listing of all public freelance jobs.
        /// <para>GET /freelance/jobs/</para>
        /// <para>This endpoint uses cursor-based pagination.</para>
        /// </summary>
        /// <param name="after">Cursor for pagination (next page). Use the cursor value from a previous response.</param>
        /// <param name="before">Cursor for pagination (previous page). Use the cursor value from a previous response.</param>
        /// <param name="limit">Maximum number of results to return. Default is 10.</param>
        /// <param name="corporationId">Filter on corporation ID (optional).</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of freelance jobs.</returns>
        public async Task<ESIModelDTO<FreelanceJobsListing>> GetFreelanceJobsListingAsync(string after = null, string before = null, int limit = 10, long? corporationId = null, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>();

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

            if (corporationId.HasValue)
            {
                queryParameters.Add("corporation_id", corporationId.Value.ToString());
            }

            var responseModel = await GetAsync("/freelance-jobs/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetFreelanceJobsListingAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<FreelanceJobsListing>(responseModel);
        }

        /// <summary>
        /// Get the details of a freelance job.
        /// <para>GET /freelance/jobs/{job_id}/</para>
        /// <para>Jobs without an ACL (public jobs) does not require authentication.</para>
        /// <para>Jobs with an ACL requires authentication, and requires that the character is:</para>
        /// <para>- An active participant of the job, or</para>
        /// <para>- A freelance job manager for the corporation that owns the job.</para>
        /// </summary>
        /// <param name="jobId">The ID of the freelance job.</param>
        /// <param name="auth">The <see cref="AuthDTO"/> object (optional for public jobs, required for jobs with ACL).</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing detailed information about the freelance job.</returns>
        public async Task<ESIModelDTO<FreelanceJobDetail>> GetFreelanceJobDetailAsync(string jobId, AuthDTO auth = null, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/freelance-jobs/{jobId}/", auth, ifNoneMatch);

            CheckResponse(nameof(GetFreelanceJobDetailAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<FreelanceJobDetail>(responseModel);
        }

        /// <summary>
        /// Listing of all freelance jobs a character is actively participating in.
        /// <para>GET /characters/{character_id}/freelance/jobs/</para>
        /// <para>Requires scope: esi-characters.read_freelance_jobs.v1</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of freelance job IDs the character is participating in.</returns>
        public async Task<ESIModelDTO<CharacterFreelanceJobsListing>> GetCharacterFreelanceJobsAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_FREELANCE_JOBS_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/freelance/jobs/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterFreelanceJobsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterFreelanceJobsListing>(responseModel);
        }

        /// <summary>
        /// Show your participation in a freelance job.
        /// <para>GET /characters/{character_id}/freelance/jobs/{job_id}/</para>
        /// <para>Requires scope: esi-characters.read_freelance_jobs.v1</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="jobId">The ID of the freelance job.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing character's participation information for the job.</returns>
        public async Task<ESIModelDTO<CharacterFreelanceJobParticipation>> GetCharacterFreelanceJobParticipationAsync(AuthDTO auth, string jobId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_FREELANCE_JOBS_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/freelance/jobs/{jobId}/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterFreelanceJobParticipationAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterFreelanceJobParticipation>(responseModel);
        }

        /// <summary>
        /// Listing of all freelance jobs for your corporation.
        /// <para>GET /corporations/{corporation_id}/freelance/jobs/</para>
        /// <para>This endpoint uses cursor-based pagination.</para>
        /// <para>Requires scope: esi-corporations.read_freelance_jobs.v1</para>
        /// <para>Requires role: Project_Manager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">The ID of the corporation.</param>
        /// <param name="after">Cursor for pagination (next page). Use the cursor value returned in a previous response.</param>
        /// <param name="before">Cursor for pagination (previous page). Use the cursor value returned in a previous response.</param>
        /// <param name="limit">Maximum number of results to return. Default is 10, max is 100.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation freelance jobs.</returns>
        public async Task<ESIModelDTO<CorporationFreelanceJobsListing>> GetCorporationFreelanceJobsAsync(AuthDTO auth, long corporationId, string after = null, string before = null, int limit = 10, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_FREELANCE_JOBS_1);

            var queryParameters = new Dictionary<string, string>();

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

            var responseModel = await GetAsync($"/corporations/{corporationId}/freelance-jobs/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationFreelanceJobsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CorporationFreelanceJobsListing>(responseModel);
        }

        /// <summary>
        /// Listing of all participants of a freelance job.
        /// <para>GET /corporations/{corporation_id}/freelance/jobs/{job_id}/participants/</para>
        /// <para>This endpoint uses cursor-based pagination.</para>
        /// <para>Requires scope: esi-corporations.read_freelance_jobs.v1</para>
        /// <para>Requires role: Project_Manager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">The ID of the corporation.</param>
        /// <param name="jobId">The ID of the freelance job.</param>
        /// <param name="after">Cursor for pagination (next page). Use '0' to start from the beginning.</param>
        /// <param name="before">Cursor for pagination (previous page). Use '0' to start from the end.</param>
        /// <param name="limit">Maximum number of results to return. Default is 10, max is 100.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of participants in the freelance job.</returns>
        public async Task<ESIModelDTO<CorporationFreelanceJobParticipants>> GetCorporationFreelanceJobParticipantsAsync(AuthDTO auth, long corporationId, string jobId, string after = null, string before = null, int limit = 10, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_FREELANCE_JOBS_1);

            var queryParameters = new Dictionary<string, string>();

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

            var responseModel = await GetAsync($"/corporations/{corporationId}/freelance-jobs/{jobId}/participants/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationFreelanceJobParticipantsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CorporationFreelanceJobParticipants>(responseModel);
        }
    }
}
