using Microsoft.Extensions.Logging;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EVEStandard.Models;
=======

>>>>>>> 4aef9560fd8fa25c04e104f4dbc7de5801d8a028

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
        public async Task<List<Ancestry>> GetAncestriesV1Async()
        {
            var responseModel = await this.GetAsync("/v1/universe/ancestries/");

            checkResponse("GetAncestriesV1Async", responseModel.Error,responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<Ancestry>>(responseModel.JSONString);
        }

        public async Task<AsteroidBelt> GetAsteroidBeltV1Async(int asteroidId)
        {
            var responseModel = await this.GetAsync(string.Format("/v1/universe/asteroid_belts/{0}/", asteroidId));

            checkResponse("GetAsteroidBeltV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<AsteroidBelt>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of bloodlines
        /// </summary>
        /// <returns></returns>
        public async Task<List<Bloodline>> GetBloodlinesV1Async()
        {
            var responseModel = await this.GetAsync("/v1/universe/bloodlines/");

            checkResponse("GetBloodlinesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<Bloodline>>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of item categories
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetCategoriesV1Async()
        {
            var responseModel = await this.GetAsync(string.Format("/v1/universe/categories/"));

            checkResponse("GetCategoriesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<int[]>(responseModel.JSONString);
        }

        /// <summary>
        /// Get information of an item category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryV1Async(int categoryId)
        {
            var responseModel = await this.GetAsync(string.Format("/v1/universe/categories/{0}/", categoryId));

            checkResponse("GetCategoryV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<Category>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of constellations
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetConstellationsV1Async()
        {
            var responseModel = await this.GetAsync(string.Format("/v1/universe/constellations/"));

            checkResponse("GetConstellationsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<int[]>(responseModel.JSONString);
        }

        /// <summary>
        /// Get information on a constellation
        /// </summary>
        /// <param name="constellationId"></param>
        /// <returns></returns>
        public async Task<Constellation> GetConstellationV1Async(int constellationId)
        {
            var responseModel = await this.GetAsync(string.Format("/v1/universe/constellations/{0}/", constellationId));

            checkResponse("GetConstellationV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<Constellation>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of factions
        /// </summary>
        /// <returns></returns>
        public async Task<List<Faction>> GetFactionsV2Async()
        {
            var responseModel = await this.GetAsync(string.Format(" /v2/universe/factions/"));

            checkResponse("GetFactionsV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<Faction>>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of graphics
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetGraphicsV1Async()
        {
            var responseModel = await this.GetAsync(string.Format("/v1/universe/graphics/"));

            checkResponse("GetGraphicsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<int[]>(responseModel.JSONString);
        }

        /// <summary>
        /// Get information on a graphic
        /// </summary>
        /// <param name="graphicId"></param>
        /// <returns></returns>
        public async Task<Graphic> GetGraphicV1Async(int graphicId)
        {
            var responseModel = await this.GetAsync(string.Format("/v1/universe/graphics/{0}/", graphicId));

            checkResponse("GetGraphicV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<Graphic>(responseModel.JSONString);
        }

        /// <summary>
        /// Get a list of item groups
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetGroupsV1Async()
        {
            var responseModel = await this.GetAsync(string.Format("/v1/universe/groups/"));

            checkResponse("GetGroupsV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<int[]>(responseModel.JSONString);
        }

        /// <summary>
        /// Get information on an item group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<Group> GetGroupV1Async(int groupId)
        {
            var responseModel = await this.GetAsync(string.Format("/v1/universe/groups/{0}/", groupId));

            checkResponse("GetGroupV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<Group>(responseModel.JSONString);
        }

        /// <summary>
        /// Resolve a set of names to IDs in the following categories: agents, alliances, characters, constellations, 
        /// corporations factions, inventory_types, regions, stations, and systems. Only exact matches will be returned. 
        /// All names searched for are cached for 12 hours.
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public async Task<Universe> PostUniverseV1Async(string[] names)
        {
            var responseModel = await this.PostAsync(string.Format("/v1/universe/ids/"), null, names);

            checkResponse("PostUniverseV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<Universe>(responseModel.JSONString);
        }
    }
}
