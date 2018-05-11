using System.Threading.Tasks;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Status : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Status>();
        internal Status(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<Models.Status>> GetStatusV1Async()
        {
            var responseModel = await GetAsync("/v1/status/");

            checkResponse("GetStatusV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Models.Status>(responseModel);
        }
    }
}
