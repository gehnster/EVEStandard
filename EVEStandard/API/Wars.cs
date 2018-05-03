using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
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

        public async Task<List<int>> ListWarsV1Async(int maxWarId)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "max_war_id", maxWarId.ToString() }
            };

            var responseModel = await GetAsync("/v1/wars/", queryParameters);

            checkResponse("ListWarsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString);
        }

        public async Task<War> GetWarInformationV1Async(int warId)
        {
            var responseModel = await GetAsync("/v1/wars/" + warId + "/");

            checkResponse("GetWarInformationV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<War>(responseModel.JSONString);
        }

        public async Task<(List<KillmailIndex>, long)> ListKillsForWarV1Async(int warId, long page=1)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/wars/" + warId + "/killmails/", queryParameters);

            checkResponse("ListKillsForWarV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<KillmailIndex>>(responseModel.JSONString), responseModel.MaxPages);
        }
    }
}
