using EVEStandard.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Insurance : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Insurance>();
        internal Insurance(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<InsurancePrice>> ListInsuranceLevelsV1Async()
        {
            var responseModel = await GetAsync("/v1/insurance/prices/");

            checkResponse("ListInsuranceLevelsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<InsurancePrice>>(responseModel.JSONString);
        }
    }
}
