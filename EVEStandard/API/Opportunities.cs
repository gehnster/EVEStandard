using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Opportunities : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Opportunities>();
        internal Opportunities(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<int>> GetOpportunitiesGroupsV1Async()
        {
            var responseModel = await GetAsync("/v1/opportunities/groups/");

            checkResponse("GetOpportunitiesGroupsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString);
        }

        public async Task<(OpportunitiesGroup, string)> GetOpportunitiesGroupV1Async(int groupId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ??Language.English }
            };

            var responseModel = await GetAsync("/v1/opportunities/groups/" + groupId + "/", null, queryParameters);

            checkResponse("GetOpportunitiesGroupV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<OpportunitiesGroup>(responseModel.JSONString), responseModel.Language);
        }

        public async Task<List<int>> GetOpportunitiesTasksV1Async()
        {
            var responseModel = await GetAsync("/v1/opportunities/tasks/");

            checkResponse("GetOpportunitiesTasksV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString);
        }

        public async Task<OpportunitiesTask> GetOpportunitiesTaskV1Async(int taskId)
        {
            var responseModel = await GetAsync("/v1/opportunities/tasks/" + taskId + "/");

            checkResponse("GetOpportunitiesTaskV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<OpportunitiesTask>(responseModel.JSONString);
        }

        public async Task<List<CharacterTask>> GetCharacterCompletedTaskV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_OPPORTUNITIES_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/opportunities/");

            checkResponse("GetCharacterCompletedTaskV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<CharacterTask>>(responseModel.JSONString);
        }
    }
}
