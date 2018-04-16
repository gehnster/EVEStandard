using EVEStandard.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
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
            var responseModel = await this.GetAsync("/v1/insurance/prices/");

            checkResponse("ListInsuranceLevelsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<InsurancePrice>>(responseModel.JSONString);
        }
    }
}
