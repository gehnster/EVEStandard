using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Dogma : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Dogma>();
        internal Dogma(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<int>>> GetAttributesV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/dogma/attributes/", ifNoneMatch);

            checkResponse("GetAttributesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<DogmaAttribute>> GetAttributeInfoV1Async(int attributeId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/dogma/attributes/{attributeId}", ifNoneMatch);

            checkResponse("GetAttributeInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<DogmaAttribute>(responseModel);
        }

        public async Task<ESIModelDTO<DogmaDynamicItem>> GetDynamicItemInfoV1Async(int typeId, long itemId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/dogma/dynamic/items/{typeId}/{itemId}", ifNoneMatch);

            checkResponse("GetDynamicItemInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<DogmaDynamicItem>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> GetEffectsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/dogma/effects/", ifNoneMatch);

            checkResponse("GetEffectsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<DogmaEffect>> GetEffectInfoV2Async(int effectId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v2/dogma/effects/{effectId}", ifNoneMatch);

            checkResponse("GetEffectInfoV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<DogmaEffect>(responseModel);
        }
    }
}
