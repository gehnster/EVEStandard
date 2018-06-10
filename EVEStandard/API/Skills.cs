using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Skills : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Skills>();

        internal Skills(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<CharacterSkills>> GetCharacterSkillsV4Async(AuthDTO auth, string ifNoneMatch=null)
        {
            checkAuth(auth, Scopes.ESI_SKILLS_READ_SKILLS_1);

            var responseModel = await GetAsync($"/v4/characters/{auth.CharacterId}/skills/", auth, ifNoneMatch);

            checkResponse("GetCharacterSkillsV4Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<CharacterSkills>(responseModel);
        }

        public async Task<ESIModelDTO<CharacterAttributes>> GetCharacterAttributesV1Async(AuthDTO auth, string ifNoneMatch=null)
        {
            checkAuth(auth, Scopes.ESI_SKILLS_READ_SKILLS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/attributes/", auth, ifNoneMatch);

            checkResponse("GetCharacterAttributesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<CharacterAttributes>(responseModel);
        }

        public async Task<ESIModelDTO<List<SkillQueue>>> GetCharacterSkillQueueV2Async(AuthDTO auth, string ifNoneMatch=null)
        {
            checkAuth(auth, Scopes.ESI_SKILLS_READ_SKILLQUEUE_1);

            var responseModel = await GetAsync($"/v2/characters/{auth.CharacterId}/skillqueue/", auth, ifNoneMatch);

            checkResponse("GetCharacterSkillQueueV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<SkillQueue>>(responseModel);
        }
    }
}
