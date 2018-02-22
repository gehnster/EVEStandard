using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Status : APIBase
    {
        internal Status(string dataSource) : base(dataSource)
        {
        }

        public async Task<Models.Status> GetStatusV1Async()
        {
            var responseModel = await this.GetAsync("/v1/status/");

            if (responseModel.Error)
            {
                throw new EVEStandardException("GetStatusV1Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }

            return JsonConvert.DeserializeObject<Models.Status>(responseModel.JSONString);
        }
    }
}
