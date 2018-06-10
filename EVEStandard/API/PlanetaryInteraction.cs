using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class PlanetaryInteraction : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<PlanetaryInteraction>();

        internal PlanetaryInteraction(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<Colony>>> GetColoniesV1Async(AuthDTO auth, string ifNoneMatch=null)
        {
            checkAuth(auth, Scopes.ESI_PLANETS_MANAGE_PLANETS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.Character.CharacterID}/planets/", auth, ifNoneMatch);

            checkResponse("GetColoniesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<Colony>>(responseModel);
        }

        public async Task<ESIModelDTO<ColonyLayout>> GetColonyLayoutV3Async(AuthDTO auth, int planetId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_PLANETS_MANAGE_PLANETS_1);

            var responseModel = await GetAsync($"/v3/characters/{auth.Character.CharacterID}/planets/" + planetId + "/", auth, ifNoneMatch);

            checkResponse("GetColonyLayoutV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<ColonyLayout>(responseModel);
        }

        public async Task<ESIModelDTO<FactorySchematic>> GetSchematicInfoV1Async(int schematicId, string ifNoneMatch=null)
        {
            var responseModel = await GetAsync($"/v1/universe/schematics/{schematicId}/", ifNoneMatch);

            checkResponse("GetSchematicInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<FactorySchematic>(responseModel);
        }

        public async Task<ESIModelDTO<List<CustomsOffice>>> ListCorporationCustomsOfficesV1Async(AuthDTO auth, int page, int corporationId, string ifNoneMatch=null)
        {
            checkAuth(auth, Scopes.ESI_PLANETS_READ_CUSTOMS_OFFICES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/customs_offices/", auth, ifNoneMatch, queryParameters);

            checkResponse("ListCorporationCustomsOfficesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<CustomsOffice>>(responseModel);
        }
    }
}
