using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Insurance : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Insurance>();

        internal Insurance(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<InsurancePrice>>> ListInsuranceLevelsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/insurance/prices/", ifNoneMatch);

            checkResponse("ListInsuranceLevelsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<InsurancePrice>>(responseModel);
        }
    }
}
