using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Status : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Status>();

        internal Status(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<Models.Status>> GetStatusV1Async(string ifNoneMatch=null)
        {
            var responseModel = await GetAsync("/v1/status/", ifNoneMatch);

            checkResponse("GetStatusV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<Models.Status>(responseModel);
        }
    }
}
