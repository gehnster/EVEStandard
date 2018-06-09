using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{

    public class Incursion : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Incursion>();

        internal Incursion(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<Models.Incursion>>> ListIncursionsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/incursions/", ifNoneMatch);

            checkResponse("ListIncursionsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Models.Incursion>>(responseModel);
        }
    }
}
