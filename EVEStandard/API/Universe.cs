using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Station = EVEStandard.Models.Station;

namespace EVEStandard.API
{
    /// <summary>
    /// Universe API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Universe : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Universe>();

        internal Universe(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Get all character ancestries.
        /// <para>GET /universe/ancestries/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of ancestries.</returns>
        public async Task<ESIModelDTO<List<Ancestry>>> GetAncestriesAsync(string language = Language.English, string ifNoneMatch=null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/universe/ancestries/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetAncestriesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Ancestry>>(responseModel);
        }

        /// <summary>
        /// Get information on an asteroid belt.
        /// <para>GET /universe/asteroid_belts/{asteroid_belt_id}/</para>
        /// </summary>
        /// <param name="asteroidBeltId">The asteroid belt identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about an asteroid belt.</returns>
        public async Task<ESIModelDTO<AsteroidBelt>> GetAsteroidBeltAsync(int asteroidBeltId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/universe/asteroid_belts/{asteroidBeltId}/", ifNoneMatch);

            CheckResponse(nameof(GetAsteroidBeltAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<AsteroidBelt>(responseModel);
        }

        /// <summary>
        /// Get a list of bloodlines.
        /// <para>GET /universe/bloodlines/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bloodlines.</returns>
        public async Task<ESIModelDTO<List<Bloodline>>> GetBloodlinesAsync(string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/universe/bloodlines/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetBloodlinesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Bloodline>>(responseModel);
        }

        /// <summary>
        /// Get a list of item categories.
        /// <para>GET /universe/categories/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of item category ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetItemCategoriesAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/universe/categories/", ifNoneMatch);

            CheckResponse(nameof(GetItemCategoriesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information of an item category.
        /// <para>GET /universe/categories/{category_id}/</para>
        /// </summary>
        /// <param name="categoryId">An Eve item category ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about an item category.</returns>
        public async Task<ESIModelDTO<Category>> GetItemCategoryInfoAsync(int categoryId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/universe/categories/{categoryId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetItemCategoryInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Category>(responseModel);
        }

        /// <summary>
        /// Get a list of constellations.
        /// <para>GET /universe/constellations/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of constellation ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetConstellationsAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/universe/constellations/", ifNoneMatch);

            CheckResponse(nameof(GetConstellationsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a constellation.
        /// <para>GET /universe/constellations/{constellation_id}/</para>
        /// </summary>
        /// <param name="constellationId">The constellation identifier.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a constellation.</returns>
        public async Task<ESIModelDTO<Constellation>> GetConstellationAsync(int constellationId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/universe/constellations/{constellationId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetConstellationAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Constellation>(responseModel);
        }

        /// <summary>
        /// Get a list of factions.
        /// <para>GET /universe/factions/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of factions.</returns>
        public async Task<ESIModelDTO<List<Faction>>> GetFactionsAsync(string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/universe/factions/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetFactionsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Faction>>(responseModel);
        }

        /// <summary>
        /// Get a list of graphics.
        /// <para>GET /universe/graphics/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of graphic ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetGraphicsAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/universe/graphics/", ifNoneMatch);

            CheckResponse(nameof(GetGraphicsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a graphic.
        /// <para>GET /universe/graphics/{graphic_id}/</para>
        /// </summary>
        /// <param name="graphicId">The graphic identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a graphic.</returns>
        public async Task<ESIModelDTO<Graphic>> GetGraphicAsync(int graphicId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/universe/graphics/{graphicId}/", ifNoneMatch);

            CheckResponse(nameof(GetGraphicAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Graphic>(responseModel);
        }

        /// <summary>
        /// Get a list of item groups.
        /// <para>GET /universe/groups</para>
        /// </summary>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of item group ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetItemGroupsAsync(int page = 1, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/universe/groups/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetItemGroupsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on an item group.
        /// <para>GET /universe/groups/{group_id}/</para>
        /// </summary>
        /// <param name="groupId">An Eve item group ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of factions.</returns>
        public async Task<ESIModelDTO<Group>> GetItemGroupAsync(int groupId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/universe/groups/{groupId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetItemGroupAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Group>(responseModel);
        }

        /// <summary>
        /// Resolve a set of names to IDs in the following categories: agents, alliances, characters, constellations, corporations factions, inventory_types, regions, stations, and systems. 
        /// Only exact matches will be returned. All names searched for are cached for 12 hours.
        /// <para>POST /universe/ids/</para>
        /// </summary>
        /// <param name="names">The names to resolve.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of factions.</returns>
        public async Task<ESIModelDTO<Models.Universe>> BulkNamesToIdsAsync(List<string> names, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await PostAsync("/universe/ids/", null, names, null, queryParameters);

            CheckResponse(nameof(BulkNamesToIdsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Models.Universe>(responseModel);
        }

        /// <summary>
        /// Get information on a moon.
        /// <para>GET /universe/moons/{moon_id}/</para>
        /// </summary>
        /// <param name="moonId">The moon identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a moon.</returns>
        public async Task<ESIModelDTO<Moon>> GetMoonInfoAsync(long moonId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/universe/moons/{moonId}/", ifNoneMatch);

            CheckResponse(nameof(GetItemGroupsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Moon>(responseModel);
        }

        /// <summary>
        /// Resolve a set of IDs to names and categories. Supported ID’s for resolving are: Characters, Corporations, Alliances, Stations, Solar Systems, Constellations, Regions, Types, Factions.
        /// <para>POST /universe/names/</para>
        /// </summary>
        /// <param name="ids">The ids to resolve.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of id/name associations for a set of ID’s. All ID’s must resolve to a name, or nothing will be returned.</returns>
        public async Task<ESIModelDTO<List<UniverseIdsToNames>>> GetNamesAndCategoriesFromIdsAsync(List<int> ids)
        {
            var responseModel = await PostAsync("/universe/names/", null, ids);

            CheckResponse(nameof(GetNamesAndCategoriesFromIdsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<UniverseIdsToNames>>(responseModel);
        }

        /// <summary>
        /// Get information on a planet.
        /// <para>GET /universe/planets/{planet_id}/</para>
        /// </summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a planet.</returns>
        public async Task<ESIModelDTO<Planet>> GetPlanetInfoAsync(long planetId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/universe/planets/{planetId}/", ifNoneMatch);

            CheckResponse(nameof(GetPlanetInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Planet>(responseModel);
        }

        /// <summary>
        /// Get a list of character races.
        /// <para>GET /universe/races/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of character races.</returns>
        public async Task<ESIModelDTO<List<Race>>> GetCharacterRacesAsync(string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/universe/races/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCharacterRacesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Race>>(responseModel);
        }

        /// <summary>
        /// Get a list of regions.
        /// <para>GET /universe/regions</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of region ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetRegionsAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/universe/regions/", ifNoneMatch);

            CheckResponse(nameof(GetRegionsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a region.
        /// <para>GET /universe/regions/{region_id}/</para>
        /// </summary>
        /// <param name="regionId">The region identifier.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a region.</returns>
        public async Task<ESIModelDTO<Region>> GetRegionInfoAsync(int regionId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/universe/regions/{regionId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetRegionInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Region>(responseModel);
        }

        /// <summary>
        /// Get information on a stargate.
        /// <para>GET /universe/stargates/{stargate_id}/</para>
        /// </summary>
        /// <param name="stargateId">The stargate identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a region.</returns>
        public async Task<ESIModelDTO<Stargate>> GetStargateInfoAsync(int stargateId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/universe/stargates/{stargateId}/", ifNoneMatch);

            CheckResponse(nameof(GetStargateInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Stargate>(responseModel);
        }

        /// <summary>
        /// Get information on a star.
        /// <para>GET /universe/stars/{star_id}/</para>
        /// </summary>
        /// <param name="starId">The star identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a star.</returns>
        public async Task<ESIModelDTO<Star>> GetStarInfoAsync(int starId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/universe/stars/{starId}/", ifNoneMatch);

            CheckResponse(nameof(GetStarInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Star>(responseModel);
        }

        /// <summary>
        /// Get information on a station.
        /// <para>GET /universe/structures/</para>
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a station.</returns>
        public async Task<ESIModelDTO<Station>> GetStationInfoAsync(int stationId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/universe/stations/{stationId}/", ifNoneMatch);

            CheckResponse(nameof(GetStationInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Station>(responseModel);
        }

        /// <summary>
        /// List all public structures.
        /// <para>GET /universe/structures</para>
        /// </summary>
        /// <param name="filter">Optional param to return structures that only have a market or basic manufacturing.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of public structure IDs.</returns>
        public async Task<ESIModelDTO<List<long>>> ListAllPublicStructuresAsync(StructureHas filter, string ifNoneMatch = null)
        {
            APIResponse responseModel;
            if (filter == StructureHas.NoFilter)
            {
                responseModel = await GetAsync("/universe/structures/", ifNoneMatch);
            }
            else
            {
                var queryParameters = new Dictionary<string, string>
                {
                    {"filter", filter == StructureHas.Market ? "market" : "manufacturing_basic" }
                };

                responseModel = await GetAsync("/universe/structures/", ifNoneMatch, queryParameters);
            }

            CheckResponse(nameof(ListAllPublicStructuresAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<long>>(responseModel);
        }

        /// <summary>
        /// Returns information on requested structure, if you are on the ACL. Otherwise, returns “Forbidden” for all inputs.
        /// <para>GET /universe/structures/{structure_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="structureId">An Eve structure ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing data about a structure.</returns>
        public async Task<ESIModelDTO<Structure>> GetStructureInfoAsync(AuthDTO auth, long structureId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_UNIVERSE_READ_STRUCTURES_1);

            var responseModel = await GetAsync($"/universe/structures/{structureId}/", auth, ifNoneMatch);

            CheckResponse(nameof(GetStructureInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Structure>(responseModel);
        }

        /// <summary>
        /// Get the number of jumps in solar systems within the last hour ending at the timestamp of the Last-Modified header, excluding wormhole space. Only systems with jumps will be listed.
        /// <para>GET /universe/system_jumps/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of systems and number of jumps.</returns>
        public async Task<ESIModelDTO<List<SystemJumps>>> GetSystemJumpsAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/universe/system_jumps/", ifNoneMatch);

            CheckResponse(nameof(GetSystemJumpsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<SystemJumps>>(responseModel);
        }

        /// <summary>
        /// Get the number of ship, pod and NPC kills per solar system within the last hour ending at the timestamp of the Last-Modified header, excluding wormhole space. Only systems with kills will be listed.
        /// <para>GET /universe/system_kills/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of systems and number of ship, pod and NPC kills.</returns>
        public async Task<ESIModelDTO<List<SystemKills>>> GetSystemKillsAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/universe/system_kills/", ifNoneMatch);

            CheckResponse(nameof(GetSystemKillsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<SystemKills>>(responseModel);
        }

        /// <summary>
        /// Get a list of solar systems.
        /// <para>GET /universe/systems/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of solar system ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetSolarSystemsAsync(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/universe/systems/", ifNoneMatch);

            CheckResponse(nameof(GetSolarSystemsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a solar system. NOTE: This route does not work with abyssal systems.
        /// <para>GET /universe/systems/{system_id}/</para>
        /// </summary>
        /// <param name="systemId">The system identifier.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a solar system.</returns>
        public async Task<ESIModelDTO<Models.System>> GetSolarSystemInfoAsync(int systemId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/universe/systems/{systemId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetSolarSystemInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Models.System>(responseModel);
        }

        /// <summary>
        /// Get a list of type ids.
        /// <para>GET /universe/types</para>
        /// </summary>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of type ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetTypesAsync(int page = 1, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/universe/types/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetTypesAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a type.
        /// <para>GET /universe/types/{type_id}/</para>
        /// </summary>
        /// <param name="typeId">An Eve item type ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a type.</returns>
        public async Task<ESIModelDTO<Type>> GetTypeInfoAsync(int typeId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/universe/types/{typeId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetTypeInfoAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Type>(responseModel);
        }

        public enum StructureHas
        {
            NoFilter,
            Market,
            ManufacturingBasic
        }
    }
}