using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Clones : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Clones>();
        internal Clones(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<Clones>> GetClonesV3Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CLONES_READ_CLONES_1);

            var responseModel = await GetAsync("/v3/characters/" + auth.Character.CharacterID + "/clones/", auth);

            checkResponse("GetClonesV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Clones>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> GetActiveImplantsV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_CLONES_READ_IMPLANTS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/implants/", auth);

            checkResponse("GetActiveImplantsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }
    }
}
