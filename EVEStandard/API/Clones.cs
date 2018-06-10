using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Clones : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Clones>();

        internal Clones(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<Clones>> GetClonesV3Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CLONES_READ_CLONES_1);

            var responseModel = await GetAsync("/v3/characters/" + auth.Character.CharacterID + "/clones/", auth, ifNoneMatch);

            checkResponse("GetClonesV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<Clones>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> GetActiveImplantsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CLONES_READ_IMPLANTS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/implants/", auth, ifNoneMatch);

            checkResponse("GetActiveImplantsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<int>>(responseModel);
        }
    }
}
