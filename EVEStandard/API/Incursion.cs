using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    using Models;

    public class Incursion : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Incursion>();
        internal Incursion(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<Incursion>> ListIncursionsV1Async()
        {
            var responseModel = await this.GetAsync("/v1/incursions/");

            checkResponse("ListIncursionsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<Incursion>>(responseModel.JSONString);
        }
    }
}
