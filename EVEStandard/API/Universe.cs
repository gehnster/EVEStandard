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
        public async Task<List<Ancestry>> GetAncestriesV1Async(string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/v1/universe/ancestries/", queryParameters);

            checkResponse("GetAncestriesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<Ancestry>>(responseModel.JSONString);
        }

        public async Task<AsteroidBelt> GetAsteroidBeltV1Async(int asteroidBeltId)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"asteroid_belt_id", asteroidBeltId.ToString()}
            };

            var responseModel = await GetAsync($"/v1/universe/asteroid_belts/{asteroidBeltId}/", queryParameters);

            checkResponse("GetAsteroidBeltV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<AsteroidBelt>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of bloodlines
        /// </summary>
        /// <returns></returns>
        public async Task<List<Bloodline>> GetBloodlinesV1Async(string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/v1/universe/bloodlines/", queryParameters);

            checkResponse("GetBloodlinesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<Bloodline>>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of item categories
        /// </summary>
        /// <returns></returns>
        public async Task<List<int>> GetItemCategoriesV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/categories/");

            checkResponse("GetItemCategoriesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString);
        }

        /// <summary>
        /// Get information of an item category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Category> GetItemCategoryInfoV1Async(int categoryId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/categories/{categoryId}/", queryParameters);

            checkResponse("GetItemCategoryInfoV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Category>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of constellations
        /// </summary>
        /// <returns></returns>
        public async Task<List<int>> GetConstellationsV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/constellations/");

            checkResponse("GetConstellationsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString);
        }

        /// <summary>
        /// Get information on a constellation
        /// </summary>
        /// <param name="constellationId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Constellation> GetConstellationV1Async(int constellationId,
            string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/constellations/{constellationId}/", queryParameters);

            checkResponse("GetConstellationV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Constellation>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of factions
        /// </summary>
        /// <returns></returns>
        public async Task<List<Faction>> GetFactionsV2Async(string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync(" /v2/universe/factions/", queryParameters);

            checkResponse("GetFactionsV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<Faction>>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of graphics
        /// </summary>
        /// <returns></returns>
        public async Task<List<int>> GetGraphicsV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/graphics/");

            checkResponse("GetGraphicsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString);
        }

        /// <summary>
        /// Get information on a graphic
        /// </summary>
        /// <param name="graphicId"></param>
        /// <returns></returns>
        public async Task<Graphic> GetGraphicV1Async(int graphicId)
        {
            var responseModel = await GetAsync($"/v1/universe/graphics/{graphicId}/");

            checkResponse("GetGraphicV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Graphic>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of item groups
        /// </summary>
        /// <returns></returns>
        public async Task<(List<int>, long)> GetItemGroupsV1Async(long page)
        {
            var responseModel = await GetAsync("/v1/universe/groups/");

            checkResponse("GetItemGroupsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString), responseModel.MaxPages);
        }

        /// <summary>
        /// Get information on an item group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Group> GetItemGroupV1Async(int groupId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/groups/{groupId}/", queryParameters);

            checkResponse("GetItemGroupV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Group>(responseModel.JSONString);
        }

        /// <summary>
        /// Resolve a set of names to IDs in the following categories: agents, alliances, characters, constellations, 
        /// corporations factions, inventory_types, regions, stations, and systems. Only exact matches will be returned. 
        /// All names searched for are cached for 12 hours.
        /// </summary>
        /// <param name="names"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Models.Universe> BulkNamesToIdsV1Async(List<string> names, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await PostAsync("/v1/universe/ids/", null, names, queryParameters);

            checkResponse("BulkNamesToIdsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Models.Universe>(responseModel.JSONString);
        }

        public async Task<Moon> GetMoonInfoV1Async(long moonId)
        {
            var responseModel = await GetAsync($"/v1/universe/moons/{moonId}/");

            checkResponse("GetItemGroupsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Moon>(responseModel.JSONString);
        }

        public async Task<UniverseIdsToNames> GetNamesAndCategoriesFromIdsV2Async(List<int> ids)
        {
            var responseModel = await PostAsync("/v2/universe/names/", null, ids);

            checkResponse("GetNamesAndCategoriesFromIdsV2Async", responseModel.Error, responseModel.LegacyWarning,
                Logger);

            return JsonConvert.DeserializeObject<UniverseIdsToNames>(responseModel.JSONString);
        }

        public async Task<Planet> GetPlanetInfoV1Async(long planetId)
        {
            var responseModel = await GetAsync($"/v1/universe/planets/{planetId}/");

            checkResponse("GetPlanetInfoV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Planet>(responseModel.JSONString);
        }

        public async Task<List<Race>> GetCharacterRacesV1Async(string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/v1/universe/races/", queryParameters);

            checkResponse("GetCharacterRacesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<Race>>(responseModel.JSONString);
        }

        public async Task<List<int>> GetRegionsV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/regions/");

            checkResponse("GetRegionsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString);
        }

        public async Task<Region> GetRegionInfoV1Async(int regionId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/regions/{regionId}/", queryParameters);

            checkResponse("GetRegionInfoV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Region>(responseModel.JSONString);
        }

        public async Task<Stargate> GetStargateInfoV1Async(int stargateId)
        {
            var responseModel = await GetAsync($"/v1/universe/stargates/{stargateId}/");

            checkResponse("GetStargateInfoV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Stargate>(responseModel.JSONString);
        }

        public async Task<Star> GetStarInfoV1Async(int starId)
        {
            var responseModel = await GetAsync($"/v1/universe/stars/{starId}/");

            checkResponse("GetStarInfoV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Star>(responseModel.JSONString);
        }

        public async Task<Station> GetStationInfoV2Async(int stationId)
        {
            var responseModel = await GetAsync($"/v2/universe/stations/{stationId}/");

            checkResponse("GetStationInfoV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Station>(responseModel.JSONString);
        }

        public async Task<List<long>> ListAllPublicStructuresV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/structures/");

            checkResponse("ListAllPublicStructuresV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString);
        }

        public async Task<Structure> GetStructureInfoV1Async(AuthDTO auth, long structureId)
        {
            checkAuth(auth, Scopes.ESI_UNIVERSE_READ_STRUCTURES_1);

            var responseModel = await GetAsync($"/v1/universe/structures/{structureId}/");

            checkResponse("GetStructureInfoV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Structure>(responseModel.JSONString);
        }

        public async Task<List<SystemJumps>> GetSystemJumpsV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/system_jumps/");

            checkResponse("GetSystemJumpsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<SystemJumps>>(responseModel.JSONString);
        }

        public async Task<List<SystemKills>> GetSystemKillsV2Async()
        {
            var responseModel = await GetAsync("/v2/universe/system_kills/");

            checkResponse("GetSystemKillsV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<SystemKills>>(responseModel.JSONString);
        }

        public async Task<List<int>> GetSolarSystemsV1Async()
        {
            var responseModel = await GetAsync("/v1/universe/systems/");

            checkResponse("GetSolarSystemsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString);
        }

        public async Task<Models.System> GetSolarSystemInfoV3Async(int systemId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v3/universe/systems/{systemId}/", queryParameters);

            checkResponse("GetSolarSystemInfoV3Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Models.System>(responseModel.JSONString);
        }

        public async Task<(List<int>, long)> GetTypesV1Async(long page=1)
        {
            var responseModel = await GetAsync("/v1/universe/types/");

            checkResponse("GetTypesV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<Type> GetTypeInfoV3Async(int typeId, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v3/universe/types/{typeId}/", queryParameters);

            checkResponse("GetTypeInfoV3Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<Type>(responseModel.JSONString);
        }
    }
}