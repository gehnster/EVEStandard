using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Opportunities : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Opportunities>();

        internal Opportunities(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<int>>> GetOpportunitiesGroupsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/opportunities/groups/", ifNoneMatch);

            checkResponse("GetOpportunitiesGroupsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<OpportunitiesGroup>> GetOpportunitiesGroupV1Async(int groupId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ??Language.English }
            };

            var responseModel = await GetAsync("/v1/opportunities/groups/" + groupId + "/", ifNoneMatch, queryParameters);

            checkResponse("GetOpportunitiesGroupV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<OpportunitiesGroup>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> GetOpportunitiesTasksV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/opportunities/tasks/", ifNoneMatch);

            checkResponse("GetOpportunitiesTasksV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<OpportunitiesTask>> GetOpportunitiesTaskV1Async(int taskId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/opportunities/tasks/" + taskId + "/", ifNoneMatch);

            checkResponse("GetOpportunitiesTaskV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<OpportunitiesTask>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterTask>>> GetCharacterCompletedTaskV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CHARACTERS_READ_OPPORTUNITIES_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/opportunities/", ifNoneMatch);

            checkResponse("GetCharacterCompletedTaskV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CharacterTask>>(responseModel);
        }
    }
}
