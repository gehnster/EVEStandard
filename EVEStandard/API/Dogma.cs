using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Models;
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

        public async Task<List<long>> GetAttributesV1Async()
        {
            var responseModel = await GetAsync("/v1/dogma/attributes/");

            checkResponse("GetAttributesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString);
        }

        public async Task<DogmaAttribute> GetAttributeInfoV1Async(long attributeId)
        {
            var responseModel = await GetAsync("/v1/dogma/attributes/" + attributeId + "/");

            checkResponse("GetAttributeInfoV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<DogmaAttribute>(responseModel.JSONString);
        }

        public async Task<List<long>> GetEffectsV1Async()
        {
            var responseModel = await GetAsync("/v1/dogma/effects/");

            checkResponse("GetEffectsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString);
        }

        public async Task<DogmaEffect> GetEffectInfoV2Async(long effectId)
        {
            var responseModel = await GetAsync("/v2/dogma/effects/" + effectId + "/");

            checkResponse("GetEffectInfoV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<DogmaEffect>(responseModel.JSONString);
        }
    }
}
