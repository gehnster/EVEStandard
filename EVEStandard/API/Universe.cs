using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EveCorpMonNet.Libraries.EVEStandard.Models;
using Newtonsoft.Json;

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

        public async Task<List<Bloodline>> GetBloodlinesV1Async()
        {
            var responseModel = await this.GetAsync("/v1/universe/bloodlines/");

            checkResponse("GetBloodlinesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<Bloodline>>(responseModel.JSONString);
        }
    }
}
