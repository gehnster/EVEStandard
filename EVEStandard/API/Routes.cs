using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Routes : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Routes>();
        internal Routes(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<int>> GetRouteV1Async(int origin, int destination, List<int> avoidSystems, List<int> connections, string flag=RoutePreference.SHORTEST)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "avoid", avoidSystems == null || avoidSystems.Count == 0 ? "" : string.Join(",", avoidSystems) },
                { "connections", connections == null || connections.Count == 0 ? "" : string.Join(",", connections) },
                { "flag", flag }
            };

            var responseModel = await GetAsync("/v1/route/" + origin + "/" + destination + "/", queryParameters);

            checkResponse("GetRouteV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<int>>(responseModel.JSONString);
        }
    }
}
