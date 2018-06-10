using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Routes : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Routes>();

        internal Routes(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<int>>> GetRouteV1Async(int origin, int destination, List<int> avoidSystems, List<int> connections, string flag=RoutePreference.SHORTEST, string ifNoneMatch=null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "avoid", avoidSystems == null || avoidSystems.Count == 0 ? "" : string.Join(",", avoidSystems) },
                { "connections", connections == null || connections.Count == 0 ? "" : string.Join(",", connections) },
                { "flag", flag }
            };

            var responseModel = await GetAsync($"/v1/route/{origin}/{destination}/", ifNoneMatch, queryParameters);

            checkResponse("GetRouteV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<int>>(responseModel);
        }
    }
}
