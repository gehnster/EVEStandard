using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Wars : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Wars>();
        internal Wars(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<int>>> ListWarsV1Async(int maxWarId)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "max_war_id", maxWarId.ToString() }
            };

            var responseModel = await GetAsync("/v1/wars/", queryParameters);

            checkResponse("ListWarsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<War>> GetWarInformationV1Async(int warId)
        {
            var responseModel = await GetAsync("/v1/wars/" + warId + "/");

            checkResponse("GetWarInformationV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<War>(responseModel);
        }

        public async Task<ESIModelDTO<List<KillmailIndex>>> ListKillsForWarV1Async(int warId, int page=1)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/wars/" + warId + "/killmails/", queryParameters);

            checkResponse("ListKillsForWarV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<KillmailIndex>>(responseModel);
        }
    }
}
