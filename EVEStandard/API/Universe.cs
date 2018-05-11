using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Station = EVEStandard.Models.Station;

namespace EVEStandard.API
{
    public class Universe : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Universe>();

        internal Universe(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Get all character ancestries
        /// </summary>
        /// <returns>List of character ancestries</returns>
        public async Task<ESIModelDTO<List<Ancestry>>> GetAncestriesV1Async(string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/v1/universe/ancestries/", queryParameters);

            checkResponse("GetAncestriesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Ancestry>>(responseModel);
        }

        public async Task<ESIModelDTO<AsteroidBelt>> GetAsteroidBeltV1Async(int asteroidBeltId)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"asteroid_belt_id", asteroidBeltId.ToString()}
            };

            var responseModel = await GetAsync($"/v1/universe/asteroid_belts/{asteroidBeltId}/", queryParameters);

            checkResponse("GetAsteroidBeltV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<AsteroidBelt>(responseModel);
        }

        /// <summary>
        /// Get a list of bloodlines
        /// </summary>
        /// <returns></returns>
        public async Task<ESIModelDTO<List<Bloodline>>> GetBloodlinesV1Async(string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/v1/universe/bloodlines/", queryParameters);

            checkResponse("GetBloodlinesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Bloodline>>(responseModel);
        }

        /// <summary>
        /// Get a list of item categories
        /// </summary>
        /// <returns></returns>
        public async Task<ESIModelDTO<List<int>>> GetItemCategoriesV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/categories/");

            checkResponse("GetItemCategoriesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information of an item category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ESIModelDTO<Category>> GetItemCategoryInfoV1Async(int categoryId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/categories/{categoryId}/", queryParameters);

            checkResponse("GetItemCategoryInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Category>(responseModel);
        }

        /// <summary>
        /// Get a list of constellations
        /// </summary>
        /// <returns></returns>
        public async Task<ESIModelDTO<List<int>>> GetConstellationsV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/constellations/");

            checkResponse("GetConstellationsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a constellation
        /// </summary>
        /// <param name="constellationId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ESIModelDTO<Constellation>> GetConstellationV1Async(int constellationId,
            string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/constellations/{constellationId}/", queryParameters);

            checkResponse("GetConstellationV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Constellation>(responseModel);
        }

        /// <summary>
        /// Get a list of factions
        /// </summary>
        /// <returns></returns>
        public async Task<ESIModelDTO<List<Faction>>> GetFactionsV2Async(string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync(" /v2/universe/factions/", queryParameters);

            checkResponse("GetFactionsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Faction>>(responseModel);
        }

        /// <summary>
        /// Get a list of graphics
        /// </summary>
        /// <returns></returns>
        public async Task<ESIModelDTO<List<int>>> GetGraphicsV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/graphics/");

            checkResponse("GetGraphicsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a graphic
        /// </summary>
        /// <param name="graphicId"></param>
        /// <returns></returns>
        public async Task<ESIModelDTO<Graphic>> GetGraphicV1Async(int graphicId)
        {
            var responseModel = await GetAsync($"/v1/universe/graphics/{graphicId}/");

            checkResponse("GetGraphicV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Graphic>(responseModel);
        }

        /// <summary>
        /// Get a list of item groups
        /// </summary>
        /// <returns></returns>
        public async Task<ESIModelDTO<List<int>>> GetItemGroupsV1Async(int page)
        {
            var responseModel = await GetAsync("/v1/universe/groups/");

            checkResponse("GetItemGroupsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on an item group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ESIModelDTO<Group>> GetItemGroupV1Async(int groupId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/groups/{groupId}/", queryParameters);

            checkResponse("GetItemGroupV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Group>(responseModel);
        }

        /// <summary>
        /// Resolve a set of names to IDs in the following categories: agents, alliances, characters, constellations, 
        /// corporations factions, inventory_types, regions, stations, and systems. Only exact matches will be returned. 
        /// All names searched for are cached for 12 hours.
        /// </summary>
        /// <param name="names"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ESIModelDTO<Models.Universe>> BulkNamesToIdsV1Async(List<string> names, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await PostAsync("/v1/universe/ids/", null, names, queryParameters);

            checkResponse("BulkNamesToIdsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Models.Universe>(responseModel);
        }

        public async Task<ESIModelDTO<Moon>> GetMoonInfoV1Async(long moonId)
        {
            var responseModel = await GetAsync($"/v1/universe/moons/{moonId}/");

            checkResponse("GetItemGroupsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Moon>(responseModel);
        }

        public async Task<ESIModelDTO<UniverseIdsToNames>> GetNamesAndCategoriesFromIdsV2Async(List<int> ids)
        {
            var responseModel = await PostAsync("/v2/universe/names/", null, ids);

            checkResponse("GetNamesAndCategoriesFromIdsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<UniverseIdsToNames>(responseModel);
        }

        public async Task<ESIModelDTO<Planet>> GetPlanetInfoV1Async(long planetId)
        {
            var responseModel = await GetAsync($"/v1/universe/planets/{planetId}/");

            checkResponse("GetPlanetInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Planet>(responseModel);
        }

        public async Task<ESIModelDTO<List<Race>>> GetCharacterRacesV1Async(string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/v1/universe/races/", queryParameters);

            checkResponse("GetCharacterRacesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Race>>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> GetRegionsV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/regions/");

            checkResponse("GetRegionsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<Region>> GetRegionInfoV1Async(int regionId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/regions/{regionId}/", queryParameters);

            checkResponse("GetRegionInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Region>(responseModel);
        }

        public async Task<ESIModelDTO<Stargate>> GetStargateInfoV1Async(int stargateId)
        {
            var responseModel = await GetAsync($"/v1/universe/stargates/{stargateId}/");

            checkResponse("GetStargateInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Stargate>(responseModel);
        }

        public async Task<ESIModelDTO<Star>> GetStarInfoV1Async(int starId)
        {
            var responseModel = await GetAsync($"/v1/universe/stars/{starId}/");

            checkResponse("GetStarInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Star>(responseModel);
        }

        public async Task<ESIModelDTO<Station>> GetStationInfoV2Async(int stationId)
        {
            var responseModel = await GetAsync($"/v2/universe/stations/{stationId}/");

            checkResponse("GetStationInfoV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Station>(responseModel);
        }

        public async Task<ESIModelDTO<List<long>>> ListAllPublicStructuresV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/structures/");

            checkResponse("ListAllPublicStructuresV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<long>>(responseModel);
        }

        public async Task<ESIModelDTO<Structure>> GetStructureInfoV1Async(AuthDTO auth, long structureId)
        {
            checkAuth(auth, Scopes.ESI_UNIVERSE_READ_STRUCTURES_1);

            var responseModel = await GetAsync($"/v1/universe/structures/{structureId}/");

            checkResponse("GetStructureInfoV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Structure>(responseModel);
        }

        public async Task<ESIModelDTO<List<SystemJumps>>> GetSystemJumpsV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/system_jumps/");

            checkResponse("GetSystemJumpsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<SystemJumps>>(responseModel);
        }

        public async Task<ESIModelDTO<List<SystemKills>>> GetSystemKillsV2Async()
        {
            var responseModel = await GetAsync("/v2/universe/system_kills/");

            checkResponse("GetSystemKillsV2Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<SystemKills>>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> GetSolarSystemsV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/systems/");

            checkResponse("GetSolarSystemsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<Models.System>> GetSolarSystemInfoV3Async(int systemId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v3/universe/systems/{systemId}/", queryParameters);

            checkResponse("GetSolarSystemInfoV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Models.System>(responseModel);
        }

        public async Task<ESIModelDTO<List<int>>> GetTypesV1Async(int page=1)
        {
            var responseModel = await GetAsync("/v1/universe/types/");

            checkResponse("GetTypesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<int>>(responseModel);
        }

        public async Task<ESIModelDTO<Type>> GetTypeInfoV3Async(int typeId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v3/universe/types/{typeId}/", queryParameters);

            checkResponse("GetTypeInfoV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<Type>(responseModel);
        }
    }
}