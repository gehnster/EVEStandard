using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Status : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Status>();
        internal Status(string dataSource) : base(dataSource)
        {
        }

        public async Task<Models.Status> GetStatusV1Async()
        {
            var responseModel = await GetAsync("/v1/status/");

            checkResponse("GetStatusV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Models.Status>(responseModel.JSONString);
        }
    }
}
