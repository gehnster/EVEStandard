using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Dogma : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Dogma>();
        internal Dogma(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<int>>> GetAttributesV1Async()
        {
            var responseModel = await GetAsync("/v1/dogma/attributes/");

            checkResponse("GetAttributesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<DogmaAttribute>> GetAttributeInfoV1Async(int attributeId)
        {
            var responseModel = await GetAsync("/v1/dogma/attributes/" + attributeId + "/");

            checkResponse("GetAttributeInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<DogmaAttribute>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> GetEffectsV1Async()
        {
            var responseModel = await GetAsync("/v1/dogma/effects/");

            checkResponse("GetEffectsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<DogmaEffect>> GetEffectInfoV2Async(int effectId)
        {
            var responseModel = await GetAsync("/v2/dogma/effects/" + effectId + "/");

            checkResponse("GetEffectInfoV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<DogmaEffect>(responseModel);
        }
    }
}
