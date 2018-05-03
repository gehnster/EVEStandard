using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class PlanetaryInteraction : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<PlanetaryInteraction>();
        internal PlanetaryInteraction(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<Colony>> GetColoniesV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_PLANETS_MANAGE_PLANETS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/planets/", auth);

            checkResponse("GetColoniesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<Colony>>(responseModel.JSONString);
        }

        public async Task<ColonyLayout> GetColonyLayoutV3Async(AuthDTO auth, int planetId)
        {
            checkAuth(auth, Scopes.ESI_PLANETS_MANAGE_PLANETS_1);

            var responseModel = await GetAsync("/v3/characters/" + auth.Character.CharacterID + "/planets/" + planetId + "/", auth);

            checkResponse("GetColonyLayoutV3Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<ColonyLayout>(responseModel.JSONString);
        }

        public async Task<FactorySchematic> GetSchematicInfoV1Async(int schematicId)
        {
            var responseModel = await GetAsync("/v1/universe/schematics/" + schematicId + "/");

            checkResponse("GetSchematicInfoV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<FactorySchematic>(responseModel.JSONString);
        }

        public async Task<(List<CustomsOffice>, long)> ListCorporationCustomsOfficesV1Async(AuthDTO auth, long page, long corporationId)
        {
            checkAuth(auth, Scopes.ESI_PLANETS_READ_CUSTOMS_OFFICES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/customs_offices/", auth, queryParameters);

            checkResponse("ListCorporationCustomsOfficesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<CustomsOffice>>(responseModel.JSONString), responseModel.MaxPages);
        }
    }
}
