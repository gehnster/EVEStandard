using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Skills : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Skills>();
        internal Skills(string dataSource) : base(dataSource)
        {
        }

        public async Task<CharacterSkills> GetCharacterSkillsV4Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_SKILLS_READ_SKILLS_1);

            var responseModel = await GetAsync("/v4/characters/" + auth.Character.CharacterID + "/skills/", auth);

            checkResponse("GetCharacterSkillsV4Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<CharacterSkills>(responseModel.JSONString);
        }

        public async Task<CharacterAttributes> GetCharacterAttributesV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_SKILLS_READ_SKILLS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/attributes/", auth);

            checkResponse("GetCharacterAttributesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<CharacterAttributes>(responseModel.JSONString);
        }

        public async Task<List<SkillQueue>> GetCharacterSkillQueueV2Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_SKILLS_READ_SKILLQUEUE_1);

            var responseModel = await GetAsync("/v2/characters/" + auth.Character.CharacterID + "/skillqueue/", auth);

            checkResponse("GetCharacterSkillQueueV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<SkillQueue>>(responseModel.JSONString);
        }
    }
}
