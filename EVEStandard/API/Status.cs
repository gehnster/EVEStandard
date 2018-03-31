using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
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
            var responseModel = await this.GetAsync("/v1/status/");

            this.checkResponse("GetStatusV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<Models.Status>(responseModel.JSONString);
        }
    }
}
