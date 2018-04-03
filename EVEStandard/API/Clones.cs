using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Clones : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Clones>();
        internal Clones(string dataSource) : base(dataSource)
        {
        }

        public async Task<Clones> GetClonesV3Async(AuthDTO auth)
        {
            this.checkAuth(auth, Scopes.ESI_CLONES_READ_CLONES_1);

            var responseModel = await this.GetAsync("/v3/characters/" + auth.Character.CharacterID + "/clones/", auth);

            this.checkResponse("GetClonesV3Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<Clones>(responseModel.JSONString);
        }

        public async Task<List<int>> GetActiveImplantsV1Async(AuthDTO auth)
        {
            this.checkAuth(auth, Scopes.ESI_CLONES_READ_IMPLANTS_1);

            var responseModel = await this.GetAsync("/v1/characters/" + auth.Character.CharacterID + "/implants/", auth);

            this.checkResponse("GetActiveImplantsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString);
        }
    }
}
