using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Meta : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Meta>();

        internal Meta(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Get the changelog of this API.
        /// <para>GET /meta/changelog/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the changelog.</returns>
        public async Task<ESIModelDTO<Models.Changelog>> GetChangelogAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/meta/changelog/", ifNoneMatch);

            CheckResponse(nameof(GetChangelogAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Models.Changelog>(responseModel);
        }

        /// <summary>
        /// Get a list of compatibility dates.
        /// <para>GET /meta/compatibility-dates/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the compatibility dates.</returns>
        public async Task<ESIModelDTO<Models.CompatibilityDates>> GetCompatabilityDatesAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/meta/compatibility-dates/", ifNoneMatch);

            CheckResponse(nameof(GetCompatabilityDatesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Models.CompatibilityDates>(responseModel);
        }
    }
}
