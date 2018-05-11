using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Sovereignty : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Sovereignty>();
        internal Sovereignty(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<SovereigntyStructure>> ListSovereigntyStructuresV1Async()
        {
            var responseModel = await GetAsync("/v1/sovereignty/structures/");

            checkResponse("ListSovereigntyStructuresV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<SovereigntyStructure>>(responseModel.JSONString);
        }

        public async Task<List<SovereigntyCampaign>> ListSovereigntyCampaignsV1Async()
        {
            var responseModel = await GetAsync("/v1/sovereignty/campaigns/");

            checkResponse("ListSovereigntyCampaignsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<SovereigntyCampaign>>(responseModel.JSONString);
        }

        public async Task<List<SovereigntyMap>> ListSovereigntyOfSystemsV1Async()
        {
            var responseModel = await GetAsync("/v1/sovereignty/map/");

            checkResponse("ListSovereigntyOfSystemsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<SovereigntyMap>>(responseModel.JSONString);
        }
    }
}
