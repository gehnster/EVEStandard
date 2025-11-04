using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Status API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Status : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Status>();

        internal Status(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// EVE Server status.
        /// <para>GET /status/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing server status.</returns>
        public async Task<ESIModelDTO<Models.Status>> GetStatusAsync(string ifNoneMatch=null)
        {
            var responseModel = await GetAsync("/status/", ifNoneMatch);

            CheckResponse(nameof(GetStatusAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Models.Status>(responseModel);
        }
    }
}
