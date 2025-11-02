using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Routes API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Routes : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Routes>();

        internal Routes(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Calculate the systems between the given origin and destination.
        /// <para>POST /route/{origin_system_id}/{destination_system_id}/</para>
        /// </summary>
        /// <param name="origin">Origin solar system ID.</param>
        /// <param name="destination">Destination solar system ID.</param>
        /// <param name="avoidSystems">Avoid solar system ID(s).</param>
        /// <param name="connections">Connected solar system pairs.</param>
        /// <param name="flag">Route security preference. Available values : shortest, secure, insecure. Default value: shortest.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing solar systems in route from origin to destination.</returns>
        public async Task<ESIModelDTO<List<long>>> PostRouteAsync(long origin, long destination, RouteRequest request, string ifNoneMatch=null)
        {
            if(request.avoid_systems.Count > 1000)
            {
                throw new EVEStandardException($"{nameof(request.avoid_systems)} cannot contain more than 1000 items.");
            }
            if(request.connections.Count > 1000)
            {
                throw new EVEStandardException($"{nameof(request.connections)} cannot contain more than 1000 items.");
            }
            if(request.security_penalty < 0 || request.security_penalty > 100)
            {
                throw new EVEStandardException($"{nameof(request.security_penalty)} must be between 0 and 100.");
            }

            var responseModel = await PostAsync($"/route/{origin}/{destination}/", request, ifNoneMatch);

            CheckResponse(nameof(PostRouteAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<long>>(responseModel);
        }

        public class RouteRequest
        {
            [JsonPropertyName("avoid_systems")]
            public List<long> avoid_systems { get; set; } = new List<long>();
            [JsonPropertyName("connections")]
            public List<RouteConnection> connections { get; set; } = new List<RouteConnection>();
            [JsonPropertyName("preference")]
            public string preference { get; set; } = RoutePreference.Shorter;
            [JsonPropertyName("security_penalty")]
            public long security_penalty { get; set; } = 50;
        }
    }
}
