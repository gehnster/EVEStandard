using EVEStandard.Models;
using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Character : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Character>();
        internal Character(string dataSource) : base(dataSource)
        {
        }

        public async Task<(List<AggregateStats>, long)> YearlyAggregateStatsV2Async(AuthDTO auth, long page)
        {
            this.checkAuth(auth, Scopes.ESI_CHARACTERSTATS_READ_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await this.GetAsync("/v2/characters/" + auth.Character.CharacterID + "/stats/", auth, queryParameters);

            this.checkResponse("YearlyAggregateStatsV2Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return (JsonConvert.DeserializeObject<List<AggregateStats>>(responseModel.JSONString), responseModel.MaxPages);
        }
    }
}
